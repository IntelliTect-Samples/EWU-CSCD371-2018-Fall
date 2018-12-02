using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotNullable.Tests
{
	[TestClass]
	public class NotNullableTests
	{
		/** Cannot use these tests because `string` does not have a default constructor
		[TestMethod]
		public void NotNullable_Create_NullableType()
		{
			NotNullable<string> nnString = new NotNullable<string>("hello world");
			Assert.IsNotNull(nnString);
			Assert.AreEqual(nnString.Value, "hello world");
		}
		
		[TestMethod]
		public void NotNullable_CreateNull_NullableType()
		{
			string refString = null;
			NotNullable<string> nnString = new NotNullable<string>(null);
			Assert.IsNotNull(nnString);
		}
		*/

		[TestMethod]
		public void NotNullable_Create_NonNullableType()
		{
			NotNullable<int> nnInt = new NotNullable<int>(5);
			Assert.IsNotNull(nnInt);
			Assert.AreEqual(nnInt.Value, 5);
		}

		// Nullable primitives still fail, so throw an error.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void NotNullable_Create_NullableType_Fail()
		{
			NotNullable<int?> nnInt = new NotNullable<int?>(null);
		}

		// This is where my implementation for `NotNullable shines`: classes with default constructors
		[TestMethod]
		public void NotNullable_Create_ClassWithDefaultConstructor()
		{
			NotNullable<TestClass> nnTestClass = new NotNullable<TestClass>(null);
			Assert.IsNotNull(nnTestClass.Value);
		}

		// Wrapped `string` in `StringWrapper`
		[TestMethod]
		public void NotNullable_Create_WrappedClassWithoutDefaultConstructor()
		{
			NotNullable<StringWrapper> nnStringWrapper = new NotNullable<StringWrapper>(null);
			Assert.IsNotNull(nnStringWrapper.Value);
		}
	}
}
