using System;
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
                IEnumerable<string> randomizedNames = Enumerable.Randomize(PatentDataAnalyzer.InventorLastNames());
                Assert.IsFalse(randomizedNames.SequenceEqual(expectedNames));
                Assert.AreEqual(expectedNames.Count,randomizedNames.Count());
            }
        }
        
        
        /*EXTRA CREDIT*/
        
        
    }
}