namespace Calcify.Classes.Math.Conversion.Temperature
{
    /// <summary>
    /// Provides static methods for converting temperature values between a custom scale used by the application and
    /// standard temperature units such as Fahrenheit, Celsius, Kelvin, and Rankine.
    /// </summary>
    /// <remarks>The conversion methods assume input values are expressed in a custom scale where 0.8 units
    /// correspond to 1 degree Celsius. Ensure that temperature values are in the expected scale before using these
    /// methods. These methods are intended for scenarios where interoperability between the application's custom
    /// temperature scale and standard units is required.</remarks>
    public static class Reaumur
    {
        /// <summary>
        /// Converts a temperature value from the custom scale used by the application to degrees Fahrenheit.
        /// </summary>
        /// <remarks>The conversion assumes the input value is in a custom scale where 0.8 units
        /// correspond to 1 degree Celsius. Use this method only with values measured in that scale.</remarks>
        /// <param name="val">The temperature value to convert, expressed in the application's custom scale.</param>
        /// <returns>The equivalent temperature in degrees Fahrenheit.</returns>
        public static double ToFahrenheit(double val)
        {
            double result = ((val / 0.8) * 1.8) + 32;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from a scale where 0.8 units equal 1 degree Celsius to degrees Celsius.
        /// </summary>
        /// <param name="val">The temperature value to convert, expressed in units where 0.8 units equal 1 degree Celsius.</param>
        /// <returns>The equivalent temperature in degrees Celsius.</returns>
        public static double ToCelsius(double val)
        {
            double result = val / 0.8;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from an unspecified scale to Kelvin using a linear transformation.
        /// </summary>
        /// <remarks>This method assumes the input value is in a scale where dividing by 0.8 and adding
        /// 273.15 yields the Kelvin temperature. Ensure the input value is in the expected scale before calling this
        /// method.</remarks>
        /// <param name="val">The temperature value to convert. Represents a value in a scale where 0.8 units correspond to 1 Kelvin.</param>
        /// <returns>The equivalent temperature in Kelvin.</returns>
        public static double ToKelvin(double val)
        {
            double result = (val / 0.8) + 273.15;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from Celsius to Rankine.
        /// </summary>
        /// <remarks>Use this method when working with thermodynamic calculations that require
        /// temperatures in the Rankine scale. The conversion uses the formula: Rankine = Celsius × 2.25 +
        /// 491.67.</remarks>
        /// <param name="val">The temperature in degrees Celsius to convert. Typically represents an absolute temperature; negative values
        /// are allowed.</param>
        /// <returns>The equivalent temperature in degrees Rankine.</returns>
        public static double ToRankine(double val)
        {
            double result = val * 2.2500 + 491.67;
            return result;
        }
    }
}
