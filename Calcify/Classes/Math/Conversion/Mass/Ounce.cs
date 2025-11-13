using System;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting weight and mass values between ounces and other common units, including
    /// grams, kilograms, tons, pounds, stones, milligrams, and micrograms.
    /// </summary>
    /// <remarks>All conversion methods validate that input values are numeric and will throw an exception if
    /// a non-numeric value (NaN) is provided. This class is intended for use in scenarios where precise unit
    /// conversions are required, such as scientific calculations or data processing. Methods do not check for negative
    /// values unless specified; callers should ensure input values are appropriate for their use case.</remarks>
    public static class Ounce
    {
        /// <summary>
        /// Converts a weight value from grams to tons.
        /// </summary>
        /// <remarks>One ton is equal to 35,274 grams. This method performs a direct conversion using this
        /// factor.</remarks>
        /// <param name="val">The weight in grams to convert. Must be a valid numeric value.</param>
        /// <returns>The equivalent weight in tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 35274;
            return result;
        }

        /// <summary>
        /// Converts a weight value from ounces to kilograms.
        /// </summary>
        /// <param name="val">The weight in ounces to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 35.274;
            return result;
        }

        /// <summary>
        /// Converts a weight value from ounces to grams.
        /// </summary>
        /// <param name="val">The weight in ounces to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.035274;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in ounces to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.000035274;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to micrograms.
        /// </summary>
        /// <param name="val">The value in ounces to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.000000035274;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to long tons (imperial tons).
        /// </summary>
        /// <remarks>One long ton is equal to 1,016.0469088 kilograms. This method uses a conversion
        /// factor of 0.000027902 for the calculation.</remarks>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons. Returns 0 if the input is 0.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000027902;
            return result;
        }

        /// <summary>
        /// Converts a value in pounds to its equivalent in short tons.
        /// </summary>
        /// <param name="val">The weight in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000031250;
            return result;
        }

        /// <summary>
        /// Converts a weight value from kilograms to stones.
        /// </summary>
        /// <remarks>One stone is equal to approximately 6.35029 kilograms. This method does not validate
        /// whether the input is negative.</remarks>
        /// <param name="val">The weight in kilograms to convert. Must be a valid numeric value.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0044643;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to its equivalent in pounds.
        /// </summary>
        /// <param name="val">The value in ounces to convert. Must be a valid number.</param>
        /// <returns>The equivalent weight in pounds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.062500;
            return result;
        }
    }
}
