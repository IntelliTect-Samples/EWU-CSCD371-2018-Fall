using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentSeven
{
    [TestClass]
    public class ManagedThreadTests
    {
        private ManagedThread TestManagedThread;

        [TestMethod]
        public void Constructor_ValidParameters_FieldsAreSet()
        {
            TestManagedThread = new ManagedThread(141421, new byte[] { 77, 90 });

            Assert.IsTrue(TestManagedThread.HandleID == 141421);
            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual<byte>(TestManagedThread.StackData, new byte[] { 77, 90 }));

            TestManagedThread.Dispose();
        }

        [TestMethod]
        public void Constructor_NoParameters_FieldsAreDefault()
        {
            TestManagedThread = new ManagedThread();

            Assert.IsTrue(TestManagedThread.HandleID == 0);
            Assert.IsTrue(TestManagedThread.StackData is null);

            TestManagedThread.Dispose();
        }

        [TestMethod]
        public void ManagedThreadNotCreated_TotalThreadInstancesIsUnchanged()
        {
            Assert.IsTrue(ManagedThread.TotalThreadInstances == 0);
        }

        [TestMethod]
        public void ManagedThreadCreated_DefaultConstructor_TotalThreadInstancesIs1()
        {
            TestManagedThread = new ManagedThread();

            Assert.IsTrue(ManagedThread.TotalThreadInstances == 1);

            TestManagedThread.Dispose();
        }

        [TestMethod]
        public void ManagedThreadCreated_NonDefaultConstructor_TotalThreadInstancesIs1()
        {
            TestManagedThread = new ManagedThread(141421, new byte[] { 77, 90 });

            Assert.IsTrue(ManagedThread.TotalThreadInstances == 1);

            TestManagedThread.Dispose();
        }

        [TestMethod]
        public void ManagedThreadCreatedAndDisposed_TotalThreadInstancesIs0()
        {
            TestManagedThread = new ManagedThread();
            TestManagedThread.Dispose();

            Assert.IsTrue(ManagedThread.TotalThreadInstances == 0);
        }

        [TestMethod]
        public void MultipleManagedThreadsCreatedAndDisposed_TotalThreadInstancesIs3()
        {
            TestManagedThread = new ManagedThread();
            ManagedThread testManagedThread2 = new ManagedThread();
            ManagedThread testManagedThread3 = new ManagedThread(1048576, new byte[] { 69, 76, 70 });
            ManagedThread testManagedThread4 = new ManagedThread();
            ManagedThread testManagedThread5 = new ManagedThread(141421, new byte[] { 77, 90 });

            testManagedThread3.Dispose();
            testManagedThread4.Dispose();

            Assert.IsTrue(ManagedThread.TotalThreadInstances == 3);

            TestManagedThread.Dispose();
            testManagedThread2.Dispose();
            testManagedThread5.Dispose();
        }

        [TestMethod]
        public void MultipleManagedThreadsCreated_OutOfScope_TotalThreadInstancesIsBetween1And5()
        {
            TestManagedThread = new ManagedThread();

            {
                ManagedThread testManagedThread2 = new ManagedThread();
                ManagedThread testManagedThread3 = new ManagedThread(1048576, new byte[] { 69, 76, 70 });
                ManagedThread testManagedThread4 = new ManagedThread();
                ManagedThread testManagedThread5 = new ManagedThread(141421, new byte[] { 77, 90 });
            }

            /*
             * The "between 1 and 5" comes from the expectation that the garbage collector could finalize
             * anywhere from one to four of the out-of-scope ManagedThread objects by this point in time.
             */
            Assert.IsTrue(ManagedThread.TotalThreadInstances >= 1 && ManagedThread.TotalThreadInstances < 6);

            TestManagedThread.Dispose();
            System.GC.Collect();
        }
    }
}