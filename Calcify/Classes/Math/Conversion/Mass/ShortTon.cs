using System;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting mass and weight values between short tons and other common units,
    /// including kilograms, grams, milligrams, micrograms, pounds, ounces, stones, and long tons.
    /// </summary>
    /// <remarks>All conversion methods use fixed conversion factors based on standard definitions for each
    /// unit. Input values must not be NaN; otherwise, an ArgumentException is thrown. This class is thread-safe and
    /// intended for utility use in applications requiring mass or weight conversions.</remarks>
    public static class ShortTon
    {
        /// <summary>
        /// Converts a value in kilograms to its equivalent in tons.
        /// </summary>
        /// <remarks>One ton is defined as 1,102.3 kilograms. This method performs a direct conversion
        /// using this factor.</remarks>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in tons as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.1023;
            return result;
        }

        /// <summary>
        /// Converts a weight value from short tons to kilograms.
        /// </summary>
        /// <param name="val">The weight value, in short tons, to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0011023;
            return result;
        }

        /// <summary>
        /// Converts a value in tons to its equivalent weight in grams.
        /// </summary>
        /// <param name="val">The weight in tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in grams as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000011023;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value, in ounces, to convert to milligrams. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000011023;
            return result;
        }

        /// <summary>
        /// Converts a mass value from short tons to micrograms.
        /// </summary>
        /// <param name="val">The mass value, in short tons, to convert to micrograms. Must not be NaN.</param>
        /// <returns>The equivalent mass in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000000011023;
            return result;
        }

        /// <summary>
        /// Converts a mass value from metric tons to long tons (imperial tons).
        /// </summary>
        /// <remarks>A long ton, also known as an imperial ton, is equal to 2,240 pounds. This method uses
        /// a fixed conversion factor of 0.89286 to convert metric tons to long tons.</remarks>
        /// <param name="val">The mass value in metric tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons. The result is calculated as metric tons multiplied by 0.89286.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.89286;
            return result;
        }

        /// <summary>
        /// Converts a weight value in grams to stones.
        /// </summary>
        /// <remarks>One stone is equal to 142.86 grams. The conversion does not round the
        /// result.</remarks>
        /// <param name="val">The weight value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 142.86;
            return result;
        }

        /// <summary>
        /// Converts a weight value from tons to pounds.
        /// </summary>
        /// <remarks>One ton is considered equal to 2,000 pounds. This method does not perform range
        /// validation on the input value.</remarks>
        /// <param name="val">The weight in tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2000;
            return result;
        }

        /// <summary>
        /// Converts a value in metric tons to ounces.
        /// </summary>
        /// <param name="val">The value, in metric tons, to convert to ounces. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 32000;
            return result;
        }
    }
}
