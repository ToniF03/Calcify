namespace Calcify.Classes.Math.Conversion.Angle
{
    /// <summary>
    /// Provides static methods for converting angular seconds to other units of angular measurement, including degrees,
    /// radians, gradians, milliradians, and angular minutes.
    /// </summary>
    /// <remarks>An angular second is a unit of angular measurement equal to 1/3600 of a degree. This class is
    /// intended for use in scientific, engineering, or geospatial applications where precise angle conversions are
    /// required. All methods are thread-safe and do not maintain any internal state.</remarks>
    public static class AngularSecond
    {
        private static double pi = System.Math.PI;

        /// <summary>
        /// Converts an angle measured in seconds to its equivalent value in gradians.
        /// </summary>
        /// <param name="val">The angle value, in seconds, to convert to gradians.</param>
        /// <returns>A double representing the angle in gradians equivalent to the specified value in seconds.</returns>
        public static double ToGradian(double val)
        {
            double result = val / 3240;
            return result;
        }

        /// <summary>
        /// Converts an angle value from arcseconds to degrees.
        /// </summary>
        /// <param name="val">The angle in arcseconds to convert. Must be a finite number.</param>
        /// <returns>The equivalent angle in degrees.</returns>
        public static double ToDegree(double val)
        {
            double result = val / 3600;
            return result;
        }

        /// <summary>
        /// Converts an angle measured in arcseconds to milliradians.
        /// </summary>
        /// <param name="val">The angle value, in arcseconds, to convert to milliradians.</param>
        /// <returns>A double representing the equivalent angle in milliradians.</returns>
        public static double ToMilliradian(double val)
        {
            double result = val * 1000 * pi / (180 * 3600);
            return result;
        }

        /// <summary>
        /// Converts an angle measured in arcseconds to its equivalent value in radians.
        /// </summary>
        /// <remarks>Use this method when working with astronomical or geodetic calculations that require
        /// conversion from arcseconds to radians. One arcsecond is equal to 1/3600 of a degree.</remarks>
        /// <param name="val">The angle, in arcseconds, to convert to radians.</param>
        /// <returns>The angle in radians that corresponds to the specified arcseconds value.</returns>
        public static double ToRadian(double val)
        {
            double result = val * pi / (180 * 3600);
            return result;
        }

        /// <summary>
        /// Converts an angular value from minutes to degrees.
        /// </summary>
        /// <param name="val">The angular value in minutes to convert. Must be a finite number.</param>
        /// <returns>The equivalent angular value in degrees.</returns>
        public static double ToAngularMinute(double val)
        {
            double result = val / 60;
            return result;
        }
    }
}
