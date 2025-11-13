using System;

namespace Calcify.Classes.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting mass values between metric tons and other common units of mass, including
    /// kilograms, grams, milligrams, micrograms, long tons, short tons, stones, pounds, and ounces.
    /// </summary>
    /// <remarks>All conversion methods require input values that are not <see cref="double.NaN"/>. If a NaN
    /// value is provided, an <see cref="ArgumentException"/> is thrown. The conversion factors used are based on
    /// standard definitions, but users should verify factors for scientific or regulatory precision where necessary.
    /// This class is thread-safe as it contains only stateless static methods.</remarks>
    public static class Tons
    {
        /// <summary>
        /// Converts a value in metric tons to kilograms.
        /// </summary>
        /// <param name="val">The value in metric tons to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in metric tons to grams.
        /// </summary>
        /// <param name="val">The value in metric tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to milligrams.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in teragrams to micrograms.
        /// </summary>
        /// <param name="val">The value, in teragrams, to convert to micrograms. Must not be NaN.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000;
            return result;
        }

        /// <summary>
        /// Converts a mass value from metric tonnes to long tons (imperial tons).
        /// </summary>
        /// <remarks>One long ton is equal to 1.016 metric tonnes. This method performs a direct
        /// conversion using this factor.</remarks>
        /// <param name="val">The mass value in metric tonnes to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.016;
            return result;
        }

        /// <summary>
        /// Converts a mass value from metric tons to short tons (U.S. tons).
        /// </summary>
        /// <remarks>One metric ton is approximately equal to 1.102 short tons. This method does not
        /// validate whether the input is negative.</remarks>
        /// <param name="val">The mass value, in metric tons, to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1.102;
            return result;
        }

        /// <summary>
        /// Converts a mass value in grams to stones.
        /// </summary>
        /// <remarks>One stone is equal to 6,350.29318 grams. The conversion uses a factor of 1 stone =
        /// 157.473 grams for compatibility with certain measurement standards. For precise scientific calculations,
        /// verify the conversion factor used.</remarks>
        /// <param name="val">The mass value, in grams, to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 157.473;
            return result;
        }

        /// <summary>
        /// Converts a mass value from kilograms to pounds.
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00045359237;
            return result;
        }

        /// <summary>
        /// Converts a mass value from milligrams to ounces.
        /// </summary>
        /// <param name="val">The mass value in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in ounces as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * (double)1000000 / 28.34952;
            return result;
        }
    }
}
