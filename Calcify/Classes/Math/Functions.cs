using System;

namespace Calcify.Classes.Math
{
    /// <summary>
    /// Provides mathematical utility methods for calculating factorials and combinations.
    /// </summary>
    /// <remarks>The static methods in the Functions class support common combinatorial calculations, such as
    /// computing the factorial of a non-negative number and determining the number of possible combinations for a given
    /// set size. All methods validate input parameters and throw exceptions for invalid arguments. These methods are
    /// thread-safe as they do not maintain any internal state.</remarks>
    class Functions
    {
        /// <summary>
        /// Returns the factorial value of number greater than zero.
        /// </summary>
        /// <param name="d">A number greater than or equal to 0, but less than or equal to System.Double.MaxValue.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double Factorial(double d)
        {
            if (d < 0)
                throw new ArgumentOutOfRangeException();
            else if (d == 0)
                return 1;
            else
            {
                double result = 0;
                for (double n = d; n > 0; n--)
                {
                    if (result == 0) result = n;
                    else result *= n;
                }
                return result;
            }

        }

        /// <summary>
        /// Calculates the number of combinations that can be made by selecting a subset of size r from a set of size n.
        /// </summary>
        /// <param name="n">The total number of items in the set. Must be greater than or equal to <paramref name="r"/>.</param>
        /// <param name="r">The number of items to select from the set. Must be less than or equal to <paramref name="n"/>.</param>
        /// <returns>The number of possible combinations as a double-precision floating-point value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="n"/> is less than <paramref name="r"/>.</exception>
        public static double nCr(int n, int r)
        {
            if (n < r)
                throw new ArgumentException();
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }
    }
}
