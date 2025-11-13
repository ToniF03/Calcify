namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting distances measured in miles to various other units of length, including
    /// inches, feet, yards, metric units, and sub-metric units.
    /// </summary>
    /// <remarks>All conversion methods use fixed conversion factors and return the equivalent value in the
    /// target unit. The input value should be a finite number representing the distance in miles. These methods are
    /// thread-safe and suitable for use in mathematical calculations or unit conversions. For conversions requiring
    /// high precision, verify the conversion factor used in each method, as some methods may use rounded values for
    /// simplicity.</remarks>
    public static class Mile
    {
        /// <summary>
        /// Converts a value from miles to inches.
        /// </summary>
        /// <param name="val">The distance in miles to convert to inches.</param>
        /// <returns>The equivalent distance in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 63360;
            return result;
        }

        /// <summary>
        /// Converts a distance from miles to feet.
        /// </summary>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 5280;
            return result;
        }

        /// <summary>
        /// Converts a distance from miles to yards.
        /// </summary>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 1760;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to hectometers.
        /// </summary>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val * 16.093;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to decameters.
        /// </summary>
        /// <param name="val">The distance in miles to convert to decameters.</param>
        /// <returns>The equivalent distance in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val * 161;
            return result;
        }

        /// <summary>
        /// Converts a distance from miles to kilometers.
        /// </summary>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val * 1.609344;
            return result;
        }

        /// <summary>
        /// Converts a distance from miles to meters.
        /// </summary>
        /// <remarks>This method uses a conversion factor of 1 mile = 1,609 meters. For more precise
        /// conversions, consider using the exact value of 1 mile = 1,609.344 meters.</remarks>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 1609;
            return result;
        }

        /// <summary>
        /// Converts a value in miles to its equivalent length in decimeters.
        /// </summary>
        /// <param name="val">The distance in miles to convert to decimeters.</param>
        /// <returns>The length in decimeters that corresponds to the specified value in miles.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 16093;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to centimeters.
        /// </summary>
        /// <param name="val">The distance in miles to convert to centimeters.</param>
        /// <returns>The equivalent distance in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 160934;
            return result;
        }

        /// <summary>
        /// Converts a value in miles to millimeters.
        /// </summary>
        /// <param name="val">The distance in miles to convert to millimeters.</param>
        /// <returns>The equivalent distance in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 1609340;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to micrometers.
        /// </summary>
        /// <param name="val">The distance in miles to convert to micrometers.</param>
        /// <returns>The equivalent distance in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 1609340000;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to nanometers.
        /// </summary>
        /// <param name="val">The distance in miles to convert to nanometers.</param>
        /// <returns>The equivalent distance in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 160934000000;
            return result;
        }
    }
}
