using System;

namespace Calcify.Classes.Math.Conversion.DataSize
{
    /// <summary>
    /// Provides static methods for converting byte values to other digital storage units, such as bits, kilobytes,
    /// megabytes, gigabytes, terabytes, petabytes, and exabytes.
    /// </summary>
    /// <remarks>All conversion methods assume binary (base-2) units, where 1 kilobyte equals 1,024 bytes, 1
    /// megabyte equals 1,024 kilobytes, and so on. The methods throw an exception if the input value is not a valid
    /// number (NaN). This class is intended for use in scenarios where precise conversions between byte-based units are
    /// required.</remarks>
    public static class Byte
    {
        /// <summary>
        /// Converts a value in bytes to its equivalent in exabytes.
        /// </summary>
        /// <remarks>One exabyte is equal to 1,152,921,504,606,846,976 bytes. This method performs a
        /// direct conversion without rounding.</remarks>
        /// <param name="val">The number of bytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent value in exabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1152921504606846976.0;
            return result;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in petabytes.
        /// </summary>
        /// <remarks>One petabyte is equal to 1,125,899,906,842,624 bytes.</remarks>
        /// <param name="val">The value in bytes to convert. Must be a valid number.</param>
        /// <returns>The equivalent value in petabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1125899906842624.0;
            return result;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in terabytes.
        /// </summary>
        /// <param name="val">The value in bytes to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in terabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1099511627776.0;
            return result;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in gigabytes.
        /// </summary>
        /// <param name="val">The value in bytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in gigabytes as a <see cref="double"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1073741824.0;
            return result;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in megabytes.
        /// </summary>
        /// <param name="val">The value in bytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the number of megabytes equivalent to the specified byte value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1048576.0;
            return result;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in kilobytes.
        /// </summary>
        /// <param name="val">The value in bytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the number of kilobytes equivalent to the specified byte value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1024.0;
            return result;
        }

        /// <summary>
        /// Converts the specified value from bytes to bits.
        /// </summary>
        /// <param name="val">The value in bytes to convert to bits. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of bits.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8;
            return result;
        }
    }
}
