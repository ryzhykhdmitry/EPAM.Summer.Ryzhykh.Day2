using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EuclideanAlgorithm
{
    public static class EuclideanAlgorithm
    {
        #region EuclideanAlgorithm
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
        public static int EuclidAlgorithm(int firstNumber, int secondNumber, out long time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            firstNumber = EuclidAlgorithm(firstNumber, secondNumber);
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            return firstNumber;
        }
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
        public static int BinaryEuclidAlgorithm(int firstNumber, int secondNumber, out long time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = BinaryEuclidAlgorithm(firstNumber, secondNumber);
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            return result;
        }
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
    
    }
}
