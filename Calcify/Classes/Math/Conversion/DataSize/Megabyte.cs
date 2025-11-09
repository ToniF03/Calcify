using System;

namespace Calcify.Classes.Math.Conversion.DataSize
{

    /// <summary>
    /// Provides static methods for converting values in megabytes to other digital storage units.
    /// </summary>
    /// <remarks>This class includes conversion methods to exabytes, petabytes, terabytes, gigabytes,
    /// kilobytes, bytes, and bits. All methods expect the input value to represent a quantity in megabytes and return
    /// the equivalent value in the target unit. The class is static and cannot be instantiated.</remarks>
    public static class Megabyte
    {
        /// <summary>
        /// Converts a value in terabytes to its equivalent in exabytes.
        /// </summary>
        /// <param name="val">The value, in terabytes, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in exabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1099511627776.0;
            return result;
        }

        /// <summary>
        /// Converts a value in gigabytes to its equivalent in petabytes.
        /// </summary>
        /// <remarks>One petabyte is equal to 1,073,741,824 gigabytes.</remarks>
        /// <param name="val">The value in gigabytes to convert. Must be a valid number.</param>
        /// <returns>The equivalent value in petabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1073741824.0;
            return result;
        }

        /// <summary>
        /// Converts a value in megabytes to its equivalent in terabytes.
        /// </summary>
        /// <remarks>One terabyte is equal to 1,048,576 megabytes. This method performs a direct
        /// conversion by dividing the input value by 1,048,576.</remarks>
        /// <param name="val">The value in megabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in terabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1048576.0;
            return result;
        }

        /// <summary>
        /// Converts a value in megabytes to its equivalent in gigabytes.
        /// </summary>
        /// <param name="val">The value in megabytes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in gigabytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1024.0;
            return result;
        }

        /// <summary>
        /// Converts the specified value in megabytes to its equivalent in kilobytes.
        /// </summary>
        /// <param name="val">The value in megabytes to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of kilobytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilobyte(double val)
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
        /// result may be imprecise for very large or very small values due to floating-point limitations.</remarks>
        /// <param name="val">The value in megabytes to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of bytes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1048576;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in bits by multiplying it by 8,388,608.
        /// </summary>
        /// <param name="val">The value to convert to bits. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the input value converted to bits.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8388608;
            return result;
        }
    }
}
