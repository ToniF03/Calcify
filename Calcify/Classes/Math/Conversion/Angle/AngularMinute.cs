namespace Calcify.Classes.Math.Conversion.Angle
{
    /// <summary>
    /// Provides static methods for converting angular minutes to other units of angular measurement, such as degrees,
    /// radians, gradians, milliradians, and angular seconds.
    /// </summary>
    /// <remarks>This class is intended for use in mathematical and scientific calculations involving angle
    /// conversions. All methods are static and do not require instantiation. The conversions assume standard
    /// definitions for each unit.</remarks>
    public static class AngularMinute
    {
        private static double pi = System.Math.PI;

        /// <summary>
        /// Converts an angle measured in degrees to its equivalent value in gradians.
        /// </summary>
        /// <remarks>One degree is equal to 1.1111 gradians. This method performs a direct conversion
        /// without rounding or validation.</remarks>
        /// <param name="val">The angle in degrees to convert. Typically, this value should be in the range 0 to 360.</param>
        /// <returns>A double representing the angle in gradians equivalent to the specified degree value.</returns>
        public static double ToGradian(double val)
        {
            double result = val / 54;
            return result;
        }

        /// <summary>
        /// Converts a value from minutes to degrees.
        /// </summary>
        /// <param name="val">The value in minutes to convert to degrees.</param>
        /// <returns>A double representing the equivalent value in degrees.</returns>
        public static double ToDegree(double val)
        {
            double result = val / 60;
            return result;
        }

        /// <summary>
        /// Converts an angle measured in minutes of arc to milliradians.
        /// </summary>
        /// <param name="val">The angle value, in minutes of arc, to convert to milliradians.</param>
        /// <returns>A double representing the equivalent angle in milliradians.</returns>
        public static double ToMilliradian(double val)
        {
            double result = val * 1000 * pi / (60 * 180);
            return result;
        }

        /// <summary>
        /// Converts an angle measured in minutes to its equivalent value in radians.
        /// </summary>
        /// <remarks>This method assumes the input value represents minutes of arc, not degrees. To
        /// convert degrees to radians, use a different conversion method.</remarks>
        /// <param name="val">The angle in minutes to convert to radians.</param>
        /// <returns>The angle in radians that corresponds to the specified value in minutes.</returns>
        public static double ToRadian(double val)
        {
            double result = val * pi / (60 * 180);
            return result;
        }

        /// <summary>
        /// Converts a value from angular minutes to angular seconds.
        /// </summary>
        /// <param name="val">The value, in angular minutes, to convert to angular seconds.</param>
        /// <returns>A double representing the equivalent value in angular seconds.</returns>
        public static double ToAngularSecond(double val)
        {
            double result = val * 60;
            return result;
        }
    }
}
