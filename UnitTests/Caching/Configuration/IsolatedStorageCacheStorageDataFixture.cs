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

#if !NUNIT
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
#endif

using Microsoft.Practices.EnterpriseLibrary.Caching.Configuration;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests;
using System.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Caching.Configuration.Tests
{
	[TestClass]
	public class IsolatedStorageCacheStorageDataFixture
	{
		private const string name1 = "name1";
		private const string encryption1 = "encryption1";
		private const string partition1 = "partition1";

		[TestMethod]
		public void CanDeserializeSerializedConfiguration()
		{
			CacheManagerSettings settings = new CacheManagerSettings();

			IsolatedStorageCacheStorageData data1 = new IsolatedStorageCacheStorageData(name1, encryption1, partition1);
			settings.BackingStores.Add(data1);

			// needed to save configuration
			settings.CacheManagers.Add(new CacheManagerData("foo", 0, 0, 0, "storage"));

			IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>();
			sections[CacheManagerSettings.SectionName] = settings;
			IConfigurationSource configurationSource
				= ConfigurationTestHelper.SaveSectionsInFileAndReturnConfigurationSource(sections);

			CacheManagerSettings roSettigs = (CacheManagerSettings)configurationSource.GetSection(CacheManagerSettings.SectionName);

			Assert.IsNotNull(roSettigs);
			Assert.AreEqual(1, roSettigs.BackingStores.Count);

			Assert.IsNotNull(roSettigs.BackingStores.Get(name1));
			Assert.AreSame(typeof(IsolatedStorageCacheStorageData), roSettigs.BackingStores.Get(name1).GetType());
			Assert.AreEqual(name1, roSettigs.BackingStores.Get(name1).Name);
			Assert.AreEqual(encryption1, ((IsolatedStorageCacheStorageData)roSettigs.BackingStores.Get(name1)).StorageEncryption);
			Assert.AreEqual(partition1, ((IsolatedStorageCacheStorageData)roSettigs.BackingStores.Get(name1)).PartitionName);
		}
	}
}
