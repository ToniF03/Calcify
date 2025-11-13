namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting distances and lengths between kilometers, meters, and various imperial
    /// and metric units.
    /// </summary>
    /// <remarks>This class includes conversion methods for units such as feet, yards, miles, hectometers,
    /// decameters, decimeters, centimeters, millimeters, micrometers, and nanometers. All methods perform direct
    /// conversions using standard conversion factors and return the result as a double. Negative values are supported
    /// where applicable and will yield corresponding negative results. Callers should ensure that input values are
    /// finite numbers to avoid unexpected results due to floating-point limitations.</remarks>
    public static class Kilometer
    {
        /// <summary>
        /// Converts a value from meters to inches.
        /// </summary>
        /// <param name="val">The length in meters to convert to inches.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 39370.1;
            return result;
        }

        /// <summary>
        /// Converts a distance from kilometers to feet.
        /// </summary>
        /// <param name="val">The distance in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 3280.84;
            return result;
        }

        /// <summary>
        /// Converts a length from kilometers to yards.
        /// </summary>
        /// <remarks>This method uses the conversion factor of 1 kilometer = 1,093.61 yards. Negative
        /// values are supported and will return the corresponding negative yard value.</remarks>
        /// <param name="val">The length value in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 1093.61;
            return result;
        }

        /// <summary>
        /// Converts a distance from kilometers to miles.
        /// </summary>
        /// <param name="val">The distance in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1.609344;
            return result;
        }

        /// <summary>
        /// Converts a length from kilometers to hectometers.
        /// </summary>
        /// <param name="val">The length value in kilometers to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to decameters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value from kilometers to meters.
        /// </summary>
        /// <param name="val">The distance in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a length value from kilometers to decimeters.
        /// </summary>
        /// <param name="val">The length in kilometers to convert to decimeters.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from kilometers to centimeters.
        /// </summary>
        /// <remarks>This method performs a direct conversion by multiplying the input value by 100,000.
        /// The result may be subject to floating-point precision limitations for very large or very small
        /// values.</remarks>
        /// <param name="val">The distance in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 100000;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to millimeters.
        /// </summary>
        /// <param name="val">The value in meters to convert to millimeters.</param>
        /// <returns>A double representing the equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to micrometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to micrometers.</param>
        /// <returns>A double representing the equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to nanometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to nanometers.</param>
        /// <returns>A double representing the equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 1000000000000;
            return result;
        }
    }
}
