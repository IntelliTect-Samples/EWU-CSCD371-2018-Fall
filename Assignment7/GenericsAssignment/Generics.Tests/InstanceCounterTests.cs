using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using src;

namespace Generics.Tests
{
    [TestClass]
    public class InstanceCounterTests
    {
        [TestMethod]
        public void InstanceCounter_CreateSeveralInstances_InstanceCountIncrements()
        {
            Assert.AreEqual(0, InstanceCounter.InstanceCount);

            InstanceCounter ic = new InstanceCounter();

            Assert.AreEqual(1, InstanceCounter.InstanceCount);

            InstanceCounter ic2 = new InstanceCounter();

            Assert.AreEqual(2, InstanceCounter.InstanceCount);

            ic.Dispose();
            ic = null;

            ic2.Dispose();
            ic2 = null;
        }

        [TestMethod]
        public void InstanceCounter_CreateInstanceAndDisposeInstance_CounterIncrementsAndDecrements()
        {
            Assert.AreEqual(0, InstanceCounter.InstanceCount);

            InstanceCounter ic = new InstanceCounter();
            
            Assert.AreEqual(1, InstanceCounter.InstanceCount);

            ic.Dispose();
            ic = null;

            Assert.AreEqual(0, InstanceCounter.InstanceCount);
        }
    }
}
