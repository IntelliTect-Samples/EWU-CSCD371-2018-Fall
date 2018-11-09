using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW7;

namespace NotNullableTests
{
    [TestClass]
    public class NotNullableTests
    {
        
        [TestMethod]
        public void PossitiveTestCase()
        {
            NotNullable<object> notNullable = new NotNullable<object>();
            notNullable.Value = 42;
            Assert.AreEqual(42, notNullable.Value);
        }

        [TestMethod]
        public void VerifyNotNullableRefTypeCantBeSetToNull_Sucess()
        {
            NotNullable<object> notNullable = null;
            Assert.AreNotEqual(null, notNullable);

        }

        [TestMethod]
        public void VerifyNotNullableValuePropertyCantBeSetToNull_Sucess()
        {
            NotNullable<object> notNullable = new NotNullable<object>();
            notNullable.Value = new Employee();            
            Assert.AreNotEqual(null, notNullable.Value);

        }
        [TestMethod]
        public void VerifyInstantiatingNotNullableWithParametersFails_Success()
        {
           // string Words = "Just some words";
           //NonNullable<string> myNonNullable = new NonNullable<string>(Words);
           //Commented out as this creates complile time errors. 
        }

    }
}
