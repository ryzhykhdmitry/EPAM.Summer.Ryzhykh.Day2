using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeMath;
using System.Diagnostics;

namespace MathMethodsTests
{
    [TestClass]
    public class MathMethodsTests
    {
        #region EuclidAlgorithmTest
        [TestMethod]
        public void EuclidAlgorithmTestMethod1()
        {
            int first = 4564878;
            int second = 5;
            long watch;
            Assert.AreEqual(1, MathMethods.EuclidAlgorithm(first, second, out watch));            
        }

        [TestMethod]
        public void EuclidAlgorithmTestMethod2()
        {
            int first = 6000;
            int second = 8123;
            long watch;
            Assert.AreEqual(1, MathMethods.EuclidAlgorithm(first, second, out watch));
            Debug.WriteLine("watch = {0}", watch);

        }

        [TestMethod]
        public void EuclidAlgorithmTestMethod3()
        {
            int first = 0;
            int second = 7;
            Assert.AreEqual(7, MathMethods.EuclidAlgorithm(first, second));
        }

        [TestMethod]
        public void EuclidAlgorithmTestMethod4()
        {
            int first = 0;
            int second = 0;
            Assert.AreEqual(0, MathMethods.EuclidAlgorithm(first, second));
        }

        [TestMethod]
        public void EuclidAlgorithmTestMethod5()
        {
            int first = 9;
            int second = 9;
            long watch;
            Assert.AreEqual(9, MathMethods.EuclidAlgorithm(first, second, out watch));            
        }

        [TestMethod]
        public void EuclidAlgorithmTestMethod6()
        {
            int first = -12;
            int second = 8;
            long watch;
            Assert.AreEqual(4, MathMethods.EuclidAlgorithm(first, second, out watch));           
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExeptionEuclidAlgorithmTestMethod()
        {
            int[] numbers = null;
            MathMethods.EuclidAlgorithm(numbers);
        }
        #endregion

        #region BinaryEuclidAlgorithmTest
        [TestMethod]
        public void BinaryEuclidAlgorithmTestMethod1()
        {
            int first = 7435446;
            int second = 7;
            long time;
            Assert.AreEqual(1, MathMethods.BinaryEuclidAlgorithm(first, second, out time));
        }

        [TestMethod]
        public void BinaryEuclidAlgorithmTestMethod2()
        {
            int first = 428;
            int second = 761;
            long time;
            Assert.AreEqual(1, MathMethods.BinaryEuclidAlgorithm(first, second, out time));
        }

        [TestMethod]
        public void BinaryEuclidAlgorithmTestMethod3()
        {
            int first = 0;
            int second = 6;
            Assert.AreEqual(6, MathMethods.BinaryEuclidAlgorithm(first, second));
        }
        [TestMethod]
        public void BinaryEuclidAlgorithmTestMethod4()
        {
            int first = 0;
            int second = 0;
            Assert.AreEqual(0, MathMethods.BinaryEuclidAlgorithm(first, second));
        }
        [TestMethod]
        public void BinaryEuclidAlgorithmTestMethod5()
        {
            int first = 9;
            int second = 9;
            Assert.AreEqual(9, MathMethods.BinaryEuclidAlgorithm(first, second));
        }
        [TestMethod]
        public void BinaryEuclidAlgorithmTestMethod6()
        {
            int first = -12;
            int second = 8;
            Assert.AreEqual(4, MathMethods.BinaryEuclidAlgorithm(first, second));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExeptionBinaryEuclidAlgorithmTestMethod()
        {
            int[] numbers = null;
            MathMethods.BinaryEuclidAlgorithm(numbers);
        }
        #endregion

        #region NewtonMethodTest
        [TestMethod]
        public void NewtonMethodTestMethod1()
        {
            double number = 512;
            int power = 3;
            double accuracy = 0;
            Assert.AreEqual(8, MathMethods.Radical(number, power, accuracy));
        }

        [TestMethod]
        public void NewtonMethodTestMEthod2()
        {
            double number = 0;
            int power = 7;
            double accurancy = 0;
            Assert.AreEqual(0, MathMethods.Radical(number, power, accurancy));
        }

        [TestMethod]
        public void NewtonMethodTestMethod3()
        {
            double number = 12;
            int power = 5;
            double accurancy = 0;
            Assert.AreEqual(1.6437, MathMethods.Radical(number, power, accurancy), 1E-4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExeptionNewtonMethodTestMethod()
        {
            double number = -10;
            int power = 2;
            double accurancy = 0;
            MathMethods.Radical(number, power, accurancy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExeptionNewtonMethodTestMethod2()
        {
            double number = 12;
            int power = 0;
            double accurancy = 0;
            MathMethods.Radical(number, power, accurancy);
        } 
        #endregion
    }
}
