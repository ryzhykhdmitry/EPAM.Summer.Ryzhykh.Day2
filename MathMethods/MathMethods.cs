using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MathMethods
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
        public static int EuclidAlgorithm(int firstNumber, int secondNumber, out long time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            firstNumber = EuclidAlgorithm(firstNumber, secondNumber);
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            return firstNumber;
        }

        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers.
        /// </summary>
        /// <param name="time">Elapsed time</param>
        /// <param name="numbers">Numbers</param>
        /// <returns>Greatest common divisor (GCD) of numbers and elapsed time.</returns>
        public static int EuclidAlgorithm(out long time, params int[] numbers)
        {
            if (numbers == null) throw new NullReferenceException();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = EuclidAlgorithm(numbers);
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers.
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns>Greatest common divisor (GCD) of numbers.</returns>
        public static int EuclidAlgorithm(params int[] numbers)
        {
            if (numbers == null) throw new NullReferenceException();
            int firstNumber = numbers[0];
            int secondNumber;
            for (int i = 1; i < numbers.Length; i++)
            {
                secondNumber = numbers[i];
                int temp = 0;
                while (secondNumber != 0)
                {
                    temp = secondNumber;
                    secondNumber = firstNumber % secondNumber;
                    firstNumber = temp;
                }
            }
            return firstNumber;
        }
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
        public static int BinaryEuclidAlgorithm(int firstNumber, int secondNumber, out long time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = BinaryEuclidAlgorithm(firstNumber, secondNumber);
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers.
        /// </summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Greatest common divisor (GCD) of numbers.</returns>
        public static int BinaryEuclidAlgorithm(params int[] numbers)
        {
            if (numbers == null) throw new NullReferenceException();
            int firstNumber = numbers[0];
            int secondNumber = numbers[1];
            int current = 2;
            int power = 1;
            while (true)
            {
                if (firstNumber == 0)
                {
                    if (current == numbers.Length)
                    {
                        secondNumber *= power;
                        power = 1;
                        return secondNumber;
                    }
                    firstNumber = numbers[current];
                    current++;
                    continue;
                }
                if (secondNumber == 0)
                {
                    if (current == numbers.Length)
                    {
                        firstNumber *= power;
                        power = 1;
                        return firstNumber;
                    }
                    secondNumber = numbers[current];
                    current++;
                    continue;
                }
                if (firstNumber == secondNumber)
                {
                    if (current == numbers.Length)
                    {
                        firstNumber *= power;
                        power = 1;
                        return firstNumber;
                    }
                    secondNumber = numbers[current];
                    current++;
                    continue;
                }
                if (firstNumber == 1 || secondNumber == 1)
                {
                    if (current == numbers.Length)
                    {
                        int temp = 1 * power;
                        power = 1;
                        return temp;
                    }
                    firstNumber = 1 * power;
                    power = 1;
                    secondNumber = numbers[current];
                    current++;
                    continue;
                }
                if ((firstNumber % 2 == 0) && (secondNumber % 2 == 0))
                {
                    power *= 2;
                    firstNumber = firstNumber >> 1;
                    secondNumber = secondNumber >> 1;
                    continue;
                }
                if ((firstNumber % 2 == 0) && (secondNumber % 2 != 0))
                {
                    firstNumber = firstNumber >> 1;
                    continue;
                }
                if ((firstNumber % 2 != 0) && (secondNumber % 2 == 0))
                {
                    secondNumber = secondNumber >> 1;
                    continue;
                }
                if (firstNumber % 2 != 0 && secondNumber % 2 != 0 && firstNumber > secondNumber)
                {
                    firstNumber = (firstNumber - secondNumber) >> 1;
                    continue;
                }
                if (firstNumber % 2 != 0 && secondNumber % 2 != 0 && firstNumber < secondNumber)
                {
                    int temp = firstNumber;
                    firstNumber = (secondNumber - firstNumber) >> 1;
                    secondNumber = temp;
                    continue;
                }
            }
        }

        /// <summary>
        /// Method for computing the greatest common divisor (GCD) of numbers and elapsed time.
        /// </summary>
        /// <param name="time">Elapsed time.</param>
        /// <param name="numbers">Numebrs.</param>
        /// <returns>Greatest common divisor (GCD) of numbers and elapsed time.</returns>
        public static int BinaryEuclidAlgorithm(out long time, params int[] numbers)
        {
            if (numbers == null) throw new NullReferenceException();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = BinaryEuclidAlgorithm(numbers);
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            return result;
        }
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
    }
}
