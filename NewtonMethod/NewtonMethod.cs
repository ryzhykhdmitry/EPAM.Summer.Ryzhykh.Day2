using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonMethod
{
    #region Newton method
    /// <summary>
    /// This class allows to get the radical by Newton's method.
    /// </summary>
    public static class NewtonMethod
    {
        /// <summary>
        /// Returns the nth root of a specified number.
        /// </summary>
        /// <param name="number">A number whose nth root is to be found.</param>
        /// <param name="power">A number that specifies the power.</param>
        /// <param name="accurancy">A number that specifies the accuracy of calculation.</param>
        /// <returns> The nth root of a number.</returns>
        public static double Radical(double number, int power, double accuracy)
        {
            if (power == 0) throw new DivideByZeroException();
            if (number < 0 && power % 2 == 0) throw new ArgumentException();
            if (number == 0) return 0;
            double x = 0, result = 1;           
            do
            {
                x = result;
                result = ((power - 1) * x + number / Math.Pow(x, power - 1)) / power;

            } while (Math.Abs(x - result) > accuracy);
            return result;
        }
    } 
    #endregion
}
