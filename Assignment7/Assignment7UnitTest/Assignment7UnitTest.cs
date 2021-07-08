using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment7UnitTest
{
    [TestClass]
    public class Assignment7UnitTest
    {
        [TestMethod]
        public void NonNullableClassTestIsNotNullWithoutValueAssign()
        {
            NonNullable<object> myNonNullable = new NonNullable<object>();
            Assert.IsNotNull(myNonNullable.Value);
        }

        [TestMethod]
        public void NonNullableClassTestIsNotNull()
        {
            NonNullable<object> myNonNullable = new NonNullable<object>
            {
                Value = 42
            };
            Assert.IsNotNull(myNonNullable.Value);
        }

        [TestMethod]
        public void ResourceManagementCreate()
        {
           ResourceManagement resourceOne = new ResourceManagement();
           ResourceManagement resourceSecond = new ResourceManagement();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Assert.AreEqual(0, ResourceManagement.count);

        }

        [TestMethod]
        public void ResourceManagementClassDisposeTest()
        {
            ResourceManagement resource = null;
            try
            {
                resource = new ResourceManagement(@"C:\Description.txt");
            }
            finally
            {
                resource?.Dispose();
            }

            Assert.AreEqual(0, ResourceManagement.count);
        }

        [TestMethod]
        public void ResourceManagementTetsDestructor()
        {
            ResourceManagement resource = null;

            resource = new ResourceManagement(@"C:\Description.txt");

            resource = null;

            GC.Collect();

            System.Threading.Thread.Sleep(100);

            Assert.AreEqual(-2, ResourceManagement.count);
        }

    }
}
