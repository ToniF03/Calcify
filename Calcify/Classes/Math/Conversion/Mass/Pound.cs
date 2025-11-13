using System;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting mass and weight values between pounds and other common units, including
    /// metric tons, kilograms, grams, milligrams, micrograms, long tons, short tons, stones, and ounces.
    /// </summary>
    /// <remarks>All conversion methods validate that input values are numeric and will throw an exception if
    /// a non-numeric value (NaN) is provided. This class is thread-safe and intended for use in scenarios where
    /// accurate unit conversion between pounds and other mass or weight units is required.</remarks>
    public static class Pound
    {
        /// <summary>
        /// Converts a mass value from pounds to metric tons.
        /// </summary>
        /// <param name="val">The mass value in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2204.6;
            return result;
        }

        /// <summary>
        /// Converts a weight value from pounds to kilograms.
        /// </summary>
        /// <param name="val">The weight in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2.2046;
            return result;
        }

        /// <summary>
        /// Converts a weight value from pounds to grams.
        /// </summary>
        /// <param name="val">The weight in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0022046;
            return result;
        }

        /// <summary>
        /// Converts a value in pounds to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000022046;
            return result;
        }

        /// <summary>
        /// Converts a mass value from pounds to micrograms.
        /// </summary>
        /// <param name="val">The mass value in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000022046;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to long tons (imperial tons).
        /// </summary>
        /// <remarks>One long ton is equal to 1,016.0469088 kilograms. This method uses a conversion
        /// factor of 0.00044643 for approximate conversion.</remarks>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00044643;
            return result;
        }

        /// <summary>
        /// Converts a mass value from kilograms to short tons (U.S. tons).
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons. One short ton is equal to 2,000 pounds or approximately 907.185
        /// kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00050000;
            return result;
        }

        /// <summary>
        /// Converts a weight value from kilograms to stones.
        /// </summary>
        /// <param name="val">The weight in kilograms to convert. Must be a valid numeric value.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.071429;
            return result;
        }

        /// <summary>
        /// Converts a value in pounds to its equivalent in ounces.
        /// </summary>
        /// <remarks>One pound is equal to 16 ounces. This method multiplies the input value by 16 to
        /// perform the conversion.</remarks>
        /// <param name="val">The value in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 16;
            return result;
        }
    }
}
