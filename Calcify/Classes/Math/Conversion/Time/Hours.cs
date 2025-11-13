using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting time values between hours and other units, including centuries, decades,
    /// years, months, weeks, days, minutes, seconds, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume fixed conversion factors and do not account for calendar
    /// variations such as leap years or differing month lengths. Each method throws an ArgumentException if the input
    /// value is not a valid number (NaN). These methods are intended for approximate calculations and should not be
    /// used where precise calendar-based conversions are required.</remarks>
    public static class Hours
    {
        /// <summary>
        /// Converts a time value, specified in hours, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is considered to be 876,000 hours. The conversion divides the input value
        /// by this constant.</remarks>
        /// <param name="val">The time value in hours to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 876000;
            return result;
        }

        /// <summary>
        /// Converts a time value from hours to decades.
        /// </summary>
        /// <remarks>One decade is considered to be 87,600 hours. This method performs a direct division
        /// without rounding.</remarks>
        /// <param name="val">The time value, in hours, to convert to decades. Must not be NaN.</param>
        /// <returns>The equivalent time in decades as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 87600;
            return result;
        }

        /// <summary>
        /// Converts a time value from hours to years.
        /// </summary>
        /// <remarks>This method assumes a year consists of 8,760 hours (365 days). For leap years or more
        /// precise calculations, consider adjusting the conversion factor.</remarks>
        /// <param name="val">The time value, in hours, to convert to years. Must not be NaN.</param>
        /// <returns>The equivalent time in years, calculated by dividing the input value by 8,760.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 8760;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of months using a fixed average month length.
        /// </summary>
        /// <remarks>This method uses 730.001 days as the average length of a month for conversion. The
        /// result may not correspond to calendar months and is intended for approximate calculations.</remarks>
        /// <param name="val">The number of days to convert to months. Must be a valid numeric value.</param>
        /// <returns>A double representing the equivalent number of months for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 730.001;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in hours, to its equivalent in weeks.
        /// </summary>
        /// <remarks>One week is considered to be 168 hours.</remarks>
        /// <param name="val">The time value in hours to convert. Must not be NaN.</param>
        /// <returns>The number of weeks equivalent to the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 168;
            return result;
        }

        /// <summary>
        /// Converts a time value from hours to days.
        /// </summary>
        /// <param name="val">The time value, in hours, to convert to days. Must not be NaN.</param>
        /// <returns>The equivalent time in days, calculated as the input value divided by 24.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 24;
            return result;
        }

        /// <summary>
        /// Converts a value in hours to its equivalent in minutes.
        /// </summary>
        /// <param name="val">The number of hours to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of minutes for the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60;
            return result;
        }

        /// <summary>
        /// Converts a value representing hours to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of hours to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of seconds for the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600;
            return result;
        }

        /// <summary>
        /// Converts a value representing hours to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The number of hours to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of milliseconds for the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600000;
            return result;
        }

        /// <summary>
        /// Converts a value in hours to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of hours to convert to microseconds. Must not be NaN.</param>
        /// <returns>The equivalent value in microseconds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600000000;
            return result;
        }

        /// <summary>
        /// Converts the specified value in hours to nanoseconds.
        /// </summary>
        /// <param name="val">The value, in hours, to convert to nanoseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified value in hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600000000000;
            return result;
        }
    }
}
