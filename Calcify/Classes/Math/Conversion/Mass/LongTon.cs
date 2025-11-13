using System;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting mass and weight values between long tons (imperial tons) and other common
    /// units, including metric tons, kilograms, grams, milligrams, micrograms, short tons, stones, pounds, and ounces.
    /// </summary>
    /// <remarks>All conversion methods validate input values to ensure they are not NaN and throw an
    /// ArgumentException if invalid. The class uses fixed conversion factors for each unit, which may be subject to
    /// floating-point precision limitations. Methods are thread-safe and intended for general-purpose unit conversions
    /// in scientific, engineering, or everyday contexts.</remarks>
    public static class LongTon
    {

        /// <summary>
        /// Converts a mass value from metric tons to long tons (imperial tons).
        /// </summary>
        /// <remarks>One metric ton is approximately equal to 0.98421 long tons. This method does not
        /// perform range checking beyond NaN validation.</remarks>
        /// <param name="val">The mass value, in metric tons, to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.98421;
            return result;
        }

        /// <summary>
        /// Converts a weight value from tons to kilograms.
        /// </summary>
        /// <param name="val">The weight value in tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00098421;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to its equivalent weight in grams.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor based on the relationship between ounces
        /// and grams. The result may be subject to floating-point precision limitations.</remarks>
        /// <param name="val">The weight in ounces to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent weight in grams as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000098421;
            return result;
        }

        /// <summary>
        /// Converts a value from grams to milligrams.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000098421;
            return result;
        }

        /// <summary>
        /// Converts a mass value from grains to micrograms.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 grain = 64,798.91 micrograms. The result may
        /// be subject to floating-point precision limitations.</remarks>
        /// <param name="val">The mass value in grains to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000000098421;
            return result;
        }

        /// <summary>
        /// Converts a value in metric tons to short tons (U.S. tons).
        /// </summary>
        /// <remarks>One metric ton is approximately equal to 1.12 short tons. This method multiplies the
        /// input value by 1.12 to perform the conversion.</remarks>
        /// <param name="val">The value, in metric tons, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1.12;
            return result;
        }

        /// <summary>
        /// Converts the specified value in kilograms to stones.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must be a valid number.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 160;
            return result;
        }

        /// <summary>
        /// Converts a value in long tons to pounds.
        /// </summary>
        /// <param name="val">The value, in long tons, to convert to pounds. Must not be NaN.</param>
        /// <returns>The equivalent weight in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2240;
            return result;
        }

        /// <summary>
        /// Converts a value in tons to its equivalent in ounces.
        /// </summary>
        /// <param name="val">The value, in tons, to convert to ounces. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 35840;
            return result;
        }
    }
}
