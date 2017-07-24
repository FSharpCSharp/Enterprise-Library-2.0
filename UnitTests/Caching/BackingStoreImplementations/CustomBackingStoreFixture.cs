//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Caching Application Block
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Caching.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests;
using Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration;
#if !NUNIT
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
#endif

namespace Microsoft.Practices.EnterpriseLibrary.Caching.BackingStoreImplementations.Tests
{
	[TestClass]
	public class CustomBackingStoreFixture
	{
		[TestMethod]
		public void CanBuildCustomBackingStoreFromGivenConfiguration()
		{
			CustomCacheStorageData customData 
				= new CustomCacheStorageData("custom", typeof(MockCustomStorageBackingStore));
			customData.SetAttributeValue(MockCustomProviderBase.AttributeKey, "value1");
			CacheManagerSettings settings = new CacheManagerSettings();
			settings.BackingStores.Add(customData);
			settings.CacheManagers.Add(new CacheManagerData("ignore", 0, 0, 0, "custom"));
			DictionaryConfigurationSource configurationSource = new DictionaryConfigurationSource();
			configurationSource.Add(CacheManagerSettings.SectionName, settings);

			IBackingStore custom 
				= EnterpriseLibraryFactory.BuildUp<IBackingStore>("custom", configurationSource);

			Assert.IsNotNull(custom);
			Assert.AreSame(typeof(MockCustomStorageBackingStore), custom.GetType());
			Assert.AreEqual("value1", ((MockCustomStorageBackingStore)custom).customValue);
		}

		[TestMethod]
		public void CanBuildCustomBackingStoreFromSavedConfiguration()
		{
			CustomCacheStorageData customData
				= new CustomCacheStorageData("custom", typeof(MockCustomStorageBackingStore));
			customData.SetAttributeValue(MockCustomProviderBase.AttributeKey, "value1");
			CacheManagerSettings settings = new CacheManagerSettings();
			settings.BackingStores.Add(customData);
			settings.CacheManagers.Add(new CacheManagerData("ignore", 0, 0, 0, "custom"));

			IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>(1);
			sections[CacheManagerSettings.SectionName] = settings;
			IConfigurationSource configurationSource 
				= ConfigurationTestHelper.SaveSectionsInFileAndReturnConfigurationSource(sections);

			IBackingStore custom
				= EnterpriseLibraryFactory.BuildUp<IBackingStore>("custom", configurationSource);

			Assert.IsNotNull(custom);
			Assert.AreSame(typeof(MockCustomStorageBackingStore), custom.GetType());
			Assert.AreEqual("value1", ((MockCustomStorageBackingStore)custom).customValue);
		}

		[TestMethod]
		public void CanDeserializeSerializedConfiguration()
		{
			CustomCacheStorageData customData
				= new CustomCacheStorageData("custom", typeof(MockCustomStorageBackingStore));
			customData.SetAttributeValue(MockCustomProviderBase.AttributeKey, "value1");
			CacheManagerSettings settings = new CacheManagerSettings();
			settings.BackingStores.Add(customData);
			settings.CacheManagers.Add(new CacheManagerData("ignore", 0, 0, 0, "custom"));

			IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>(1);
			sections[CacheManagerSettings.SectionName] = settings;
			IConfigurationSource configurationSource
				= ConfigurationTestHelper.SaveSectionsInFileAndReturnConfigurationSource(sections);

			CacheManagerSettings roSettigs = (CacheManagerSettings)configurationSource.GetSection(CacheManagerSettings.SectionName);

			Assert.IsNotNull(roSettigs);
			Assert.AreEqual(1, roSettigs.BackingStores.Count);

			Assert.IsNotNull(roSettigs.BackingStores.Get("custom"));
			Assert.AreSame(typeof(CustomCacheStorageData), roSettigs.BackingStores.Get("custom").GetType());
			Assert.AreEqual("custom", ((CustomCacheStorageData)roSettigs.BackingStores.Get("custom")).Name);
			Assert.AreEqual(typeof(MockCustomStorageBackingStore), ((CustomCacheStorageData)roSettigs.BackingStores.Get("custom")).Type);
			Assert.AreEqual("value1", ((CustomCacheStorageData)roSettigs.BackingStores.Get("custom")).Attributes[MockCustomProviderBase.AttributeKey]);
		}
	}
}
