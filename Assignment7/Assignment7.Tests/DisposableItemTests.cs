using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Assignment7.Tests
{
    [TestClass]
    public class DisposableItemTests
    {


        [TestMethod]
        public void CreateDisposableItem_ResourcesAvailableDecreases()
        {
            int resourcesBefore = DisposableItem.ResourcesAvailable;
            DisposableItem item = new DisposableItem();
            Assert.AreEqual(resourcesBefore-1, DisposableItem.ResourcesAvailable);
            item.Dispose();
        }


        /*This method was causing some issues with other tests. In particular
         * item and item2 were not having their resources freed manually and 
         * were relying upon the GarbageCollector to do so. In order to free these
         * resources immediately I included a Try/Catch block with some elements 
         * outside of the block so they could be manually freed in the catch.
         */
        [TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void CreateDisposableItem_NoResourcesAvailable_ExceptionThrown()
        {
            DisposableItem item = new DisposableItem();
            DisposableItem item2 = new DisposableItem();
            try
            {    
                DisposableItem item3 = new DisposableItem(); //fails
                Assert.Fail();
            }
        
            catch(InvalidOperationException ex)
            {
                item.Dispose();
                item2.Dispose();
            }
            
           
        }

        [TestMethod]
        public void ManuallyDisposeItem_ResourceFreed()
        {
            int resourcesBefore = DisposableItem.ResourcesAvailable;
            DisposableItem item = new DisposableItem();
            item.Dispose();
            Assert.AreEqual(resourcesBefore, DisposableItem.ResourcesAvailable);
        }


        /*
        This test relies upon the Finalize method which executes on its own thread. (Page 453)
        This makes its execution difficult to predict and failures of this test method
        difficult to diagnose. Sleeping this thread stopped me from getting any intermittent
        failures, but there is not a guarantee this will always pass
        */
        [TestMethod]
        public void ItemLeavesScope_ObjectFinalizeInvoked_ResourceFreed()
        {
            int resourcesBefore = DisposableItem.ResourcesAvailable;
            int generation = GarbageMaker.MakeGarbage();
            GC.Collect(generation);
            System.Threading.Thread.Sleep(100); //sleep this thread to allow time for finalization
            Assert.AreEqual(resourcesBefore, DisposableItem.ResourcesAvailable);
        }

    }

    class GarbageMaker
    {
        public static int MakeGarbage()
        {
            DisposableItem item = new DisposableItem();
            DisposableItem item2 = new DisposableItem();
            return GC.GetGeneration(item);
        }
    }
}
