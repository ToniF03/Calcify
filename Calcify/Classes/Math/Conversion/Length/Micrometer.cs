namespace Calcify.Classes.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting length and area values between micrometers, nanometers, and various
    /// metric and imperial units.
    /// </summary>
    /// <remarks>This class offers a set of unit conversion utilities for micrometers and nanometers,
    /// including conversions to inches, feet, yards, miles, hectometers, decameters, kilometers, meters, decimeters,
    /// centimeters, millimeters, and nanometers. All methods perform direct conversions using standard unit factors and
    /// may be subject to floating-point precision limitations for very large or very small values. The class is static
    /// and cannot be instantiated.</remarks>
    public static class Micrometer
    {
        /// <summary>
        /// Converts a value from micrometers to inches.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that 1 inch equals 25,400
        /// micrometers. The result may be imprecise for very large or very small values due to floating-point
        /// limitations.</remarks>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val / 25400;
            return result;
        }

        /// <summary>
        /// Converts a length value from micrometers to feet.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 304800;
            return result;
        }

        /// <summary>
        /// Converts a value in microns to yards.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one yard equals
        /// 914,400 microns. The result may be a fractional value.</remarks>
        /// <param name="val">The length in microns to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 914400;
            return result;
        }

        /// <summary>
        /// Converts a distance from nanometers to miles.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor 1 mile = 1,609,344,000
        /// nanometers. Negative input values will result in negative output values, which may not be meaningful for
        /// physical distances.</remarks>
        /// <param name="val">The distance value in nanometers to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1609344000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanometers to hectometers.
        /// </summary>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 100000000;
            return result;
        }

        /// <summary>
        /// Converts a length from nanometers to decameters.
        /// </summary>
        /// <param name="val">The length value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 10000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to kilometers.
        /// </summary>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to meters.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to decimeters.
        /// </summary>
        /// <param name="val">The length value in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 100000;
            return result;
        }

        /// <summary>
        /// Converts a value in square micrometers to square centimeters.
        /// </summary>
        /// <remarks>This method performs a direct conversion by dividing the input value by 10,000. The
        /// result may be subject to floating-point precision limitations for very large or very small values.</remarks>
        /// <param name="val">The area value, in square micrometers, to convert to square centimeters.</param>
        /// <returns>The equivalent area in square centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val / 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to millimeters.
        /// </summary>
        /// <param name="val">The value in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent value in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to nanometers.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 1000;
            return result;
        }
    }
}
