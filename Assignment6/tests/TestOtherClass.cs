    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Assignment6;
    using System.Runtime.InteropServices;
    [TestClass]
    public class TestOtherClass
    {
        private SeperateClassSquare _TestingSeperateClass
        {
            get;
            set;
        }
        [TestInitialize]
        public void SetupSquare()
        {
            _TestingSeperateClass = new SeperateClassSquare(2,3);
        }

        [TestMethod]
        public void UnchangedClassValidTest()
        {
            SeperateClassSquare newStruct = new SeperateClassSquare(42,42);
            _TestingSeperateClass.copyValueToSquareStructure(newStruct);
            Assert.AreEqual(_TestingSeperateClass.height, newStruct.height);
            Assert.AreEqual(_TestingSeperateClass.width, _TestingSeperateClass.width);
        }

        [TestMethod]
        public void ChangedClassByReferenceValidTest()
        {
            SeperateClassSquare newStruct = new SeperateClassSquare(42,42);
            _TestingSeperateClass.copyValueToSquareStructureReference(ref newStruct);
            Assert.AreEqual(_TestingSeperateClass.height, newStruct.height);
            Assert.AreEqual(_TestingSeperateClass.width, _TestingSeperateClass.width);
        }
    }