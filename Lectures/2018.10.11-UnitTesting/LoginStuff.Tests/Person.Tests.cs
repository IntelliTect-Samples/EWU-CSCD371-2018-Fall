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

        [TestMethod]
        public void UserName_ChangeName_Success()
        {
            Person person = new Person("Inigo", "Montoya", "Password");
            person.FirstName = "Frank";
            Assert.AreEqual("Frank", person.FirstName);
            person.LastName = "Nelson";
            Assert.AreEqual("Nelson", person.LastName);
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
            Person person = new Person("Inigo.Montoya", "password");
            Assert.AreEqual("Inigo", person.FirstName);
            Assert.AreEqual("Montoya", person.LastName);
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
    }


}
