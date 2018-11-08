using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7.Tests
{
    [TestClass]
    public class NotNullableTests
    {

        [TestMethod]
        public void Test_NotNullable_Accepts_Valid_Value_Type_Success()
        {
            StringBuilder stringBuilder = new StringBuilder("My string builder!!");
            NotNullable<StringBuilder> notNullable = new NotNullable<StringBuilder>(stringBuilder);
            
            Assert.AreEqual(stringBuilder, notNullable.Value);
        }
        

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ensure_NotNullable_Cannot_Accept_Null()
        {
            NotNullable<StringBuilder> notNullable = new NotNullable<StringBuilder>(null);
            Assert.Fail();
        }
    }
}