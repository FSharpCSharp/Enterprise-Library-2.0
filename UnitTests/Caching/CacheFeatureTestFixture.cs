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

using System;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.Tests;
#if !NUNIT
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestMethod = NUnit.Framework.TestAttribute; 
#endif


namespace Microsoft.Practices.EnterpriseLibrary.Caching.Tests
{
	[TestClass]
    public class CacheFeatureTestFixture :  ICacheItemRefreshAction
    {
		private static CacheManagerFactory factory;
		private static CacheManager shortCacheManager;
		private static CacheManager smallCacheManager;

		private static string expiredKeys = "";
		private static string expiredValues = "";
		private static string removalReasons = "";

		[TestInitialize]
		public void StartCacheProcesses()
        {
            factory = new CacheManagerFactory(TestConfigurationSource.GenerateConfiguration());
            shortCacheManager = factory.Create("ShortInMemoryPersistence");
            smallCacheManager = factory.Create("SmallInMemoryPersistence");

            expiredKeys = "";
            expiredValues = "";
            removalReasons = "";
        }

		[TestCleanup]
		public void StopCacheProcesses()
        {
            shortCacheManager.Dispose();
            smallCacheManager.Dispose();
        }

		[TestMethod]
        public void CanConstructSystem()
        {
            Thread.Sleep(2000);
        }

		[TestMethod]
        public void ExpirationWillRemoveItemFromCache()
        {
            shortCacheManager.Add("ExpiresImmediately", "value1", CacheItemPriority.Normal, null, new AlwaysExpired());
            Thread.Sleep(1500);
            Assert.IsNull(shortCacheManager.GetData("ExpiresImmediately"), "Expiration should have removed item from cache");
        }

		[TestMethod]
        public void PutItThroughSomeExpirations()
        {
            shortCacheManager.Add("ExpiresImmediately", "Value1", CacheItemPriority.NotRemovable, this, new AlwaysExpired());
            shortCacheManager.Add("NeverExpires", "Value2", CacheItemPriority.NotRemovable, this, new NeverExpired());
            shortCacheManager.Add("ExpiresInFiveSeconds", "Value3", CacheItemPriority.NotRemovable, this, new AbsoluteTime(TimeSpan.FromSeconds(5.0)));
            shortCacheManager.Add("ExpiresInTwoSeconds", "Value4", CacheItemPriority.NotRemovable, this, new AbsoluteTime(TimeSpan.FromSeconds(2.0)));

            Thread.Sleep(3500);

            Assert.IsNull(shortCacheManager.GetData("ExpiresImmediately"), "This should have been expired during the first expiration run");
            Assert.IsNull(shortCacheManager.GetData("ExpiresInTwoSeconds"), "This should have been expired about 2 seconds after test started");
            Assert.IsNotNull(shortCacheManager.GetData("ExpiresInFiveSeconds"), "This should not be expired yet");

            Thread.Sleep(4000);

            Assert.IsNull(shortCacheManager.GetData("ExpiresInFiveSeconds"), "Its time had come and it should be gone");
            Assert.IsNotNull(shortCacheManager.GetData("NeverExpires"), "This item should never expire from the cache");
            Assert.AreEqual("ExpiresImmediatelyExpiresInTwoSecondsExpiresInFiveSeconds", expiredKeys);
            Assert.AreEqual("Value1Value4Value3", expiredValues);
            Assert.AreEqual("ExpiredExpiredExpired", removalReasons);
        }

		[TestMethod]
        public void MakeItScavenge()
        {
            smallCacheManager.Add("key1", "value1", CacheItemPriority.NotRemovable, this, new NeverExpired());
            smallCacheManager.Add("key2", "value2", CacheItemPriority.High, this, new NeverExpired());
            smallCacheManager.Add("key3", "value3", CacheItemPriority.Low, this, new NeverExpired());
            smallCacheManager.Add("key4", "value4", CacheItemPriority.Normal, this, new NeverExpired());

            Thread.Sleep(1000);

            Assert.AreEqual(2, smallCacheManager.Count);
            Assert.IsNotNull(smallCacheManager.GetData("key1"));
            Assert.IsNotNull(smallCacheManager.GetData("key2"));

            Assert.AreEqual("key3key4", expiredKeys);
            Assert.AreEqual("value3value4", expiredValues);
            Assert.AreEqual("ScavengedScavenged", removalReasons);
        }

        public void Refresh(string key, object expiredValue, CacheItemRemovedReason removalReason)
        {
            expiredKeys += key;
            expiredValues += expiredValue;
            removalReasons += removalReason.ToString();
        }
    }
}

