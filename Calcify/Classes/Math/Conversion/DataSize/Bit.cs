using System;

namespace Calcify.Classes.Math.Conversion.DataSize
{
    /// <summary>
    /// Provides static methods for converting a value in bits to larger digital storage units, including bytes,
    /// kilobytes, megabytes, gigabytes, terabytes, petabytes, and exabytes.
    /// </summary>
    /// <remarks>All conversion methods assume binary (base-2) units, where each unit is a power of two
    /// multiple of bits. These methods are useful for translating raw bit counts into more commonly used storage
    /// measurements. The class is static and cannot be instantiated.</remarks>
    public static class Bit
    {
        /// <summary>
        /// Converts the specified value, in bytes, to its equivalent in exabytes.
        /// </summary>
        /// <remarks>One exabyte is equal to 9,223,372,036,854,775,808 bytes.</remarks>
        /// <param name="val">The value in bytes to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of exabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 9223372036854775808.0;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in petabytes.
        /// </summary>
        /// <remarks>One petabyte is equal to 9,007,199,254,740,992 bytes. This method performs a direct
        /// conversion using this value.</remarks>
        /// <param name="val">The number of bytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of petabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 9007199254740992.0;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in terabytes.
        /// </summary>
        /// <remarks>One terabyte is equal to 8,796,093,022,208 bytes. This method performs a direct
        /// division and does not round the result.</remarks>
        /// <param name="val">The value in bytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of terabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8796093022208.0;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in gigabytes.
        /// </summary>
        /// <remarks>One gigabyte is defined as 8,589,934,592 bytes (2^33).</remarks>
        /// <param name="val">The value in bytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in gigabytes as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8589934592.0;
        }

        /// <summary>
        /// Converts a value in bytes to its equivalent in megabytes.
        /// </summary>
        /// <param name="val">The value, in bytes, to convert to megabytes. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The number of megabytes equivalent to the specified byte value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8388608.0;
        }

        /// <summary>
        /// Converts the specified value from bits to kilobytes using a factor of 8,192 bits per kilobyte.
        /// </summary>
        /// <remarks>This method uses 8,192 bits as the definition of one kilobyte, which is commonly used
        /// in computing contexts. If the input value is not a valid number, an exception is thrown.</remarks>
        /// <param name="val">The value in bits to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in kilobytes as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8192.0;
        }

        /// <summary>
        /// Converts the specified value from bits to bytes.
        /// </summary>
        /// <param name="val">The value, in bits, to convert to bytes. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The number of bytes equivalent to the specified bit value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8;
        }
    }
}
