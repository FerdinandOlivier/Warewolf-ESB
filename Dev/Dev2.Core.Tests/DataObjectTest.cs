﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Dev2.Data.Enums;
using Dev2.DataList.Contract;
using Dev2.Diagnostics;
using Dev2.DynamicServices;
using Dev2.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming
namespace Dev2.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DataObjectTest
    {
        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DsfDataObject_RawPayload")]
        public void DsfDataObject_RawPayload_WhenNull_ExpectEmptyString()
        {
            //------------Setup for test--------------------------
            IDSFDataObject dataObject = new DsfDataObject(string.Empty, Guid.NewGuid());

            //------------Execute Test---------------------------
            var result = dataObject.RawPayload;

            //------------Assert Results-------------------------
            Assert.AreEqual(string.Empty, result, "RawPayload did not return and empty string");
        }

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DsfDataObjectz_RawPayload")]
        public void DsfDataObjectz_RawPayload_WhenNotNull_ExpectRawPayload()
        {
            //------------Setup for test--------------------------
            IDSFDataObject dataObject = new DsfDataObject(string.Empty, Guid.NewGuid(), "foo");

            //------------Execute Test---------------------------
            var result = dataObject.RawPayload;

            //------------Assert Results-------------------------
            StringAssert.Contains(result, "foo");
        }

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DsfDataObject_Clone")]
        public void DsfDataObject_Clone_NormalClone_FullDuplicationForProperties()
        {
            //------------Setup for test--------------------------
            IDSFDataObject dataObject = new DsfDataObject(string.Empty, Guid.NewGuid(), "<x>1</x>");
            Guid wfInstanceID = Guid.NewGuid();

            dataObject.BookmarkExecutionCallbackID = Guid.NewGuid();
            dataObject.CurrentBookmarkName = "def";
            dataObject.DataList = "<x/>";
            dataObject.DataListID = Guid.NewGuid();
            dataObject.DatalistInMergeDepth = enTranslationDepth.Data;
            dataObject.DatalistInMergeID = Guid.NewGuid();
            dataObject.DatalistInMergeType = enDataListMergeTypes.Union;
            dataObject.DatalistOutMergeDepth = enTranslationDepth.Data;
            dataObject.DatalistOutMergeFrequency = DataListMergeFrequency.Always;
            dataObject.DatalistOutMergeID = Guid.NewGuid();
            dataObject.DatalistOutMergeType = enDataListMergeTypes.Union;
            dataObject.DebugSessionID = Guid.NewGuid();
            dataObject.EnvironmentID = Guid.NewGuid();
            dataObject.Errors = new ErrorResultTO();
            dataObject.Errors.AddError("my error");
            dataObject.ExecutionCallbackID = Guid.NewGuid();
            dataObject.ExecutionOrigin = ExecutionOrigin.Debug;
            dataObject.ExecutionOriginDescription = "xxx";
            dataObject.ForceDeleteAtNextNativeActivityCleanup = true;
            dataObject.IsDataListScoped = false;
            dataObject.IsDebug = true;
            dataObject.IsFromWebServer = true;
            dataObject.IsOnDemandSimulation = true;
            dataObject.IsWebpage = false;
            dataObject.NumberOfSteps = 2;
            dataObject.OriginalInstanceID = Guid.NewGuid();
            dataObject.ParentInstanceID = "1211";
            dataObject.ParentServiceName = "xxx";
            dataObject.ParentThreadID = 2;
            dataObject.ParentWorkflowInstanceId = "1233";
            dataObject.RawPayload = "<raw>a</raw>";
            dataObject.RemoteDebugItems = new List<DebugState>();
            dataObject.RemoteInvoke = false;
            dataObject.RemoteInvokeResultShape = "<x/>";
            dataObject.RemoteInvokerID = "999";
            dataObject.RemoteServiceType = "NA";
            dataObject.ResourceID = Guid.NewGuid();
            dataObject.ReturnType = EmitionTypes.XML;
            dataObject.ServerID = Guid.NewGuid();
            dataObject.ServiceName = "xxx";
            dataObject.WorkflowInstanceId = wfInstanceID;
            dataObject.WorkflowResumeable = false;
            dataObject.ParentID = Guid.NewGuid();
            dataObject.WorkspaceID = Guid.NewGuid();
            dataObject.ClientID = Guid.NewGuid();
            dataObject.RunWorkflowAsync = true;
            dataObject.IsDebugNested = true;
            var threadsToDispose = new Dictionary<int, List<Guid>>();
            List<Guid> guidList = new List<Guid> { Guid.NewGuid() };
            threadsToDispose.Add(3, guidList);
            dataObject.ThreadsToDispose = threadsToDispose;

            //------------Execute Test---------------------------
            IDSFDataObject clonedObject = dataObject.Clone();

            //------------Assert Results-------------------------

            // check counts, then check values
            var properties = typeof(IDSFDataObject).GetProperties();
            Assert.AreEqual(49, properties.Length);

            // now check each value to ensure it transfered
            Assert.AreEqual(dataObject.BookmarkExecutionCallbackID, clonedObject.BookmarkExecutionCallbackID);
            Assert.AreEqual(dataObject.CurrentBookmarkName, clonedObject.CurrentBookmarkName);
            Assert.AreEqual(dataObject.DataList, clonedObject.DataList);
            Assert.AreEqual(dataObject.DataListID, clonedObject.DataListID);
            Assert.AreEqual(dataObject.DatalistInMergeDepth, clonedObject.DatalistInMergeDepth);
            Assert.AreEqual(dataObject.DatalistInMergeID, clonedObject.DatalistInMergeID);
            Assert.AreEqual(dataObject.DatalistInMergeType, clonedObject.DatalistInMergeType);
            Assert.AreEqual(dataObject.DatalistOutMergeDepth, clonedObject.DatalistOutMergeDepth);
            Assert.AreEqual(dataObject.DatalistOutMergeFrequency, clonedObject.DatalistOutMergeFrequency);
            Assert.AreEqual(dataObject.DatalistOutMergeID, clonedObject.DatalistOutMergeID);
            Assert.AreEqual(dataObject.DatalistOutMergeType, clonedObject.DatalistOutMergeType);
            Assert.AreEqual(dataObject.DebugSessionID, clonedObject.DebugSessionID);
            Assert.AreEqual(dataObject.EnvironmentID, clonedObject.EnvironmentID);
            Assert.AreEqual(dataObject.Errors, clonedObject.Errors);
            Assert.AreEqual(dataObject.ExecutingUser, clonedObject.ExecutingUser);
            Assert.AreEqual(dataObject.ExecutionCallbackID, clonedObject.ExecutionCallbackID);
            Assert.AreEqual(dataObject.ExecutionOrigin, clonedObject.ExecutionOrigin);
            Assert.AreEqual(dataObject.ExecutionOriginDescription, clonedObject.ExecutionOriginDescription);
            Assert.AreEqual(dataObject.ForceDeleteAtNextNativeActivityCleanup, clonedObject.ForceDeleteAtNextNativeActivityCleanup);
            Assert.AreEqual(dataObject.IsDataListScoped, clonedObject.IsDataListScoped);
            Assert.AreEqual(dataObject.IsDebug, clonedObject.IsDebug);
            Assert.AreEqual(dataObject.IsFromWebServer, clonedObject.IsFromWebServer);
            Assert.AreEqual(dataObject.IsOnDemandSimulation, clonedObject.IsOnDemandSimulation);
            Assert.AreEqual(dataObject.IsRemoteWorkflow, clonedObject.IsRemoteWorkflow);
            Assert.AreEqual(dataObject.IsWebpage, clonedObject.IsWebpage);
            Assert.AreEqual(dataObject.NumberOfSteps, clonedObject.NumberOfSteps);
            Assert.AreEqual(dataObject.OriginalInstanceID, clonedObject.OriginalInstanceID);
            Assert.AreEqual(dataObject.ParentInstanceID, clonedObject.ParentInstanceID);
            Assert.AreEqual(dataObject.ParentServiceName, clonedObject.ParentServiceName);
            Assert.AreEqual(dataObject.ParentThreadID, clonedObject.ParentThreadID);
            Assert.AreEqual(dataObject.ParentWorkflowInstanceId, clonedObject.ParentWorkflowInstanceId);
            Assert.AreEqual(dataObject.RawPayload, clonedObject.RawPayload);
            Assert.AreEqual(dataObject.RemoteDebugItems, clonedObject.RemoteDebugItems);
            Assert.AreEqual(dataObject.RemoteInvoke, clonedObject.RemoteInvoke);
            Assert.AreEqual(dataObject.RemoteInvokeResultShape, clonedObject.RemoteInvokeResultShape);
            Assert.AreEqual(dataObject.RemoteInvokerID, clonedObject.RemoteInvokerID);
            Assert.AreEqual(dataObject.RemoteServiceType, clonedObject.RemoteServiceType);
            Assert.AreEqual(dataObject.ResourceID, clonedObject.ResourceID);
            Assert.AreEqual(dataObject.ReturnType, clonedObject.ReturnType);
            Assert.AreEqual(dataObject.ServerID, clonedObject.ServerID);
            Assert.AreEqual(dataObject.ClientID, clonedObject.ClientID);
            Assert.AreEqual(dataObject.ServiceName, clonedObject.ServiceName);
            Assert.AreEqual(dataObject.WorkflowInstanceId, clonedObject.WorkflowInstanceId);
            Assert.AreEqual(dataObject.WorkflowResumeable, clonedObject.WorkflowResumeable);
            Assert.AreEqual(dataObject.WorkspaceID, clonedObject.WorkspaceID);
            Assert.AreEqual(dataObject.ThreadsToDispose, clonedObject.ThreadsToDispose);
            Assert.AreEqual(dataObject.ParentID, clonedObject.ParentID);
            Assert.AreEqual(dataObject.RunWorkflowAsync, clonedObject.RunWorkflowAsync);
            Assert.AreEqual(dataObject.IsDebugNested, clonedObject.IsDebugNested);
        }

        #region Debug Mode Test

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("DataObject_IsDebugMode")]
        public void DataObject_IsDebugMode_IsDebugIsTrueAndRunWorkflowAsyncIsTrue_IsDebugModeIsFalse()
        {
            //------------Setup for test--------------------------
            IDSFDataObject dataObject = new DsfDataObject(string.Empty, Guid.NewGuid(), "<x>1</x>");
            dataObject.RunWorkflowAsync = true;
            dataObject.IsDebug = true;
            //------------Execute Test---------------------------
            var isDebug = dataObject.IsDebugMode();
            //------------Assert Results-------------------------
            Assert.IsFalse(isDebug);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("DataObject_IsDebugMode")]
        public void DataObject_IsDebugMode_IsDebugIsTrueAndRunWorkflowAsyncIsFalse_IsDebugModeIsTrue()
        {
            //------------Setup for test--------------------------
            IDSFDataObject dataObject = new DsfDataObject(string.Empty, Guid.NewGuid(), "<x>1</x>");
            dataObject.RunWorkflowAsync = false;
            dataObject.IsDebug = true;
            //------------Execute Test---------------------------
            var isDebug = dataObject.IsDebugMode();
            //------------Assert Results-------------------------
            Assert.IsTrue(isDebug);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("DataObject_IsDebugMode")]
        public void DataObject_IsDebugMode_RemoteInvokeIsTrueAndRunWorkflowAsyncIsTrue_IsDebugModeIsFalse()
        {
            //------------Setup for test--------------------------
            IDSFDataObject dataObject = new DsfDataObject(string.Empty, Guid.NewGuid(), "<x>1</x>");
            dataObject.RunWorkflowAsync = true;
            dataObject.RemoteInvoke = true;
            //------------Execute Test---------------------------
            var isDebug = dataObject.IsDebugMode();
            //------------Assert Results-------------------------
            Assert.IsFalse(isDebug);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("DataObject_IsDebugMode")]
        public void DataObject_IsDebugMode_RemoteInvokeIsTrueAndRunWorkflowAsyncIsFalse_IsDebugModeIsTrue()
        {
            //------------Setup for test--------------------------
            IDSFDataObject dataObject = new DsfDataObject(string.Empty, Guid.NewGuid(), "<x>1</x>");
            dataObject.RunWorkflowAsync = false;
            dataObject.RemoteInvoke = true;
            //------------Execute Test---------------------------
            var isDebug = dataObject.IsDebugMode();
            //------------Assert Results-------------------------
            Assert.IsTrue(isDebug);
        }

        #endregion

        #region Constructor Test

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DataObject_Ctor")]
        public void DataObject_Ctor_WhenXmlStringContainsAllButDataMergePropertiesSet_ExpectParseAndSet()
        {
            //------------Setup for test--------------------------
            var debugID = Guid.NewGuid();
            var envID = Guid.NewGuid();
            var exeID = Guid.NewGuid();
            var bookmarkID = Guid.NewGuid();
            var parentID = Guid.NewGuid();
            var instID = Guid.NewGuid();

            var xmlStr = "<Payload>" +
                         "<IsDebug>true</IsDebug>" +
                         "<DebugSessionID>" + debugID + "</DebugSessionID>" +
                         "<EnvironmentID>" + envID + "</EnvironmentID>" +
                         "<IsOnDemandSimulation>true</IsOnDemandSimulation>" +
                         "<ParentServiceName>TestParentService</ParentServiceName>" +
                         "<ExecutionCallbackID>" + exeID + "</ExecutionCallbackID>" +
                         "<BookmarkExecutionCallbackID>" + bookmarkID + "</BookmarkExecutionCallbackID>" +
                         "<ParentInstanceID>" + parentID + "</ParentInstanceID>" +
                         "<NumberOfSteps>5</NumberOfSteps>" +
                         "<CurrentBookmarkName>MyBookmark</CurrentBookmarkName>" +
                         "<WorkflowInstanceId>" + instID + "</WorkflowInstanceId>" +
                         "<IsDataListScoped>true</IsDataListScoped>" +
                         "<Service>MyTestService</Service>" +
                         "</Payload>";


            //------------Execute Test---------------------------
            var dataObjct = new DsfDataObject(xmlStr, Guid.NewGuid(), "<x>1</x>");

            //------------Assert Results-------------------------
            Assert.IsTrue(dataObjct.IsDebug);
            StringAssert.Contains(dataObjct.DebugSessionID.ToString(), debugID.ToString());
            StringAssert.Contains(dataObjct.EnvironmentID.ToString(), envID.ToString());
            Assert.IsTrue(dataObjct.IsOnDemandSimulation);
            StringAssert.Contains(dataObjct.ParentServiceName, "TestParentService");
            StringAssert.Contains(dataObjct.ExecutionCallbackID.ToString(), exeID.ToString());
            StringAssert.Contains(dataObjct.BookmarkExecutionCallbackID.ToString(), bookmarkID.ToString());
            StringAssert.Contains(dataObjct.ParentInstanceID, parentID.ToString());
            Assert.AreEqual(5, dataObjct.NumberOfSteps, "Wrong number of steps");
            StringAssert.Contains(dataObjct.CurrentBookmarkName, "MyBookmark");
            StringAssert.Contains(dataObjct.WorkflowInstanceId.ToString(), instID.ToString());
            Assert.IsTrue(dataObjct.IsDataListScoped);
            StringAssert.Contains(dataObjct.ServiceName, "MyTestService");
            StringAssert.Contains(dataObjct.RawPayload, xmlStr);

            // Default Data Merge Checks
            StringAssert.Contains(dataObjct.DatalistOutMergeID.ToString(), Guid.Empty.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeType.ToString(), enDataListMergeTypes.Intersection.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeDepth.ToString(), enTranslationDepth.Data_With_Blank_OverWrite.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeFrequency.ToString(), DataListMergeFrequency.OnCompletion.ToString());

            StringAssert.Contains(dataObjct.DatalistInMergeID.ToString(), Guid.Empty.ToString());
            StringAssert.Contains(dataObjct.DatalistInMergeType.ToString(), enDataListMergeTypes.Intersection.ToString());
            StringAssert.Contains(dataObjct.DatalistInMergeDepth.ToString(), enTranslationDepth.Data_With_Blank_OverWrite.ToString());

        }

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DataObject_Ctor")]
        public void DataObject_Ctor_WhenXmlStringgDoesNotHaveIsDebugModeSetButHasBDSDebugModeSet_ExpectParseAndSetAndIsDebugStillTrue()
        {
            //------------Setup for test--------------------------
            var debugID = Guid.NewGuid();
            var envID = Guid.NewGuid();
            var exeID = Guid.NewGuid();
            var bookmarkID = Guid.NewGuid();
            var parentID = Guid.NewGuid();
            var instID = Guid.NewGuid();

            var xmlStr = "<Payload>" +
                         "<BDSDebugMode>true</BDSDebugMode>" +
                         "<DebugSessionID>" + debugID + "</DebugSessionID>" +
                         "<EnvironmentID>" + envID + "</EnvironmentID>" +
                         "<IsOnDemandSimulation>true</IsOnDemandSimulation>" +
                         "<ParentServiceName>TestParentService</ParentServiceName>" +
                         "<ExecutionCallbackID>" + exeID + "</ExecutionCallbackID>" +
                         "<BookmarkExecutionCallbackID>" + bookmarkID + "</BookmarkExecutionCallbackID>" +
                         "<ParentInstanceID>" + parentID + "</ParentInstanceID>" +
                         "<NumberOfSteps>5</NumberOfSteps>" +
                         "<CurrentBookmarkName>MyBookmark</CurrentBookmarkName>" +
                         "<WorkflowInstanceId>" + instID + "</WorkflowInstanceId>" +
                         "<IsDataListScoped>true</IsDataListScoped>" +
                         "<Service>MyTestService</Service>" +
                         "</Payload>";


            //------------Execute Test---------------------------
            var dataObjct = new DsfDataObject(xmlStr, Guid.NewGuid(), "<x>1</x>");

            //------------Assert Results-------------------------
            Assert.IsTrue(dataObjct.IsDebug);
            StringAssert.Contains(dataObjct.DebugSessionID.ToString(), debugID.ToString());
            StringAssert.Contains(dataObjct.EnvironmentID.ToString(), envID.ToString());
            Assert.IsTrue(dataObjct.IsOnDemandSimulation);
            StringAssert.Contains(dataObjct.ParentServiceName, "TestParentService");
            StringAssert.Contains(dataObjct.ExecutionCallbackID.ToString(), exeID.ToString());
            StringAssert.Contains(dataObjct.BookmarkExecutionCallbackID.ToString(), bookmarkID.ToString());
            StringAssert.Contains(dataObjct.ParentInstanceID, parentID.ToString());
            Assert.AreEqual(5, dataObjct.NumberOfSteps, "Wrong number of steps");
            StringAssert.Contains(dataObjct.CurrentBookmarkName, "MyBookmark");
            StringAssert.Contains(dataObjct.WorkflowInstanceId.ToString(), instID.ToString());
            Assert.IsTrue(dataObjct.IsDataListScoped);
            StringAssert.Contains(dataObjct.ServiceName, "MyTestService");
            StringAssert.Contains(dataObjct.RawPayload, xmlStr);

            // Default Data Merge Checks
            StringAssert.Contains(dataObjct.DatalistOutMergeID.ToString(), Guid.Empty.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeType.ToString(), enDataListMergeTypes.Intersection.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeDepth.ToString(), enTranslationDepth.Data_With_Blank_OverWrite.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeFrequency.ToString(), DataListMergeFrequency.OnCompletion.ToString());

            StringAssert.Contains(dataObjct.DatalistInMergeID.ToString(), Guid.Empty.ToString());
            StringAssert.Contains(dataObjct.DatalistInMergeType.ToString(), enDataListMergeTypes.Intersection.ToString());
            StringAssert.Contains(dataObjct.DatalistInMergeDepth.ToString(), enTranslationDepth.Data_With_Blank_OverWrite.ToString());

        }

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DataObject_Ctor")]
        public void DataObject_Ctor_WhenXmlStringDoesNotHaveBookmarkExecutionCallbackIDSet_ExpectParseAndSet()
        {
            //------------Setup for test--------------------------
            var debugID = Guid.NewGuid();
            var envID = Guid.NewGuid();
            var exeID = Guid.NewGuid();
            var parentID = Guid.NewGuid();
            var instID = Guid.NewGuid();

            var xmlStr = "<Payload>" +
                         "<IsDebug>true</IsDebug>" +
                         "<DebugSessionID>" + debugID + "</DebugSessionID>" +
                         "<EnvironmentID>" + envID + "</EnvironmentID>" +
                         "<IsOnDemandSimulation>true</IsOnDemandSimulation>" +
                         "<ParentServiceName>TestParentService</ParentServiceName>" +
                         "<ExecutionCallbackID>" + exeID + "</ExecutionCallbackID>" +
                         "<ParentInstanceID>" + parentID + "</ParentInstanceID>" +
                         "<NumberOfSteps>5</NumberOfSteps>" +
                         "<CurrentBookmarkName>MyBookmark</CurrentBookmarkName>" +
                         "<WorkflowInstanceId>" + instID + "</WorkflowInstanceId>" +
                         "<IsDataListScoped>true</IsDataListScoped>" +
                         "<Service>MyTestService</Service>" +
                         "</Payload>";


            //------------Execute Test---------------------------
            var dataObjct = new DsfDataObject(xmlStr, Guid.NewGuid(), "<x>1</x>");

            //------------Assert Results-------------------------
            Assert.IsTrue(dataObjct.IsDebug);
            StringAssert.Contains(dataObjct.DebugSessionID.ToString(), debugID.ToString());
            StringAssert.Contains(dataObjct.EnvironmentID.ToString(), envID.ToString());
            Assert.IsTrue(dataObjct.IsOnDemandSimulation);
            StringAssert.Contains(dataObjct.ParentServiceName, "TestParentService");
            StringAssert.Contains(dataObjct.ExecutionCallbackID.ToString(), exeID.ToString());
            StringAssert.Contains(dataObjct.BookmarkExecutionCallbackID.ToString(), exeID.ToString());
            StringAssert.Contains(dataObjct.ParentInstanceID, parentID.ToString());
            Assert.AreEqual(5, dataObjct.NumberOfSteps, "Wrong number of steps");
            StringAssert.Contains(dataObjct.CurrentBookmarkName, "MyBookmark");
            StringAssert.Contains(dataObjct.WorkflowInstanceId.ToString(), instID.ToString());
            Assert.IsTrue(dataObjct.IsDataListScoped);
            StringAssert.Contains(dataObjct.ServiceName, "MyTestService");
            StringAssert.Contains(dataObjct.RawPayload, xmlStr);

            // Default Data Merge Checks
            StringAssert.Contains(dataObjct.DatalistOutMergeID.ToString(), Guid.Empty.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeType.ToString(), enDataListMergeTypes.Intersection.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeDepth.ToString(), enTranslationDepth.Data_With_Blank_OverWrite.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeFrequency.ToString(), DataListMergeFrequency.OnCompletion.ToString());

            StringAssert.Contains(dataObjct.DatalistInMergeID.ToString(), Guid.Empty.ToString());
            StringAssert.Contains(dataObjct.DatalistInMergeType.ToString(), enDataListMergeTypes.Intersection.ToString());
            StringAssert.Contains(dataObjct.DatalistInMergeDepth.ToString(), enTranslationDepth.Data_With_Blank_OverWrite.ToString());

        }

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DataObject_Ctor")]
        public void DataObject_Ctor_WhenXmlStringContainsAllIncludingDataMergePropertiesSet_ExpectParseAndSet()
        {
            //------------Setup for test--------------------------
            var debugID = Guid.NewGuid();
            var envID = Guid.NewGuid();
            var exeID = Guid.NewGuid();
            var bookmarkID = Guid.NewGuid();
            var parentID = Guid.NewGuid();
            var instID = Guid.NewGuid();
            var mergeIDOut = Guid.NewGuid();
            var mergeIDIn = Guid.NewGuid();

            var xmlStr = "<Payload>" +
                         "<IsDebug>true</IsDebug>" +
                         "<DebugSessionID>" + debugID + "</DebugSessionID>" +
                         "<EnvironmentID>" + envID + "</EnvironmentID>" +
                         "<IsOnDemandSimulation>true</IsOnDemandSimulation>" +
                         "<ParentServiceName>TestParentService</ParentServiceName>" +
                         "<ExecutionCallbackID>" + exeID + "</ExecutionCallbackID>" +
                         "<BookmarkExecutionCallbackID>" + bookmarkID + "</BookmarkExecutionCallbackID>" +
                         "<ParentInstanceID>" + parentID + "</ParentInstanceID>" +
                         "<NumberOfSteps>5</NumberOfSteps>" +
                         "<CurrentBookmarkName>MyBookmark</CurrentBookmarkName>" +
                         "<WorkflowInstanceId>" + instID + "</WorkflowInstanceId>" +
                         "<IsDataListScoped>true</IsDataListScoped>" +
                         "<Service>MyTestService</Service>" +
                         "<DatalistOutMergeID>" + mergeIDOut + "</DatalistOutMergeID>" +
                         "<DatalistOutMergeType>Union</DatalistOutMergeType>" +
                         "<DatalistOutMergeDepth>Data</DatalistOutMergeDepth>" +
                         "<DatalistOutMergeFrequency>Never</DatalistOutMergeFrequency>" +
                         "<DatalistInMergeID>" + mergeIDIn + "</DatalistInMergeID>" +
                         "<DatalistInMergeType>Union</DatalistInMergeType>" +
                         "<DatalistInMergeDepth>Data</DatalistInMergeDepth>" +
                         "</Payload>";


            //------------Execute Test---------------------------
            var dataObjct = new DsfDataObject(xmlStr, Guid.NewGuid(), "<x>1</x>");

            //------------Assert Results-------------------------
            Assert.IsTrue(dataObjct.IsDebug);
            StringAssert.Contains(dataObjct.DebugSessionID.ToString(), debugID.ToString());
            StringAssert.Contains(dataObjct.EnvironmentID.ToString(), envID.ToString());
            Assert.IsTrue(dataObjct.IsOnDemandSimulation);
            StringAssert.Contains(dataObjct.ParentServiceName, "TestParentService");
            StringAssert.Contains(dataObjct.ExecutionCallbackID.ToString(), exeID.ToString());
            StringAssert.Contains(dataObjct.BookmarkExecutionCallbackID.ToString(), bookmarkID.ToString());
            StringAssert.Contains(dataObjct.ParentInstanceID, parentID.ToString());
            Assert.AreEqual(5, dataObjct.NumberOfSteps, "Wrong number of steps");
            StringAssert.Contains(dataObjct.CurrentBookmarkName, "MyBookmark");
            StringAssert.Contains(dataObjct.WorkflowInstanceId.ToString(), instID.ToString());
            Assert.IsTrue(dataObjct.IsDataListScoped);
            StringAssert.Contains(dataObjct.ServiceName, "MyTestService");
            StringAssert.Contains(dataObjct.RawPayload, xmlStr);

            // Data Merge Checks
            StringAssert.Contains(dataObjct.DatalistOutMergeID.ToString(), mergeIDOut.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeType.ToString(), enDataListMergeTypes.Union.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeDepth.ToString(), enTranslationDepth.Data.ToString());
            StringAssert.Contains(dataObjct.DatalistOutMergeFrequency.ToString(), DataListMergeFrequency.Never.ToString());

            StringAssert.Contains(dataObjct.DatalistInMergeID.ToString(), mergeIDIn.ToString());
            StringAssert.Contains(dataObjct.DatalistInMergeType.ToString(), enDataListMergeTypes.Union.ToString());
            StringAssert.Contains(dataObjct.DatalistInMergeDepth.ToString(), enTranslationDepth.Data.ToString());

        }

        #endregion
    }
}
