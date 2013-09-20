﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Windows;
using Caliburn.Micro;
using Dev2.Composition;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.Core.Models;
using Dev2.Studio.Core.Services.System;
using Dev2.Studio.Core.ViewModels.Base;
using Dev2.Studio.Feedback;
using Dev2.Studio.Feedback.Actions;
using Dev2.Studio.ViewModels.Help;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dev2.Core.Tests.Feedback.Actions
{
    [TestClass]
    public class EmailFeedbackActionTests
    {
        private SystemInfoTO GetMockSysInfo()
        {
            return new SystemInfoTO
            {
                ApplicationExecutionBits = 32,
                Edition = "Professional",
                Name = "Windows 7",
                ServicePack = "ServicePack 1",
                Version = "1.1.1.1"
            };
        }

        //[TestMethod]
        //public void StartFeedBack_Expected_ShowMethodCalledOnWindowManager()
        //{
        //    var mockSysInfo = new Mock<ISystemInfoService>();
        //    mockSysInfo.Setup(c => c.GetSystemInfo()).Returns(GetMockSysInfo());

        //    var mockWindowManager = new Mock<IWindowManager>();
        //    mockWindowManager.Setup(w => w.ShowWindow(It.IsAny<BaseViewModel>(), null, null)).Verifiable();

        //    ImportService.CurrentContext =
        //        CompositionInitializer.InitializeWithWindowManagerTest(mockSysInfo, mockWindowManager);

        //    var connection = new Mock<IEnvironmentConnection>();
        //    var environment = new Mock<IEnvironmentModel>();
        //    environment.Setup(env => env.Connection).Returns(connection.Object);
        //    var emailAction = new EmailFeedbackAction(new Dictionary<string, string>(), environment.Object);
        //    //ImportService.SatisfyImports(emailAction);

        //    emailAction.StartFeedback();
        //    mockWindowManager.Verify(c => c.ShowWindow(It.IsAny<SimpleBaseViewModel>(), null, null), Times.Once());
        //}

        //[TestMethod]
        //[Owner("Ashley Lewis")]
        //[TestCategory("EmailFeedbackAction_DisplayFeedbackWindow")]
        //public void EmailFeedbackAction_DisplayFeedbackWindow_NullEnvionment_ServerLogFileAttached()
        //{
        //    const string expected = ";ExpectedServerLogFilePath";
        //    string actual = null;

        //    var windowManager = new Mock<IWindowManager>();
        //    windowManager.Setup(c => c.ShowWindow(It.IsAny<Object>(), It.IsAny<Object>(), It.IsAny<IDictionary<string,Object>>())).Callback((Object vm, Object obj,IDictionary<string,Object> dictionary)=>
        //    {
        //        actual = (vm is FeedbackViewModel)?(vm as FeedbackViewModel).ServerLogAttachmentPath:null;
        //    });

        //    ImportService.CurrentContext = CompositionInitializer.InitializeForFeedbackActionTests(Dev2MockFactory.CreateIPopup(MessageBoxResult.OK), new Mock<IFeedBackRecorder>(), new Mock<IFeedbackInvoker>(), windowManager);
        //    var connection = new Mock<IEnvironmentConnection>();
        //    var environment = new Mock<IEnvironmentModel>();
        //    environment.Setup(env=>env.Connection).Returns(connection.Object);
        //    var emailFeedbackAction = new EmailFeedbackAction(expected, environment.Object);
        //    ImportService.SatisfyImports(emailFeedbackAction);
            
        //    //------------Execute Test---------------------------
        //    emailFeedbackAction.DisplayFeedbackWindow();

        //    //------------Assert Server Log File Attached--------
        //    Assert.AreEqual(expected.Split(';')[1], actual, "No log file attached");
        //}
    }
}
