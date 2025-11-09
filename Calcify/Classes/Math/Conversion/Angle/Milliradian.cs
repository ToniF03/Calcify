namespace Calcify.Classes.Math.Conversion.Angle
{
    /// <summary>
    /// Provides static methods for converting angular measurements from milliradians to other units, including degrees,
    /// radians, gradians, angular minutes, and angular seconds.
    /// </summary>
    /// <remarks>This class is intended for use in mathematical, scientific, or engineering applications where
    /// milliradian-based angle conversions are required. All methods are static and do not require instantiation of the
    /// class.</remarks>
    public static class Milliradian
    {
        private static double pi = System.Math.PI;

        /// <summary>
        /// Converts an angle measured in radians to its equivalent value in gradians.
        /// </summary>
        /// <remarks>One gradian is equal to 1/400 of a full circle. This method assumes the input value
        /// is in radians and returns the corresponding value in gradians.</remarks>
        /// <param name="val">The angle, in radians, to convert to gradians.</param>
        /// <returns>The angle measured in gradians that is equivalent to the specified value in radians.</returns>
        public static double ToGradian(double val)
        {
            double result = val * 200 / (1000 * pi);
            return result;
        }

        /// <summary>
        /// Converts a value from milliradians to degrees.
        /// </summary>
        /// <param name="val">The angle in milliradians to convert to degrees.</param>
        /// <returns>The equivalent angle in degrees.</returns>
        public static double ToDegree(double val)
        {
            double result = val * 180 / (1000 * pi);
            return result;
        }

        /// <summary>
        /// Converts the specified value from milliradians to radians.
        /// </summary>
        /// <param name="val">The angle value in milliradians to convert. Must be a finite number.</param>
        /// <returns>The equivalent angle in radians.</returns>
        public static double ToRadian(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from milliradians to angular minutes.
        /// </summary>
        /// <param name="val">The value in milliradians to convert to angular minutes.</param>
        /// <returns>A double representing the equivalent value in angular minutes.</returns>
        public static double ToAngularMinute(double val)
        {
            double result = val * (60 * 180) / (1000 * pi);
            return result;
        }

        /// <summary>
        /// Converts an angle measured in milliradians to angular seconds.
        /// </summary>
        /// <param name="val">The angle value to convert, specified in milliradians.</param>
        /// <returns>A double representing the equivalent angle in angular seconds.</returns>
        public static double ToAngularSecond(double val)
        {
            double result = val * (3600 * 180) / (1000 * pi);
            return result;
        }
    }
}
