using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting mass values from kilograms to various other units of measurement,
    /// including metric tons, grams, milligrams, micrograms, long tons, short tons, stones, pounds, and ounces.
    /// </summary>
    /// <remarks>All conversion methods require the input value to be a valid double that is not <see
    /// cref="double.NaN"/>. If an invalid value is provided, an <see cref="ArgumentException"/> is thrown. This class
    /// is intended for use in scenarios where precise mass unit conversions are needed, such as scientific
    /// calculations, engineering applications, or data processing involving international units.</remarks>
    public static class Kilogram
    {
        /// <summary>
        /// Converts the specified value from kilograms to metric tons.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from kilograms to grams.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to micrograms.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to long tons (imperial tons).
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons. Returns 0 if the input value is 0.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000984;
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
            double result = val * 0.0011023;
            return result;
        }

        /// <summary>
        /// Converts a weight value from kilograms to stones.
        /// </summary>
        /// <remarks>One stone is equal to approximately 6.35029 kilograms. This method uses a conversion
        /// factor of 0.15747 to convert kilograms to stones.</remarks>
        /// <param name="val">The weight in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.15747;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to its equivalent weight in pounds.
        /// </summary>
        /// <param name="val">The weight in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in pounds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2.2046;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to its equivalent in ounces.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 35.274;
            return result;
        }
    }
}
