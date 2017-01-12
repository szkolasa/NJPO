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
    }
}
