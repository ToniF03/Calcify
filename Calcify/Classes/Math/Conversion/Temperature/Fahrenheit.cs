namespace Calcify.Classes.Math.Conversion.Temperature
{
    /// <summary>
    /// Provides static methods for converting temperatures from degrees Fahrenheit to other temperature scales,
    /// including Kelvin, Celsius, Rankine, and Réaumur.
    /// </summary>
    /// <remarks>All conversion methods use standard formulas for temperature conversion and do not perform
    /// input validation. These methods are suitable for scientific and engineering calculations where precise
    /// temperature conversions are required. The class is static and cannot be instantiated.</remarks>
    public static class Fahrenheit
    {
        /// <summary>
        /// Converts a temperature from degrees Fahrenheit to Kelvin.
        /// </summary>
        /// <remarks>This method uses the standard conversion formula: K = ((F - 32) × 5/9) + 273.15. The
        /// result may be less than zero for sufficiently low input values.</remarks>
        /// <param name="val">The temperature value in degrees Fahrenheit to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in Kelvin.</returns>
        public static double ToKelvin(double val)
        {
            double x = 5; double y = 9; double z = (val - (double)32) * (x / y) + (double)273.15;
            double result = z;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from degrees Fahrenheit to degrees Celsius.
        /// </summary>
        /// <param name="val">The temperature in degrees Fahrenheit to convert.</param>
        /// <returns>The equivalent temperature in degrees Celsius.</returns>
        public static double ToCelsius(double val)
        {
            double result = (val - 32) / 1.8;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Fahrenheit to degrees Rankine.
        /// </summary>
        /// <remarks>Degrees Rankine is an absolute temperature scale used primarily in engineering
        /// fields. The conversion adds 459.67 to the Fahrenheit value to obtain the Rankine temperature.</remarks>
        /// <param name="val">The temperature value in degrees Fahrenheit to convert. Typically represents an absolute temperature
        /// measurement.</param>
        /// <returns>The equivalent temperature in degrees Rankine.</returns>
        public static double ToRankine(double val)
        {
            double z = val + (double)459.67;
            double result = z;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Fahrenheit to degrees Réaumur.
        /// </summary>
        /// <remarks>The Réaumur scale is primarily used in some scientific contexts and historical
        /// references. This method does not perform range validation on the input value.</remarks>
        /// <param name="val">The temperature value in degrees Fahrenheit to convert.</param>
        /// <returns>The equivalent temperature in degrees Réaumur.</returns>
        public static double ToReaumur(double val)
        {
            double result = (val - (double)32) / (double)1.8 * (double)0.8;
            return result;
        }
    }
}
