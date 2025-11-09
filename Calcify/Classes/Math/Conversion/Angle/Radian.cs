namespace Calcify.Classes.Math.Conversion.Angle
{
    /// <summary>
    /// Provides static methods for converting angle measurements from radians to other units, including gradians,
    /// degrees, milliradians, angular minutes, and angular seconds.
    /// </summary>
    /// <remarks>This class is intended for use when precise conversion between radians and other common
    /// angular units is required. All methods assume the input value is in radians and return the corresponding value
    /// in the target unit. The class is thread-safe and does not maintain any internal state.</remarks>
    public static class Radian
    {
        private static double pi = System.Math.PI;

        /// <summary>
        /// Converts an angle measured in radians to its equivalent value in gradians.
        /// </summary>
        /// <remarks>One radian is equal to approximately 63.662 gradians. Gradians are commonly used in
        /// fields such as surveying and engineering, where a right angle is defined as 100 gradians.</remarks>
        /// <param name="val">The angle, in radians, to convert to gradians.</param>
        /// <returns>A double representing the angle in gradians equivalent to the specified radian value.</returns>
        public static double ToGradian(double val)
        {
            double result = val * 200 / pi;
            return result;
        }

        /// <summary>
        /// Converts an angle measured in radians to its equivalent in degrees.
        /// </summary>
        /// <param name="val">The angle value, in radians, to convert to degrees.</param>
        /// <returns>A double representing the angle in degrees that corresponds to the specified radian value.</returns>
        public static double ToDegree(double val)
        {
            double result = val * 180 / pi;
            return result;
        }

        /// <summary>
        /// Converts an angle measured in radians to milliradians.
        /// </summary>
        /// <param name="val">The angle value, in radians, to convert to milliradians.</param>
        /// <returns>A double representing the equivalent angle in milliradians.</returns>
        public static double ToMilliradian(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts an angle value from radians to angular minutes.
        /// </summary>
        /// <param name="val">The angle in radians to convert to angular minutes.</param>
        /// <returns>A double representing the equivalent angle in angular minutes.</returns>
        public static double ToAngularMinute(double val)
        {
            double result = val * (60 * 180) / pi;
            return result;
        }

        /// <summary>
        /// Converts an angle value from radians to angular seconds.
        /// </summary>
        /// <param name="val">The angle in radians to convert to angular seconds.</param>
        /// <returns>A double representing the equivalent angle in angular seconds.</returns>
        public static double ToAngularSecond(double val)
        {
            double result = val * (3600 * 180) / pi;
            return result;
        }
    }
}
