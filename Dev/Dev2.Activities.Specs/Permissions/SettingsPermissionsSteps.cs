
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2015 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Dev2.Network;
using Dev2.Services.Security;
using Dev2.Studio.Core;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.Core.Models;
using Dev2.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using SecPermissions = Dev2.Common.Interfaces.Security.Permissions;
namespace Dev2.Activities.Specs.Permissions
{
    [Binding]
    public class SettingsPermissionsSteps
    {
        [BeforeScenario("Security")]
        public void ClearSecuritySettings()
        {
            AppSettings.LocalHost = string.Format("http://{0}:3142", Environment.MachineName.ToLowerInvariant());
            var environmentModel = EnvironmentRepository.Instance.Source;
            environmentModel.Connect();
            while(!environmentModel.IsConnected)
            {
                environmentModel.Connect();
                Thread.Sleep(100);
            }

            var currentSettings = environmentModel.ResourceRepository.ReadSettings(environmentModel);
            ScenarioContext.Current.Add("initialSettings",currentSettings);
            Data.Settings.Settings settings = new Data.Settings.Settings
            {
                Security = new SecuritySettingsTO(new List<WindowsGroupPermission>())
            };


            environmentModel.ResourceRepository.WriteSettings(environmentModel, settings);
            
            environmentModel.Disconnect();
        }

        [Given(@"I have a server ""(.*)""")]
        public void GivenIHaveAServer(string serverName)
        {
            AppSettings.LocalHost = string.Format("http://{0}:3142", Environment.MachineName.ToLowerInvariant());
            var environmentModel = EnvironmentRepository.Instance.Source;
            ScenarioContext.Current.Add("environment", environmentModel);
        }

        [Given(@"it has '(.*)' with '(.*)'")]
        public void GivenItHasWith(string groupName, string groupRights)
        {
            var groupPermssions = new WindowsGroupPermission
            {
                WindowsGroup = groupName,
                ResourceID = Guid.Empty,
                IsServer = true
            };
            var permissionsStrings = groupRights.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var permissionsString in permissionsStrings)
            {
                SecPermissions permission;
                if(Enum.TryParse(permissionsString.Replace(" ", ""), true, out permission))
                {
                    groupPermssions.Permissions |= permission;
                }
            }
            Data.Settings.Settings settings = new Data.Settings.Settings
            {
                Security = new SecuritySettingsTO(new List<WindowsGroupPermission> { groupPermssions })
            };

            var environmentModel = ScenarioContext.Current.Get<IEnvironmentModel>("environment");
            EnsureEnvironmentConnected(environmentModel);
            environmentModel.ResourceRepository.WriteSettings(environmentModel, settings);
            environmentModel.Disconnect();
        }

        static void EnsureEnvironmentConnected(IEnvironmentModel environmentModel)
        {
            var i = 0;
            while(!environmentModel.IsConnected)
            {
                environmentModel.Connect();
                Thread.Sleep(1000);
                i++;
                if (i == 30)
                {
                    Assert.Fail("Server {0} did not connect within 30 secs{1}", environmentModel.DisplayName,DateTime.Now);
                }
            }
        }

