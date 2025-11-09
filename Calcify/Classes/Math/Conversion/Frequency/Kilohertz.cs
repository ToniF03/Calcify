using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcify.Classes.Math.Conversion.Frequency
{
    /// <summary>
    /// Provides static methods for converting frequency values between kilohertz, hertz, megahertz, and gigahertz
    /// units.
    /// </summary>
    /// <remarks>This class is intended for use in scenarios where frequency unit conversions are required,
    /// such as signal processing or electronics calculations. All methods are static and do not require instantiation
    /// of the class. Input values should be finite and within the valid range for the respective conversion
    /// method.</remarks>
    public static class Kilohertz
    {
        /// <summary>
        /// Converts a frequency value from kilohertz to hertz.
        /// </summary>
        /// <param name="val">The frequency value in kilohertz to convert. Must be a finite number.</param>
        /// <returns>The equivalent frequency in hertz.</returns>
        public static double ToHertz(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a frequency value from kilohertz to megahertz.
        /// </summary>
        /// <param name="val">The frequency value in kilohertz to convert. Must be a finite number.</param>
        /// <returns>The equivalent frequency in megahertz.</returns>
        public static double ToMegahertz(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a frequency value from hertz to gigahertz.
        /// </summary>
        /// <param name="val">The frequency value in hertz to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent frequency in gigahertz.</returns>
        public static double ToGigahertz(double val)
        {
            double result = val / 1000000;
            return result;
        }
    }
}
