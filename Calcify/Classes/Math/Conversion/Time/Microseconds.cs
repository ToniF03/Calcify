using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting time values between microseconds and other time units, including
    /// nanoseconds, milliseconds, seconds, minutes, hours, days, weeks, months, years, decades, and centuries.
    /// </summary>
    /// <remarks>All conversion methods validate that the input value is not <see cref="double.NaN"/> and
    /// throw an <see cref="ArgumentException"/> if this condition is not met. The conversions use fixed values for unit
    /// lengths, which may not account for calendar variations or leap years. These methods are intended for
    /// general-purpose time unit conversions and do not perform additional range or overflow checks.</remarks>
    public static class Microseconds
    {
        /// <summary>
        /// Converts a time value, specified in femtoseconds, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is considered to be 3,153,600,000,000,000 femtoseconds.</remarks>
        /// <param name="val">The time value in femtoseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified femtoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in femtoseconds, to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is defined as 315,360,000,000,000 femtoseconds. This method does not
        /// validate the range of the input value beyond checking for NaN.</remarks>
        /// <param name="val">The time value to convert, in femtoseconds. Must not be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified femtoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from femtoseconds to years.
        /// </summary>
        /// <remarks>One year is considered to be 31,536,000,000,000 femtoseconds. This method does not
        /// perform range checking beyond NaN validation.</remarks>
        /// <param name="val">The time interval to convert, specified in femtoseconds. Must not be NaN.</param>
        /// <returns>The equivalent time in years as a double-precision floating-point value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from nanoseconds to months.
        /// </summary>
        /// <remarks>One month is considered to be 2,628,000,000,000 nanoseconds. This conversion uses a
        /// fixed average month length and may not account for variations in calendar months.</remarks>
        /// <param name="val">The time value, in nanoseconds, to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in months, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from ticks to weeks.
        /// </summary>
        /// <remarks>One week is defined as 604,800,000,000 ticks. This method does not validate that the
        /// input represents a whole number of weeks.</remarks>
        /// <param name="val">The time value, in ticks, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent number of weeks represented by the specified tick value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from 100-nanosecond intervals to days.
        /// </summary>
        /// <remarks>This method is useful for converting time values commonly used in Windows file times
        /// or .NET ticks to a day-based representation.</remarks>
        /// <param name="val">The time value, in 100-nanosecond intervals, to convert to days. Must not be NaN.</param>
        /// <returns>The equivalent number of days represented by the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from ticks to hours.
        /// </summary>
        /// <param name="val">The time value, in ticks, to convert to hours. Must not be NaN.</param>
        /// <returns>A double representing the equivalent time in hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing microseconds to its equivalent in minutes.
        /// </summary>
        /// <param name="val">The value, in microseconds, to convert to minutes. Must not be NaN.</param>
        /// <returns>A double representing the number of minutes equivalent to the specified microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60000000;
            return result;
        }

        /// <summary>
        /// Converts a value from microseconds to seconds.
        /// </summary>
        /// <param name="val">The value in microseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from microseconds to milliseconds.
        /// </summary>
        /// <param name="val">The value, in microseconds, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent value in milliseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in microseconds to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The value in microseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent value in nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
    }
}
