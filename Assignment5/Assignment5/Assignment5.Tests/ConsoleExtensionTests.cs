using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    [TestClass]
    public class ConsoleExtensionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetString_RequiresConsole()
        {
            ConsoleExtensions.GetString(null, "Message");
        }

        [TestMethod]
        public void GetString_DefaultsMessage()
        {
            var console = new TestableConsole();
            console.LinesToRead.Add("ignored");

            console.GetString(null);

            Assert.AreEqual("Enter a string", console.WrittenLines[0]);
        }

        [TestMethod]
        public void GetString_CanReadString()
        {
            var console = new TestableConsole();
            console.LinesToRead.Add("my string");

            string value = console.GetString("My message");

            Assert.AreEqual("My message", console.WrittenLines[0]);
            Assert.AreEqual("my string", value);
        }

        [TestMethod]
        public void GetString_RepromptsIfTheInputIsNotValid()
        {
            var console = new TestableConsole();
            console.LinesToRead.Add(" ");
            console.LinesToRead.Add("my better input");

            string value = console.GetString("My message");

            Assert.AreEqual("My message", console.WrittenLines[0]);
            Assert.AreEqual("My message", console.WrittenLines[1]);
            Assert.AreEqual("my better input", value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDateTime_RequiresConsole()
        {
            ConsoleExtensions.GetDateTime(null, "Message");
        }

        [TestMethod]
        public void GetDateTime_DefaultsMessage()
        {
            var console = new TestableConsole();
            console.LinesToRead.Add(DateTime.Today.ToString("d"));

            console.GetDateTime(null);

            Assert.AreEqual("Enter a DateTime", console.WrittenLines[0]);
        }

        [TestMethod]
        public void GetDateTime_CanReadDateTime()
        {
            var console = new TestableConsole();
            var today = DateTime.Today;
            //NB: Using the ToString on DateTime to handle different locals
            console.LinesToRead.Add(today.ToString("d"));

            DateTime value = console.GetDateTime("My message");

            Assert.AreEqual("My message", console.WrittenLines[0]);
            Assert.AreEqual(today, value);
        }

        [TestMethod]
        public void GetDateTime_RepromptsIfTheInputIsNotValid()
        {
            var console = new TestableConsole();
            var today = DateTime.Today;
            console.LinesToRead.Add("bad datetime");
            //NB: Using the ToString on DateTime to handle different locals
            console.LinesToRead.Add(today.ToString("d"));

            DateTime value = console.GetDateTime("My message");

            Assert.AreEqual("My message", console.WrittenLines[0]);
            Assert.AreEqual("My message", console.WrittenLines[0]);
            Assert.AreEqual(today, value);
        }
    }
}