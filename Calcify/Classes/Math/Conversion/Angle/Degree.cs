namespace Calcify.Classes.Math.Conversion.Angle
{
    /// <summary>
    /// Provides static methods for converting angles measured in degrees to other units, including gradians,
    /// milliradians, radians, angular minutes, and angular seconds.
    /// </summary>
    /// <remarks>This class is intended for use in mathematical and scientific calculations where angle unit
    /// conversions are required. All methods are static and do not require instantiation of the class.</remarks>
    public static class Degree
    {
        private static double pi = System.Math.PI;

        /// <summary>
        /// Converts an angle measured in degrees to its equivalent in gradians.
        /// </summary>
        /// <remarks>One degree is equal to 200/180 (approximately 1.1111) gradians. Gradians are commonly
        /// used in some fields such as surveying and engineering, where a right angle is 100 gradians.</remarks>
        /// <param name="val">The angle in degrees to convert. Typically, this value should be within the range 0 to 360, but any real
        /// number is accepted.</param>
        /// <returns>A double-precision floating-point number representing the angle in gradians.</returns>
        public static double ToGradian(double val)
        {
            double result = val * 200 / 180;
            return result;
        }

        /// <summary>
        /// Converts an angle measured in degrees to milliradians.
        /// </summary>
        /// <param name="val">The angle value, in degrees, to convert to milliradians.</param>
        /// <returns>A double representing the equivalent angle in milliradians.</returns>
        public static double ToMilliradian(double val)
        {
            double result = val * 1000 * pi / 180;
            return result;
        }

        /// <summary>
        /// Converts an angle from degrees to radians.
        /// </summary>
        /// <param name="val">The angle in degrees to convert. Typically, this value should be in the range 0 to 360, but any real number
        /// is accepted.</param>
        /// <returns>A double representing the equivalent angle in radians.</returns>
        public static double ToRadian(double val)
        {
            double result = val * pi / 180;
            return result;
        }

        /// <summary>
        /// Converts an angular value from degrees to angular minutes.
        /// </summary>
        /// <param name="val">The value, in degrees, to convert to angular minutes.</param>
        /// <returns>A double representing the equivalent angular minutes of the specified degree value.</returns>
        public static double ToAngularMinute(double val)
        {
            double result = val * 60;
            return result;
        }

        /// <summary>
        /// Converts an angle measured in degrees to its equivalent value in angular seconds.
        /// </summary>
        /// <param name="val">The angle in degrees to convert to angular seconds.</param>
        /// <returns>A double representing the angle in angular seconds.</returns>
        public static double ToAngularSecond(double val)
        {
            double result = val * 3600;
            return result;
        }
    }
}
