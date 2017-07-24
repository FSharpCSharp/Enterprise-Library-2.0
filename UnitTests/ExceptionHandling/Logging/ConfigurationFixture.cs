//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Exception Handling Application Block
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging.Configuration;

#if !NUNIT
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
#endif

using SysConfig = System.Configuration;
using System;

namespace Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging.Tests
{
	[TestClass]
	public class ConfigurationFixture
	{
		[TestMethod]
		public void CanReadAndWriteLoggingHandler()
		{
			ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
			fileMap.ExeConfigFilename = "test.exe.config";
			SysConfig.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            config.Sections.Remove(ExceptionHandlingSettings.SectionName);
            config.Sections.Add(ExceptionHandlingSettings.SectionName, CreateSettings());
			config.Save(ConfigurationSaveMode.Full);
			
			config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
			ExceptionHandlingSettings settings = (ExceptionHandlingSettings)config.Sections[ExceptionHandlingSettings.SectionName];
			LoggingExceptionHandlerData data = (LoggingExceptionHandlerData)settings.ExceptionPolicies.Get("test").ExceptionTypes.Get("test").ExceptionHandlers.Get("test");
			config.Sections.Remove(ExceptionHandlingSettings.SectionName);
			config.Save(ConfigurationSaveMode.Full);


			Assert.AreEqual("test", data.Name);
			Assert.AreEqual("cat1", data.LogCategory);
			Assert.AreEqual(1, data.EventId);
			Assert.AreEqual(System.Diagnostics.TraceEventType.Error, data.Severity);
			Assert.AreEqual("title", data.Title);
			Assert.AreEqual(typeof(XmlExceptionFormatter), data.FormatterType);
			Assert.AreEqual(4, data.Priority);
		}

		private static ExceptionHandlingSettings CreateSettings()
		{
			LoggingExceptionHandlerData logData = new LoggingExceptionHandlerData("test", "cat1", 1, System.Diagnostics.TraceEventType.Error, "title", typeof(XmlExceptionFormatter), 4);
			ExceptionTypeData typeData = new ExceptionTypeData("test", typeof(Exception), PostHandlingAction.None);
			typeData.ExceptionHandlers.Add(logData);
			ExceptionPolicyData policy = new ExceptionPolicyData("test");
			policy.ExceptionTypes.Add(typeData);			
			ExceptionHandlingSettings settings = new ExceptionHandlingSettings();
			settings.ExceptionPolicies.Add(policy);
			return settings;
		}
	}
}
