using EssentialCSharpChapter15Listing15_10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Assingment9;
using System;
using System.Linq;

namespace TestAssignment9
{

    [TestClass]
    public class TestPatentDataAnalyzer
    {

        [DataRow(1, 3)]
        [DataRow(2, 1)]
        [DataRow(3, 1)]
        [DataRow(4, 1)]
        [DataRow(5, 1)]
        [DataRow(6, 1)]
        [DataRow(7, 1)]
        [TestMethod]
        public void TestPass_VerifyCorrectNumOfIdOccurInPatient(long id, int expectedOccur)
        {
            int actualOccur = PatentDataAnalyzer.NumOfOccurance(id);
            Assert.AreEqual(expectedOccur, actualOccur);
        }

        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(7, 2)]
        [DataRow(8, 1)]
        [TestMethod]
        public void TestFail_VerifyIncorrectectResultsForOccurInPatient(long id, int expectedOccur)
        {
            int actualOccur = PatentDataAnalyzer.NumOfOccurance(id);
            Assert.AreNotEqual(expectedOccur, actualOccur);
        }

        //InventorNames
        [DataRow("UK")]
        [TestMethod]
        public void TestPass_VerifyInventorNamesFindsCorrect_1(string country)
        {
            List<string> expectedList = new List<string> { "George Stephenson" };

            List<string> actualList = PatentDataAnalyzer.InventorNames(country);
           
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [DataRow("USA")]
        [TestMethod]
        public void TestPass_VerifyInventorNamesFindsCorrect_2(string country)
        {
            List<string> expectedList = new List<string> { "Benjamin Franklin", "Orville Wright", "Wilbur Wright", "Samuel Morse", "John Michaelis", "Mary Phelps Jacob" };

            List<string> actualList = PatentDataAnalyzer.InventorNames(country);
            
            CollectionAssert.Equals(expectedList, actualList);
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestFail_VerifyExceptionThrownFor_GetInventorsWithMultiplePariants()
        {
            PatentDataAnalyzer.InventorNames(null);
        }

        [DataRow("Atlantis")]
        [DataRow("Kanto")]
        [DataRow("Bikini Bottom")]
        [DataRow("Peru")]
        [TestMethod]
        public void TestPass_VerifyInventorNamesFindsCorrect_CountryNotInFile(string country)
        {
            List<string> list = PatentDataAnalyzer.InventorNames(country);

            int sizeOfInvalidCountryName = list.Count;

            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void TestPass_VerifyGetInventorsWithMultiplePariants()
        {
            List<Inventor> expected = PatentDataAnalyzer.GetInventorsWithMulitplePatents(3);

            List<Inventor> actual = new List<Inventor> {
                                                        new Inventor()
                                                        {
                                                            Name = "Benjamin Franklin",
                                                            City = "Philadelphia",
                                                            State = "PA",
                                                            Country = "USA",
                                                            Id = 1
                                                        }};

            CollectionAssert.AreEqual(expected, actual, new InventorComparer());
        }

        [TestMethod]
        public void TestPass_ReverseOrderIdOfLastName()
        {
            string[] byIDRev = new List<string>(from inventors
                                                   in PatentData.Inventors
                                                orderby inventors.Id
                                                select inventors.Name).ToArray();

            string[] byRevIDLastName = PatentDataAnalyzer.InventorLastNames().ToArray();

            for (int index = 0; index < byIDRev.Length; index++)
            {
                Assert.AreEqual(byIDRev[index].Split(" ").Last(), byRevIDLastName[byIDRev.Length - 1 - index]);
            }
        }

        [TestMethod]
        public void TestPass_VerifyDistinctLocationOfInventor()
        {
            List<string> actual = PatentDataAnalyzer.LocationsWithInventors().Split(",").ToList();
            List<Inventor> InventorsList = PatentData.Inventors.ToList();
            int count;
            string address;

            foreach (Inventor currentInventor in InventorsList)
            {
                address = (currentInventor.State + "-" + currentInventor.Country);
                count = (from location
                         in actual
                         where location.Equals(address)
                         select location
                         ).Count();

                Assert.AreEqual(1, count);
            }
        }

        [TestMethod]
        [DataRow(1, new int[] { 1, 1, 2, 3, 5, 8, 13})]
        [DataRow(2, new int[] { 1, 3, 8, 21 })]
        [DataRow(3, new int[] { 2, 8, 34, 144 })]
        [DataRow(4, new int[] { 3, 21, 144, 987 })]
        public void TestPass_VerifyCorrectFibonacciList(int nth, int[] expected)
        {
            List<int> subsetOfFib = new List<int> { 1, 2, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987 };

            List<int> actual = PatentDataAnalyzer.NthFibonacciNumbers(nth).Take(expected.Length).ToList();

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-32)]
        [DataRow(-42)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFail_VerifyExceptionThrownForNthFib(int nth)
        {
            List<int> actualWontReach = PatentDataAnalyzer.NthFibonacciNumbers(nth).Take(1).ToList();//test if atleast one element was calculated
            //can't test on empty take, as when it returns the exception I think it returns a emtpy IEnumerable, so it would
            //not run into the error of Take(0) if empty but would if Take(0+n) as long as n > 0.
        }

    }

    /// <summary>
    /// I had to ponder if I should run two seperate tests for Randomize, and I decided to due to the directions
    /// detailing that the Randomize method should not be different on each of the three runs and random.
    /// If two are diffrent yet called from the same randomize method, I don't think it would be required retest
    /// as tests should also "test for one objective". Doing so may have broken the rule of tests being independent,
    /// but I could say that for some of the other tests in my program, it's difficult for me to understand where
    /// the line sometimes is.
    /// </summary>
    [TestClass]
    public class TestEnumerablesClass
    {
        [TestMethod]
        public void TestPass_VerifyDifferentRandomOnThreeProductions()
        {
            //List<Inventor> originalInventorList = PatentData.Inventors.ToList();
            List<Inventor> randomInventorList1 = Assingment9.Enumerable.Randomize(PatentData.Inventors).ToList(),
                           randomInventorList2 = Assingment9.Enumerable.Randomize(PatentData.Inventors).ToList(),
                           randomInventorList3 = Assingment9.Enumerable.Randomize(PatentData.Inventors).ToList();

            //CollectionAssert.AreNotEqual(randomInventorList1, originalInventorList, new InventorComparer());
            CollectionAssert.AreNotEqual(randomInventorList1, randomInventorList2, new InventorComparer());

            //CollectionAssert.AreNotEqual(randomInventorList1, originalInventorList, new InventorComparer());
            CollectionAssert.AreNotEqual(randomInventorList1, randomInventorList2, new InventorComparer());

            //CollectionAssert.AreNotEqual(randomInventorList2, originalInventorList, new InventorComparer());
            CollectionAssert.AreNotEqual(randomInventorList2, randomInventorList3, new InventorComparer());
        }

        // hard time switching if should be two seperate
        //or have two types of tests in one method that are needed to succeed to pass overall test objective.

        [TestMethod]
        public void TestPass_VerifyRandomSort()
        {
            List<Inventor> originalInventorList = PatentData.Inventors.ToList();
            List<Inventor> randomInventorList = Assingment9.Enumerable.Randomize(PatentData.Inventors).ToList();
            CollectionAssert.AreNotEqual(originalInventorList, randomInventorList, new InventorComparer());
        }
    }

    /// <summary>
    ///Tested helper methods that control the flow, if the helper methods are working properly,
    ///the comparer should function properly as well.
    ///TestPass_VerifyGetInventorsWithMultiplePariants() tests two lists for the equality given the comparer
    ///I didn't think it was necessary writing the test again but did so. 
    ///Seeing that the helper methods work properly and the comparer works properly as well,
    ///I don't think it is needed to test each possible case of the comparer.    
    /// </summary>
    [TestClass]
    public class TestInventorComparator
    {
        private InventorComparer _TestComparator;

        [TestInitialize]
        public void SetUp()
        {
            _TestComparator = new InventorComparer();
        }

        [TestMethod]
        public void TestPass_VerifyEqualityForComparer()
        {
            Inventor twinOne = new Inventor()
                                            {
                                                Name = "Benjamin Franklin",
                                                City = "Philadelphia",
                                                State = "PA",
                                                Country = "USA",
                                                Id = 1
                                            };

            Inventor twinTwo = new Inventor()
                                            {
                                                Name = "Benjamin Franklin",
                                                City = "Philadelphia",
                                                State = "PA",
                                                Country = "USA",
                                                Id = 1
                                            };
            Assert.AreEqual(0, _TestComparator.Compare(twinOne, twinTwo));
        }

        [DataRow(123456789, 123456789)]
        [DataRow(42, 42)]
        [DataRow(0, 0)]
        [TestMethod]
        public void TestPass_VerifyCorrectOutputForCompareLong(long id1, long id2)
        {
            Assert.AreEqual(0, _TestComparator.CompareLong(id1,id2));
        }

        [DataRow(-123456789, 123456789)]
        [DataRow(43, 42)]
        [DataRow(10000000000, 0)]
        [TestMethod]
        public void TestFail_VerifyCorrectOutputForCompareLong(long id1, long id2)
        {
            Assert.AreNotEqual(0, _TestComparator.CompareLong(id1, id2));
        }

        [DataRow("Tzu", "Tzu")]
        [DataRow("", "")]
        [DataRow("aVeryBigWordThisIsYodaSaid", "aVeryBigWordThisIsYodaSaid")]
        [TestMethod]
        public void TestPass_VerifyCorrectOutputForCompareString(string string1, string string2)
        {
            Assert.AreEqual(0, _TestComparator.CompareString(string1, string2));
        }

        [DataRow("Drake", "Josh")]
        [DataRow("", "Earth")]
        [DataRow("aVeryBigWordThisIsYodaSaid", "smallWord")]
        [TestMethod]
        public void TestFail_VerifyCorrectOutputForCompareString(string string1, string string2)
        {
            Assert.AreNotEqual(0, _TestComparator.CompareString(string1, string2));
        }

    }
}
