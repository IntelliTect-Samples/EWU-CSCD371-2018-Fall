    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Assignment6;
    using System.Runtime.InteropServices;
    [TestClass]
    public class StructAssignmentTests
    {
        private SeperateStructRectangle _TestingSeperateStructure
        {
            get;
            set;
        }
        [TestInitialize]
        public void SetupRectangle()
        {
            _TestingSeperateStructure = new SeperateStructRectangle{width = 2, height = 3};
        }

        [TestMethod]
        public void UnchangedStructValidTest()
        {
            SeperateStructRectangle newStruct = new SeperateStructRectangle{width = 42, height = 42};
            _TestingSeperateStructure.copyValueToRectangleStructure(newStruct);
            Assert.AreEqual(_TestingSeperateStructure.height, 3);
            Assert.AreEqual(_TestingSeperateStructure.width, 2);
        }

        [TestMethod]
        public void ChangedStructByReferenceValidTest()
        {
            SeperateStructRectangle newStruct = new SeperateStructRectangle{width = 42, height = 42};
            _TestingSeperateStructure.copyValueToRectangleStructureReference(ref newStruct);
            Assert.AreEqual(_TestingSeperateStructure.height, newStruct.height);
            Assert.AreEqual(_TestingSeperateStructure.width, newStruct.width);
        }
        
        [TestMethod]
        public void ChangeValueByInterfaceValidTest()
        {
            IArea newStruct = _TestingSeperateStructure;
            newStruct.reset();
            Assert.AreEqual(0, _TestingSeperateStructure.height);
            Assert.AreEqual(0, _TestingSeperateStructure.width);
        }
    }