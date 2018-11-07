using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class StructTests
    {
        [TestMethod]
        public void PassStructToMethod_ChangeStructValuesInMethod_NoChangeInStructInCallingMethod()
        {
            TestStruct myStruct = new TestStruct(1, "old value");
            
            ChangeValuesInStruct(myStruct);
            
            Assert.AreEqual(1, myStruct.NumericValue);
            Assert.AreEqual("old value", myStruct.StringValue);
        }
        
        public static void ChangeValuesInStruct(TestStruct toUse)
        {
            toUse.NumericValue = 5;
            toUse.StringValue = "new value";
        }
        
        [TestMethod]
        public void PassClassToMethod_ChangeClassValuesInMethod_NoChangeInClassInCallingMethod()
        {
            TestClass myClass = new TestClass(1, "old value");
            
            ChangeValuesInClass(myClass);
            
            Assert.AreEqual(5, myClass.NumericValue);
            Assert.AreEqual("new value", myClass.StringValue);
        }
        
        public static void ChangeValuesInClass(TestClass toUse)
        {
            toUse.NumericValue = 5;
            toUse.StringValue = "new value";
        }
        
        [TestMethod]
        public void PassStructReferenceToMethod_ChangeStructValuesInMethod_ClassInCallingMethodChanges()
        {
            TestStruct myStruct = new TestStruct(1, "old value");
            
            ChangeValuesInStructWithRef(ref myStruct);
            
            Assert.AreEqual(5, myStruct.NumericValue);
            Assert.AreEqual("new value", myStruct.StringValue);
        }
        
        public static void ChangeValuesInStructWithRef(ref TestStruct toUse)
        {
            toUse.NumericValue = 5;
            toUse.StringValue = "new value";
        }
        
        [TestMethod]
        public void PassClassReferenceToMethod_CreateNewClassInstance_ClassInCallingMethodChanges()
        {
            TestClass myClass = new TestClass(1, "old value");
            
            CreateNewClassReference(ref myClass);
            
            Assert.AreEqual(5, myClass.NumericValue);
            Assert.AreEqual("new value", myClass.StringValue);
        }
        
        public static void CreateNewClassReference(ref TestClass toUse)
        {
            toUse = new TestClass(5, "new value");
        }
        
        [TestMethod]
        public void PassStructToInterfaceThenMethod_StructInCallingMethodChanges()
        {
            TestStruct myStruct = new TestStruct(1, "old value");

            IExample castedStruct = (IExample) myStruct;
            
            ModifyValuesInClass(ref castedStruct);

            TestStruct newStruct = (TestStruct) castedStruct;
            
            Assert.AreEqual(5, newStruct.NumericValue);
        }
        
        public static void ModifyValuesInClass(ref IExample passedInterface)
        {
            passedInterface.ChangeValue(5);
        }
    }

    
    public class TestClass
    {
        public int NumericValue { get; set; }
        
        public string StringValue { get; set; }

        public TestClass(int numVal, string stringVal)
        {
            NumericValue = numVal;
            StringValue = stringVal;
        }
    }

    public struct TestStruct : IExample
    {
        public int NumericValue { get; set; }
        
        public string StringValue { get; set; }
        
        public TestStruct(int numVal, string stringVal)
        {
            NumericValue = numVal;
            StringValue = stringVal;
        }

        public void ChangeValue(int newValue)
        {
            NumericValue = newValue;
        }
    }

    public interface IExample
    {
        void ChangeValue(int newValue);
    }
}