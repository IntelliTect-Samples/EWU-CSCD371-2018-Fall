using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManager.Tests
{
    [TestClass]
    public class GenericTypesTests
    {

        [TestMethod]
        public void Instantiate_ResourceManager_Gives_NonNull_Value()
        {
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>();
            Assert.IsNotNull(myNonNullable.Value);
        }

        [TestMethod]
        public void Instantiate_ResourceManager_Sets_HasValue_To_True()
        {
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>();
            Assert.IsTrue(myNonNullable.HasValue);
        }

        [TestMethod]
        public void Instantiation_Passing_In_Null_To_NonNullable_Gives_NonNull()
        {
            ResourceManager rm = null;
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>(rm);
            Assert.IsNotNull(myNonNullable.Value);
            Assert.IsTrue(myNonNullable.HasValue);
        }

        [TestMethod]
        public void Instantiation_Passing_In_T_To_NonNullable_Sets_Value_To_Ref()
        {
            ResourceManager rm = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt");
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>(rm);

            Assert.IsNotNull(myNonNullable.Value);
            Assert.IsTrue(myNonNullable.HasValue);
            Assert.AreEqual(rm, myNonNullable.Value);
        }

        [TestMethod]
        public void Getting_Value_From_NonNullable_Returns_T()
        {
            ResourceManager rm = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt");
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>(rm);

            Assert.IsNotNull(myNonNullable.Value);
            Assert.IsTrue(myNonNullable.HasValue);

            ResourceManager rm2 = myNonNullable.Value;

            Assert.AreEqual(rm, rm2);
            Assert.AreEqual(rm2.FileChecker, rm.FileChecker);
        }

        [TestMethod]
        public void GetValueOrDefault_From_NonNullable_Returns_T()
        {
            ResourceManager rm = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt");
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>(rm);

            ResourceManager rm2 = myNonNullable.GetValueOrDefault();

            Assert.AreEqual(rm, rm2);
            Assert.AreEqual(rm.FileChecker, rm2.FileChecker);
        }
                [TestMethod]
        public void GetValueOrDefault_Input_A_Default_Returns_Value_If_HasValue_True()
        {
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>();

            ResourceManager defaultValue = new ResourceManager(@"C:\ProgramData\Temp\testFile2.txt");
            ResourceManager rm2 = myNonNullable.GetValueOrDefault(defaultValue);

            Assert.AreNotEqual(defaultValue, rm2);
        }
    }
}
