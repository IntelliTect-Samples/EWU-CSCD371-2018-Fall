using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace ResourceManager.Tests
{
    [TestClass]
    public class ResourceManagerTests
    {

        [TestMethod]
        public void Instantiating_Class_Incrememnts_Instance_Count()
        {
            int instanceCount = ResourceManager.Count;
            ResourceManager myThirdFileChecker = null;
            myThirdFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt");

            Assert.AreEqual(instanceCount + 1, ResourceManager.Count);
            myThirdFileChecker.Dispose();

        } // end Instantiating_Class_Incrememnts_Instance_Count()

        [TestMethod]
        public void Explicitly_Calling_Dispose_Decrememnts_Instance_Count()
        {
            {
                int instanceCount = ResourceManager.Count;
                ResourceManager myThirdFileChecker = null;

                try
                {
                    myThirdFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt");
                    Assert.AreEqual(instanceCount + 1, ResourceManager.Count);
                }
                finally
                {
                    myThirdFileChecker?.Dispose();
                    Assert.AreEqual(ResourceManager.Count, instanceCount);
                }
            }
        } // end Explicitly_Calling_Dispose_Decrememnts_Instance_Count()

        [TestMethod]
        public void Finalizer_Calls_Dispose_Decrements_Instance_Count()
        {
            int beginningInstanceCount = ResourceManager.Count;
            {

                ResourceManager myThirdFileChecker = null;
                myThirdFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt");
                Assert.AreEqual(beginningInstanceCount + 1, ResourceManager.Count);

            }

            GC.Collect();
            GC.Collect();

            // the number of instances has decreased -> Finalizer
            Assert.AreNotEqual(beginningInstanceCount, ResourceManager.Count);
            Assert.AreNotEqual(0, ResourceManager.Count);


        } // end Finalizer_Calls_Dispose_Decrememnts_Instance_Count()

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Using_Statement_Closes_Resources_Automatically()
        {
            {

                int beginningCount = ResourceManager.Count;

                try
                {
                    using (ResourceManager myFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt"))
                    {
                        Assert.AreEqual(ResourceManager.Count, beginningCount + 1);
                    }

                    using (ResourceManager mySecondFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile2.txt"))
                    {

                        int i = 0;
                        int bad = 5 / i;
                    }
                    // do stuff

                }
                finally
                {
                    Assert.AreEqual(ResourceManager.Count, beginningCount);
                }
            }
        } // end Using_Statement_Closes_Resources_Automatically()
    } // end class ResourceManagerTests
}
