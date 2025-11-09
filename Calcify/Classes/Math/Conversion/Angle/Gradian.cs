namespace Calcify.Classes.Math.Conversion.Angle
{
    /// <summary>
    /// Provides static methods for converting angles measured in gradians to other units, including degrees, radians,
    /// milliradians, angular minutes, and angular seconds.
    /// </summary>
    /// <remarks>A gradian, also known as a gon, is an angular unit where 100 gradians equal a right angle and
    /// 400 gradians equal a full circle. This class is intended for use in mathematical, scientific, or engineering
    /// applications where gradian-based angle conversions are required. All methods are thread-safe and do not maintain
    /// any internal state.</remarks>
    public static class Gradian
    {
        private static double pi = System.Math.PI;

        /// <summary>
        /// Converts a value from grads (also known as gradians or gon) to degrees.
        /// </summary>
        /// <remarks>Grads are an alternative unit of angular measurement where a full circle is 400 grads. This
        /// method uses the conversion factor that 200 grads equal 180 degrees.</remarks>
        /// <param name="val">The angle value in grads to convert. Typically ranges from 0 to 200 for a full circle.</param>
        /// <returns>The equivalent angle in degrees.</returns>
        public static double ToDegree(double val)
        {
            double result = val * 180 / 200;
            return result;
        }

        /// <summary>
        /// Converts an angle measured in gon (gradian) to milliradian.
        /// </summary>
        /// <remarks>Milliradian is commonly used in scientific and engineering applications for precise
        /// angular measurements. One gon equals 0.01570796 radians, and one milliradian equals 0.001 radians.</remarks>
        /// <param name="val">The angle value in gon to convert. Represents a measurement where 400 gon equals a full circle.</param>
        /// <returns>A double representing the equivalent angle in milliradian.</returns>
        public static double ToMilliradian(double val)
        {
            double result = val * 1000 * pi / 200;
            return result;
        }

        /// <summary>
        /// Converts an angle measured in gradians to its equivalent in radians.
        /// </summary>
        /// <param name="val">The angle value in gradians to convert. Typically, 200 gradians equals π radians.</param>
        /// <returns>The angle in radians that corresponds to the specified gradian value.</returns>
        public static double ToRadian(double val)
        {
            double result = val * pi / 200;
            return result;
        }

        /// <summary>
        /// Converts the specified value to angular minutes using a fixed conversion factor.
        /// </summary>
        /// <param name="val">The value to convert to angular minutes.</param>
        /// <returns>A double representing the converted value in angular minutes.</returns>
        public static double ToAngularMinute(double val)
        {
            double result = val * 54;
            return result;
        }
        /// <summary>
        /// Converts a value from degrees to angular seconds.
        /// </summary>
        /// <param name="val">The value in degrees to convert to angular seconds.</param>
        /// <returns>A double representing the equivalent value in angular seconds.</returns>
        public static double ToAngularSecond(double val)
        {
            double result = val * 3240;
            return result;
        }
    }
}
