using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW7;
using System;

namespace NotNullableTests
{
    [TestClass]
    public class ResourceTests
    {

        [TestMethod]
        public void MangResource_CreateAndDisposeOfOneResourceWithUsing_Success()
        {
            MangResource MR;
            using (MR = new MangResource(@"C:\Users\Jeff\source\repos\HW7\HW7\SomeFile.txt"))
            Assert.AreEqual(1, MangResource.TotalNumOfResources);
                MR = null;

            GC.Collect();
            Assert.AreEqual(0, MangResource.TotalNumOfResources);
        }

        [TestMethod]
        public void MangResource_CreateAndDisposeOfTwoResourceWithUsing_Success()
        {
            MangResource MR1;
            MangResource MR2;
            using (MR1 = new MangResource(@"C:\Users\Jeff\source\repos\HW7\HW7\SomeFile.txt"))
            using (MR2 = new MangResource(@"C:\Users\Jeff\source\repos\HW7\HW7\OtherFile.txt"))

                Assert.AreEqual(2, MangResource.TotalNumOfResources);
            MR1 = null;
            MR2 = null;
          
            Assert.AreEqual(0, MangResource.TotalNumOfResources);
        }

        [TestMethod]
        public void MangResource_CreateAndDisposeOfTwpResourceUsingDispose_Success()
        {
            MangResource MR1 = null; 
            MangResource MR2 = null;
            try { 
                 MR1 = new MangResource(@"C:\Users\Jeff\source\repos\HW7\HW7\SomeFile.txt");
                 MR2 = new MangResource(@"C:\Users\Jeff\source\repos\HW7\HW7\OtherFile.txt");
                Assert.AreEqual(2, MangResource.TotalNumOfResources);
            }
            finally
            {
                MR1.Dispose();
                MR2.Dispose();                
            }   

            Assert.AreEqual(0, MangResource.TotalNumOfResources);
        }
    }
}
