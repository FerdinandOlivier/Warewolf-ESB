using System;
using System.IO;
using System.Threading;
using Dev2.Tests.Runtime.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Flickering.Specs.Runtime.Tests
{
    [TestClass]
    public class FlickeringServerSecurityServiceTests
    {
        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("ServerSecurityService_OnFileChanged")]
        public void ServerSecurityService_OnFileChanged_RaisingEvents_DisabledAndEnabled()
        {
            //------------Setup for test--------------------------
            var fileName = string.Format("secure_{0}.config", Guid.NewGuid());
            File.WriteAllText(fileName, @"xxx");

            var serverSecurityService = new TestServerSecurityService(fileName);

            //------------Execute Test---------------------------
            File.WriteAllText(fileName, @"ssss");
            ServerSecurityServiceTests.WaitForEvents();

            //------------Assert Results-------------------------
            Assert.AreEqual(2, serverSecurityService.OnFileChangedEnableRaisingEventsEnabled.Count);
            Assert.IsFalse(serverSecurityService.OnFileChangedEnableRaisingEventsEnabled[0]);
            Assert.IsTrue(serverSecurityService.OnFileChangedEnableRaisingEventsEnabled[1]);

            serverSecurityService.Dispose();
        }
    }
}
