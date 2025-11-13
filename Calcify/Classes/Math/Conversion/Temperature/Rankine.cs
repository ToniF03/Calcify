namespace Calcify.Classes.Math.Conversion.Temperature
{
    /// <summary>
    /// Provides static methods for converting temperatures from degrees Rankine to other temperature scales, including
    /// Fahrenheit, Celsius, Kelvin, and Réaumur.
    /// </summary>
    /// <remarks>All conversion methods assume the input value is a finite number representing a temperature
    /// in degrees Rankine. The methods perform direct mathematical conversions and do not validate the physical
    /// plausibility of the input. Negative or extremely large values are converted according to the respective formulas
    /// and may represent temperatures below absolute zero or outside typical ranges.</remarks>
    public static class Rankine
    {

        /// <summary>
        /// Converts a temperature value from degrees Rankine to degrees Fahrenheit.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the formula: Fahrenheit = Rankine -
        /// 459.67. If the input value is not a valid number, the result may be undefined (such as NaN or
        /// Infinity).</remarks>
        /// <param name="val">The temperature in degrees Rankine to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in degrees Fahrenheit.</returns>
        public static double ToFahrenheit(double val)
        {
            double result = (val - 491.67) + 32.00;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Rankine to degrees Celsius.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the formula: (Rankine - 491.67) / 1.8.
        /// The result may be negative for temperatures below absolute zero in Rankine.</remarks>
        /// <param name="val">The temperature value in degrees Rankine to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in degrees Celsius.</returns>
        public static double ToCelsius(double val)
        {
            double result = (val - 491.67) / 1.8;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from degrees Rankine to kelvins.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the standard formula for Rankine to
        /// kelvin. Negative values are valid and represent temperatures below absolute zero in the Rankine
        /// scale.</remarks>
        /// <param name="val">The temperature in degrees Rankine to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in kelvins.</returns>
        public static double ToKelvin(double val)
        {
            double result = ((val - 491.67) / 1.8) + 273.15;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Rankine to degrees Réaumur.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the formula: Réaumur = (Rankine -
        /// 491.67) / 2.25. The input value is not validated for physical plausibility; negative or extremely large
        /// values will be converted mathematically.</remarks>
        /// <param name="val">The temperature value in degrees Rankine to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in degrees Réaumur.</returns>
        public static double ToReaumur(double val)
        {
            double result = (val - 491.67) / 2.25;
            return result;
        }
    }
}
