using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7.Tests
{
    [TestClass]
    public class MyDisposableClassTests
    {
        [TestMethod]
        public void MyDisposableClass_ForgetToDisposeDisposableClass_InstantiationCountIs0()
        {
            MyDisposableClass.ResetInstantiationCount();

            MyDisposableClass.MakeSomeGarbageForGarbageCollector();
            
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Assert.AreEqual(0, MyDisposableClass.InstantiationCount);
        }

        [TestMethod]
        public void MyDisposableClass_ManuallyDisposeOfObjects_InstantiationCountIs0()
        {
            MyDisposableClass.ResetInstantiationCount();
            
            MyDisposableClass myClass = new MyDisposableClass();
            MyDisposableClass myClass2 = new MyDisposableClass();

            int instantiationCountBeforeDisposing = MyDisposableClass.InstantiationCount;
              
            myClass.Dispose();
            myClass2.Dispose();
            
            Assert.AreEqual(2, instantiationCountBeforeDisposing);
            Assert.AreEqual(0, MyDisposableClass.InstantiationCount);
        }

        [TestMethod]
        public void MyDisposableClass_ManuallyDisposeOfObjectsAndRunGarbageCollector_InstantiationCountDoesntDropBelow0()
        {
            MyDisposableClass.ResetInstantiationCount();

            MyDisposableClass myClass = new MyDisposableClass();
            MyDisposableClass myClass2 = new MyDisposableClass();

            int instantiationCountBeforeDisposing = MyDisposableClass.InstantiationCount;

            myClass.Dispose();
            myClass2.Dispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Assert.AreEqual(2, instantiationCountBeforeDisposing);
            Assert.AreEqual(0, MyDisposableClass.InstantiationCount);
        }
    }
}
