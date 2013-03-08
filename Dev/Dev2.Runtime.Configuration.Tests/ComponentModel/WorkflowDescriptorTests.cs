﻿using System;
using System.Xml.Linq;
using Dev2.Runtime.Configuration.ComponentModel;
using Dev2.Runtime.Configuration.Tests.XML;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Runtime.Configuration.Tests.ComponentModel
{
    [TestClass]
    public class WorkflowDescriptorTests
    {
        #region CTOR

        [TestMethod]
        public void ConstructorWithNullXmlArgumentExpectedDoesNotThrowException()
        {
            var workflow = new WorkflowDescriptor(null);
            Assert.IsNotNull(workflow);
        }

        [TestMethod]
        public void ConstructorWithInvalidXmlArgumentExpectedDoesNotThrowException()
        {
            var workflow = new WorkflowDescriptor(new XElement("x", new XElement("y"), new XElement("z")));
            Assert.IsNotNull(workflow);
        }

        [TestMethod]
        public void ConstructorWithValidXmlArgumentExpectedInitializesAllProperties()
        {
            var xml = XmlResource.Fetch("Workflow");
            var workflow = new WorkflowDescriptor(xml);

            var properties = workflow.GetType().GetProperties();

            foreach(var property in properties)
            {
                var expected = xml.AttributeSafe(property.Name).ToLower();
                var actual = property.GetValue(workflow).ToString().ToLower();
                Assert.AreEqual(expected, actual);
            }
        }

        #endregion

        #region ToXmlExpectedReturnsXml

        [TestMethod]
        public void ToXmlExpectedReturnsXml()
        {
            var workflow = new WorkflowDescriptor();
            var result = workflow.ToXml();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(XElement));
        }

        [TestMethod]
        public void ToXmlExpectedSerializesEachProperty()
        {
            var workflow = new WorkflowDescriptor
            {
                WorkflowID = Guid.NewGuid(),
                Name = "Testing123",
                IsSelected = true
            };
            var result = workflow.ToXml();

            var properties = workflow.GetType().GetProperties();
            foreach(var property in properties)
            {
                var expected = property.GetValue(workflow).ToString().ToLower();
                var actual = result.AttributeSafe(property.Name).ToLower();
                Assert.AreEqual(expected, actual);
            }
        }

        #endregion
    }
}
