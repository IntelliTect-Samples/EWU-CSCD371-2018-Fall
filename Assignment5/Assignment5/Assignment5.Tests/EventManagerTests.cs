using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    [TestClass]
    public class EventManagerTests
    {
        [TestMethod]
        public void CanCreateUniversityCourse()
        {
            //Arrange
            var console = new TestableConsole();
            console.LinesToRead.Add("1");
            console.LinesToRead.Add("CSCD371");
            console.LinesToRead.Add("EWU");
            console.LinesToRead.Add("11/02/18");
            console.LinesToRead.Add("11/30/18");
            console.LinesToRead.Add("3");
            console.LinesToRead.Add("4");
            var eventManager = new EventManager(console);

            //Act
            eventManager.Run();

            //Assert
            console.DidDisplayMenu(0);
            Assert.AreEqual("What is the name of the course?", console.WrittenLines[5]);
            Assert.AreEqual("Where is the course being taught?", console.WrittenLines[6]);
            Assert.AreEqual("What day does CSCD371 start (mm/dd/yy)?", console.WrittenLines[7]);
            Assert.AreEqual("What day does CSCD371 end (mm/dd/yy)?", console.WrittenLines[8]);
            console.DidDisplayMenu(9);
            Assert.AreEqual("Events:", console.WrittenLines[14]);
            Assert.AreEqual("University course: CSCD371 at EWU from 11/2/2018 to 11/30/2018", console.WrittenLines[15]);
        }

        [TestMethod]
        public void CanCreateEvent()
        {
            //Arrange
            var console = new TestableConsole();
            console.LinesToRead.Add("2");
            console.LinesToRead.Add("Pony Circus");
            console.LinesToRead.Add("Pony Land");
            console.LinesToRead.Add("1/15/19");
            console.LinesToRead.Add("3");
            console.LinesToRead.Add("4");
            var eventManager = new EventManager(console);

            //Act
            eventManager.Run();

            //Assert
            console.DidDisplayMenu(0);
            Assert.AreEqual("What is the name of the event?", console.WrittenLines[5]);
            Assert.AreEqual("Where is the event being held?", console.WrittenLines[6]);
            Assert.AreEqual("When is Pony Circus (mm/dd/yy)?", console.WrittenLines[7]);
            console.DidDisplayMenu(8);
            Assert.AreEqual("Events:", console.WrittenLines[13]);
            Assert.AreEqual("Event: Pony Circus at Pony Land on 1/15/2019", console.WrittenLines[14]);
        }

        [TestMethod]
        public void InvalidMenuOptionIsRejected()
        {
            //Arrange
            var console = new TestableConsole();
            console.LinesToRead.Add("0");
            console.LinesToRead.Add("4");
            var eventManager = new EventManager(console);

            //Act
            eventManager.Run();

            //Assert
            console.DidDisplayMenu(0);
            Assert.AreEqual("'0' is not valid", console.WrittenLines[5]);
            console.DidDisplayMenu(6);
        }
    }
}