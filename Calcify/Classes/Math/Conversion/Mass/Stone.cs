using System;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting between various units of mass, including stones, kilograms, tons, carats,
    /// grams, milligrams, micrograms, pounds, and ounces.
    /// </summary>
    /// <remarks>All conversion methods validate input values to ensure they are valid numbers and will throw
    /// an exception if a value is NaN. This class is intended for use in scenarios where precise mass unit conversions
    /// are required, such as scientific calculations or weight measurement applications. All methods are thread-safe
    /// and can be used concurrently.</remarks>
    public static class Stone
    {
        /// <summary>
        /// Converts a value in kilograms to metric tons.
        /// </summary>
        /// <param name="val">The mass in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 157.47;
            return result;
        }

        /// <summary>
        /// Converts a value in stones to its equivalent weight in kilograms.
        /// </summary>
        /// <remarks>One stone is equal to approximately 6.35029 kilograms. This method uses a conversion
        /// factor of 0.15747 stones per kilogram.</remarks>
        /// <param name="val">The weight in stones to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.15747;
            return result;
        }

        /// <summary>
        /// Converts a value from carats to grams.
        /// </summary>
        /// <param name="val">The value in carats to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00015747;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000015747;
            return result;
        }

        /// <summary>
        /// Converts a value from grams to micrograms.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000015747;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to long tons (imperial tons).
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0062500;
            return result;
        }

        /// <summary>
        /// Converts a mass value from kilograms to short tons (U.S. tons).
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0070000;
            return result;
        }

        /// <summary>
        /// Converts a value in stones to its equivalent weight in pounds.
        /// </summary>
        /// <remarks>One stone is equal to 14 pounds. This method multiplies the input value by 14 to
        /// perform the conversion.</remarks>
        /// <param name="val">The weight in stones to convert. Must be a valid number.</param>
        /// <returns>The equivalent weight in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 14;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to ounces using a fixed conversion factor.
        /// </summary>
        /// <remarks>This method uses a conversion factor of 224 to convert grams to ounces. Ensure that
        /// the input value is a valid number.</remarks>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 224;
            return result;
        }
    }
}
