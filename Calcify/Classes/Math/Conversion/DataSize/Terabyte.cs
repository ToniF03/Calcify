using System;

namespace Calcify.Classes.Math.Conversion.DataSize
{
    /// <summary>
    /// Provides static methods for converting values between terabytes and other digital storage units, including
    /// exabytes, petabytes, gigabytes, megabytes, kilobytes, bytes, and bits.
    /// </summary>
    /// <remarks>All conversion methods require the input value to be a valid number (not NaN) and perform
    /// direct mathematical conversions based on standard binary unit definitions. Results may be subject to
    /// floating-point precision limitations for very large values. This class is thread-safe as it contains only
    /// stateless static methods.</remarks>
    public static class Terabyte
    {
        /// <summary>
        /// Converts a value in terabytes to its equivalent in exabytes.
        /// </summary>
        /// <remarks>One exabyte is equal to 1,048,576 terabytes. This method performs a direct division
        /// to convert the input value.</remarks>
        /// <param name="val">The value in terabytes to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in exabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1048576.0;
            return result;
        }

        /// <summary>
        /// Converts a value in terabytes to its equivalent in petabytes.
        /// </summary>
        /// <remarks>One petabyte is equal to 1,024 terabytes. This method performs a simple division to
        /// convert the input value.</remarks>
        /// <param name="val">The value in terabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in petabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1024.0;
            return result;
        }

        /// <summary>
        /// Converts the specified value in terabytes to its equivalent in gigabytes.
        /// </summary>
        /// <param name="val">The value, in terabytes, to convert to gigabytes. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of gigabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1024;
            return result;
        }

        /// <summary>
        /// Converts the specified value from megabytes to bytes.
        /// </summary>
        /// <remarks>This method multiplies the input value by 1,048,576 to perform the conversion. The
        /// result may be subject to floating-point precision limitations.</remarks>
        /// <param name="val">The value in megabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of bytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1048576;
            return result;
        }

        /// <summary>
        /// Converts the specified value from gigabytes to kilobytes.
        /// </summary>
        /// <remarks>This method multiplies the input value by 1,073,741,824 to perform the conversion, as
        /// one gigabyte equals 1,073,741,824 kilobytes.</remarks>
        /// <param name="val">The value in gigabytes to convert. Must be a valid number.</param>
        /// <returns>The equivalent value in kilobytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1073741824;
            return result;
        }

        /// <summary>
        /// Converts the specified value, in terabytes, to its equivalent number of bytes.
        /// </summary>
        /// <remarks>This method multiplies the input value by 1,099,511,627,776 (the number of bytes in
        /// one terabyte). The result may be subject to floating-point precision limitations for very large
        /// values.</remarks>
        /// <param name="val">The value to convert, expressed in terabytes. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the number of bytes equivalent to the specified terabyte value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1099511627776.0;
            return result;
        }

        /// <summary>
        /// Converts the specified value from terabits to bits.
        /// </summary>
        /// <remarks>This method multiplies the input value by 8,796,093,022,208 to perform the conversion
        /// from terabits to bits. The result may be subject to floating-point precision limitations.</remarks>
        /// <param name="val">The value in terabits to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of bits.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8796093022208.0;
            return result;
        }
    }
}
