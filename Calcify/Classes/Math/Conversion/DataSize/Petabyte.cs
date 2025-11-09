using System;

namespace Calcify.Classes.Math.Conversion.DataSize
{
    /// <summary>
    /// Provides static methods for converting data storage values between petabytes and other units, including
    /// exabytes, terabytes, gigabytes, megabytes, kilobytes, bytes, and bits.
    /// </summary>
    /// <remarks>All conversion methods require input values that are not <see cref="double.NaN"/> and may be
    /// subject to floating-point precision limitations for very large numbers. The class is intended for use in
    /// scenarios where precise conversions between large-scale data units are needed.</remarks>
    public static class Petabyte
    {
        /// <summary>
        /// Converts a value in petabytes to its equivalent in exabytes.
        /// </summary>
        /// <param name="val">The value, in petabytes, to convert to exabytes. Must not be NaN.</param>
        /// <returns>A double representing the equivalent value in exabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1024.0;
            return result;
        }

        /// <summary>
        /// Converts a value in petabytes to its equivalent in terabytes.
        /// </summary>
        /// <param name="val">The value, in petabytes, to convert to terabytes. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of terabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1024;
            return result;
        }

        /// <summary>
        /// Converts the specified value from terabytes to gigabytes.
        /// </summary>
        /// <param name="val">The value in terabytes to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent value in gigabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1048576;
            return result;
        }

        /// <summary>
        /// Converts the specified value, in gigabytes, to its equivalent in megabytes.
        /// </summary>
        /// <remarks>One gigabyte is considered equal to 1,073,741,824 megabytes in this
        /// conversion.</remarks>
        /// <param name="val">The value in gigabytes to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of megabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1073741824;
            return result;
        }

        /// <summary>
        /// Converts the specified value, in terabytes, to its equivalent in kilobytes.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor 1 terabyte =
        /// 1,099,511,627,776 kilobytes. The result may be subject to floating-point precision limitations for very
        /// large values.</remarks>
        /// <param name="val">The numeric value in terabytes to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of kilobytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1099511627776.0;
            return result;
        }

        /// <summary>
        /// Converts the specified value, interpreted as terabytes, to its equivalent number of bytes.
        /// </summary>
        /// <remarks>This method multiplies the input value by 1,125,899,906,842,624 (the number of bytes
        /// in one terabyte). The result may be subject to floating-point precision limitations for very large
        /// values.</remarks>
        /// <param name="val">The value in terabytes to convert to bytes. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the number of bytes equivalent to the specified terabyte value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1125899906842624.0;
            return result;
        }

        /// <summary>
        /// Converts the specified double-precision floating-point value to its bit representation as a double.
        /// </summary>
        /// <remarks>This method multiplies the input value by 2^53 (9007199254740992.0) to obtain its bit
        /// representation. The result may be subject to floating-point precision limitations.</remarks>
        /// <param name="val">The double-precision floating-point value to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A double representing the bit value of the input parameter.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 9007199254740992.0;
            return result;
        }
    }
}
