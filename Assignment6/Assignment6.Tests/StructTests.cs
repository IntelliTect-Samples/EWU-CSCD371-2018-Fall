using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class StructTests
    {
        [TestMethod]
        public static void TestMethod1()
        {
            
        }
    }

    public class TestClass
    {
        public int NumericValue { get; set; }
        
        public string StringValue { get; set; }

        public TestClass(int numVal, string stringVal)
        {
            NumericValue = numVal;
            StringValue = stringVal;
        }
    }

    struct TestStruct
    {
        public int NumericValue { get; set; }
        
        public string StringValue { get; set; }
        
        public TestStruct(int numVal, string stringVal)
        {
            NumericValue = numVal;
            StringValue = stringVal;
        }
    }
}