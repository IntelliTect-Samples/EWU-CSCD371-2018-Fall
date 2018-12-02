using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7
{
    [TestClass]
    public class NonNullableTests
    {
        [TestMethod]
        public void String_Value_Null()
        {
            NonNullable<string> NullValueString = new NonNullable<string>();
            Assert.IsNotNull(NullValueString);
        }
        [TestMethod]
        public void Test_Object_Null()
        {
            Object newObject = new Object();
            NonNullable<string> NullValueString = new NonNullable<string>();
            NonNullable<object> newObject2 = new NonNullable<object>(newObject);
            Assert.IsNotNull(newObject2);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Default_Constructor_Returns_Null_NonNullable()
        {
            NonNullable<object> newObject = new NonNullable<object>();
            Assert.IsNotNull(newObject);
            Assert.IsNull(newObject.Value);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void String_Null()
        {
            string newString = null;
            string newString2;
            NonNullable<string> NullString = new NonNullable<string>(newString);
            Assert.IsNull(NullString);
            Assert.IsNotNull(NullString.Value);
        }

    }
}
