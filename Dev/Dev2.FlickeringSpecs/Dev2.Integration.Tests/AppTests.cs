
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Integration.Tests
{
    [TestClass]
    public class AppTests
    {
        private static string deployDir;
        const string ServerProcessName = "Warewolf Server.exe";
        const string StudioProcessName = "Warewolf Studio";

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            deployDir = testContext.TestDeploymentDir;
        }

     

        private static string GetProcessPath(string processName)
        {
            var query = new SelectQuery(@"SELECT * FROM Win32_Process where Name LIKE '%" + processName + "%'");
            ManagementObjectCollection processes;
            //initialize the searcher with the query it is
            //supposed to execute
            using(ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                //execute the query
                processes = searcher.Get();
                if(processes.Count <= 0)
                {
                    return null;
                }
            }
            if(processes == null || processes.Count == 0)
            {
                return null;
            }
            return (from ManagementObject process in processes select (process.Properties["ExecutablePath"].Value ?? string.Empty).ToString()).FirstOrDefault();
        }

        #region Server Lifecycle Manager Test Utils

        private static string outputData = string.Empty;
        private static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            // Collect the sort command output. 
            var data = outLine.Data;
            if(!String.IsNullOrEmpty(data))
            {
                outputData += data;
            }
        }

        private int FetchRunningServerID()
        {
            const string wmiQueryString = "SELECT ProcessId FROM Win32_Process WHERE Name LIKE 'Warewolf Server%'";
            using(var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using(var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();

                    if(mo != null)
                    {
                        var id = mo.Properties["ProcessId"].Value.ToString();

                        int myID;
                        Int32.TryParse(id, out myID);

                        return myID;
                    }
                }
            }

            return 0;
        }

        #endregion
    }
}
