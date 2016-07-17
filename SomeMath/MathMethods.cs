using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SomeMath
{
    /// <summary>
    /// Allows to use some math methods.
    /// </summary>
    public static class MathMethods
    {
        #region EuclideanAlgorithm
        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of two numbers.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Greatest common divisor (GCD) of two numbers.</returns>
        public static int EuclidAlgorithm(int firstNumber, int secondNumber)
        {
            int temp;
            while (secondNumber != 0)
            {
                temp = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = temp;
            }
            return Math.Abs(firstNumber);
        }
        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of two numbers.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="time">Elapsed time.</param>
        /// <returns>Greatest common divisor (GCD) of two numbers and elapsed time.</returns>
        public static int EuclidAlgorithm(int firstNumber, int secondNumber, out long time) =>
            TimeSpent(EuclidAlgorithm, firstNumber, secondNumber, out time);        

        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers.
        /// </summary>
        /// <param name="time">Elapsed time</param>
        /// <param name="numbers">Numbers</param>
        /// <returns>Greatest common divisor (GCD) of numbers and elapsed time.</returns>
        public static int EuclidAlgorithm(out long time, params int[] numbers) =>
            TimeSpent(EuclidAlgorithm, numbers, out time);       

        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers.
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns>Greatest common divisor (GCD) of numbers.</returns>
        public static int EuclidAlgorithm(params int[] numbers) => UniversalGCD(EuclidAlgorithm, numbers);      
        #endregion

        #region BinaryEuclideanAlgorithm
        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Greatest common divisor (GCD) of two numbers.</returns>
        public static int BinaryEuclidAlgorithm(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                return secondNumber;
            }
            if (secondNumber == 0)
            {
                return firstNumber;
            }
            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }
            if (firstNumber == 1 || secondNumber == 1)
            {
                return 1;
            }
            if ((firstNumber % 2 == 0) && (secondNumber % 2 == 0))
            {
                return 2 * BinaryEuclidAlgorithm(firstNumber >> 1, secondNumber >> 1);
            }
            if ((firstNumber % 2 == 0) && (secondNumber % 2 != 0))
            {
                return BinaryEuclidAlgorithm(firstNumber >> 1, secondNumber);
            }
            if ((firstNumber % 2 != 0) && (secondNumber % 2 == 0))
            {
                return BinaryEuclidAlgorithm(firstNumber, secondNumber >> 1);
            }
            if (firstNumber % 2 != 0 && secondNumber % 2 != 0 && firstNumber > secondNumber)
            {
                return BinaryEuclidAlgorithm((firstNumber - secondNumber) >> 1, secondNumber);
            }
            if (firstNumber % 2 != 0 && secondNumber % 2 != 0 && firstNumber < secondNumber)
            {
                return BinaryEuclidAlgorithm((secondNumber - firstNumber) >> 1, firstNumber);
            }
            return 0;
        }

        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers and elapsed time.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="time">Elapsed time.</param>
        /// <returns>Greatest common divisor (GCD) of two numbers and elapsed time.</returns>
        public static int BinaryEuclidAlgorithm(int firstNumber, int secondNumber, out long time) =>
            TimeSpent(BinaryEuclidAlgorithm, firstNumber, secondNumber, out time);        

        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers.
        /// </summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Greatest common divisor (GCD) of numbers.</returns>
        public static int BinaryEuclidAlgorithm(params int[] numbers) => UniversalGCD(BinaryEuclidAlgorithm, numbers);        

        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers and elapsed time.
        /// </summary>
        /// <param name="time">Elapsed time.</param>
        /// <param name="numbers">Numebrs.</param>
        /// <returns>Greatest common divisor (GCD) of numbers and elapsed time.</returns>
        public static int BinaryEuclidAlgorithm(out long time, params int[] numbers) =>
            TimeSpent(BinaryEuclidAlgorithm, numbers, out time);
       
        #endregion

        #region Newton method        
            /// <summary>
            /// Returns the nth root of a specified number by Newton's method.
            /// </summary>
            /// <param name="number">A number whose nth root is to be found.</param>
            /// <param name="power">A number that specifies the power.</param>
            /// <param name="accurancy">A number that specifies the accuracy of calculation.</param>
            /// <returns> The nth root of a number.</returns>
            public static double Radical(double number, int power, double accuracy)
            {
                if (number < 0 && power % 2 == 0 || power == 0) throw new ArgumentException();
                if (number == 0) return 0;
                double x = 0, result = 1;
                do
                {
                    x = result;
                    result = ((power - 1) * x + number / Math.Pow(x, power - 1)) / power;

                } while (Math.Abs(x - result) > accuracy);
                return result;
            }
        #endregion

        #region Helpers
        /// <summary>
        /// Universal method for all GCD.
        /// </summary>
        /// <param name="method">Method for GCD calculation.</param>
        /// <param name="arg">Arguments.</param>
        /// <returns>Int GCD.</returns>
        private static int UniversalGCD(Func<int, int, int> method, int[] arg)
        {
            if (arg.Length == 0) throw new ArgumentNullException();
            if (arg.Length == 1) return arg[0];
            int temp = arg[0];
            foreach (var item in arg)
            {
                temp = method(temp, item);
            }
            return temp;
        }

        /// <summary>
        /// Calculating time spent for 2 arguments.
        /// </summary>
        /// <param name="method">Method.</param>
        /// <param name="a">Argument 1.</param>
        /// <param name="b">Argument 2.</param>
        /// <param name="time">Time spent.</param>
        /// <returns>GCD and time spent as out parameter.</returns>
        private static int TimeSpent(Func<int, int, int> method, int a, int b, out long time) =>
            TimeSpent((int[] x) => method(x[0], x[1]), new int[2] { a, b }, out time);

        /// <summary>
        /// Calculating time spent for arguments.
        /// </summary>
        /// <param name="method">Method.</param>
        /// <param name="arg">Arguments.</param>
        /// <param name="time">Time spent.</param>
        /// <returns>GCD and time spent as out parameter.</returns>
        private static int TimeSpent(Func<int[], int> method, int[] arg, out long time)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = method(arg);
            watch.Stop();
            time = watch.ElapsedTicks;
            return res;
        } 
        #endregion
    }
}