namespace Calcify.Classes.Math.Conversion.Temperature
{
    /// <summary>
    /// Provides static methods for converting temperature values between Kelvin and other temperature scales.
    /// </summary>
    /// <remarks>This class includes methods for converting Kelvin temperatures to Celsius, Fahrenheit,
    /// Réaumur, and for converting Celsius to Rankine. All methods are static and do not perform validation for
    /// physically meaningful temperature ranges; callers should ensure input values are appropriate for the desired
    /// conversion. The class is intended for use in scientific, engineering, or educational applications where
    /// temperature conversions are required.</remarks>
    public static class Kelvin
    {

        /// <summary>
        /// Converts a temperature value from Kelvin to Celsius.
        /// </summary>
        /// <param name="val">The temperature in Kelvin to convert. Must be greater than or equal to 0.</param>
        /// <returns>The equivalent temperature in Celsius.</returns>
        public static double ToCelsius(double val)
        {
            double result = val - 273.15;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from Kelvin to Fahrenheit.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the standard formula. Negative Kelvin
        /// values are not physically meaningful and may result in unexpected output.</remarks>
        /// <param name="val">The temperature in Kelvin to convert. Must be greater than or equal to 0.</param>
        /// <returns>The equivalent temperature in Fahrenheit.</returns>
        public static double ToFahrenheit(double val)
        {
            double result = (val - 273.15) * 1.8 + 32.00;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Celsius to degrees Rankine.
        /// </summary>
        /// <param name="val">The temperature value in degrees Celsius to convert.</param>
        /// <returns>The equivalent temperature in degrees Rankine.</returns>
        public static double ToRankine(double val)
        {
            double result = val * 1.8;
            return result;
        }

        /// <summary>
        /// Converts a temperature from Kelvin to Réaumur.
        /// </summary>
        /// <remarks>The Réaumur scale sets the freezing point of water at 0° and the boiling point at
        /// 80°. This method does not validate that the input is above absolute zero; passing a value less than 0 may
        /// result in nonsensical results.</remarks>
        /// <param name="val">The temperature value in Kelvin to convert. Must be greater than or equal to absolute zero (0 K).</param>
        /// <returns>The equivalent temperature in degrees Réaumur.</returns>
        public static double ToReaumur(double val)
        {
            double result = (val - 273.15) * 0.8;
            return result;
        }
    }
}
