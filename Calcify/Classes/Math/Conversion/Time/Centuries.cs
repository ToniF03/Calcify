using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting between centuries, millennia, years, and other time units using fixed
    /// conversion factors.
    /// </summary>
    /// <remarks>All conversion methods assume standard calendar years and do not account for leap years or
    /// calendar variations. Each method throws an ArgumentException if the input value is NaN.</remarks>
    public static class Centuries
    {
        /// <summary>
        /// Converts a value representing years to its equivalent in decades.
        /// </summary>
        /// <param name="val">The number of years to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of decades.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in years by multiplying it by 100.
        /// </summary>
        /// <param name="val">The value to convert to years. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the input value converted to years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in months.
        /// </summary>
        /// <param name="val">The value to convert. Must be a valid number; cannot be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the converted value in months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1200;
            return result;
        }

        /// <summary>
        /// Converts the specified value to an equivalent number of weeks using a fixed conversion factor.
        /// </summary>
        /// <param name="val">The value to convert to weeks. Must be a valid number; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of weeks for the specified value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 5214.29;
            return result;
        }

        /// <summary>
        /// Converts a value representing centuries to the equivalent number of days.
        /// </summary>
        /// <param name="val">The number of centuries to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The number of days equivalent to the specified number of centuries.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 36500;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing centuries, to the equivalent number of hours.
        /// </summary>
        /// <param name="val">The number of centuries to convert to hours. Must not be NaN.</param>
        /// <returns>The equivalent number of hours for the specified number of centuries.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 876000;
            return result;
        }

        /// <summary>
        /// Converts a value representing centuries to the equivalent number of minutes.
        /// </summary>
        /// <param name="val">The number of centuries to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The total number of minutes in the specified number of centuries.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 52560000;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing millennia, to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of millennia to convert to seconds. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the equivalent number of seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000;
            return result;
        }

        /// <summary>
        /// Converts a value representing millennia to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The number of millennia to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of milliseconds for the specified number of millennia.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing millennia to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of millennia to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the equivalent number of microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in nanoseconds.
        /// </summary>
        /// <remarks>One year is considered as 3,153,600,000,000,000,000 nanoseconds. This method does not
        /// account for leap years or calendar variations.</remarks>
        /// <param name="val">The number of years to convert to nanoseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000000000000;
            return result;
        }
    }
}
