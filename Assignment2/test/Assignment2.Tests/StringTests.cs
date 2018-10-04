using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment2.Tests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void TestStringEquals()
        { 
            Assert.AreEqual(true, "Raymond".Equals("Raymond"));
            Assert.AreEqual(true, "Frank".Equals("Frank"));
            Assert.AreEqual(false, "One".Equals("Two"));
            Assert.AreEqual(true, "Three".Equals("Three"));
        }

        [TestMethod]
        public void TestStringLength()
        {
            Assert.AreEqual(5, "Frank".Length);
            Assert.AreEqual(0, "".Length);
            Assert.AreEqual(9, "123456789".Length);
            Assert.AreEqual(3, "123".Length);
        }

        [TestMethod]
        public void TestStringTrim()
        {
            Assert.AreEqual("Trim", " Trim  ".Trim());
            Assert.AreEqual("Heyo", " Heyo".Trim());
            Assert.AreEqual("This", "This ".Trim());
        }

        [TestMethod]
        public void TestStringToUpperCase()
        {
            Assert.AreEqual("HEY", "hey".ToUpper());
            Assert.AreEqual("THIS IS COOL", "this is cool".ToUpper());
            Assert.AreEqual("THIS IS TEST 3", "this IS teSt 3".ToUpper());
            Assert.AreEqual("ONE TWO THREE", "one TWO THREE".ToUpper());
        }
    }
}
