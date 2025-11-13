using System;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting mass values between grams and other common metric and imperial units.
    /// </summary>
    /// <remarks>This class includes conversion methods for kilograms, metric tons, milligrams, micrograms,
    /// long tons, short tons, stones, pounds, and ounces. All methods require valid numeric input values and will throw
    /// an exception if the input is not a number (NaN). The class is thread-safe and intended for use in scenarios
    /// where precise mass unit conversions are required.</remarks>
    public static class Gram
    {
        /// <summary>
        /// Converts a value from kilograms to metric tons.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to its equivalent in kilograms.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from grams to micrograms.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in micrograms to long tons.
        /// </summary>
        /// <param name="val">The value in micrograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000098421;
            return result;
        }

        /// <summary>
        /// Converts a mass value from micrograms to short tons.
        /// </summary>
        /// <param name="val">The mass value in micrograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000011023;
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
            double result = val * 0.00015747;
            return result;
        }

        /// <summary>
        /// Converts a mass value from grams to pounds.
        /// </summary>
        /// <param name="val">The mass value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0022046;
            return result;
        }

        /// <summary>
        /// Converts a mass value from grams to ounces.
        /// </summary>
        /// <param name="val">The mass value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.035274;
            return result;
        }
    }
}
