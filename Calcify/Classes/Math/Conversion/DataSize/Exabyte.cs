using System;

namespace Calcify.Classes.Math.Conversion.DataSize
{
    /// <summary>
    /// Provides static methods for converting between various digital storage units, including terabytes, petabytes,
    /// gigabytes, megabytes, kilobytes, bytes, and bits.
    /// </summary>
    /// <remarks>All conversion methods use binary (IEC) units for calculations and accept double-precision
    /// floating-point values as input. Each method throws an ArgumentException if the input value is NaN. These methods
    /// are intended for large-scale data conversions and may return values that exceed the range of standard numeric
    /// types.</remarks>
    public static class Exabyte
    {
        /// <summary>
        /// Converts a value in terabytes to its equivalent in petabytes.
        /// </summary>
        /// <param name="val">The value, in terabytes, to convert to petabytes.</param>
        /// <returns>A double representing the equivalent value in petabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1024;
            return result;
        }

        /// <summary>
        /// Converts a value in gigabytes to its equivalent in terabytes.
        /// </summary>
        /// <remarks>This method assumes a conversion factor of 1 terabyte = 1,048,576 gigabytes. The
        /// result is calculated by multiplying the input value by 1,048,576.</remarks>
        /// <param name="val">The value in gigabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent value in terabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1048576;
            return result;
        }

        /// <summary>
        /// Converts the specified value from gigabytes to bytes.
        /// </summary>
        /// <param name="val">The value in gigabytes to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of bytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1073741824;
            return result;
        }

        /// <summary>
        /// Converts the specified value from terabytes to megabytes.
        /// </summary>
        /// <param name="val">The value, in terabytes, to convert to megabytes.</param>
        /// <returns>A double representing the equivalent number of megabytes for the specified terabyte value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1099511627776.0;
            return result;
        }

        /// <summary>
        /// Converts the specified value, interpreted as tebibytes (TiB), to kilobytes (KB).
        /// </summary>
        /// <remarks>One tebibyte (TiB) is equal to 1,125,899,906,842,624 bytes, or 1,125,899,906,842.624
        /// kilobytes. This method uses binary (IEC) units for conversion.</remarks>
        /// <param name="val">The numeric value in tebibytes to convert to kilobytes. Must not be NaN.</param>
        /// <returns>The equivalent value in kilobytes as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1125899906842624.0;
            return result;
        }

        /// <summary>
        /// Converts the specified double-precision floating-point value to its equivalent byte value by multiplying it
        /// by 2^60.
        /// </summary>
        /// <remarks>This method performs a scaling operation by multiplying the input value by 2^60. The
        /// result may exceed the range of a byte and is returned as a double. Use this method when a large-scale
        /// conversion is required.</remarks>
        /// <param name="val">The double-precision floating-point value to convert. Must not be NaN.</param>
        /// <returns>A double representing the input value multiplied by 1,152,921,504,606,846,976 (2^60).</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1152921504606846976.0;
            return result;
        }

        /// <summary>
        /// Converts the specified double-precision floating-point value to its equivalent value in bits, represented as
        /// a double.
        /// </summary>
        /// <param name="val">The double-precision floating-point value to convert. Must not be NaN.</param>
        /// <returns>A double representing the bit-equivalent value of the input parameter.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 9223372036854775808.0;
            return result;
        }
    }
}
