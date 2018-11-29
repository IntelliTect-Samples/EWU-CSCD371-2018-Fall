using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment9.Tests
{
    [TestClass]
    public class PatentDataAnalyzerTests
    {
        [DataTestMethod]
        [DataRow("USA")]
        [DataRow("UK")]
        [DataRow("SE")]    
        public void Get_Inventor_Name_By_Country_Success(string country)
        {
            var query = PatentDataAnalyzer.GetInventorNames(country);
            
            
        }
    }
}