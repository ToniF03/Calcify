namespace Calcify.Classes.Math.Conversion.Temperature
{
    /// <summary>
    /// Provides static methods for converting temperatures from degrees Celsius to other temperature scales, including
    /// Kelvin, Fahrenheit, Rankine, and Réaumur.
    /// </summary>
    /// <remarks>This class is intended for use in scientific, engineering, and general applications where
    /// temperature conversions from the Celsius scale are required. All methods are static and do not require
    /// instantiation. The conversion formulas used are based on standard definitions for each temperature
    /// scale.</remarks>
    public static class Celsius
    {

        /// <summary>
        /// Converts a temperature from degrees Celsius to Kelvin.
        /// </summary>
        /// <param name="val">The temperature value in degrees Celsius to convert. Can be any real number.</param>
        /// <returns>The equivalent temperature in Kelvin.</returns>
        public static double ToKelvin(double val)
        {
            double result = val + 273.15;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from degrees Celsius to degrees Fahrenheit.
        /// </summary>
        /// <param name="val">The temperature in degrees Celsius to convert.</param>
        /// <returns>The equivalent temperature in degrees Fahrenheit.</returns>
        public static double ToFahrenheit(double val)
        {
            double result = (val * 1.8) + 32;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Celsius to degrees Rankine.
        /// </summary>
        /// <remarks>Use this method when working with thermodynamic calculations that require
        /// temperatures in the Rankine scale. The conversion uses the formula: Rankine = (Celsius × 1.8) +
        /// 491.67.</remarks>
        /// <param name="val">The temperature value in degrees Celsius to convert. Typically represents an absolute or relative
        /// temperature measurement.</param>
        /// <returns>The equivalent temperature in degrees Rankine.</returns>
        public static double ToRankine(double val)
        {
            double result = (val * 1.8) + 491.67;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Celsius to degrees Réaumur.
        /// </summary>
        /// <param name="val">The temperature value in degrees Celsius to convert.</param>
        /// <returns>The equivalent temperature in degrees Réaumur.</returns>
        public static double ToReaumur(double val)
        {
            double result = val * 0.8;
            return result;
        }
    }
}
