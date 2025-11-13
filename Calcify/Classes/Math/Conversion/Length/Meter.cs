namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting length and distance values from meters to various metric and imperial
    /// units.
    /// </summary>
    /// <remarks>All conversion methods use standard unit conversion factors and return the equivalent value
    /// in the target unit. Methods accept finite double values; results may be imprecise for very large or very small
    /// inputs due to floating-point limitations. This class is thread-safe and intended for utility use in measurement
    /// and unit conversion scenarios.</remarks>
    public static class Meter
    {
        /// <summary>
        /// Converts a length from meters to inches.
        /// </summary>
        /// <param name="val">The length value in meters to convert to inches.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 39.3701;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to feet.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 meter = 3.28084 feet. The result may be
        /// imprecise for very large or very small values due to floating-point limitations.</remarks>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 3.28084;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to yards.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 1.09361;
            return result;
        }

        /// <summary>
        /// Converts a distance from meters to miles.
        /// </summary>
        /// <remarks>One mile is defined as 1,609 meters. The conversion is performed using this fixed
        /// ratio. Negative values are allowed but may not be meaningful for physical distances.</remarks>
        /// <param name="val">The distance in meters to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1609;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to hectometers.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to decameters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
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
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to decimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to centimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to millimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert to millimeters.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in meters to micrometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to micrometers.</param>
        /// <returns>A double representing the equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to nanometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to nanometers.</param>
        /// <returns>A double representing the equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 1000000000;
            return result;
        }
    }
}
