using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting time values expressed in minutes to various other units, including
    /// centuries, decades, years, months, weeks, days, hours, seconds, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume fixed conversion factors and do not account for leap years,
    /// calendar variations, or time zone differences. Each method throws an ArgumentException if the input value is not
    /// a valid number (NaN). These methods are intended for straightforward time unit conversions and may not be
    /// suitable for precise calendrical calculations.</remarks>
    public static class Minutes
    {
        /// <summary>
        /// Converts a time value, specified in minutes, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is considered to be 52,560,000 minutes.</remarks>
        /// <param name="val">The time value in minutes to convert. Must be a valid number.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of minutes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 52560000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in minutes, to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is considered to be 5,256,000 minutes. This method performs a simple
        /// division and does not account for leap years or calendar variations.</remarks>
        /// <param name="val">The time value in minutes to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified number of minutes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 5256000;
            return result;
        }

        /// <summary>
        /// Converts a time value from minutes to years.
        /// </summary>
        /// <remarks>This method assumes a year consists of 525,600 minutes (365 days).</remarks>
        /// <param name="val">The time value, in minutes, to convert to years. Must not be NaN.</param>
        /// <returns>The equivalent time in years, calculated as the input value divided by 525,600.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 525600;
            return result;
        }

        /// <summary>
        /// Converts a time value from hours to months using a fixed conversion factor.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 43,800 hours per month. The result may
        /// not reflect calendar month variations.</remarks>
        /// <param name="val">The time value in hours to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A double representing the equivalent number of months for the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 43800;
            return result;
        }

        /// <summary>
        /// Converts a time value from minutes to weeks.
        /// </summary>
        /// <remarks>One week is considered to be 10,080 minutes. The conversion divides the input value
        /// by 10,080.</remarks>
        /// <param name="val">The time value, in minutes, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent time in weeks, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 10080;
            return result;
        }

        /// <summary>
        /// Converts a time value from minutes to days.
        /// </summary>
        /// <param name="val">The time value, in minutes, to convert to days. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of days for the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1440;
            return result;
        }

        /// <summary>
        /// Converts a time value from minutes to hours.
        /// </summary>
        /// <param name="val">The time value, in minutes, to convert to hours. Must not be NaN.</param>
        /// <returns>The equivalent time in hours as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60;
            return result;
        }

        /// <summary>
        /// Converts a value in minutes to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of minutes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60;
            return result;
        }

        /// <summary>
        /// Converts a value representing minutes to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The number of minutes to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of milliseconds for the specified number of minutes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from minutes to microseconds.
        /// </summary>
        /// <param name="val">The value, in minutes, to convert to microseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of microseconds for the specified value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60000000;
            return result;
        }

        /// <summary>
        /// Converts a value in minutes to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The number of minutes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60000000000;
            return result;
        }
    }
}
