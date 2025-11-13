using System;

namespace Calcify.Classes.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting time durations expressed in months or years to other units such as
    /// centuries, decades, years, weeks, days, hours, minutes, seconds, milliseconds, microseconds, and nanoseconds.
    /// All conversions use standard or average values for each unit and are intended for approximate calculations.
    /// </summary>
    /// <remarks>The conversion methods in this class use fixed or average values for time units (e.g.,
    /// average days per month, hours per month, days per year) and may not reflect exact calendar durations. These
    /// methods are suitable for general-purpose or approximate calculations, but may not be appropriate for scenarios
    /// requiring precise date or time computations. All methods validate input values and throw an ArgumentException if
    /// the input is NaN.</remarks>
    public static class Months
    {
        /// <summary>
        /// Converts a value representing months to its equivalent in centuries.
        /// </summary>
        /// <param name="val">The number of months to convert. Must not be NaN.</param>
        /// <returns>A double value representing the number of centuries equivalent to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1200;
            return result;
        }

        /// <summary>
        /// Converts a value representing months to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is defined as 120 months. The conversion divides the input value by
        /// 120.</remarks>
        /// <param name="val">The number of months to convert. Must not be NaN.</param>
        /// <returns>A double value representing the number of decades equivalent to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 120;
            return result;
        }

        /// <summary>
        /// Converts a value in months to its equivalent in years.
        /// </summary>
        /// <param name="val">The number of months to convert. Must not be NaN.</param>
        /// <returns>The number of years equivalent to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 12;
            return result;
        }

        /// <summary>
        /// Converts a value in months to its approximate equivalent in weeks.
        /// </summary>
        /// <remarks>This method uses an average conversion factor of 4.345 weeks per month, which may not
        /// reflect the exact number of weeks in every month.</remarks>
        /// <param name="val">The number of months to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The approximate number of weeks corresponding to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 4.345;
            return result;
        }

        /// <summary>
        /// Converts a value representing months to the equivalent number of days using an average month length.
        /// </summary>
        /// <remarks>This method uses an average month length of 30.417 days for the conversion. The
        /// result may not be precise for calendar calculations that require exact day counts.</remarks>
        /// <param name="val">The number of months to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the approximate number of days corresponding to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 30.417;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing months, to the equivalent number of hours.
        /// </summary>
        /// <remarks>This method assumes a fixed value of 730 hours per month, which may not reflect
        /// actual calendar month durations. Use this conversion for approximate calculations where such precision is
        /// acceptable.</remarks>
        /// <param name="val">The number of months to convert to hours. Must not be NaN.</param>
        /// <returns>A double value representing the total number of hours in the specified number of months, assuming each month
        /// has 730 hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 730;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of minutes.
        /// </summary>
        /// <remarks>This method assumes a year consists of 43,800 minutes, based on a 365-day year. Leap
        /// years are not accounted for.</remarks>
        /// <param name="val">The number of years to convert to minutes. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent number of minutes for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 43800;
            return result;
        }

        /// <summary>
        /// Converts a value representing months into the equivalent number of seconds.
        /// </summary>
        /// <remarks>This method assumes a fixed conversion rate of 2,628,000 seconds per month, which may
        /// not reflect the exact number of seconds in all calendar months.</remarks>
        /// <param name="val">The number of months to convert to seconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent number of seconds for the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000;
            return result;
        }

        /// <summary>
        /// Converts a value representing months into the equivalent number of milliseconds.
        /// </summary>
        /// <remarks>This method assumes a fixed month length of 30.44 days (the average length of a month
        /// in the Gregorian calendar) when performing the conversion.</remarks>
        /// <param name="val">The number of months to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the total number of milliseconds equivalent to the specified
        /// number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from years to microseconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365.25 days to account for leap
        /// years.</remarks>
        /// <param name="val">The number of years to convert. Must not be NaN.</param>
        /// <returns>The equivalent number of microseconds represented by the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in years to its equivalent duration in nanoseconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365.25 days for conversion purposes.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent duration in nanoseconds as a double-precision floating-point value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000000000000;
            return result;
        }
    }
}
