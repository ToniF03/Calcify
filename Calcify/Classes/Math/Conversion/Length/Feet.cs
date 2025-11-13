namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting length and distance values from feet to various other units of
    /// measurement, including inches, yards, miles, metric units, and SI units.
    /// </summary>
    /// <remarks>All conversion methods use fixed conversion factors and operate on finite numeric values.
    /// These methods are intended for straightforward unit conversions and do not perform input validation. Results may
    /// be subject to floating-point precision limitations, especially for very large or very small values. This class
    /// is thread-safe as it contains only stateless static methods.</remarks>
    public static class Feet
    {
        /// <summary>
        /// Converts a length value from feet to inches.
        /// </summary>
        /// <param name="val">The length, in feet, to convert to inches.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 12;
            return result;
        }

        /// <summary>
        /// Converts a length value from feet to yards.
        /// </summary>
        /// <param name="val">The length in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 3;
            return result;
        }

        /// <summary>
        /// Converts a distance measured in feet to its equivalent in miles.
        /// </summary>
        /// <param name="val">The distance in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 5280;
            return result;
        }

        /// <summary>
        /// Converts a length from feet to hectometers.
        /// </summary>
        /// <param name="val">The length value in feet to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 328.1;
            return result;
        }

        /// <summary>
        /// Converts a length value from feet to decameters.
        /// </summary>
        /// <param name="val">The length, in feet, to convert to decameters.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 32.808;
            return result;
        }

        /// <summary>
        /// Converts a length value from feet to kilometers.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 1 kilometer = 3,281 feet. The result
        /// may be imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 3281;
            return result;
        }

        /// <summary>
        /// Converts a length value from feet to meters.
        /// </summary>
        /// <param name="val">The length in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 3.281;
            return result;
        }

        /// <summary>
        /// Converts a length from feet to decimeters.
        /// </summary>
        /// <remarks>This method multiplies the input value by 3.048 to perform the conversion. The result
        /// may be positive, negative, or zero depending on the input value.</remarks>
        /// <param name="val">The length value in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 3.048;
            return result;
        }

        /// <summary>
        /// Converts a length from feet to centimeters.
        /// </summary>
        /// <param name="val">The length value in feet to convert to centimeters.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 30.48;
            return result;
        }

        /// <summary>
        /// Converts a value in feet to millimeters.
        /// </summary>
        /// <param name="val">The length in feet to convert to millimeters.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 304.8;
            return result;
        }

        /// <summary>
        /// Converts a value in feet to micrometers.
        /// </summary>
        /// <param name="val">The length in feet to convert to micrometers.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 304800;
            return result;
        }

        /// <summary>
        /// Converts a value in feet to nanometers.
        /// </summary>
        /// <param name="val">The length in feet to convert to nanometers.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 304800000;
            return result;
        }
    }
}
