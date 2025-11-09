namespace Calcify.Classes.Math.Conversion.Frequency
{
    /// <summary>
    /// Provides static methods for converting frequency values between gigahertz (GHz), megahertz (MHz), kilohertz
    /// (kHz), and hertz (Hz).
    /// </summary>
    /// <remarks>This class is intended for use in scenarios where frequency unit conversions are required,
    /// such as signal processing, hardware interfacing, or scientific calculations. All methods are static and do not
    /// require instantiation of the class.</remarks>
    public static class Gigahertz
    {
        /// <summary>
        /// Converts a frequency value from gigahertz (GHz) to hertz (Hz).
        /// </summary>
        /// <param name="val">The frequency value in gigahertz to convert. Must be a finite number.</param>
        /// <returns>The equivalent frequency in hertz.</returns>
        public static double ToHertz(double val)
        {
            double result = val * 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a frequency value from megahertz to kilohertz.
        /// </summary>
        /// <param name="val">The frequency value in megahertz to convert. Must be a finite number.</param>
        /// <returns>A double representing the equivalent frequency in kilohertz.</returns>
        public static double ToKilohertz(double val)
        {
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a frequency value from gigahertz to megahertz.
        /// </summary>
        /// <param name="val">The frequency value, in gigahertz, to convert to megahertz.</param>
        /// <returns>A double representing the equivalent frequency in megahertz.</returns>
        public static double ToMegahertz(double val)
        {
            double result = val * 1000;
            return result;
        }
    }
}
