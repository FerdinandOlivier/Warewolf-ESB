﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Dev2.Common;
using Dev2.Common.ServiceModel;
using Dev2.Runtime.Diagnostics;
using Newtonsoft.Json;
using PluginSource = Dev2.Runtime.ServiceModel.Data.PluginSource;
using Dev2.Runtime.ServiceModel.Esb.Brokers;

namespace Dev2.Runtime.ServiceModel
{
    public class PluginSources : ExceptionManager
    {
        #region Get

        // POST: Service/PluginSources/Get
        public PluginSource Get(string resourceID, Guid workspaceID, Guid dataListID)
        {
            var result = new PluginSource { ResourceID = Guid.Empty, ResourceType = ResourceType.PluginSource };
            try
            {
                var xmlStr = Resources.ReadXml(workspaceID, ResourceType.PluginSource, resourceID);
                if(!string.IsNullOrEmpty(xmlStr))
                {
                    var xml = XElement.Parse(xmlStr);
                    result = new PluginSource(xml);
                }
            }
            catch(Exception ex)
            {
                RaiseError(ex);
            }
            return result;
        }

        #endregion

        #region Save
        
        // POST: Service/PluginSources/Save
        public string Save(string args, Guid workspaceID, Guid dataListID)
        {
            var pluginSourceDetails = JsonConvert.DeserializeObject<PluginSource>(args);

            if(string.IsNullOrEmpty(pluginSourceDetails.AssemblyName))
            {
                //resolve AssemblyName from AssemblyLocation
                if (!pluginSourceDetails.AssemblyLocation.StartsWith(GlobalConstants.GACPrefix))
                {
                    //assembly location refers to a file, read the assembly name out of the dll file
                    pluginSourceDetails.AssemblyLocation = pluginSourceDetails.AssemblyLocation.EndsWith("\\") ?
                        pluginSourceDetails.AssemblyLocation.Remove(pluginSourceDetails.AssemblyLocation.Length - 1) : //remove trailing slashes if they exist
                        pluginSourceDetails.AssemblyLocation; //else do nothing
                    try
                    {
                        pluginSourceDetails.AssemblyName = AssemblyName.GetAssemblyName(pluginSourceDetails.AssemblyLocation).Name;
                    }
                    catch(Exception)
                    {
                        if(!string.IsNullOrEmpty(pluginSourceDetails.AssemblyLocation))
                        {
                            pluginSourceDetails.AssemblyName = pluginSourceDetails.AssemblyLocation.Substring(pluginSourceDetails.AssemblyLocation.LastIndexOf("\\", StringComparison.Ordinal)+1, pluginSourceDetails.AssemblyLocation.IndexOf(".dll", StringComparison.Ordinal) - pluginSourceDetails.AssemblyLocation.LastIndexOf("\\", StringComparison.Ordinal)-1);
                        }
                    }
                }
                else
                {
                    //assembly location refers to the GAC
                    var getName = pluginSourceDetails.AssemblyLocation.Substring(pluginSourceDetails.AssemblyLocation.IndexOf(':') + 1);//To get just the name add length, pluginSourceDetails.AssemblyLocation.IndexOf(',') - 4
                    pluginSourceDetails.AssemblyName = getName;
                }
            }

            pluginSourceDetails.Save(workspaceID);
            if (workspaceID != GlobalConstants.ServerWorkspaceID)
            {
                pluginSourceDetails.Save(GlobalConstants.ServerWorkspaceID);
            }

            return pluginSourceDetails.ToString();
        }

        #endregion

        #region GetDirectoryIntellisense - TODO : REFACTOR

        // POST: Service/PluginSources/GetDirectoryIntellisense
        public string GetDirectoryIntellisense(string args, Guid workspaceID, Guid dataListID)
        {
            var directory = new DirectoryInfo(args);

            //Build intellisense results
            IList<string> dirList = new List<string>();
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                dirList.Add(args + d.Name);
            }
            foreach (FileInfo f in directory.GetFiles())
            {
                if(f.Name.EndsWith(".dll"))
                {
                    dirList.Add(args + f.Name);
                }
            }
            return JsonConvert.SerializeObject(dirList);
        }

        #endregion

        #region ValidateAssemblyImageFormat

        // POST: Service/PluginSources/ValidateAssemblyImageFormat
        public string ValidateAssemblyImageFormat(string args, Guid workspaceID, Guid dataListID)
        {
            var toJson = @"{""validationresult"":""failure""}";

            var broker = new PluginBroker();

            string errorMsg;

            if(broker.ValidatePlugin(args, out errorMsg))
            {
                toJson = @"{""validationresult"":""success""}";
            }
            else
            {
                toJson = @"{""validationresult"":"""+errorMsg+@"""}";
            }
            
            return toJson;
        }

        #endregion
    }
}