using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting time values between milliseconds and other time units, including
    /// nanoseconds, microseconds, seconds, minutes, hours, days, weeks, months, years, decades, and centuries.
    /// </summary>
    /// <remarks>All conversion methods require input values that are not <see cref="double.NaN"/> and will
    /// throw an <see cref="ArgumentException"/> if a NaN value is provided. The conversions use fixed factors and do
    /// not account for calendar variations, leap years, or time zone differences. These methods are intended for
    /// general-purpose time unit conversions and may not be suitable for precise calendrical calculations.</remarks>
    public static class Milliseconds
    {
        /// <summary>
        /// Converts a time value, specified in nanoseconds, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is considered to be 3,153,600,000,000 nanoseconds. The conversion is
        /// performed using this constant factor.</remarks>
        /// <param name="val">The time value in nanoseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in nanoseconds, to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is defined as 315,360,000,000 nanoseconds. This method does not validate
        /// whether the input is within a realistic range for time values.</remarks>
        /// <param name="val">The time value in nanoseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to years.
        /// </summary>
        /// <remarks>One year is considered to be 31,536,000,000 milliseconds. This method does not
        /// account for leap years or calendar variations.</remarks>
        /// <param name="val">The time value, in milliseconds, to convert to years. Must not be NaN.</param>
        /// <returns>The equivalent time in years, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to months.
        /// </summary>
        /// <remarks>This method assumes one month is equal to 2,628,000,000 milliseconds (approximately
        /// 30.44 days).</remarks>
        /// <param name="val">The time value, in milliseconds, to convert to months. Must not be NaN.</param>
        /// <returns>The equivalent number of months represented by the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to weeks.
        /// </summary>
        /// <param name="val">The time value, in milliseconds, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent number of weeks represented by the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to days.
        /// </summary>
        /// <param name="val">The time value, in milliseconds, to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in days, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to hours.
        /// </summary>
        /// <param name="val">The time value in milliseconds to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in hours as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to minutes.
        /// </summary>
        /// <param name="val">The time value, in milliseconds, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent time in minutes as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60000;
            return result;
        }

        /// <summary>
        /// Converts a value from milliseconds to seconds.
        /// </summary>
        /// <param name="val">The value in milliseconds to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in seconds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in milliseconds to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The value in milliseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in milliseconds to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The value in milliseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
    }
}
