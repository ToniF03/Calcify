namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting between various metric and imperial length and area units, including
    /// meters, kilometers, inches, feet, yards, miles, decameters, centimeters, millimeters, micrometers, and
    /// nanometers.
    /// </summary>
    /// <remarks>All conversion methods use fixed conversion factors and operate on double-precision
    /// floating-point values. Results may be imprecise for very large or very small values due to floating-point
    /// arithmetic limitations. Negative values are accepted for area conversions where appropriate. This class is
    /// thread-safe as it contains only static methods and does not maintain state.</remarks>
    public static class Hectometer
    {
        /// <summary>
        /// Converts a value from meters to inches.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 1 meter = 39.3701 inches. The result
        /// may be imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 3937.01;
            return result;
        }

        /// <summary>
        /// Converts a length from kilometers to feet.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 1 kilometer = 328.084 feet. The result
        /// may be imprecise for very large or very small values due to floating-point limitations.</remarks>
        /// <param name="val">The length value in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 328.084;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to yards.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 109.361;
            return result;
        }

        /// <summary>
        /// Converts a distance from kilometers to miles.
        /// </summary>
        /// <param name="val">The distance value in kilometers to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 16.093;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to decameters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a value from hectometers to kilometers.
        /// </summary>
        /// <param name="val">The distance value in hectometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to meters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value in meters to its equivalent in decimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert to decimeters.</param>
        /// <returns>A double representing the equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from square meters to square centimeters.
        /// </summary>
        /// <remarks>This method multiplies the input value by 10,000 to perform the conversion. Negative
        /// values are allowed and will be converted accordingly.</remarks>
        /// <param name="val">The area in square meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent area in square centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from kilometers to millimeters.
        /// </summary>
        /// <param name="val">The value in kilometers to convert to millimeters.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 100000;
            return result;
        }

        /// <summary>
        /// Converts a value in centimeters to micrometers.
        /// </summary>
        /// <param name="val">The length value in centimeters to convert to micrometers.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 100000000;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to nanometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to nanometers.</param>
        /// <returns>A double representing the equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 100000000000;
            return result;
        }
    }
}
