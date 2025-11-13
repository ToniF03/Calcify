namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting length and distance measurements between meters, decimeters, centimeters,
    /// and various imperial and metric units.
    /// </summary>
    /// <remarks>All conversion methods use standard conversion factors and return the result as a
    /// double-precision floating-point value. Methods do not perform input validation; callers should ensure that input
    /// values are within valid ranges and are finite numbers. This class is thread-safe as it contains only stateless
    /// static methods.</remarks>
    public static class Decameter
    {
        /// <summary>
        /// Converts a measurement from meters to inches.
        /// </summary>
        /// <param name="val">The value in meters to convert to inches.</param>
        /// <returns>The equivalent measurement in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 393.701;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to feet.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 meter = 3.28084 feet. The result may be
        /// imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length value in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 32.8084;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to yards.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 10.9361;
            return result;
        }

        /// <summary>
        /// Converts a distance from meters to miles.
        /// </summary>
        /// <param name="val">The distance in meters to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 160.93;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to hectometers.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to kilometers.
        /// </summary>
        /// <param name="val">The distance in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a value from decimeters to meters.
        /// </summary>
        /// <param name="val">The value in decimeters to convert to meters.</param>
        /// <returns>The equivalent value in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to decimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to centimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert to centimeters.</param>
        /// <returns>A double representing the equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to millimeters.
        /// </summary>
        /// <param name="val">The length value in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 10000;
            return result;
        }

        /// <summary>
        /// Converts a value in centimeters to micrometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 10000000;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to nanometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert to nanometers.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 10000000000;
            return result;
        }
    }
}
