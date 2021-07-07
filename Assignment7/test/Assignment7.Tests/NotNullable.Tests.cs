using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7.Tests
{
    [TestClass]
    public class NotNullableTests
    {
        [TestMethod]
        public void NotNullable_CreateNotNullableObjectAndSetItToNull_ObjectNotSetToNull()
        {
            NotNullable<TestClass> myClass = new NotNullable<TestClass>();

            myClass.Value = null;

            Assert.IsNotNull(myClass.Value);
        }

        [TestMethod]
        public void NotNullable_DefaultConstructorForNotNullable_ValueNotNull()
        {
            Assert.IsNotNull(new NotNullable<TestClass>());
        }

        [TestMethod]
        public void NotNullable_SetAndThenGetValue_ReturnsBob()
        {
            NotNullable<TestClass> notNull = new NotNullable<TestClass>();
            notNull.Value.Name = "Bob";
            Assert.AreEqual("Bob", notNull.Value.Name);
        }
    }

    public class TestClass
    {
        public string Name { get; set; }

        public TestClass()
        {
            Name = "TestClass";
        }
    }
}