        [When(@"connected as user part of '(.*)'")]
        public void WhenConnectedAsUserPartOf(string userGroup)
        {
            if(AccountExists("SpecsUser"))
            {
                if(!IsUserInGroup("SpecsUser", userGroup))
                {
                    try
                    {
                        SecurityIdentifier id = GetUserSecurityIdentifier("SpecsUser");
                        PrincipalContext context = new PrincipalContext(ContextType.Machine);
                        UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.Sid, id.Value);
                        AddUserToGroup(userGroup, context, userPrincipal);
                    }
                    catch(Exception)
                    {
                        Assert.Fail("User not found");
                    }
                }
            }
            else
            {
                CreateLocalWindowsAccount("SpecsUser", "T35t3r!@#", userGroup);
            }
            var reconnectModel = new EnvironmentModel(Guid.NewGuid(), new ServerProxy(AppSettings.LocalHost, "SpecsUser", "T35t3r!@#")) { Name = "Other Connection" };
            try
            {
                reconnectModel.Connect();
            }
            catch(UnauthorizedAccessException)
            {
                Assert.Fail("Connection unauthorized when connecting to local Warewolf server as user who is part of '" + userGroup + "' user group.");
            }
            ScenarioContext.Current.Add("currentEnvironment", reconnectModel);
        }

        public static bool CreateLocalWindowsAccount(string username, string password, string groupName)
        {
            try
            {
                PrincipalContext context = new PrincipalContext(ContextType.Machine);
                UserPrincipal user = new UserPrincipal(context);
                user.SetPassword(password);
                user.DisplayName = username;
                user.Name = username;
                user.UserCannotChangePassword = true;
                user.PasswordNeverExpires = true;

                user.Save();
                AddUserToGroup(groupName, context, user);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(@"error creating user" + ex.Message);
                return false;
            }
        }

        static void AddUserToGroup(string groupName, PrincipalContext context, UserPrincipal user)
        {
            GroupPrincipal usersGroup = GroupPrincipal.FindByIdentity(context, groupName);
            if(usersGroup != null)
            {
                usersGroup.Members.Add(user);
                usersGroup.Save();
            }
        }

        public static bool AccountExists(string name)
        {
            bool accountExists = false;
            try
            {
                var id = GetUserSecurityIdentifier(name);
                accountExists = id.IsAccountSid();
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch(Exception)
            // ReSharper restore EmptyGeneralCatchClause
            {
                /* Invalid user account */
            }
            return accountExists;
        }

        static SecurityIdentifier GetUserSecurityIdentifier(string name)
        {
            NTAccount acct = new NTAccount(Environment.MachineName, name);
            SecurityIdentifier id = (SecurityIdentifier)acct.Translate(typeof(SecurityIdentifier));
            return id;
        }

        bool IsUserInGroup(string name, string group)
        {
            PrincipalContext context = new PrincipalContext(ContextType.Machine);
            GroupPrincipal usersGroup = GroupPrincipal.FindByIdentity(context, group);
            if(usersGroup != null)
            {
                var principalCollection = usersGroup.Members;
                if((from member in principalCollection
                    select name.Equals(member.Name, StringComparison.InvariantCultureIgnoreCase)).Any())
                {
                    return true;
                }
            }
            return false;
        }

        [Then(@"resources should have '(.*)'")]
        public async void ThenResourcesShouldHave(string resourcePerms)
        {
            var environmentModel = await LoadResources();
            SecPermissions resourcePermissions = SecPermissions.None;
            var permissionsStrings = resourcePerms.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var permissionsString in permissionsStrings)
            {
                SecPermissions permission;
                if(Enum.TryParse(permissionsString.Replace(" ", ""), true, out permission))
                {
                    resourcePermissions |= permission;
                }
            }
            var resourceModels = environmentModel.ResourceRepository.All();
            var totalNumberOfResources = resourceModels.Count;
            var allMatch = resourceModels.Count(model => model.UserPermissions == resourcePermissions);
            Assert.IsTrue(totalNumberOfResources - allMatch <= 1); //This is to cater for the scenerios where we specify a resource permission
        }

        static async Task<IEnvironmentModel> LoadResources()
        {
            var environmentModel = ScenarioContext.Current.Get<IEnvironmentModel>("currentEnvironment");
            EnsureEnvironmentConnected(environmentModel);
            if(environmentModel.IsConnected)
            {
                if(!environmentModel.HasLoadedResources)
                {
                    await environmentModel.ForceLoadResourcesAsync();
                }
            }
            var resourceModels = environmentModel.ResourceRepository.All();
            foreach(var resourceModel in resourceModels)
            {
                resourceModel.UserPermissions = environmentModel.AuthorizationService.GetResourcePermissions(resourceModel.ID);
            }
            return environmentModel;
        }

        [Then(@"resources should not have '(.*)'")]
        public async void ThenResourcesShouldNotHave(string resourcePerms)
        {
            var environmentModel = await LoadResources();
            SecPermissions resourcePermissions = SecPermissions.None;
            var permissionsStrings = resourcePerms.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var permissionsString in permissionsStrings)
            {
                SecPermissions permission;
                if(Enum.TryParse(permissionsString.Replace(" ", ""), true, out permission))
                {
                    resourcePermissions |= permission;
                }
            }
            var resourceModels = environmentModel.ResourceRepository.All();
            var allMatch = resourceModels.Count(model => model.UserPermissions == resourcePermissions);
            var totalNumberOfResources = resourceModels.Count;
            Assert.IsTrue(totalNumberOfResources - allMatch <= 1);
        }

        [Given(@"Resource '(.*)' has rights '(.*)' for '(.*)'")]
        public void GivenResourceHasRights(string resourceName, string resourceRights, string groupName)
        {
            var environmentModel = ScenarioContext.Current.Get<IEnvironmentModel>("environment");
            EnsureEnvironmentConnected(environmentModel);
            var resourceRepository = environmentModel.ResourceRepository;
            var settings = resourceRepository.ReadSettings(environmentModel);
            environmentModel.ForceLoadResources();

            var resourceModel = resourceRepository.FindSingle(model => model.Category.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase));
            Assert.IsNotNull(resourceModel, "Did not find: " + resourceName);
            SecPermissions resourcePermissions = SecPermissions.None;
            var permissionsStrings = resourceRights.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var permissionsString in permissionsStrings)
            {
                SecPermissions permission;
                if(Enum.TryParse(permissionsString.Replace(" ", ""), true, out permission))
                {
                    resourcePermissions |= permission;
                }
            }
            settings.Security.WindowsGroupPermissions.RemoveAll(permission => permission.ResourceID == resourceModel.ID);
            var windowsGroupPermission = new WindowsGroupPermission { WindowsGroup = groupName, ResourceID = resourceModel.ID, ResourceName = resourceName, IsServer = false, Permissions = resourcePermissions };
            settings.Security.WindowsGroupPermissions.Add(windowsGroupPermission);
            resourceRepository.WriteSettings(environmentModel, settings);
        }

        [Then(@"'(.*)' should have '(.*)'")]
        public void ThenShouldHave(string resourceName, string resourcePerms)
        {
            var environmentModel = ScenarioContext.Current.Get<IEnvironmentModel>("currentEnvironment");
            EnsureEnvironmentConnected(environmentModel);
            var resourceRepository = environmentModel.ResourceRepository;
            environmentModel.ForceLoadResources();

            var resourceModel = resourceRepository.FindSingle(model => model.Category.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase));
            Assert.IsNotNull(resourceModel);
            SecPermissions resourcePermissions = SecPermissions.None;
            var permissionsStrings = resourcePerms.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var permissionsString in permissionsStrings)
            {
                SecPermissions permission;
                if(Enum.TryParse(permissionsString.Replace(" ", ""), true, out permission))
                {
                    resourcePermissions |= permission;
                }
            }
            resourceModel.UserPermissions = environmentModel.AuthorizationService.GetResourcePermissions(resourceModel.ID);
            Assert.AreEqual(resourcePermissions, resourceModel.UserPermissions);
        }

        [AfterScenario("Security")]
        public void DoCleanUp()
        {
            IEnvironmentModel currentEnvironment;
            ScenarioContext.Current.TryGetValue("currentEnvironment", out currentEnvironment);
            IEnvironmentModel environmentModel;
            ScenarioContext.Current.TryGetValue("environment", out environmentModel);
            Data.Settings.Settings currentSettings;
            ScenarioContext.Current.TryGetValue("initialSettings",out currentSettings);

            if(environmentModel != null)
            {
                try
                {
                    if(currentSettings!= null)
                    environmentModel.ResourceRepository.WriteSettings(environmentModel, currentSettings);

                }
                finally { environmentModel.Disconnect(); }
               
              
            }
            if (currentEnvironment != null)
            {

                currentEnvironment.Disconnect();
            }
        }
    }
}
