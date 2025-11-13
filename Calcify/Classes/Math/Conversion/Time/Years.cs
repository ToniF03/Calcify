using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting a value representing years to equivalent durations in other time units,
    /// such as centuries, decades, months, weeks, days, hours, minutes, seconds, milliseconds, microseconds, and
    /// nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume standard calendar values (e.g., 365 days per year) and do not
    /// account for leap years or calendar variations unless otherwise noted. Methods will throw an ArgumentException if
    /// the input value is NaN.</remarks>
    public static class Years
    {
        /// <summary>
        /// Converts a value representing years to its equivalent in centuries.
        /// </summary>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in decades.
        /// </summary>
        /// <param name="val">The number of years to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the number of decades equivalent to the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in months.
        /// </summary>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of months for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 12;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of weeks.
        /// </summary>
        /// <remarks>The conversion uses an average of 52.1429 weeks per year, which accounts for leap
        /// years over a 400-year cycle.</remarks>
        /// <param name="val">The number of years to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of weeks for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 52.1429;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of days.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365 days and does not account for leap years
        /// or calendar variations.</remarks>
        /// <param name="val">The number of years to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the equivalent number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 365;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of hours.
        /// </summary>
        /// <remarks>This method assumes a year consists of 8,760 hours (365 days). Leap years are not
        /// accounted for.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of hours for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8760;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of minutes.
        /// </summary>
        /// <remarks>This method assumes a year consists of 525,600 minutes (i.e., 365 days). Leap years
        /// are not accounted for.</remarks>
        /// <param name="val">The number of years to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The number of minutes equivalent to the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 525600;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in seconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of exactly 31,536,000 seconds (365 days). Leap
        /// years and variations in calendar systems are not accounted for.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of seconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent duration in milliseconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365 days and does not account for leap years
        /// or calendar variations.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent duration in milliseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of years to convert to microseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of microseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The number of years to convert to nanoseconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000000000000;
            return result;
        }
    }
}
