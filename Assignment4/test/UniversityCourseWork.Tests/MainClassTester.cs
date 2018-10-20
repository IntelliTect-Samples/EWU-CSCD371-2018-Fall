using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCourseWork.Tests
{
    [TestClass]
    public class MainClassTester
    {
        [TestMethod]
        public void Readonly_Property_Creation_Success()
        {
            MainClass UC = new MainClass("Unchanged");
            Assert.AreEqual("Unchanged", UC.StringToChange);
        }

        [TestMethod]
        public void Validation_Property_Valid_Property_Success()
        {
            MainClass UC = new MainClass();
            Assert.AreEqual(24, UC.Degree = 24);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Validation_Property_Invalid_Property_Exception()
        {
            MainClass UC = new MainClass();
            Assert.AreEqual(24, UC.Degree = 43);
        }

        [TestMethod]
        public void Calculated_Property_Creation_Success()
        {
            MainClass UC = new MainClass(42);
            Assert.AreEqual(1764, UC.CalculatedProperty);
        }

        [TestMethod]
        public void Automatically_Implemented_Property_Creation_Success()
        {
            MainClass UC = new MainClass();
            UC.AutoImplementedProperty = "Hello World";
            Assert.AreEqual("Hello World", UC.AutoImplementedProperty);
        }
    }
}
