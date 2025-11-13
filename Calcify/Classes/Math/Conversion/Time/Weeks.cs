using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting time values between weeks and other units, including days, hours,
    /// minutes, seconds, months, years, decades, centuries, and various time intervals.
    /// </summary>
    /// <remarks>All conversion methods require valid numeric input values and will throw an ArgumentException
    /// if the provided value is NaN. Conversion factors are based on standard or average values and may result in
    /// approximate results for units such as months, years, or decades. This class is thread-safe and intended for
    /// utility use in time-related calculations.</remarks>
    public static class Weeks
    {
        /// <summary>
        /// Converts a value representing days to its equivalent in centuries.
        /// </summary>
        /// <param name="val">The number of days to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 5214.3;
            return result;
        }

        /// <summary>
        /// Converts a value from years to decades using a fixed conversion factor.
        /// </summary>
        /// <remarks>This method uses a conversion factor of 521.43 years per decade. The result may not
        /// reflect standard calendar decades and is based on the specified factor.</remarks>
        /// <param name="val">The number of years to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of decades.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 521.43;
            return result;
        }
        /// <summary>
        /// Converts a value representing weeks to its equivalent in years.
        /// </summary>
        /// <remarks>The conversion uses 52.143 weeks per year as the basis for calculation.</remarks>
        /// <param name="val">The number of weeks to convert. Must be a valid numeric value.</param>
        /// <returns>A double representing the equivalent number of years for the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 52.143;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of months using an average month length.
        /// </summary>
        /// <remarks>This method uses an average month length of 4.345 weeks (approximately 30.44 days)
        /// for the conversion. The result is an approximation and may not reflect calendar month boundaries.</remarks>
        /// <param name="val">The number of days to convert to months. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the approximate number of months corresponding to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 4.345;
            return result;
        }

        /// <summary>
        /// Converts the specified number of weeks to the equivalent number of days.
        /// </summary>
        /// <param name="val">The number of weeks to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the total number of days corresponding to the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 7;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing weeks, to the equivalent number of hours.
        /// </summary>
        /// <param name="val">The number of weeks to convert to hours. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the total number of hours in the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 168;
            return result;
        }

        /// <summary>
        /// Converts a value representing weeks to the equivalent number of minutes.
        /// </summary>
        /// <param name="val">The number of weeks to convert to minutes. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent number of minutes for the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 10080;
            return result;
        }

        /// <summary>
        /// Converts a value representing weeks to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of weeks to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The number of seconds equivalent to the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800;
            return result;
        }

        /// <summary>
        /// Converts a value representing weeks to its equivalent duration in milliseconds.
        /// </summary>
        /// <param name="val">The number of weeks to convert. Must be a valid numeric value; cannot be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the specified number of weeks in milliseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800000;
            return result;
        }

        /// <summary>
        /// Converts a value representing weeks to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of weeks to convert to microseconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of microseconds equivalent to the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800000000;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing weeks, to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The number of weeks to convert to nanoseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800000000000;
            return result;
        }
    }
}
