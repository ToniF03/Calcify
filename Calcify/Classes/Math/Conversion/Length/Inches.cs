namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting length measurements from inches to various metric and imperial units.
    /// </summary>
    /// <remarks>This class offers a set of conversion methods for transforming values in inches to feet,
    /// yards, miles, hectometers, decameters, kilometers, meters, decimeters, centimeters, millimeters, micrometers,
    /// and nanometers. All methods use fixed conversion factors and return the converted value as a double. The methods
    /// do not perform validation on input values; callers should ensure that input values are finite numbers. Results
    /// may be imprecise for very large or very small values due to floating-point arithmetic limitations.</remarks>
    public static class Inches
    {
        /// <summary>
        /// Converts a length from inches to feet.
        /// </summary>
        /// <param name="val">The length value in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 12;
            return result;
        }

        /// <summary>
        /// Converts a length from inches to yards.
        /// </summary>
        /// <param name="val">The length value, in inches, to convert to yards.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 36;
            return result;
        }

        /// <summary>
        /// Converts a length from inches to miles.
        /// </summary>
        /// <param name="val">The length value, in inches, to convert to miles.</param>
        /// <returns>The equivalent length in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 63360;
            return result;
        }

        /// <summary>
        /// Converts a length value from inches to hectometers.
        /// </summary>
        /// <param name="val">The length in inches to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 3937;
            return result;
        }

        /// <summary>
        /// Converts a length value from inches to decameters.
        /// </summary>
        /// <param name="val">The length in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 393.701;
            return result;
        }

        /// <summary>
        /// Converts a length from inches to kilometers.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 1 kilometer = 39,370 inches. The result
        /// may be imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length value in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 39370;
            return result;
        }

        /// <summary>
        /// Converts a length value from inches to meters.
        /// </summary>
        /// <param name="val">The length, in inches, to convert to meters.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 39.37;
            return result;
        }

        /// <summary>
        /// Converts a length value from inches to decimeters.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 inch = 0.254 decimeters. The result may be
        /// imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 3.937;
            return result;
        }

        /// <summary>
        /// Converts a length from inches to centimeters.
        /// </summary>
        /// <param name="val">The length in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 2.54;
            return result;
        }

        /// <summary>
        /// Converts a value from inches to millimeters.
        /// </summary>
        /// <param name="val">The length in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 25.4;
            return result;
        }

        /// <summary>
        /// Converts a value from inches to micrometers.
        /// </summary>
        /// <param name="val">The length in inches to convert to micrometers.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 25400;
            return result;
        }

        /// <summary>
        /// Converts a value in inches to nanometers.
        /// </summary>
        /// <param name="val">The length value in inches to convert to nanometers.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 25400000;
            return result;
        }
    }
}
