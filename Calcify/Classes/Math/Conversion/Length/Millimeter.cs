namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting between millimeters, micrometers, and other units of length and area.
    /// </summary>
    /// <remarks>This class offers a set of utility methods for performing direct conversions between metric
    /// and imperial units, including inches, feet, yards, miles, hectometers, decameters, kilometers, meters,
    /// decimeters, centimeters, micrometers, and nanometers. All methods are static and do not require instantiation.
    /// Negative and non-integer values are supported where appropriate. Input values should be finite numbers; passing
    /// non-finite values (such as NaN or infinity) may result in undefined behavior.</remarks>
    public static class Millimeter
    {
        /// <summary>
        /// Converts a measurement from millimeters to inches.
        /// </summary>
        /// <param name="val">The value in millimeters to convert to inches.</param>
        /// <returns>The equivalent measurement in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val / 25.4;
            return result;
        }

        /// <summary>
        /// Converts a length from millimeters to feet.
        /// </summary>
        /// <param name="val">The length value in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 304.8;
            return result;
        }

        /// <summary>
        /// Converts a length value from millimeters to yards.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one yard equals 914
        /// millimeters. Negative values are supported and will return a negative result.</remarks>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 914;
            return result;
        }

        /// <summary>
        /// Converts a distance from micrometers to miles.
        /// </summary>
        /// <param name="val">The distance value, in micrometers, to convert to miles.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1609000;
            return result;
        }

        /// <summary>
        /// Converts a length value from micrometers to hectometers.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 100000;
            return result;
        }

        /// <summary>
        /// Converts a length value from square centimeters to square decameters.
        /// </summary>
        /// <param name="val">The area, in square centimeters, to convert to square decameters.</param>
        /// <returns>The equivalent area in square decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to kilometers.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a length value from millimeters to meters.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a length value from centimeters to decimeters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a value from millimeters to centimeters.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value in millimeters to micrometers.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in micrometers to nanometers.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 1000000;
            return result;
        }
    }
}
