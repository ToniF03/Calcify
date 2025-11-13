using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting time values specified in seconds to various other time units, including
    /// centuries, decades, years, months, weeks, days, hours, minutes, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods require the input value to be a valid double that is not <see
    /// cref="double.NaN"/>. If an invalid value is provided, an <see cref="ArgumentException"/> is thrown. The
    /// conversions use fixed values for the length of each time unit, which may not account for calendar variations
    /// (such as leap years or differing month lengths). These methods are intended for approximate calculations and
    /// should not be used where precise calendar accuracy is required.</remarks>
    public static class Seconds
    {
        /// <summary>
        /// Converts a time value, specified in seconds, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is defined as 3,153,600,000 seconds.</remarks>
        /// <param name="val">The time value in seconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the number of centuries equivalent to the specified time in seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to decades.
        /// </summary>
        /// <remarks>One decade is defined as 315,360,000 seconds (10 years of 365 days each).</remarks>
        /// <param name="val">The time value, in seconds, to convert to decades. Must not be NaN.</param>
        /// <returns>The equivalent time in decades, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to years.
        /// </summary>
        /// <remarks>One year is considered to be 31,536,000 seconds (365 days).</remarks>
        /// <param name="val">The time value, in seconds, to convert to years. Must not be NaN.</param>
        /// <returns>The equivalent time in years as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to months using a fixed average month length.
        /// </summary>
        /// <remarks>This method uses 2,628,000 seconds as the average length of a month, which may not
        /// reflect calendar month variations. The result is a fractional value representing months.</remarks>
        /// <param name="val">The time value in seconds to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in months, calculated by dividing the input value by 2,628,000 (the average number of
        /// seconds in a month).</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to weeks.
        /// </summary>
        /// <param name="val">The time interval, in seconds, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent time in weeks, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to days.
        /// </summary>
        /// <param name="val">The time value, in seconds, to convert to days. Must not be NaN.</param>
        /// <returns>The equivalent time in days, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to hours.
        /// </summary>
        /// <param name="val">The time value, in seconds, to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in hours, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to minutes.
        /// </summary>
        /// <param name="val">The time value, in seconds, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent time in minutes as a <see cref="double"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60;
            return result;
        }

        /// <summary>
        /// Converts a value in seconds to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The value in seconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of milliseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from seconds to microseconds.
        /// </summary>
        /// <param name="val">The value in seconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent value in microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in seconds to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The time interval in seconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the specified time interval in nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
    }
}
