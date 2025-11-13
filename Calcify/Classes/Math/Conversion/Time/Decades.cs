using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting between various time units, such as decades, centuries, years, months,
    /// days, hours, minutes, seconds, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume fixed conversion factors and do not account for calendar
    /// variations such as leap years unless otherwise noted. Input values must be valid numeric values and cannot be
    /// NaN; methods will throw an ArgumentException if invalid input is provided.</remarks>
    public static class Decades
    {
        /// <summary>
        /// Converts a value representing decades to its equivalent in centuries.
        /// </summary>
        /// <param name="val">The number of decades to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of decades.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in years.
        /// </summary>
        /// <param name="val">The value to convert. Must be a valid number; cannot be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the input value converted to years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in months.
        /// </summary>
        /// <param name="val">The value to convert to months. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the converted value in months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 120;
            return result;
        }

        /// <summary>
        /// Converts a value from days to weeks using a fixed conversion factor.
        /// </summary>
        /// <remarks>The conversion uses a factor of 521.429 to calculate weeks from days. This method
        /// does not validate whether the input value is within a typical range for days.</remarks>
        /// <param name="val">The number of days to convert to weeks. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of weeks for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 521.429;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing years, to the equivalent number of days.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365 days. Leap years are not accounted for in
        /// the conversion.</remarks>
        /// <param name="val">The number of years to convert to days. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the equivalent number of days for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3650;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of hours.
        /// </summary>
        /// <remarks>This method assumes a year consists of 8,760 hours (365 days). Leap years are not
        /// accounted for in the calculation.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The number of hours equivalent to the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 87600;
            return result;
        }

        /// <summary>
        /// Converts a value representing millennia to the equivalent number of minutes.
        /// </summary>
        /// <param name="val">The number of millennia to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The total number of minutes corresponding to the specified number of millennia.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 5256000;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing centuries, to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of centuries to convert to seconds. Must not be NaN.</param>
        /// <returns>The number of seconds equivalent to the specified number of centuries.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent duration in milliseconds.
        /// </summary>
        /// <param name="val">The number of years to convert to milliseconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent duration in milliseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of years to convert to microseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of microseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in nanoseconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365 days. Leap years and calendar variations
        /// are not considered.</remarks>
        /// <param name="val">The number of years to convert to nanoseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000000000000;
            return result;
        }
    }
}
