using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment9.Tests
{
    [TestClass]
    public class PatentDataAnalyzerTests
    {
        [DataTestMethod]
        [DataRow("USA", 6)]
        [DataRow("UK", 1)]
        [DataRow("SE", 0)]    
        public void Get_Inventor_Name_By_Country_Success(string country, int expectedCount)
        {
            List<string> query = PatentDataAnalyzer.InventorNames(country);
            Assert.AreEqual(expectedCount, query.Count);
        }


        [TestMethod]
        public void Get_Inventor_Last_Names_Success()
        {
            IEnumerable<string> query = PatentDataAnalyzer.InventorLastNames();
            List<string> expectedNames = new List<string>
            {
                "Jacob",
                "Michaelis",
                "Stephenson",
                "Morse",
                "Wright",
                "Wright",
                "Franklin"
            };
            int count = 0;
            foreach (string lastName in query)
                Assert.AreEqual(expectedNames[count++], lastName);
            
            Assert.AreEqual(expectedNames.Count,count);
        }

        [TestMethod]
        public void Get_Unique_Locations_String_Success()
        {
            string resultLocations = PatentDataAnalyzer.LocationsWithInventors();
            var resultLocationList = resultLocations.Split(", ");
            Inventor[] inventorList = PatentData.Inventors;
            List<string> locationsList = new List<string>(
                inventorList.Select(inventor => $"{inventor.State}-{inventor.Country}"));
            int count = 0;
            foreach (string resultLocation in resultLocationList)
            {
                Assert.IsTrue(locationsList.Contains(resultLocation));
                count++;
            }
            Assert.AreEqual(5,count);
        }

        [TestMethod]
        public void Get_Randomized_Last_Names_Success()
        {
           List<string> expectedNames = new List<string>
            {
                "Jacob",
                "Michaelis",
                "Stephenson",
                "Morse",
                "Wright",
                "Wright",
                "Franklin"
            };

            for (int i = 0; i < 3; i++)
            {
                List<string> randomizedNames = Enumerable.Randomize(PatentDataAnalyzer.InventorLastNames()).ToList();
                Assert.IsFalse(randomizedNames.SequenceEqual(expectedNames));
                Assert.AreEqual(expectedNames.Count,randomizedNames.Count);
            }
        }
        
        
        /*EXTRA CREDIT*/

        [DataTestMethod]
        [DataRow(1, new long[]{2,3,4,5,6,7})]
        [DataRow(2, null)]
        [DataRow(3, new long[]{1})]
        [DataRow(4, null)]
        public void Get_Inventors_With_N_Patents(int n, long[] expectedInventorIds)
        {
            List<Inventor> inventorsWithNPatents = PatentDataAnalyzer.GetInventorsWithMulitplePatents(n);
            foreach (Inventor inventor in inventorsWithNPatents)
                Assert.IsTrue(expectedInventorIds.Contains(inventor.Id), $"failed id: {inventor.Id}");
            
           Assert.AreEqual(expectedInventorIds?.Length ?? 0, inventorsWithNPatents.Count);
        }

        [DataTestMethod]
        [DataRow(1, new long[]{1,1,2,3,5,8})]
        [DataRow(2,new long[]{1,3,8,21,55,144,377,987})]
        [DataRow(5,new long[]{5,55,610,6765,75025,832040,9227465})]
        public void Get_Every_N_Fibonacci_Success(int n, long[] expected)
        {
            var fibonacciNums = PatentDataAnalyzer.NthFibonacciNumbers(n).Take(expected.Length).ToList();
            Assert.IsTrue(expected.SequenceEqual(fibonacciNums));
        }
    }
}