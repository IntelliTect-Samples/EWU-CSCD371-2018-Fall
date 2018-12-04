using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW9;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PatentData.Tests
{
    [TestClass]
    public class PatentDataTests
    {
        [TestMethod]
        public void InventorNames_InventorsLastNamesFromUSA_Success()
        {
            List<string> QueryResultsOfInventorsFullNames = PatentDataAnalyzer.InventorNames("USA");
            int CountOfQueryResultsInventorNames = QueryResultsOfInventorsFullNames.Count;

            List<string> ExpectedSetOfInventorsFullNames = new List<string>
            {
                "Benjamin Franklin",
                "Orville Wright",
                "Wilbur Wright",
                "Samuel Morse",
                "John Michaelis",
                "Mary Phelps Jacob"
            };
            int CountOfExpectedInventorsNames = ExpectedSetOfInventorsFullNames.Count;

            Assert.AreEqual(CountOfExpectedInventorsNames, CountOfQueryResultsInventorNames);
            foreach (string inventor in QueryResultsOfInventorsFullNames)
            {
                Assert.IsTrue(ExpectedSetOfInventorsFullNames.Contains(inventor));
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PaterntDataAnalyer_InventorNames_InvalidCountry_ExceptionThrown()
        {
            string ContainsNull = null;
            List<string> QueryResultsOfInventorsFullNames = PatentDataAnalyzer.InventorNames(ContainsNull);

        }

        [TestMethod]
        public void PaterntDataAnalyer_InventorLastNames_Success()
        {
            List<string> expectedInventorsLastNames = new List<string>
            {
                "Franklin", "Wright", "Morse", "Stephenson", "Michaelis", "Jacob"
            };

            IEnumerable<string> QueryResultsOfInventorsLastNames = PatentDataAnalyzer.InventorLastNames();

            
            foreach (string lastName in QueryResultsOfInventorsLastNames)
            {
                Assert.IsTrue(expectedInventorsLastNames.Contains(lastName));
            }
        }

        [TestMethod]
        public void PaternDataAnalyer_LocationsWithInventors_Success()
        {
            string expectedLocationsWithInventors = "PA-USA,NC-USA,NY-USA,Northumberland-UK,IL-USA";
            string actualLocationsWithInventors = PatentDataAnalyzer.LocationsWithInventors();

            Assert.AreEqual(expectedLocationsWithInventors, actualLocationsWithInventors);
        }



        [TestMethod]
        public void Enumerable_RandomizeCollection_NormalSet_Success()
        {
            for (int i = 0; i < 3; i++)
            {
                IEnumerable<Patent> patents = HW9.PatentData.Patents;
                IEnumerable<Patent> randomPatents = HW9.PatentData.Patents;
                randomPatents = HW9.Enumerable.RandomizeCollection<Patent>(patents);
                Assert.IsFalse(randomPatents.SequenceEqual(patents));
            }

        }

        [TestMethod]
        public void PatentDataAnalyzer_NthFibonacciNumbers_SkipEveryOtherFibNum_Success()
        {
            IEnumerable<int> actualSkipEveryOtherFibNumbers = PatentDataAnalyzer.NthFibonacciNumbers(2);

            IEnumerable<int> ExpectedFibSeriesSkippingEveryOtherOne = new List<int>()
                {   0,
                    1,
                    3,
                    8,
                    21,
                    55,
                    144,
                    377,
                    987,
                    2584,
                    6765,
                    17711,
                    46368,
                    121393,
                    317811,
                    832040,
                    2178309,
                    5702887,
                    14930352
                };

            Assert.IsTrue(actualSkipEveryOtherFibNumbers.SequenceEqual(ExpectedFibSeriesSkippingEveryOtherOne));

        }

        [TestMethod]
        public void PatentDataAnalyzer_NthFibonacciNumbers_SkipEvery3rdFibNum_Success()
        {
            IEnumerable<int> actualSkipEveryOtherFibNumbers = PatentDataAnalyzer.NthFibonacciNumbers(3);

            IEnumerable<int> ExpectedFibSeriesSkippingEvery3rdnumber = new List<int>()
                {   0,
                    2,
                    8,
                    34,
                    144,
                    610,
                    2584,
                    10946,
                    46368,
                    196418,
                    832040,
                    3524578,
                    14930352,
                };

            Assert.IsTrue(actualSkipEveryOtherFibNumbers.SequenceEqual(ExpectedFibSeriesSkippingEvery3rdnumber));

        }
    }
}
