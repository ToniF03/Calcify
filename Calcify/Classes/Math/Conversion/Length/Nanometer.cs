namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting length values from nanometers (and picometers) to various metric and
    /// imperial units.
    /// </summary>
    /// <remarks>All conversion methods perform direct calculations using fixed conversion factors. Results
    /// may be subject to floating-point precision limitations for very large or very small input values. This class is
    /// thread-safe and intended for utility use; it cannot be instantiated.</remarks>
    public static class Nanometer
    {
        /// <summary>
        /// Converts a value from nanometers to inches.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor 1 inch = 25,400,000
        /// nanometers. The result may be imprecise for very large or very small values due to floating-point
        /// limitations.</remarks>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val / 25400000;
            return result;
        }

        /// <summary>
        /// Converts a length value from nanometers to feet.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one foot equals
        /// 304,800,000 nanometers. The result may be subject to floating-point precision limitations for very large or
        /// very small values.</remarks>
        /// <param name="val">The length to convert, specified in nanometers.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 304800000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to yards.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one yard equals
        /// 914,400,000 nanometers. The result may be subject to floating-point precision limitations for very large or
        /// very small input values.</remarks>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 914400000;
            return result;
        }

        /// <summary>
        /// Converts a distance from nanometers to miles.
        /// </summary>
        /// <remarks>One mile is equal to 1,609,000,000,000 nanometers. This method performs a direct
        /// conversion using this factor.</remarks>
        /// <param name="val">The distance value in nanometers to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1609000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to hectometers.
        /// </summary>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 100000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to decameters.
        /// </summary>
        /// <param name="val">The length value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 10000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from picometers to kilometers.
        /// </summary>
        /// <param name="val">The length in picometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 1000000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to meters.
        /// </summary>
        /// <param name="val">The length value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to decimeters.
        /// </summary>
        /// <remarks>This method performs a direct conversion by dividing the input value by 100,000,000.
        /// The result may be positive or negative depending on the input value.</remarks>
        /// <param name="val">The length value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 100000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to centimeters.
        /// </summary>
        /// <remarks>This method performs a direct conversion by dividing the input value by 10,000,000.
        /// The result may be subject to floating-point precision limitations for very large or very small
        /// values.</remarks>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val / 10000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to millimeters.
        /// </summary>
        /// <param name="val">The value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanometers to micrometers.
        /// </summary>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val / 1000;
            return result;
        }
    }
}
