using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting time values between nanoseconds and other time units, such as
    /// microseconds, milliseconds, seconds, minutes, hours, days, weeks, months, years, decades, and centuries.
    /// </summary>
    /// <remarks>This class offers utility methods for time conversions commonly needed when working with
    /// high-precision time intervals. All methods perform direct conversions based on fixed unit definitions and do not
    /// validate whether the input values represent meaningful or typical time spans. Each method throws an
    /// ArgumentException if the input value is NaN. The class is thread-safe and intended for use in scenarios
    /// requiring precise time unit conversions.</remarks>
    public static class Nanoseconds
    {
        /// <summary>
        /// Converts a time value, specified in ticks, to its equivalent number of centuries.
        /// </summary>
        /// <remarks>One century is defined as 3,153,600,000,000,000,000 ticks. This method does not
        /// validate whether the input represents a meaningful time span; it performs a direct conversion.</remarks>
        /// <param name="val">The time value in ticks to convert. Must not be NaN.</param>
        /// <returns>The number of centuries represented by the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in femtoseconds, to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is defined as 315,360,000,000,000,000 femtoseconds. This method does not
        /// validate for negative or infinite values.</remarks>
        /// <param name="val">The time value in femtoseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified femtoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from femtoseconds to years.
        /// </summary>
        /// <remarks>One year is considered to be 31,536,000,000,000,000 femtoseconds. This method does
        /// not perform range checking beyond NaN validation.</remarks>
        /// <param name="val">The time interval to convert, specified in femtoseconds. Must not be NaN.</param>
        /// <returns>The equivalent time in years as a double-precision floating-point value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in picoseconds, to the equivalent number of months.
        /// </summary>
        /// <remarks>One month is considered to be 2,628,000,000,000,000 picoseconds. The conversion may
        /// result in a fractional value if the input does not represent an exact number of months.</remarks>
        /// <param name="val">The time value in picoseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The number of months equivalent to the specified time value. The result may be fractional.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from ticks to weeks.
        /// </summary>
        /// <remarks>One week is defined as 604,800,000,000,000 ticks. This method does not validate that
        /// the input is within a typical range for time values.</remarks>
        /// <param name="val">The time value, in ticks, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent number of weeks represented by the specified tick value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800000000000;
            return result;
        }

        /// <summary>
        /// Converts a time interval specified in ticks to its equivalent value in days.
        /// </summary>
        /// <remarks>One day is defined as 86,400,000,000,000 ticks. This method does not validate whether
        /// the input represents a valid time interval; it simply performs the conversion.</remarks>
        /// <param name="val">The time interval, in ticks, to convert to days. Must not be NaN.</param>
        /// <returns>The number of days that corresponds to the specified number of ticks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from ticks to hours.
        /// </summary>
        /// <remarks>One tick represents 100 nanoseconds. Use this method to convert tick-based time
        /// values to hours for calculations or display.</remarks>
        /// <param name="val">The time value, in ticks, to convert to hours. Must not be NaN.</param>
        /// <returns>The equivalent time in hours, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from 100-nanosecond units to minutes.
        /// </summary>
        /// <remarks>This method is useful for converting time values represented in .NET ticks (where one
        /// tick equals 100 nanoseconds) to minutes. The conversion is performed by dividing the input value by
        /// 60,000,000,000.</remarks>
        /// <param name="val">The time value to convert, specified in 100-nanosecond units. Must not be NaN.</param>
        /// <returns>The equivalent time in minutes as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanoseconds to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The time interval in nanoseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent time in seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanoseconds to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The value in nanoseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in milliseconds as a <see cref="double"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanoseconds to microseconds.
        /// </summary>
        /// <param name="val">The value in nanoseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
    }
}
