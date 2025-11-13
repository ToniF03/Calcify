namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting lengths and distances between yards and various other units of
    /// measurement, including inches, feet, miles, metric units, and more.
    /// </summary>
    /// <remarks>This class offers a set of utility methods for performing common unit conversions involving
    /// yards. All methods are static and do not require instantiation of the class. The conversion factors used are
    /// standard approximations suitable for general-purpose calculations; for applications requiring high precision,
    /// verify the conversion factor as needed. Input values should be finite numbers, and some methods may require
    /// non-negative values as specified in their documentation.</remarks>
    public static class Yard
    {
        /// <summary>
        /// Converts a measurement from yards to inches.
        /// </summary>
        /// <remarks>This method multiplies the input value by 36 to perform the conversion, as one yard
        /// equals 36 inches.</remarks>
        /// <param name="val">The value in yards to convert to inches.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 36;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to feet.
        /// </summary>
        /// <remarks>This method uses an approximate conversion factor of 3 feet per meter. For precise
        /// scientific or engineering calculations, consider using a more accurate conversion factor.</remarks>
        /// <param name="val">The length value in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 3;
            return result;
        }

        /// <summary>
        /// Converts a distance measured in yards to the equivalent distance in miles.
        /// </summary>
        /// <param name="val">The distance in yards to convert. Must be a non-negative value.</param>
        /// <returns>The distance in miles that is equivalent to the specified number of yards.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1760;
            return result;
        }

        /// <summary>
        /// Converts a value from yards to hectometers.
        /// </summary>
        /// <param name="val">The length in yards to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 109.36;
            return result;
        }

        /// <summary>
        /// Converts a length value from yards to decameters.
        /// </summary>
        /// <param name="val">The length in yards to convert to decameters.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 10.936;
            return result;
        }

        /// <summary>
        /// Converts a distance measured in yards to its equivalent value in kilometers.
        /// </summary>
        /// <param name="val">The distance in yards to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 1093.6;
            return result;
        }

        /// <summary>
        /// Converts a length from yards to meters.
        /// </summary>
        /// <param name="val">The length value in yards to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 0.9144;
            return result;
        }

        /// <summary>
        /// Converts a length from yards to decimeters.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 yard = 9.144 decimeters. The result may be
        /// positive or negative depending on the input value.</remarks>
        /// <param name="val">The length value in yards to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 9.144;
            return result;
        }

        /// <summary>
        /// Converts a value in yards to its equivalent length in centimeters.
        /// </summary>
        /// <param name="val">The length in yards to convert. Must be a finite number.</param>
        /// <returns>The length in centimeters that corresponds to the specified value in yards.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 91.44;
            return result;
        }

        /// <summary>
        /// Converts a value in yards to its equivalent length in millimeters.
        /// </summary>
        /// <param name="val">The length in yards to convert. Must be a finite number.</param>
        /// <returns>The length in millimeters that corresponds to the specified value in yards.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 914.4;
            return result;
        }

        /// <summary>
        /// Converts a value in yards to micrometers.
        /// </summary>
        /// <param name="val">The length in yards to convert to micrometers.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 914400;
            return result;
        }

        /// <summary>
        /// Converts a value from inches to nanometers.
        /// </summary>
        /// <param name="val">The length in inches to convert to nanometers.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 914400000;
            return result;
        }
    }
}
