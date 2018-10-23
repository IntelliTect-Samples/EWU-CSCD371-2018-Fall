using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoginStuff.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Create_Person_Success()
        {
            Person person = new Person("Inigo", "Montoya", "Password");
            Assert.AreEqual("Inigo", person.FirstName);
            Assert.AreEqual("Montoya", person.LastName);
            Assert.AreEqual("Inigo.Montoya", person.UserName);

        }

        private Person Person { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Person = new Person("Inigo", "Montoya", "Password");
        }

        [TestMethod]
        public void UserName_ChangeName_Success()
        {
            Person.FirstName = "Frank";
            Assert.AreEqual("Frank", Person.FirstName);
            Person.LastName = "Nelson";
            Assert.AreEqual("Nelson", Person.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UserName_AssignNull_Throws()
        {
            Person person = new Person(null, "password");
        }

        [TestMethod]
        public void UserName_AssignInigoDotMontoya_Success()
        {
            Assert.AreEqual("Inigo", Person.FirstName);
            Assert.AreEqual("Montoya", Person.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(".Montoya")]
        [DataRow("Inigo.")]
        [DataRow(".")]
        [DataRow("")]
        public void UserName_AssignEmptyLastName_Throw(string userName)
        {
            Person person = new Person("Inigo.Montoya", "password");
            person.UserName = userName;
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }


}
