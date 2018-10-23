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
    }


}
