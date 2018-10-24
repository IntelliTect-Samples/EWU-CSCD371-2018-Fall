using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoginStuff.Tests
{
    [TestClass]
    public class ApplicationTests
    {
        [TestMethod]
        public void Login_UserNameWithValidPassword_ReturnTrue()
        {
            Assert.IsTrue(
                Application.Login("Inigo.Montoya", "password"));
        }

        [TestMethod]
        public void Login_UserNameWithInValidPassword_ReturnFalse()
        {
            Assert.IsFalse(
                Application.Login("Inigo.Montoya", "badpassword"));
        }

        [TestMethod]
        public void Login_UserNamePrincessButtercupWithInValidPassword_ReturnFalse()
        {
            Assert.IsFalse(
                Application.Login("Princess.Buttercup", "badpassword"));
        }

        [TestMethod]
        public void Login_UserNamePrincessButtercupWithInValidPassword_ReturnTrue()
        {
            Assert.IsTrue(
                Application.Login("Princess.Buttercup", "AnybodyWantAPeanut"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Ignore("Not yet implemented")]
        public void Login_UserNameIsNull_ThrowException()
        {
            Application.Login(null, "password");
        }

        [TestInitialize]
        public void SetupMethod()
        {
            Application.RegisteredIds.Clear();
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            
        }

        [TestMethod]
        public void Regsiter_Method_Adds_Multiple_People()
        {
            Person person = new Person("Mark", "M", "123");
            Person person2 = new Person("Kevin", "B", "reallySecure");

            int count1 = Application.Register(person);
            int count2 = Application.Register(person2);

            Assert.AreEqual(1, count1);
            Assert.AreEqual(2, count2);
        }

        [TestMethod]
        public void Register_With_Employee()
        {
            Person employee = new Employee("Stoke", "s", "456");
            
            int count = Application.Register(employee);

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Register_With_UniversityCourse()
        {
            var course = new UniversityCourse
            {
                Id = "42"
            };

            int count = Application.Register(course);

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Register_With_Object_Throws()
        {
            Application.Register(new object());
        }

        [TestMethod]
        [Ignore("Not implemented yet")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Register_With_Null_Throws()
        {
            Application.Register(null);
        }
    }
}
