using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7
{
    [TestClass]
    public class ResourceManagementTests
    {
        protected string FullPath { get; set; }

        [TestMethod]
        public void Test_Create_Two_Resources_Then_Dispose()
        {
            ResourceManagement managedResource1;
            ResourceManagement managedResource2;

            using (managedResource1 = new ResourceManagement(FullPath = Path.GetFullPath(@"myFile.txt")))
            using (managedResource2 = new ResourceManagement(FullPath = Path.GetFullPath(@"secondFile.txt")))
                Assert.AreEqual(2, ResourceManagement.resources);
            managedResource1 = null;
            managedResource2 = null;

            Assert.AreEqual(0, ResourceManagement.resources);
        }
        [TestMethod]
        public void Test_Manually_Dispose_Two_Resources()
        {
            ResourceManagement managedResource1 = null;
            ResourceManagement managedResource2 = null;
            try
            {
                managedResource1 = new ResourceManagement(FullPath = Path.GetFullPath("myFile.txt"));
                managedResource2 = new ResourceManagement(FullPath = Path.GetFullPath("secondFile.txt"));
                Assert.AreEqual(2, ResourceManagement.resources);
            }
            finally
            {
                managedResource1.Dispose();
                managedResource2.Dispose();
            }
            Assert.AreEqual(0, ResourceManagement.resources);
        }

        [TestMethod]
        public void Test_Create_Resource_Then_Dispose()
        {
            ResourceManagement managedResource;
            using (managedResource = new ResourceManagement(FullPath = Path.GetFullPath("myFile.txt")))
                Assert.AreEqual(1, ResourceManagement.resources);
            managedResource = null;
            GC.Collect(); //force garbage collection

            Assert.AreEqual(0, ResourceManagement.resources);
        }
        
    }

}