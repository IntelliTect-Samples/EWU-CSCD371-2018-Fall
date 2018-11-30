using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment9.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InventorNames_UsingCountryUSA_ReturnsProperlyOrderedList()
        {
            List<string> correctList = new List<string>()
            {
                "Benjamin Franklin",
                "Orville Wright",
                "Wilbur Wright",
                "Samuel Morse",
                "John Michaelis",
                "Mary Phelps Jacob"
            };

            List<string> calculatedList = PatentDataAnalyzer.InventorNames("USA");
            
            Assert.IsTrue(correctList.SequenceEqual(calculatedList));
        }
        
        [TestMethod]
        public void InventorNames_UsingCountryUK_ReturnsProperlyOrderedList()
        {
            List<string> correctList = new List<string>()
            {
                "George Stephenson"
            };

            List<string> calculatedList = PatentDataAnalyzer.InventorNames("UK");
            
            Assert.IsTrue(correctList.SequenceEqual(calculatedList));
        }

        [TestMethod]
        public void InventorLastNames_ReturnsProperlyOrderedList()
        {
            List<string> correctList = new List<string>()
            {
                "Jacob",
                "Michaelis",
                "Stephenson",
                "Morse",
                "Wright",
                "Wright",
                "Franklin"
            };

            List<string> calculatedList = PatentDataAnalyzer.InventorLastNames();
            
            Assert.IsTrue(correctList.SequenceEqual(calculatedList));
        }
        
        [TestMethod]
        public void LocationsWithInventors_ReturnsProperlyOrderedList()
        {
            string expected = "PA-USA,NC-USA,NY-USA,Northumberland-UK,IL-USA";
            
            Assert.AreEqual(expected, PatentDataAnalyzer.LocationsWithInventors());
        }
        
        [TestMethod]
        public void Randomize_DoesNotReturnSameOrderFor3Iterations()
        {
            IEnumerable<Inventor> originalList = PatentData.Inventors;

            for (int i = 0; i < 3; i++)
            {
                IEnumerable<Inventor> randomList = originalList.Randomize();
                Assert.IsFalse(originalList.SequenceEqual(randomList));
            }
        }

        [TestMethod] // 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946,
        public void NthFibonacciNumbers_GetEveryFibonacciNumber_ValidateUpTo5thElement()
        {
            IEnumerable<int> fibSequence = PatentDataAnalyzer.NthFibonacciNumbers(1);

            Assert.AreEqual(1, fibSequence.ElementAt(0));
            Assert.AreEqual(1, fibSequence.ElementAt(1));
            Assert.AreEqual(2, fibSequence.ElementAt(2));
            Assert.AreEqual(3, fibSequence.ElementAt(3));
            Assert.AreEqual(5, fibSequence.ElementAt(4));
        }
        
        [TestMethod] // 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946,
        public void NthFibonacciNumbers_GetEvery4thFibonacciNumber_ValidateUpTo5thElement()
        {
            IEnumerable<int> fibSequence = PatentDataAnalyzer.NthFibonacciNumbers(4);

            Assert.AreEqual(3, fibSequence.ElementAt(0));
            Assert.AreEqual(21, fibSequence.ElementAt(1));
            Assert.AreEqual(144, fibSequence.ElementAt(2));
            Assert.AreEqual(987, fibSequence.ElementAt(3));
            Assert.AreEqual(6765, fibSequence.ElementAt(4));
        }
        
        [TestMethod] // 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946,
        public void NthFibonacciNumbers_GetEvery2ndFibonacciNumber_ValidateUpTo5thElement()
        {
            IEnumerable<int> fibSequence = PatentDataAnalyzer.NthFibonacciNumbers(2);

            Assert.AreEqual(1, fibSequence.ElementAt(0));
            Assert.AreEqual(3, fibSequence.ElementAt(1));
            Assert.AreEqual(8, fibSequence.ElementAt(2));
            Assert.AreEqual(21, fibSequence.ElementAt(3));
            Assert.AreEqual(55, fibSequence.ElementAt(4));
        }
    }
}