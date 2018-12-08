using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentSeven
{
    [TestClass]
    public class NotNullableTests
    {
        private NotNullable<ManagedThread> TestNotNullable;

        [TestMethod]
        public void Constructor_NoParameters_ValueIsNotNull()
        {
            TestNotNullable = new NotNullable<ManagedThread>();

            Assert.IsTrue(TestNotNullable.Value != null);
        }

        [TestMethod]
        public void SetValue_ValidParameter_ValueIsChanged()
        {
            TestNotNullable = new NotNullable<ManagedThread>();
            ManagedThread testManagedThread = new ManagedThread();

            TestNotNullable.Value = testManagedThread;

            Assert.IsTrue(TestNotNullable.Value == testManagedThread);
        }

        [TestMethod]
        public void SetValue_NullParameter_ValueIsUnchanged()
        {
            TestNotNullable = new NotNullable<ManagedThread>();
            ManagedThread testManagedThread = new ManagedThread();

            TestNotNullable.Value = testManagedThread;
            TestNotNullable.Value = null;

            Assert.IsTrue(TestNotNullable.Value == testManagedThread);
        }
    }
}