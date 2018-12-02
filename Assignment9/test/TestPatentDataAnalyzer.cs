using EssentialCSharpChapter15Listing15_10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using src;
using System;

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
        public void TestPass_Verify(string country)
        {
            List<string> expectedList = new List<string> { "George Stephenson" };
            List<string> list = PatentDataAnalyzer.InventorNames(country);
            //Console.WriteLine(list.ToArray());
            CollectionAssert.Equals(expectedList, list);
        }

        [DataRow("USA")]
        [TestMethod]
        public void TestPass_VerifyInventorNamesFindsCorrect_2(string country)
        {
            List<string> expectedList = new List<string> { "Benjamin Franklin", "Orville Wright", "Wilbur Wright", "Samuel Morse", "John Michaelis", "Mary Phelps Jacob" };
            List<string> list = PatentDataAnalyzer.InventorNames(country);
            //Console.WriteLine(list.ToArray());
            CollectionAssert.Equals(expectedList, list);
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
            InventorComparator t = new InventorComparator();
            CollectionAssert.AreEqual(expected, actual, t);
        }
    }

    [TestClass]
    public class TestInventorComparator
    {
        private InventorComparator _TestComparator = new InventorComparator();

        [SetUp]
        public void SetUp()
        {
            _TestComparator = new InventorComparator();
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

        [DataRow("Tzu", "Josh")]
        [DataRow("", "Earth")]
        [DataRow("aVeryBigWordThisIsYodaSaid", "smallWord")]
        [TestMethod]
        public void TestFail_VerifyCorrectOutputForCompareString(string string1, string string2)
        {
            Assert.AreNotEqual(0, _TestComparator.CompareString(string1, string2));
        }
    }
}
