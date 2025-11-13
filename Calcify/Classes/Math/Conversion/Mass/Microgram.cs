using System;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting mass values between micrograms and other units of measurement, including
    /// tons, kilograms, grams, milligrams, stones, pounds, and ounces.
    /// </summary>
    /// <remarks>All conversion methods validate that the input value is not <see cref="double.NaN"/> and
    /// throw an <see cref="ArgumentException"/> if this condition is not met. The class is intended for use in
    /// scenarios where precise mass unit conversions are required, and does not perform range or overflow checks beyond
    /// NaN validation.</remarks>
    public static class Microgram
    {
        /// <summary>
        /// Converts the specified value from units to trillions (tons).
        /// </summary>
        /// <param name="val">The numeric value to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in trillions (tons) as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanograms to kilograms.
        /// </summary>
        /// <param name="val">The mass value in nanograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanograms to grams.
        /// </summary>
        /// <param name="val">The value in nanograms to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
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
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a mass value from nanograms to long tons.
        /// </summary>
        /// <param name="val">The mass value in nanograms to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000000098421;
            return result;
        }

        /// <summary>
        /// Converts a value from picograms to short tons (U.S. tons).
        /// </summary>
        /// <remarks>A short ton is equal to 2,000 pounds. This method uses a fixed conversion factor of
        /// 1.1023 × 10⁻¹² to convert picograms to short tons.</remarks>
        /// <param name="val">The mass value in picograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000000011023;
            return result;
        }

        /// <summary>
        /// Converts a mass value from nanograms to stones.
        /// </summary>
        /// <remarks>One stone is equal to 6,350,293,180 nanograms. This method does not validate the
        /// range of the input value beyond checking for <see cref="double.NaN"/>.</remarks>
        /// <param name="val">The mass value, in nanograms, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent mass in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000015747;
            return result;
        }

        /// <summary>
        /// Converts a value in nanograms to pounds.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 0.0000000022046 to convert nanograms to
        /// pounds.</remarks>
        /// <param name="val">The mass value in nanograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000022046;
            return result;
        }

        /// <summary>
        /// Converts a value in milligrams to its equivalent in ounces.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 0.000000035274 to convert milligrams to
        /// ounces.</remarks>
        /// <param name="val">The value in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000000035274;
            return result;
        }
    }
}
