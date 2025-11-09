using System;

namespace Calcify.Classes.Math.Conversion.DataSize
{
    /// <summary>
    /// Provides static methods for converting values in kilobytes to other digital storage units, including bits,
    /// bytes, megabytes, gigabytes, terabytes, petabytes, and exabytes.
    /// </summary>
    /// <remarks>All conversion methods assume base-2 (binary) units, where 1 kilobyte equals 1,024 bytes.
    /// These methods are intended for scenarios where precise binary conversions are required, such as file size
    /// calculations or memory usage reporting. The class is static and cannot be instantiated.</remarks>
    public static class Kilobyte
    {

        /// <summary>
        /// Converts a value in bytes to its equivalent in exabytes.
        /// </summary>
        /// <param name="val">The value in bytes to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in exabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1125899906842624.0;
            return result;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in petabytes.
        /// </summary>
        /// <remarks>One petabyte is equal to 1,099,511,627,776 bytes. This method performs a direct
        /// conversion without rounding.</remarks>
        /// <param name="val">The number of bytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of petabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1099511627776.0;
            return result;
        }

        /// <summary>
        /// Converts a value in megabytes to its equivalent in terabytes.
        /// </summary>
        /// <remarks>One terabyte is equal to 1,073,741,824 megabytes. This method does not perform range
        /// checking beyond validating that the input is not NaN.</remarks>
        /// <param name="val">The value in megabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of terabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1073741824.0;
            return result;
        }

        /// <summary>
        /// Converts a value in megabytes to its equivalent in gigabytes.
        /// </summary>
        /// <param name="val">The value, in megabytes, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent value in gigabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1048576.0;
            return result;
        }

        /// <summary>
        /// Converts a value in kilobytes to its equivalent in megabytes.
        /// </summary>
        /// <remarks>This method performs a simple division by 1024 to convert kilobytes to megabytes. The
        /// conversion does not account for binary (1024-based) versus decimal (1000-based) units; it uses 1024 as the
        /// divisor, which is standard for binary megabytes.</remarks>
        /// <param name="val">The value in kilobytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in megabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1024.0;
            return result;
        }

        /// <summary>
        /// Converts the specified value in kilobytes to its equivalent in bytes.
        /// </summary>
        /// <param name="val">The value in kilobytes to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of bytes equivalent to the specified kilobyte value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1024;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in bits by multiplying by 8,192.
        /// </summary>
        /// <param name="val">The numeric value to convert to bits. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the input value converted to bits.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8192;
            return result;
        }
    }
}
