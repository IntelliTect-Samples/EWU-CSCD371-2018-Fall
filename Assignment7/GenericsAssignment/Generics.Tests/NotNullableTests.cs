using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;
using src;

namespace Generics.Tests
{
    [TestClass]
    public class NotNullableTests
    {
        [TestMethod]
        public void NotNullable_WrapInteger_RetainsCorrectValue()
        {
            int number = 42;
            NotNullable<int> nn = new NotNullable<int>(number);

            Assert.AreEqual(number, nn.Value);
        }

        [TestMethod]
        public void NotNullable_WrapRandomSetToNull_NotNullableIsNotNull()
        {
            Random random = null;
            NotNullable<Random> nn = new NotNullable<Random>(random);

            Assert.AreNotEqual(null, nn.Value);
        }

        [TestMethod]
        public void NotNullable_WrapBigInteger_Success()
        {
            BigInteger bi = new BigInteger(42);
            NotNullable<BigInteger> nn = new NotNullable<BigInteger>(bi);

            Assert.AreEqual(42, nn.Value);
        }

        [TestMethod]
        public void NotNullable_WrapBigIntegerWithDefaultConstructor_Success()
        {
            NotNullable<BigInteger> nn = new NotNullable<BigInteger>();

            Assert.AreEqual(0, nn.Value);
        }

        [TestMethod]
        public void NotNullable_SetToNull_UnfortunateSuccess()
        {
            NotNullable<double> nn = null;

            Assert.AreEqual(null, nn);
        }

        [TestMethod]
        public void NotNullable_ManipulateValue_ValueChanges()
        {
            NotNullable<int> nn = new NotNullable<int>();

            nn.Value = 41;
            nn.Value++;

            Assert.AreEqual(42, nn.Value);
        }

        [TestMethod]
        public void NotNullable_AssignNullValue_ValueIsNotNull()
        {
            NotNullable<Random> nn = new NotNullable<Random>();

            nn.Value = null;

            Assert.AreNotEqual(null, nn.Value);
        }
    }
}