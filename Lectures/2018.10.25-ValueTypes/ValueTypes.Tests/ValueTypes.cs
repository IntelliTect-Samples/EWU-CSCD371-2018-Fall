using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValueTypes.Tests
{
    enum MyEnum : byte
    {
        Off = 1,
        On
    }

    struct MyImmutableStruct
    {
        public int FirstNumber { get { return _FirstNumber; } private set { _FirstNumber = value; } }
        private int _FirstNumber;
        public int SecondNumber { get; }
        public MyImmutableStruct(int firstNumber, int secondNumber)
        {
            _FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }
    }
    
    interface ISimpleInterface
    {
        int FirstNumber { get; set; }
        int SecondNumber { get; set; }
    }
    public struct MyStruct : ISimpleInterface
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
    }
    class MyClass
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
    }

    //[Flags]
    enum FileAttributes
    {
        ReadOnly = 1 << 0,
        Hidden = 1 << 1,
        System = 1 << 2,
        Directory = 1 << 4,
    }

    public class MyClassWithStruct
    {
        public MyStruct MyStruct { get; set; }
    }

    [TestClass]
    public class ValueTypes
    {
        [TestMethod]
        public void TestMyClassWithStruct()
        {
            var myClass = new MyClassWithStruct();

            Assert.AreEqual(default(int), myClass.MyStruct.FirstNumber);
        }
        void QuickTest(Boolean boolValue)
        {
            Assert.IsTrue(boolValue);
        }
        void DoSomething(ISimpleInterface myPassedInStruct)
        {
            myPassedInStruct.FirstNumber = myPassedInStruct.SecondNumber;

            Assert.AreEqual(myPassedInStruct.SecondNumber, myPassedInStruct.FirstNumber);
        }

        void DoSomethingByRef(ref MyStruct myPassedInStruct)
        {
            myPassedInStruct.FirstNumber = myPassedInStruct.SecondNumber;

            Assert.AreEqual(myPassedInStruct.SecondNumber, myPassedInStruct.FirstNumber);
        }

        [TestMethod]
        public void ParseEnumNotDecoratedWithFlag()
        {
            FileAttributes myAttributes;
            Enum.TryParse("Directory, Hidden", out myAttributes);
            Assert.IsTrue(myAttributes.HasFlag(FileAttributes.Hidden));
            Assert.AreEqual(3, (int)(FileAttributes.ReadOnly | FileAttributes.Hidden));
        }

        [TestMethod]
        public void MutateInMethod()
        {
            var myStruct = new MyStruct { FirstNumber = 5, SecondNumber = 42 };
            var mySimpleInterface = myStruct as ISimpleInterface;
            DoSomething(mySimpleInterface);

            Assert.AreEqual(mySimpleInterface.SecondNumber, mySimpleInterface.FirstNumber);
        }

        [TestMethod]
        public void MutateInMethodByRef()
        {
            var myStruct = new MyStruct { FirstNumber = 5, SecondNumber = 42 };
            DoSomethingByRef(ref myStruct);

            Assert.AreEqual(myStruct.SecondNumber, myStruct.FirstNumber);
        }

        [TestMethod]
        public void CreateImmutableStructDefaultConstructor()
        {
            var myImmutableStruct = new MyImmutableStruct();
            Assert.AreEqual(0, myImmutableStruct.FirstNumber);
        }

        [TestMethod]
        public void CreateImmutableStructCustomConstructor()
        {
            var myImmutableStruct = new MyImmutableStruct(42, 5);
            Assert.AreEqual(42, myImmutableStruct.FirstNumber);

            var myImmutableStruct2 = myImmutableStruct;
            Assert.AreEqual(myImmutableStruct.FirstNumber, myImmutableStruct2.FirstNumber);
        }

        [TestMethod]
        public void AssertStructsAreEqual()
        {
            var myStruct1 = new MyStruct
            {
                FirstNumber = 1,
                SecondNumber = 42
            };

            var myStruct2 = myStruct1;

            Assert.AreEqual(myStruct1, myStruct2);
        }

        // [TestMethod]
        public void AssertStructsAreSame()
        {
            var myStruct1 = new MyStruct
            {
                FirstNumber = 1,
                SecondNumber = 42
            };

            var myStruct2 = myStruct1;

            Assert.AreSame(myStruct1, myStruct2);
        }

        [TestMethod]
        public void AssertStructsAreNotEqualAfterValueChange()
        {
            var myStruct1 = new MyStruct
            {
                FirstNumber = 1,
                SecondNumber = 42
            };

            var myStruct2 = myStruct1;

            myStruct2.SecondNumber = 5;

            Assert.AreNotEqual(myStruct1, myStruct2);
            Assert.AreEqual(42, myStruct1.SecondNumber);
            Assert.AreEqual(5, myStruct2.SecondNumber);
        }

        [TestMethod]
        public void AssertClassesAreEqual()
        {
            var myClass1 = new MyClass
            {
                FirstNumber = 1,
                SecondNumber = 42
            };

            var myClass2 = myClass1;

            Assert.AreEqual(myClass1, myClass2);
        }

        [TestMethod]
        public void AssertClassesAreSame()
        {
            var myClass1 = new MyClass
            {
                FirstNumber = 1,
                SecondNumber = 42
            };

            var myClass2 = myClass1;

            Assert.AreSame(myClass1, myClass2);
        }

        [TestMethod]
        public void AssertClassesAreEqualAfterChange()
        {
            var myClass1 = new MyClass
            {
                FirstNumber = 1,
                SecondNumber = 42
            };

            var myClass2 = myClass1;

            myClass1.SecondNumber = 5;

            Assert.AreEqual(myClass1, myClass2);
            Assert.AreEqual(5, myClass1.SecondNumber);
            Assert.AreEqual(5, myClass2.SecondNumber);
        }
    }
}
