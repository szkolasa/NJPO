using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJPO.UnitTest;

namespace NJPO.UnitTest.UnitTests
{
    [TestClass]
    public class QuadraticEquationTests
    {
        private QuadraticEquation.QuadraticEquation _quadraticEquation;

        [TestInitialize]
        public void TestInit()
        {
            _quadraticEquation = new QuadraticEquation.QuadraticEquation();
        }

        [TestMethod]
        public void ShouldReturnTwoNulls()
        {
            // Arrange
            _quadraticEquation.A = 5;
            _quadraticEquation.B = 1;
            _quadraticEquation.C = 7;

            double? x1, x2;

            // Act
            _quadraticEquation.ZerosOfFunction(out x1, out x2);

            // Assert
            Assert.IsNull(x1);
            Assert.IsNull(x2);
        }

        [TestMethod]
        public void ShouldReturnOneZero()
        {
            // Arrange
            _quadraticEquation.A = 4;
            _quadraticEquation.B = 4;
            _quadraticEquation.C = 1;

            double? x1, x2;

            // Act
            _quadraticEquation.ZerosOfFunction(out x1, out x2);

            // Assert
            Assert.IsNotNull(x1);
            Assert.IsNull(x2);
        }

        [TestMethod]
        public void ShouldReturnTwoZeros()
        {
            // Arrange
            _quadraticEquation.A = 1;
            _quadraticEquation.B = 3;
            _quadraticEquation.C = -2;

            double? x1, x2;

            // Act
            _quadraticEquation.ZerosOfFunction(out x1, out x2);

            // Assert
            Assert.IsTrue(x1.HasValue);
            Assert.IsNotNull(x2);
        }

        [TestMethod]
        public void ShouldReturnSpecificValues()
        {
            // Arrange
            _quadraticEquation.A = 1;
            _quadraticEquation.B = -4;
            _quadraticEquation.C = 3;

            double? x1, x2;

            // Act
            _quadraticEquation.ZerosOfFunction(out x1, out x2);

            // Assert
            Assert.AreEqual(x1, 3);
            Assert.AreEqual(x2, 1);
        }

        [TestMethod]
        public void ShouldReturnDivideByZeroException()
        {
            // Arrange
            _quadraticEquation.A = 0;
            _quadraticEquation.B = 10;
            _quadraticEquation.C = 3;

            double? x1, x2;
            Exception exception = null;

            // Act
            try
            {
                _quadraticEquation.ZerosOfFunction(out x1, out x2);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            Assert.IsInstanceOfType(exception, typeof(DivideByZeroException));
        }
    }
}
