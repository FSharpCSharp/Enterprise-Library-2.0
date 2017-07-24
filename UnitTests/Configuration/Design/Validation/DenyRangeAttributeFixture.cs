//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Core
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

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design.Tests;

namespace Microsoft.Practices.EnterpriseLibrary.Configuration.Design.Validation.Tests
{
	[TestClass]
	public class DenyRangeAttributeFixture : ConfigurationDesignHost
	{
		private MyTestClass rangeClass;
		private PropertyInfo int32Info;
		private PropertyInfo doubleInfo;
		private PropertyInfo floatInfo;
		private PropertyInfo charInfo;
		private PropertyInfo stringInfo;
		private PropertyInfo shortInfo;
		private PropertyInfo byteInfo;
		private PropertyInfo decimalInfo;

		protected override void InitializeCore()
		{
			rangeClass = new MyTestClass();
			int32Info = rangeClass.GetType().GetProperty("Int32Value");
			doubleInfo = rangeClass.GetType().GetProperty("DoubleValue");
			floatInfo = rangeClass.GetType().GetProperty("FloatValue");
			charInfo = rangeClass.GetType().GetProperty("CharValue");
			stringInfo = rangeClass.GetType().GetProperty("StringValue");
			shortInfo = rangeClass.GetType().GetProperty("ShortValue");
			byteInfo = rangeClass.GetType().GetProperty("ByteValue");
			decimalInfo = rangeClass.GetType().GetProperty("DecimalValue");
		}

		[TestMethod]
		public void Int32OutOfRange()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute(3, RangeBoundaryType.Inclusive, 43, RangeBoundaryType.Exclusive);
			rangeClass.Int32Value = 2;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, int32Info, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void Int32InRangeCausesError()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute(3, RangeBoundaryType.Inclusive, 43, RangeBoundaryType.Exclusive);
			rangeClass.Int32Value = 25;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, int32Info, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void DoubleOutOfRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute(3D, RangeBoundaryType.Inclusive, 43D, RangeBoundaryType.Exclusive);
			rangeClass.DoubleValue = 2;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, doubleInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void DoubleInRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute(3D, RangeBoundaryType.Inclusive, 43D, RangeBoundaryType.Exclusive);
			rangeClass.DoubleValue = 25;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, doubleInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void FloatOutOfRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute(3f, RangeBoundaryType.Inclusive, 43f, RangeBoundaryType.Exclusive);
			rangeClass.FloatValue = 2;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, floatInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void FloatInRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute(3f, RangeBoundaryType.Inclusive, 43f, RangeBoundaryType.Exclusive);
			rangeClass.FloatValue = 25;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, floatInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void ShortOutOfRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute((Int16)3, RangeBoundaryType.Inclusive, (Int16)43, RangeBoundaryType.Exclusive);
			rangeClass.ShortValue = 2;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, shortInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void ShortInRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute((Int16)3, RangeBoundaryType.Inclusive, (Int16)43, RangeBoundaryType.Exclusive);
			rangeClass.ShortValue = 25;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, shortInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}


		[TestMethod]
		public void ByteOutOfRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute((byte)3, RangeBoundaryType.Inclusive, (byte)43, RangeBoundaryType.Exclusive);
			rangeClass.ByteValue = 2;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, byteInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void ByteInRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute((byte)3, RangeBoundaryType.Inclusive, (byte)43, RangeBoundaryType.Exclusive);
			rangeClass.ByteValue = 25;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, byteInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void DecimalOutOfRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute((decimal)3, RangeBoundaryType.Inclusive, (decimal)43, RangeBoundaryType.Exclusive);
			rangeClass.DecimalValue = 2;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, decimalInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void DecimalInRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute((decimal)3, RangeBoundaryType.Inclusive, (decimal)43, RangeBoundaryType.Exclusive);
			rangeClass.DecimalValue = 25;
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, decimalInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void CharOutOfRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute('a', RangeBoundaryType.Inclusive, 'd', RangeBoundaryType.Exclusive);
			rangeClass.CharValue = 'd';
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, charInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void CharInRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute('a', RangeBoundaryType.Inclusive, 'd', RangeBoundaryType.Exclusive);
			rangeClass.CharValue = 'c';
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, charInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void StringOutOfRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute("Anna", RangeBoundaryType.Inclusive, "Scott", RangeBoundaryType.Exclusive);
			rangeClass.StringValue = "Zeek";
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, stringInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		public void StringInRangeTest()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute("Anna", RangeBoundaryType.Inclusive, "Grace", RangeBoundaryType.Exclusive);
			rangeClass.StringValue = "Dee";
			List<ValidationError> errors = new List<ValidationError>();
			assertRange.Validate(rangeClass, stringInfo, errors, ServiceProvider);

			Assert.AreEqual(1, errors.Count);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void LowerBoundHigherThanUpperBoundThrows()
		{
			DenyRangeAttribute assertRange = new DenyRangeAttribute(5, RangeBoundaryType.Inclusive, 3, RangeBoundaryType.Exclusive);
		}

		private class MyTestClass
		{
			private int int32Value;
			private double doubleValue;
			private float floatValue;
			private char charValue;
			private string stringValue;
			private short shortValue;
			private byte byteValue;
			private decimal decimalValue;

			public int Int32Value
			{
				get { return int32Value; }
				set { int32Value = value; }
			}

			public double DoubleValue
			{
				get { return doubleValue; }
				set { doubleValue = value; }
			}

			public byte ByteValue
			{
				get { return byteValue; }
				set { byteValue = value; }
			}

			public decimal DecimalValue
			{
				get { return decimalValue; }
				set { decimalValue = value; }
			}

			public short ShortValue
			{
				get { return shortValue; }
				set { shortValue = value; }
			}

			public float FloatValue
			{
				get { return floatValue; }
				set { floatValue = value; }
			}

			public char CharValue
			{
				get { return charValue; }
				set { charValue = value; }
			}

			public string StringValue
			{
				get { return stringValue; }
				set { stringValue = value; }
			}
		}
	}
}