namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting length and area values between centimeters and other metric and imperial
    /// units.
    /// </summary>
    /// <remarks>This class includes a variety of conversion methods for common units such as inches, feet,
    /// yards, miles, meters, kilometers, millimeters, micrometers, nanometers, decimeters, decameters, and hectometers.
    /// All methods are thread-safe and do not maintain any internal state. Input values should be finite numbers unless
    /// otherwise specified in the method documentation. Negative input values will result in negative output values,
    /// reflecting the direction of measurement.</remarks>
    public static class Centimeter
    {
        /// <summary>
        /// Converts a length value from centimeters to inches.
        /// </summary>
        /// <remarks>This method uses the conversion factor of 1 inch = 2.54 centimeters. The result may
        /// be negative if the input value is negative.</remarks>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val / 2.54;
            return result;
        }

        /// <summary>
        /// Converts a length from centimeters to feet.
        /// </summary>
        /// <param name="val">The length value in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 30.48;
            return result;
        }

        /// <summary>
        /// Converts a length from centimeters to yards.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one yard equals 91.44
        /// centimeters. The result may be positive or negative depending on the input value.</remarks>
        /// <param name="val">The length value in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 91.44;
            return result;
        }

        /// <summary>
        /// Converts a distance from centimeters to miles.
        /// </summary>
        /// <param name="val">The distance to convert, in centimeters. Must be a finite number.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 160934;
            return result;
        }

        /// <summary>
        /// Converts a value from square centimeters to hectometers.
        /// </summary>
        /// <param name="val">The area value, in square centimeters, to convert to hectometers.</param>
        /// <returns>The equivalent area in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 10000;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to decameters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to kilometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 100000;
            return result;
        }

        /// <summary>
        /// Converts a length value from centimeters to meters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a length value from millimeters to decimeters.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to millimeters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Can be any double value, including negative or zero.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 10;
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
        /// Converts a value from micrometers to nanometers.
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
