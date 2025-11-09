namespace Calcify.Classes.Math.Conversion.Frequency
{
    /// <summary>
    /// Provides static methods for converting frequency values from hertz to higher units such as kilohertz, megahertz,
    /// and gigahertz.
    /// </summary>
    /// <remarks>This class is intended for use in scenarios where frequency conversions between hertz and its
    /// multiples are required. All methods assume the input value is a finite number representing frequency in hertz.
    /// The class cannot be instantiated.</remarks>
    public static class Hertz
    {
        /// <summary>
        /// Converts a frequency value from hertz to kilohertz.
        /// </summary>
        /// <param name="val">The frequency value in hertz to convert. Must be a finite number.</param>
        /// <returns>The equivalent frequency in kilohertz.</returns>
        public static double ToKilohertz(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a frequency value from hertz to megahertz.
        /// </summary>
        /// <param name="val">The frequency value in hertz to convert. Must be a finite number.</param>
        /// <returns>The equivalent frequency in megahertz.</returns>
        public static double ToMegahertz(double val)
        {
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a frequency value from hertz to gigahertz.
        /// </summary>
        /// <param name="val">The frequency value in hertz to convert. Must be a finite number.</param>
        /// <returns>The equivalent frequency in gigahertz.</returns>
        public static double ToGigahertz(double val)
        {
            double result = val / 1000000000;
            return result;
        }
    }
}
