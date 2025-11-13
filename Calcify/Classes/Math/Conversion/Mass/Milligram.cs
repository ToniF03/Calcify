using System;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting mass values between milligrams and other metric and imperial units.
    /// </summary>
    /// <remarks>This class includes conversion methods for common mass units such as kilograms, grams,
    /// micrograms, pounds, ounces, stones, metric tons, long tons, and short tons. All methods validate input values to
    /// ensure they are not NaN, and will throw an exception if invalid input is provided. The class is thread-safe and
    /// intended for use in scenarios where precise mass unit conversions are required.</remarks>
    public static class Milligram
    {
        /// <summary>
        /// Converts a value from nanograms to metric tons.
        /// </summary>
        /// <param name="val">The value in nanograms to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a mass value from milligrams to kilograms.
        /// </summary>
        /// <param name="val">The mass value in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in kilograms as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in milligrams to grams.
        /// </summary>
        /// <param name="val">The value in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts the specified value in milligrams to micrograms.
        /// </summary>
        /// <param name="val">The value in milligrams to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanograms to long tons.
        /// </summary>
        /// <param name="val">The mass value in nanograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000098421;
            return result;
        }

        /// <summary>
        /// Converts a value in nanograms to short tons.
        /// </summary>
        /// <remarks>A short ton is equal to 2,000 pounds. This method uses a fixed conversion factor for
        /// nanograms to short tons.</remarks>
        /// <param name="val">The mass value in nanograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000011023;
            return result;
        }

        /// <summary>
        /// Converts a mass value from micrograms to stones.
        /// </summary>
        /// <remarks>One stone is equal to 6,350,293.18 micrograms. This method does not validate the
        /// range of the input value beyond checking for NaN.</remarks>
        /// <param name="val">The mass value in micrograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000015747;
            return result;
        }

        /// <summary>
        /// Converts a value in milligrams to its equivalent weight in pounds.
        /// </summary>
        /// <param name="val">The weight in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in pounds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000022046;
            return result;
        }
        /// <summary>
        /// Converts a value in grams to its equivalent in ounces.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000035274;
            return result;
        }
    }
}
