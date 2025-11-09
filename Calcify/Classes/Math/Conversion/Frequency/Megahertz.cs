namespace Calcify.Classes.Math.Conversion.Frequency
{
    /// <summary>
    /// Provides static methods for converting frequency values from megahertz (MHz) to other units of frequency,
    /// including hertz (Hz), kilohertz (kHz), and gigahertz (GHz).
    /// </summary>
    /// <remarks>This class is intended for use in scenarios where frequency conversions between megahertz and
    /// other standard units are required. All methods are static and do not require instantiation of the class. Input
    /// values should be finite numbers; negative values may not be meaningful in typical frequency contexts.</remarks>
    public static class Megahertz
    {
        /// <summary>
        /// Converts a frequency value from megahertz (MHz) to hertz (Hz).
        /// </summary>
        /// <param name="val">The frequency value in megahertz (MHz) to convert. Must be a finite number.</param>
        /// <returns>The equivalent frequency in hertz (Hz).</returns>
        public static double ToHertz(double val)
        {
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a frequency value from megahertz to kilohertz.
        /// </summary>
        /// <param name="val">The frequency value in megahertz to convert. Must be a finite number.</param>
        /// <returns>The equivalent frequency in kilohertz.</returns>
        public static double ToKilohertz(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a frequency value from megahertz to gigahertz.
        /// </summary>
        /// <param name="val">The frequency value in megahertz to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent frequency in gigahertz.</returns>
        public static double ToGigahertz(double val)
        {
            double result = val / 1000;
            return result;
        }
    }
}
