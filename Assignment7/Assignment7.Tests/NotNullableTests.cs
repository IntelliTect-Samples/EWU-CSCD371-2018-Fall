using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment7.Tests
{
    [TestClass]
    public class NotNullableTests
    {
        private NotNullable<string> _NotNullString;
        private string _Input;

        [TestInitialize]
        public void SetupNotNullable()
        {
            _Input = "I am not Null, I'm a real string!";
            _NotNullString = new NotNullable<string>(_Input);
        }

        [TestMethod]
        public void PassInstatiatedValue_NotNullableInitialized()
        {
            Assert.IsNotNull(_NotNullString.Value);
        }

        [TestMethod]
        public void PassInstatiatedValue_EqualToNotNullableValue()
        {
            Assert.AreEqual(_Input, _NotNullString.Value);
        }


        //Ideally we could specify T as not null and the compiler 
        //would mark the following code as error
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassNullValue_ExceptionThrown()
        {
            NotNullable<string> sut = new NotNullable<string>(null);
            Assert.Fail();
        }

    }
}
