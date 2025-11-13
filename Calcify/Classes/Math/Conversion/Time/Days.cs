using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting a number of days to equivalent values in other time units, such as
    /// centuries, decades, years, months, weeks, hours, minutes, seconds, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume standard time unit lengths and do not account for leap years or
    /// calendar irregularities. Methods throw an ArgumentException if the input value is not a valid number
    /// (NaN).</remarks>
    public static class Days
    {
        /// <summary>
        /// Converts a number of days to the equivalent number of centuries.
        /// </summary>
        /// <remarks>One century is considered to be 36,500 days.</remarks>
        /// <param name="val">The number of days to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 36500;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in decades.
        /// </summary>
        /// <remarks>A decade is considered as 3,650 days (10 years of 365 days each). This method does
        /// not account for leap years.</remarks>
        /// <param name="val">The number of days to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3650;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of years.
        /// </summary>
        /// <param name="val">The number of days to convert. Must not be NaN.</param>
        /// <returns>A double value representing the equivalent number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 365;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of months.
        /// </summary>
        /// <remarks>The conversion uses an average month length of 30.417 days. The result is an
        /// approximation and may not reflect calendar month boundaries.</remarks>
        /// <param name="val">The number of days to convert to months. Must be a valid numeric value.</param>
        /// <returns>A double representing the approximate number of months corresponding to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 30.417;
            return result;
        }

        /// <summary>
        /// Converts a number of days to the equivalent number of weeks.
        /// </summary>
        /// <param name="val">The number of days to convert. Must be a valid numeric value.</param>
        /// <returns>The number of weeks equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 7;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in hours.
        /// </summary>
        /// <param name="val">The number of days to convert to hours. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of hours for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 24;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of minutes.
        /// </summary>
        /// <param name="val">The number of days to convert to minutes. Must not be NaN.</param>
        /// <returns>The equivalent number of minutes for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1440;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of days to convert to seconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the total number of seconds equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The number of days to convert to milliseconds. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the specified number of days in milliseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400000;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of days to convert to microseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of microseconds for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The number of days to convert to nanoseconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400000000000;
            return result;
        }
    }
}
