namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting length and distance measurements between metric and imperial units,
    /// including centimeters, meters, millimeters, inches, feet, yards, miles, hectometers, decameters, kilometers,
    /// micrometers, and nanometers.
    /// </summary>
    /// <remarks>All conversion methods are stateless and thread-safe. Input values should be finite numbers
    /// unless otherwise specified. These methods are intended for straightforward unit conversions and do not perform
    /// validation beyond the documented requirements for each parameter.</remarks>
    public static class Decimeter
    {

        /// <summary>
        /// Converts a measurement from centimeters to inches.
        /// </summary>
        /// <param name="val">The value in centimeters to convert to inches.</param>
        /// <returns>The equivalent measurement in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 3.93701;
            return result;
        }

        /// <summary>
        /// Converts a length from centimeters to feet.
        /// </summary>
        /// <param name="val">The length value in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 3.048;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to yards.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 9.144;
            return result;
        }

        /// <summary>
        /// Converts a distance from meters to miles.
        /// </summary>
        /// <param name="val">The distance in meters to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 16093.4;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to hectometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a length value from centimeters to decameters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to kilometers.
        /// </summary>
        /// <param name="val">The distance in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from decimeters to meters.
        /// </summary>
        /// <param name="val">The length in decimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value from millimeters to centimeters.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to millimeters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Can be any double value, including negative or zero.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value in centimeters to micrometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 100000;
            return result;
        }

        /// <summary>
        /// Converts a value in centimeters to nanometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 100000000;
            return result;
        }
    }
}
