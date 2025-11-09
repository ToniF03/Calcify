using System;

namespace Calcify.Classes.Math.Conversion.DataSize
{
    /// <summary>
    /// Provides static methods for converting values in gigabytes to other digital storage units.
    /// </summary>
    /// <remarks>This class includes conversion methods to exabytes, petabytes, terabytes, megabytes,
    /// kilobytes, bytes, and bits using binary (base-2) multiples. All methods require a valid numeric value
    /// representing gigabytes and will throw an exception if the input is not a number. The class is static and cannot
    /// be instantiated.</remarks>
    public static class Gigabyte
    {
        /// <summary>
        /// Converts a value in gibibytes to exabytes.
        /// </summary>
        /// <remarks>One exabyte is equal to 1,073,741,824 gibibytes.</remarks>
        /// <param name="val">The value, in gibibytes, to convert to exabytes. Must not be NaN.</param>
        /// <returns>The equivalent value in exabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1073741824.0;
            return result;
        }

        /// <summary>
        /// Converts a value in terabytes to its equivalent in petabytes.
        /// </summary>
        /// <remarks>One petabyte is equal to 1,048,576 terabytes. This method performs a simple division
        /// to convert the unit.</remarks>
        /// <param name="val">The value in terabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in petabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1048576.0;
            return result;
        }

        /// <summary>
        /// Converts a value in gigabytes to its equivalent in terabytes.
        /// </summary>
        /// <param name="val">The value in gigabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in terabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1024.0;
            return result;
        }

        /// <summary>
        /// Converts the specified value from gigabytes to megabytes.
        /// </summary>
        /// <param name="val">The value in gigabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent value in megabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1024;
            return result;
        }

        /// <summary>
        /// Converts the specified value, in megabytes, to its equivalent in kilobytes.
        /// </summary>
        /// <param name="val">The value in megabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of kilobytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1048576;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in bytes by multiplying it by 1,073,741,824.
        /// </summary>
        /// <remarks>This method treats the input as a value in gigabytes and returns its equivalent in
        /// bytes. The conversion uses the binary definition of a gigabyte (1 GB = 1,073,741,824 bytes).</remarks>
        /// <param name="val">The numeric value to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the input value multiplied by 1,073,741,824.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1073741824;
            return result;
        }

        /// <summary>
        /// Converts the specified value from gigabytes to bits.
        /// </summary>
        /// <remarks>This method multiplies the input value by 8,589,934,592 to perform the conversion.
        /// The result may be subject to floating-point precision limitations for very large values.</remarks>
        /// <param name="val">The value in gigabytes to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of bits for the specified gigabyte value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8589934592.0;
            return result;
        }
    }
}
