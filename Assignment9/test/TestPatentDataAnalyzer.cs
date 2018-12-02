using EssentialCSharpChapter15Listing15_10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using src;
using System;
using System.Linq;

namespace TestPatentDataAnalyzer
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
           
            //Console.WriteLine(list.ToArray());
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [DataRow("USA")]
        [TestMethod]
        public void TestPass_VerifyInventorNamesFindsCorrect_2(string country)
        {
            List<string> expectedList = new List<string> { "Benjamin Franklin", "Orville Wright", "Wilbur Wright", "Samuel Morse", "John Michaelis", "Mary Phelps Jacob" };

            List<string> actualList = PatentDataAnalyzer.InventorNames(country);
            
            //Console.WriteLine(list.ToArray());
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

            //Console.WriteLine(list.ToArray());
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
            //Console.WriteLine(list.ToArray());
            CollectionAssert.AreEqual(expected, actual, new InventorComparer());
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
