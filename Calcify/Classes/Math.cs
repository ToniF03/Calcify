using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calcify.Math.Conversion.Frequency
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
namespace Calcify.Math.Conversion.Length
{
    /// <summary>
    /// Provides static methods for converting length values from nanometers (and picometers) to various metric and
    /// imperial units.
    /// </summary>
    /// <remarks>All conversion methods perform direct calculations using fixed conversion factors. Results
    /// may be subject to floating-point precision limitations for very large or very small input values. This class is
    /// thread-safe and intended for utility use; it cannot be instantiated.</remarks>
    public static class Nanometer
    {
        /// <summary>
        /// Converts a value from nanometers to inches.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor 1 inch = 25,400,000
        /// nanometers. The result may be imprecise for very large or very small values due to floating-point
        /// limitations.</remarks>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val / 25400000;
            return result;
        }

        /// <summary>
        /// Converts a length value from nanometers to feet.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one foot equals
        /// 304,800,000 nanometers. The result may be subject to floating-point precision limitations for very large or
        /// very small values.</remarks>
        /// <param name="val">The length to convert, specified in nanometers.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 304800000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to yards.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one yard equals
        /// 914,400,000 nanometers. The result may be subject to floating-point precision limitations for very large or
        /// very small input values.</remarks>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 914400000;
            return result;
        }

        /// <summary>
        /// Converts a distance from nanometers to miles.
        /// </summary>
        /// <remarks>One mile is equal to 1,609,000,000,000 nanometers. This method performs a direct
        /// conversion using this factor.</remarks>
        /// <param name="val">The distance value in nanometers to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1609000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to hectometers.
        /// </summary>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 100000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to decameters.
        /// </summary>
        /// <param name="val">The length value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 10000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from picometers to kilometers.
        /// </summary>
        /// <param name="val">The length in picometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 1000000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to meters.
        /// </summary>
        /// <param name="val">The length value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to decimeters.
        /// </summary>
        /// <remarks>This method performs a direct conversion by dividing the input value by 100,000,000.
        /// The result may be positive or negative depending on the input value.</remarks>
        /// <param name="val">The length value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 100000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to centimeters.
        /// </summary>
        /// <remarks>This method performs a direct conversion by dividing the input value by 10,000,000.
        /// The result may be subject to floating-point precision limitations for very large or very small
        /// values.</remarks>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val / 10000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to millimeters.
        /// </summary>
        /// <param name="val">The value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanometers to micrometers.
        /// </summary>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val / 1000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting length and area values between micrometers, nanometers, and various
    /// metric and imperial units.
    /// </summary>
    /// <remarks>This class offers a set of unit conversion utilities for micrometers and nanometers,
    /// including conversions to inches, feet, yards, miles, hectometers, decameters, kilometers, meters, decimeters,
    /// centimeters, millimeters, and nanometers. All methods perform direct conversions using standard unit factors and
    /// may be subject to floating-point precision limitations for very large or very small values. The class is static
    /// and cannot be instantiated.</remarks>
    public static class Micrometer
    {
        /// <summary>
        /// Converts a value from micrometers to inches.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that 1 inch equals 25,400
        /// micrometers. The result may be imprecise for very large or very small values due to floating-point
        /// limitations.</remarks>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val / 25400;
            return result;
        }

        /// <summary>
        /// Converts a length value from micrometers to feet.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 304800;
            return result;
        }

        /// <summary>
        /// Converts a value in microns to yards.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one yard equals
        /// 914,400 microns. The result may be a fractional value.</remarks>
        /// <param name="val">The length in microns to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 914400;
            return result;
        }

        /// <summary>
        /// Converts a distance from nanometers to miles.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor 1 mile = 1,609,344,000
        /// nanometers. Negative input values will result in negative output values, which may not be meaningful for
        /// physical distances.</remarks>
        /// <param name="val">The distance value in nanometers to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1609344000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanometers to hectometers.
        /// </summary>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 100000000;
            return result;
        }

        /// <summary>
        /// Converts a length from nanometers to decameters.
        /// </summary>
        /// <param name="val">The length value in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 10000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanometers to kilometers.
        /// </summary>
        /// <param name="val">The length in nanometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to meters.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to decimeters.
        /// </summary>
        /// <param name="val">The length value in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 100000;
            return result;
        }

        /// <summary>
        /// Converts a value in square micrometers to square centimeters.
        /// </summary>
        /// <remarks>This method performs a direct conversion by dividing the input value by 10,000. The
        /// result may be subject to floating-point precision limitations for very large or very small values.</remarks>
        /// <param name="val">The area value, in square micrometers, to convert to square centimeters.</param>
        /// <returns>The equivalent area in square centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val / 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to millimeters.
        /// </summary>
        /// <param name="val">The value in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent value in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to nanometers.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 1000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting between millimeters, micrometers, and other units of length and area.
    /// </summary>
    /// <remarks>This class offers a set of utility methods for performing direct conversions between metric
    /// and imperial units, including inches, feet, yards, miles, hectometers, decameters, kilometers, meters,
    /// decimeters, centimeters, micrometers, and nanometers. All methods are static and do not require instantiation.
    /// Negative and non-integer values are supported where appropriate. Input values should be finite numbers; passing
    /// non-finite values (such as NaN or infinity) may result in undefined behavior.</remarks>
    public static class Millimeter
    {
        /// <summary>
        /// Converts a measurement from millimeters to inches.
        /// </summary>
        /// <param name="val">The value in millimeters to convert to inches.</param>
        /// <returns>The equivalent measurement in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val / 25.4;
            return result;
        }

        /// <summary>
        /// Converts a length from millimeters to feet.
        /// </summary>
        /// <param name="val">The length value in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 304.8;
            return result;
        }

        /// <summary>
        /// Converts a length value from millimeters to yards.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one yard equals 914
        /// millimeters. Negative values are supported and will return a negative result.</remarks>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 914;
            return result;
        }

        /// <summary>
        /// Converts a distance from micrometers to miles.
        /// </summary>
        /// <param name="val">The distance value, in micrometers, to convert to miles.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1609000;
            return result;
        }

        /// <summary>
        /// Converts a length value from micrometers to hectometers.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 100000;
            return result;
        }

        /// <summary>
        /// Converts a length value from square centimeters to square decameters.
        /// </summary>
        /// <param name="val">The area, in square centimeters, to convert to square decameters.</param>
        /// <returns>The equivalent area in square decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to kilometers.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a length value from millimeters to meters.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a length value from centimeters to decimeters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a value from millimeters to centimeters.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value in millimeters to micrometers.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in micrometers to nanometers.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 1000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting length and area values between centimeters and other metric and imperial
    /// units.
    /// </summary>
    /// <remarks>This class includes a variety of conversion methods for common units such as inches, feet,
    /// yards, miles, meters, kilometers, millimeters, micrometers, nanometers, decimeters, decameters, and hectometers.
    /// All methods are thread-safe and do not maintain any internal state. Input values should be finite numbers unless
    /// otherwise specified in the method documentation. Negative input values will result in negative output values,
    /// reflecting the direction of measurement.</remarks>
    public static class Centimeter
    {
        /// <summary>
        /// Converts a length value from centimeters to inches.
        /// </summary>
        /// <remarks>This method uses the conversion factor of 1 inch = 2.54 centimeters. The result may
        /// be negative if the input value is negative.</remarks>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val / 2.54;
            return result;
        }

        /// <summary>
        /// Converts a length from centimeters to feet.
        /// </summary>
        /// <param name="val">The length value in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 30.48;
            return result;
        }

        /// <summary>
        /// Converts a length from centimeters to yards.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the factor that one yard equals 91.44
        /// centimeters. The result may be positive or negative depending on the input value.</remarks>
        /// <param name="val">The length value in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 91.44;
            return result;
        }

        /// <summary>
        /// Converts a distance from centimeters to miles.
        /// </summary>
        /// <param name="val">The distance to convert, in centimeters. Must be a finite number.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 160934;
            return result;
        }

        /// <summary>
        /// Converts a value from square centimeters to hectometers.
        /// </summary>
        /// <param name="val">The area value, in square centimeters, to convert to hectometers.</param>
        /// <returns>The equivalent area in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 10000;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to decameters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to kilometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 100000;
            return result;
        }

        /// <summary>
        /// Converts a length value from centimeters to meters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a length value from millimeters to decimeters.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to millimeters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Can be any double value, including negative or zero.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a value in millimeters to micrometers.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from micrometers to nanometers.
        /// </summary>
        /// <param name="val">The length in micrometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 1000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting length and distance measurements between metric and imperial units,
    /// including centimeters, meters, millimeters, inches, feet, yards, miles, hectometers, decameters, kilometers,
    /// micrometers, and nanometers.
    /// </summary>
    /// <remarks>All conversion methods are stateless and thread-safe. Input values should be finite numbers
    /// unless otherwise specified. These methods are intended for straightforward unit conversions and do not perform
    /// validation beyond the documented requirements for each parameter.</remarks>
    public static class Decimeter
    {

        /// <summary>
        /// Converts a measurement from centimeters to inches.
        /// </summary>
        /// <param name="val">The value in centimeters to convert to inches.</param>
        /// <returns>The equivalent measurement in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 3.93701;
            return result;
        }

        /// <summary>
        /// Converts a length from centimeters to feet.
        /// </summary>
        /// <param name="val">The length value in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 3.048;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to yards.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 9.144;
            return result;
        }

        /// <summary>
        /// Converts a distance from meters to miles.
        /// </summary>
        /// <param name="val">The distance in meters to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 16093.4;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to hectometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a length value from centimeters to decameters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to kilometers.
        /// </summary>
        /// <param name="val">The distance in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from decimeters to meters.
        /// </summary>
        /// <param name="val">The length in decimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value from millimeters to centimeters.
        /// </summary>
        /// <param name="val">The length in millimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to millimeters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Can be any double value, including negative or zero.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value in centimeters to micrometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 100000;
            return result;
        }

        /// <summary>
        /// Converts a value in centimeters to nanometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 100000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting length and distance values from meters to various metric and imperial
    /// units.
    /// </summary>
    /// <remarks>All conversion methods use standard unit conversion factors and return the equivalent value
    /// in the target unit. Methods accept finite double values; results may be imprecise for very large or very small
    /// inputs due to floating-point limitations. This class is thread-safe and intended for utility use in measurement
    /// and unit conversion scenarios.</remarks>
    public static class Meter
    {
        /// <summary>
        /// Converts a length from meters to inches.
        /// </summary>
        /// <param name="val">The length value in meters to convert to inches.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 39.3701;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to feet.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 meter = 3.28084 feet. The result may be
        /// imprecise for very large or very small values due to floating-point limitations.</remarks>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 3.28084;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to yards.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 1.09361;
            return result;
        }

        /// <summary>
        /// Converts a distance from meters to miles.
        /// </summary>
        /// <remarks>One mile is defined as 1,609 meters. The conversion is performed using this fixed
        /// ratio. Negative values are allowed but may not be meaningful for physical distances.</remarks>
        /// <param name="val">The distance in meters to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1609;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to hectometers.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to decameters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to kilometers.
        /// </summary>
        /// <param name="val">The distance in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to decimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to centimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to millimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert to millimeters.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in meters to micrometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to micrometers.</param>
        /// <returns>A double representing the equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to nanometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to nanometers.</param>
        /// <returns>A double representing the equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 1000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting distances and lengths between kilometers, meters, and various imperial
    /// and metric units.
    /// </summary>
    /// <remarks>This class includes conversion methods for units such as feet, yards, miles, hectometers,
    /// decameters, decimeters, centimeters, millimeters, micrometers, and nanometers. All methods perform direct
    /// conversions using standard conversion factors and return the result as a double. Negative values are supported
    /// where applicable and will yield corresponding negative results. Callers should ensure that input values are
    /// finite numbers to avoid unexpected results due to floating-point limitations.</remarks>
    public static class Kilometer
    {
        /// <summary>
        /// Converts a value from meters to inches.
        /// </summary>
        /// <param name="val">The length in meters to convert to inches.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 39370.1;
            return result;
        }

        /// <summary>
        /// Converts a distance from kilometers to feet.
        /// </summary>
        /// <param name="val">The distance in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 3280.84;
            return result;
        }

        /// <summary>
        /// Converts a length from kilometers to yards.
        /// </summary>
        /// <remarks>This method uses the conversion factor of 1 kilometer = 1,093.61 yards. Negative
        /// values are supported and will return the corresponding negative yard value.</remarks>
        /// <param name="val">The length value in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 1093.61;
            return result;
        }

        /// <summary>
        /// Converts a distance from kilometers to miles.
        /// </summary>
        /// <param name="val">The distance in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1.609344;
            return result;
        }

        /// <summary>
        /// Converts a length from kilometers to hectometers.
        /// </summary>
        /// <param name="val">The length value in kilometers to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to decameters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value from kilometers to meters.
        /// </summary>
        /// <param name="val">The distance in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a length value from kilometers to decimeters.
        /// </summary>
        /// <param name="val">The length in kilometers to convert to decimeters.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from kilometers to centimeters.
        /// </summary>
        /// <remarks>This method performs a direct conversion by multiplying the input value by 100,000.
        /// The result may be subject to floating-point precision limitations for very large or very small
        /// values.</remarks>
        /// <param name="val">The distance in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 100000;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to millimeters.
        /// </summary>
        /// <param name="val">The value in meters to convert to millimeters.</param>
        /// <returns>A double representing the equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to micrometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to micrometers.</param>
        /// <returns>A double representing the equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to nanometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to nanometers.</param>
        /// <returns>A double representing the equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 1000000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting length and distance measurements between meters, decimeters, centimeters,
    /// and various imperial and metric units.
    /// </summary>
    /// <remarks>All conversion methods use standard conversion factors and return the result as a
    /// double-precision floating-point value. Methods do not perform input validation; callers should ensure that input
    /// values are within valid ranges and are finite numbers. This class is thread-safe as it contains only stateless
    /// static methods.</remarks>
    public static class Decameter
    {
        /// <summary>
        /// Converts a measurement from meters to inches.
        /// </summary>
        /// <param name="val">The value in meters to convert to inches.</param>
        /// <returns>The equivalent measurement in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 393.701;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to feet.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 meter = 3.28084 feet. The result may be
        /// imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length value in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 32.8084;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to yards.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 10.9361;
            return result;
        }

        /// <summary>
        /// Converts a distance from meters to miles.
        /// </summary>
        /// <param name="val">The distance in meters to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 160.93;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to hectometers.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to kilometers.
        /// </summary>
        /// <param name="val">The distance in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a value from decimeters to meters.
        /// </summary>
        /// <param name="val">The value in decimeters to convert to meters.</param>
        /// <returns>The equivalent value in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to decimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to centimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert to centimeters.</param>
        /// <returns>A double representing the equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to millimeters.
        /// </summary>
        /// <param name="val">The length value in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 10000;
            return result;
        }

        /// <summary>
        /// Converts a value in centimeters to micrometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 10000000;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to nanometers.
        /// </summary>
        /// <param name="val">The length in centimeters to convert to nanometers.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 10000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting between various metric and imperial length and area units, including
    /// meters, kilometers, inches, feet, yards, miles, decameters, centimeters, millimeters, micrometers, and
    /// nanometers.
    /// </summary>
    /// <remarks>All conversion methods use fixed conversion factors and operate on double-precision
    /// floating-point values. Results may be imprecise for very large or very small values due to floating-point
    /// arithmetic limitations. Negative values are accepted for area conversions where appropriate. This class is
    /// thread-safe as it contains only static methods and does not maintain state.</remarks>
    public static class Hectometer
    {
        /// <summary>
        /// Converts a value from meters to inches.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 1 meter = 39.3701 inches. The result
        /// may be imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 3937.01;
            return result;
        }

        /// <summary>
        /// Converts a length from kilometers to feet.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 1 kilometer = 328.084 feet. The result
        /// may be imprecise for very large or very small values due to floating-point limitations.</remarks>
        /// <param name="val">The length value in kilometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 328.084;
            return result;
        }

        /// <summary>
        /// Converts a length value from meters to yards.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 109.361;
            return result;
        }

        /// <summary>
        /// Converts a distance from kilometers to miles.
        /// </summary>
        /// <param name="val">The distance value in kilometers to convert. Must be greater than or equal to zero.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 16.093;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to decameters.
        /// </summary>
        /// <param name="val">The length in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts a value from hectometers to kilometers.
        /// </summary>
        /// <param name="val">The distance value in hectometers to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value from centimeters to meters.
        /// </summary>
        /// <param name="val">The length in centimeters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts a value in meters to its equivalent in decimeters.
        /// </summary>
        /// <param name="val">The length in meters to convert to decimeters.</param>
        /// <returns>A double representing the equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value from square meters to square centimeters.
        /// </summary>
        /// <remarks>This method multiplies the input value by 10,000 to perform the conversion. Negative
        /// values are allowed and will be converted accordingly.</remarks>
        /// <param name="val">The area in square meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent area in square centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 10000;
            return result;
        }

        /// <summary>
        /// Converts a value from kilometers to millimeters.
        /// </summary>
        /// <param name="val">The value in kilometers to convert to millimeters.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 100000;
            return result;
        }

        /// <summary>
        /// Converts a value in centimeters to micrometers.
        /// </summary>
        /// <param name="val">The length value in centimeters to convert to micrometers.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 100000000;
            return result;
        }

        /// <summary>
        /// Converts a value from meters to nanometers.
        /// </summary>
        /// <param name="val">The length in meters to convert to nanometers.</param>
        /// <returns>A double representing the equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 100000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting distances measured in miles to various other units of length, including
    /// inches, feet, yards, metric units, and sub-metric units.
    /// </summary>
    /// <remarks>All conversion methods use fixed conversion factors and return the equivalent value in the
    /// target unit. The input value should be a finite number representing the distance in miles. These methods are
    /// thread-safe and suitable for use in mathematical calculations or unit conversions. For conversions requiring
    /// high precision, verify the conversion factor used in each method, as some methods may use rounded values for
    /// simplicity.</remarks>
    public static class Mile
    {
        /// <summary>
        /// Converts a value from miles to inches.
        /// </summary>
        /// <param name="val">The distance in miles to convert to inches.</param>
        /// <returns>The equivalent distance in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 63360;
            return result;
        }

        /// <summary>
        /// Converts a distance from miles to feet.
        /// </summary>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 5280;
            return result;
        }

        /// <summary>
        /// Converts a distance from miles to yards.
        /// </summary>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val * 1760;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to hectometers.
        /// </summary>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val * 16.093;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to decameters.
        /// </summary>
        /// <param name="val">The distance in miles to convert to decameters.</param>
        /// <returns>The equivalent distance in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val * 161;
            return result;
        }

        /// <summary>
        /// Converts a distance from miles to kilometers.
        /// </summary>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val * 1.609344;
            return result;
        }

        /// <summary>
        /// Converts a distance from miles to meters.
        /// </summary>
        /// <remarks>This method uses a conversion factor of 1 mile = 1,609 meters. For more precise
        /// conversions, consider using the exact value of 1 mile = 1,609.344 meters.</remarks>
        /// <param name="val">The distance in miles to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 1609;
            return result;
        }

        /// <summary>
        /// Converts a value in miles to its equivalent length in decimeters.
        /// </summary>
        /// <param name="val">The distance in miles to convert to decimeters.</param>
        /// <returns>The length in decimeters that corresponds to the specified value in miles.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 16093;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to centimeters.
        /// </summary>
        /// <param name="val">The distance in miles to convert to centimeters.</param>
        /// <returns>The equivalent distance in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 160934;
            return result;
        }

        /// <summary>
        /// Converts a value in miles to millimeters.
        /// </summary>
        /// <param name="val">The distance in miles to convert to millimeters.</param>
        /// <returns>The equivalent distance in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 1609340;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to micrometers.
        /// </summary>
        /// <param name="val">The distance in miles to convert to micrometers.</param>
        /// <returns>The equivalent distance in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 1609340000;
            return result;
        }

        /// <summary>
        /// Converts a value from miles to nanometers.
        /// </summary>
        /// <param name="val">The distance in miles to convert to nanometers.</param>
        /// <returns>The equivalent distance in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 160934000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting lengths and distances between yards and various other units of
    /// measurement, including inches, feet, miles, metric units, and more.
    /// </summary>
    /// <remarks>This class offers a set of utility methods for performing common unit conversions involving
    /// yards. All methods are static and do not require instantiation of the class. The conversion factors used are
    /// standard approximations suitable for general-purpose calculations; for applications requiring high precision,
    /// verify the conversion factor as needed. Input values should be finite numbers, and some methods may require
    /// non-negative values as specified in their documentation.</remarks>
    public static class Yard
    {
        /// <summary>
        /// Converts a measurement from yards to inches.
        /// </summary>
        /// <remarks>This method multiplies the input value by 36 to perform the conversion, as one yard
        /// equals 36 inches.</remarks>
        /// <param name="val">The value in yards to convert to inches.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 36;
            return result;
        }

        /// <summary>
        /// Converts a length from meters to feet.
        /// </summary>
        /// <remarks>This method uses an approximate conversion factor of 3 feet per meter. For precise
        /// scientific or engineering calculations, consider using a more accurate conversion factor.</remarks>
        /// <param name="val">The length value in meters to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val * 3;
            return result;
        }

        /// <summary>
        /// Converts a distance measured in yards to the equivalent distance in miles.
        /// </summary>
        /// <param name="val">The distance in yards to convert. Must be a non-negative value.</param>
        /// <returns>The distance in miles that is equivalent to the specified number of yards.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 1760;
            return result;
        }

        /// <summary>
        /// Converts a value from yards to hectometers.
        /// </summary>
        /// <param name="val">The length in yards to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 109.36;
            return result;
        }

        /// <summary>
        /// Converts a length value from yards to decameters.
        /// </summary>
        /// <param name="val">The length in yards to convert to decameters.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 10.936;
            return result;
        }

        /// <summary>
        /// Converts a distance measured in yards to its equivalent value in kilometers.
        /// </summary>
        /// <param name="val">The distance in yards to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 1093.6;
            return result;
        }

        /// <summary>
        /// Converts a length from yards to meters.
        /// </summary>
        /// <param name="val">The length value in yards to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val * 0.9144;
            return result;
        }

        /// <summary>
        /// Converts a length from yards to decimeters.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 yard = 9.144 decimeters. The result may be
        /// positive or negative depending on the input value.</remarks>
        /// <param name="val">The length value in yards to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 9.144;
            return result;
        }

        /// <summary>
        /// Converts a value in yards to its equivalent length in centimeters.
        /// </summary>
        /// <param name="val">The length in yards to convert. Must be a finite number.</param>
        /// <returns>The length in centimeters that corresponds to the specified value in yards.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 91.44;
            return result;
        }

        /// <summary>
        /// Converts a value in yards to its equivalent length in millimeters.
        /// </summary>
        /// <param name="val">The length in yards to convert. Must be a finite number.</param>
        /// <returns>The length in millimeters that corresponds to the specified value in yards.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 914.4;
            return result;
        }

        /// <summary>
        /// Converts a value in yards to micrometers.
        /// </summary>
        /// <param name="val">The length in yards to convert to micrometers.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 914400;
            return result;
        }

        /// <summary>
        /// Converts a value from inches to nanometers.
        /// </summary>
        /// <param name="val">The length in inches to convert to nanometers.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 914400000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting length and distance values from feet to various other units of
    /// measurement, including inches, yards, miles, metric units, and SI units.
    /// </summary>
    /// <remarks>All conversion methods use fixed conversion factors and operate on finite numeric values.
    /// These methods are intended for straightforward unit conversions and do not perform input validation. Results may
    /// be subject to floating-point precision limitations, especially for very large or very small values. This class
    /// is thread-safe as it contains only stateless static methods.</remarks>
    public static class Feet
    {
        /// <summary>
        /// Converts a length value from feet to inches.
        /// </summary>
        /// <param name="val">The length, in feet, to convert to inches.</param>
        /// <returns>The equivalent length in inches.</returns>
        public static double ToInches(double val)
        {
            double result = val * 12;
            return result;
        }

        /// <summary>
        /// Converts a length value from feet to yards.
        /// </summary>
        /// <param name="val">The length in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 3;
            return result;
        }

        /// <summary>
        /// Converts a distance measured in feet to its equivalent in miles.
        /// </summary>
        /// <param name="val">The distance in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent distance in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 5280;
            return result;
        }

        /// <summary>
        /// Converts a length from feet to hectometers.
        /// </summary>
        /// <param name="val">The length value in feet to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 328.1;
            return result;
        }

        /// <summary>
        /// Converts a length value from feet to decameters.
        /// </summary>
        /// <param name="val">The length, in feet, to convert to decameters.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 32.808;
            return result;
        }

        /// <summary>
        /// Converts a length value from feet to kilometers.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 1 kilometer = 3,281 feet. The result
        /// may be imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 3281;
            return result;
        }

        /// <summary>
        /// Converts a length value from feet to meters.
        /// </summary>
        /// <param name="val">The length in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 3.281;
            return result;
        }

        /// <summary>
        /// Converts a length from feet to decimeters.
        /// </summary>
        /// <remarks>This method multiplies the input value by 3.048 to perform the conversion. The result
        /// may be positive, negative, or zero depending on the input value.</remarks>
        /// <param name="val">The length value in feet to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val * 3.048;
            return result;
        }

        /// <summary>
        /// Converts a length from feet to centimeters.
        /// </summary>
        /// <param name="val">The length value in feet to convert to centimeters.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 30.48;
            return result;
        }

        /// <summary>
        /// Converts a value in feet to millimeters.
        /// </summary>
        /// <param name="val">The length in feet to convert to millimeters.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 304.8;
            return result;
        }

        /// <summary>
        /// Converts a value in feet to micrometers.
        /// </summary>
        /// <param name="val">The length in feet to convert to micrometers.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 304800;
            return result;
        }

        /// <summary>
        /// Converts a value in feet to nanometers.
        /// </summary>
        /// <param name="val">The length in feet to convert to nanometers.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 304800000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting length measurements from inches to various metric and imperial units.
    /// </summary>
    /// <remarks>This class offers a set of conversion methods for transforming values in inches to feet,
    /// yards, miles, hectometers, decameters, kilometers, meters, decimeters, centimeters, millimeters, micrometers,
    /// and nanometers. All methods use fixed conversion factors and return the converted value as a double. The methods
    /// do not perform validation on input values; callers should ensure that input values are finite numbers. Results
    /// may be imprecise for very large or very small values due to floating-point arithmetic limitations.</remarks>
    public static class Inches
    {
        /// <summary>
        /// Converts a length from inches to feet.
        /// </summary>
        /// <param name="val">The length value in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in feet.</returns>
        public static double ToFeet(double val)
        {
            double result = val / 12;
            return result;
        }

        /// <summary>
        /// Converts a length from inches to yards.
        /// </summary>
        /// <param name="val">The length value, in inches, to convert to yards.</param>
        /// <returns>The equivalent length in yards.</returns>
        public static double ToYards(double val)
        {
            double result = val / 36;
            return result;
        }

        /// <summary>
        /// Converts a length from inches to miles.
        /// </summary>
        /// <param name="val">The length value, in inches, to convert to miles.</param>
        /// <returns>The equivalent length in miles.</returns>
        public static double ToMiles(double val)
        {
            double result = val / 63360;
            return result;
        }

        /// <summary>
        /// Converts a length value from inches to hectometers.
        /// </summary>
        /// <param name="val">The length in inches to convert to hectometers.</param>
        /// <returns>The equivalent length in hectometers.</returns>
        public static double ToHectometer(double val)
        {
            double result = val / 3937;
            return result;
        }

        /// <summary>
        /// Converts a length value from inches to decameters.
        /// </summary>
        /// <param name="val">The length in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decameters.</returns>
        public static double ToDecameter(double val)
        {
            double result = val / 393.701;
            return result;
        }

        /// <summary>
        /// Converts a length from inches to kilometers.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 1 kilometer = 39,370 inches. The result
        /// may be imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length value in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in kilometers.</returns>
        public static double ToKilometer(double val)
        {
            double result = val / 39370;
            return result;
        }

        /// <summary>
        /// Converts a length value from inches to meters.
        /// </summary>
        /// <param name="val">The length, in inches, to convert to meters.</param>
        /// <returns>The equivalent length in meters.</returns>
        public static double ToMeter(double val)
        {
            double result = val / 39.37;
            return result;
        }

        /// <summary>
        /// Converts a length value from inches to decimeters.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 inch = 0.254 decimeters. The result may be
        /// imprecise for very large or very small values due to floating-point arithmetic.</remarks>
        /// <param name="val">The length in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in decimeters.</returns>
        public static double ToDecimeter(double val)
        {
            double result = val / 3.937;
            return result;
        }

        /// <summary>
        /// Converts a length from inches to centimeters.
        /// </summary>
        /// <param name="val">The length in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in centimeters.</returns>
        public static double ToCentimeter(double val)
        {
            double result = val * 2.54;
            return result;
        }

        /// <summary>
        /// Converts a value from inches to millimeters.
        /// </summary>
        /// <param name="val">The length in inches to convert. Must be a finite number.</param>
        /// <returns>The equivalent length in millimeters.</returns>
        public static double ToMillimeter(double val)
        {
            double result = val * 25.4;
            return result;
        }

        /// <summary>
        /// Converts a value from inches to micrometers.
        /// </summary>
        /// <param name="val">The length in inches to convert to micrometers.</param>
        /// <returns>The equivalent length in micrometers.</returns>
        public static double ToMicrometer(double val)
        {
            double result = val * 25400;
            return result;
        }

        /// <summary>
        /// Converts a value in inches to nanometers.
        /// </summary>
        /// <param name="val">The length value in inches to convert to nanometers.</param>
        /// <returns>The equivalent length in nanometers.</returns>
        public static double ToNanometer(double val)
        {
            double result = val * 25400000;
            return result;
        }
    }
}
namespace Calcify.Math.Conversion.Mass
{
    /// <summary>
    /// Provides static methods for converting mass values between metric tons and other common units of mass, including
    /// kilograms, grams, milligrams, micrograms, long tons, short tons, stones, pounds, and ounces.
    /// </summary>
    /// <remarks>All conversion methods require input values that are not <see cref="double.NaN"/>. If a NaN
    /// value is provided, an <see cref="ArgumentException"/> is thrown. The conversion factors used are based on
    /// standard definitions, but users should verify factors for scientific or regulatory precision where necessary.
    /// This class is thread-safe as it contains only stateless static methods.</remarks>
    public static class Tons
    {
        /// <summary>
        /// Converts a value in metric tons to kilograms.
        /// </summary>
        /// <param name="val">The value in metric tons to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in metric tons to grams.
        /// </summary>
        /// <param name="val">The value in metric tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to milligrams.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in teragrams to micrograms.
        /// </summary>
        /// <param name="val">The value, in teragrams, to convert to micrograms. Must not be NaN.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000;
            return result;
        }

        /// <summary>
        /// Converts a mass value from metric tonnes to long tons (imperial tons).
        /// </summary>
        /// <remarks>One long ton is equal to 1.016 metric tonnes. This method performs a direct
        /// conversion using this factor.</remarks>
        /// <param name="val">The mass value in metric tonnes to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.016;
            return result;
        }

        /// <summary>
        /// Converts a mass value from metric tons to short tons (U.S. tons).
        /// </summary>
        /// <remarks>One metric ton is approximately equal to 1.102 short tons. This method does not
        /// validate whether the input is negative.</remarks>
        /// <param name="val">The mass value, in metric tons, to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1.102;
            return result;
        }

        /// <summary>
        /// Converts a mass value in grams to stones.
        /// </summary>
        /// <remarks>One stone is equal to 6,350.29318 grams. The conversion uses a factor of 1 stone =
        /// 157.473 grams for compatibility with certain measurement standards. For precise scientific calculations,
        /// verify the conversion factor used.</remarks>
        /// <param name="val">The mass value, in grams, to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 157.473;
            return result;
        }

        /// <summary>
        /// Converts a mass value from kilograms to pounds.
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00045359237;
            return result;
        }

        /// <summary>
        /// Converts a mass value from milligrams to ounces.
        /// </summary>
        /// <param name="val">The mass value in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in ounces as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * (double)1000000 / 28.34952;
            return result;
        }
    }
    public static class Kilograms
    {
        /// <summary>
        /// Converts the specified value from kilograms to metric tons.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from kilograms to grams.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to micrograms.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to long tons (imperial tons).
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons. Returns 0 if the input value is 0.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000984;
            return result;
        }

        /// <summary>
        /// Converts a mass value from kilograms to short tons (U.S. tons).
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0011023;
            return result;
        }

        /// <summary>
        /// Converts a weight value from kilograms to stones.
        /// </summary>
        /// <remarks>One stone is equal to approximately 6.35029 kilograms. This method uses a conversion
        /// factor of 0.15747 to convert kilograms to stones.</remarks>
        /// <param name="val">The weight in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.15747;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to its equivalent weight in pounds.
        /// </summary>
        /// <param name="val">The weight in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in pounds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2.2046;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to its equivalent in ounces.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 35.274;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting mass values between grams and other common metric and imperial units.
    /// </summary>
    /// <remarks>This class includes conversion methods for kilograms, metric tons, milligrams, micrograms,
    /// long tons, short tons, stones, pounds, and ounces. All methods require valid numeric input values and will throw
    /// an exception if the input is not a number (NaN). The class is thread-safe and intended for use in scenarios
    /// where precise mass unit conversions are required.</remarks>
    public static class Grams
    {
        /// <summary>
        /// Converts a value from kilograms to metric tons.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to its equivalent in kilograms.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from grams to micrograms.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in micrograms to long tons.
        /// </summary>
        /// <param name="val">The value in micrograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000098421;
            return result;
        }

        /// <summary>
        /// Converts a mass value from micrograms to short tons.
        /// </summary>
        /// <param name="val">The mass value in micrograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000011023;
            return result;
        }

        /// <summary>
        /// Converts a weight value from kilograms to stones.
        /// </summary>
        /// <param name="val">The weight in kilograms to convert. Must be a valid numeric value.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00015747;
            return result;
        }

        /// <summary>
        /// Converts a mass value from grams to pounds.
        /// </summary>
        /// <param name="val">The mass value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0022046;
            return result;
        }

        /// <summary>
        /// Converts a mass value from grams to ounces.
        /// </summary>
        /// <param name="val">The mass value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.035274;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting mass values between milligrams and other metric and imperial units.
    /// </summary>
    /// <remarks>This class includes conversion methods for common mass units such as kilograms, grams,
    /// micrograms, pounds, ounces, stones, metric tons, long tons, and short tons. All methods validate input values to
    /// ensure they are not NaN, and will throw an exception if invalid input is provided. The class is thread-safe and
    /// intended for use in scenarios where precise mass unit conversions are required.</remarks>
    public static class Milligrams
    {
        /// <summary>
        /// Converts a value from nanograms to metric tons.
        /// </summary>
        /// <param name="val">The value in nanograms to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a mass value from milligrams to kilograms.
        /// </summary>
        /// <param name="val">The mass value in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in kilograms as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in milligrams to grams.
        /// </summary>
        /// <param name="val">The value in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts the specified value in milligrams to micrograms.
        /// </summary>
        /// <param name="val">The value in milligrams to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanograms to long tons.
        /// </summary>
        /// <param name="val">The mass value in nanograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000098421;
            return result;
        }

        /// <summary>
        /// Converts a value in nanograms to short tons.
        /// </summary>
        /// <remarks>A short ton is equal to 2,000 pounds. This method uses a fixed conversion factor for
        /// nanograms to short tons.</remarks>
        /// <param name="val">The mass value in nanograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000011023;
            return result;
        }

        /// <summary>
        /// Converts a mass value from micrograms to stones.
        /// </summary>
        /// <remarks>One stone is equal to 6,350,293.18 micrograms. This method does not validate the
        /// range of the input value beyond checking for NaN.</remarks>
        /// <param name="val">The mass value in micrograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000015747;
            return result;
        }

        /// <summary>
        /// Converts a value in milligrams to its equivalent weight in pounds.
        /// </summary>
        /// <param name="val">The weight in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in pounds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000022046;
            return result;
        }
        /// <summary>
        /// Converts a value in grams to its equivalent in ounces.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000035274;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting mass values between micrograms and other units of measurement, including
    /// tons, kilograms, grams, milligrams, stones, pounds, and ounces.
    /// </summary>
    /// <remarks>All conversion methods validate that the input value is not <see cref="double.NaN"/> and
    /// throw an <see cref="ArgumentException"/> if this condition is not met. The class is intended for use in
    /// scenarios where precise mass unit conversions are required, and does not perform range or overflow checks beyond
    /// NaN validation.</remarks>
    public static class Micrograms
    {
        /// <summary>
        /// Converts the specified value from units to trillions (tons).
        /// </summary>
        /// <param name="val">The numeric value to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in trillions (tons) as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanograms to kilograms.
        /// </summary>
        /// <param name="val">The mass value in nanograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value from nanograms to grams.
        /// </summary>
        /// <param name="val">The value in nanograms to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a mass value from nanograms to long tons.
        /// </summary>
        /// <param name="val">The mass value in nanograms to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000000098421;
            return result;
        }

        /// <summary>
        /// Converts a value from picograms to short tons (U.S. tons).
        /// </summary>
        /// <remarks>A short ton is equal to 2,000 pounds. This method uses a fixed conversion factor of
        /// 1.1023 × 10⁻¹² to convert picograms to short tons.</remarks>
        /// <param name="val">The mass value in picograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000000011023;
            return result;
        }

        /// <summary>
        /// Converts a mass value from nanograms to stones.
        /// </summary>
        /// <remarks>One stone is equal to 6,350,293,180 nanograms. This method does not validate the
        /// range of the input value beyond checking for <see cref="double.NaN"/>.</remarks>
        /// <param name="val">The mass value, in nanograms, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent mass in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000015747;
            return result;
        }

        /// <summary>
        /// Converts a value in nanograms to pounds.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 0.0000000022046 to convert nanograms to
        /// pounds.</remarks>
        /// <param name="val">The mass value in nanograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000022046;
            return result;
        }

        /// <summary>
        /// Converts a value in milligrams to its equivalent in ounces.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 0.000000035274 to convert milligrams to
        /// ounces.</remarks>
        /// <param name="val">The value in milligrams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000000035274;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting mass and weight values between long tons (imperial tons) and other common
    /// units, including metric tons, kilograms, grams, milligrams, micrograms, short tons, stones, pounds, and ounces.
    /// </summary>
    /// <remarks>All conversion methods validate input values to ensure they are not NaN and throw an
    /// ArgumentException if invalid. The class uses fixed conversion factors for each unit, which may be subject to
    /// floating-point precision limitations. Methods are thread-safe and intended for general-purpose unit conversions
    /// in scientific, engineering, or everyday contexts.</remarks>
    public static class LongTons
    {

        /// <summary>
        /// Converts a mass value from metric tons to long tons (imperial tons).
        /// </summary>
        /// <remarks>One metric ton is approximately equal to 0.98421 long tons. This method does not
        /// perform range checking beyond NaN validation.</remarks>
        /// <param name="val">The mass value, in metric tons, to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.98421;
            return result;
        }

        /// <summary>
        /// Converts a weight value from tons to kilograms.
        /// </summary>
        /// <param name="val">The weight value in tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00098421;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to its equivalent weight in grams.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor based on the relationship between ounces
        /// and grams. The result may be subject to floating-point precision limitations.</remarks>
        /// <param name="val">The weight in ounces to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent weight in grams as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000098421;
            return result;
        }

        /// <summary>
        /// Converts a value from grams to milligrams.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000098421;
            return result;
        }

        /// <summary>
        /// Converts a mass value from grains to micrograms.
        /// </summary>
        /// <remarks>This method uses the conversion factor 1 grain = 64,798.91 micrograms. The result may
        /// be subject to floating-point precision limitations.</remarks>
        /// <param name="val">The mass value in grains to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000000098421;
            return result;
        }

        /// <summary>
        /// Converts a value in metric tons to short tons (U.S. tons).
        /// </summary>
        /// <remarks>One metric ton is approximately equal to 1.12 short tons. This method multiplies the
        /// input value by 1.12 to perform the conversion.</remarks>
        /// <param name="val">The value, in metric tons, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1.12;
            return result;
        }

        /// <summary>
        /// Converts the specified value in kilograms to stones.
        /// </summary>
        /// <param name="val">The value in kilograms to convert. Must be a valid number.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 160;
            return result;
        }

        /// <summary>
        /// Converts a value in long tons to pounds.
        /// </summary>
        /// <param name="val">The value, in long tons, to convert to pounds. Must not be NaN.</param>
        /// <returns>The equivalent weight in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2240;
            return result;
        }

        /// <summary>
        /// Converts a value in tons to its equivalent in ounces.
        /// </summary>
        /// <param name="val">The value, in tons, to convert to ounces. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 35840;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting mass and weight values between short tons and other common units,
    /// including kilograms, grams, milligrams, micrograms, pounds, ounces, stones, and long tons.
    /// </summary>
    /// <remarks>All conversion methods use fixed conversion factors based on standard definitions for each
    /// unit. Input values must not be NaN; otherwise, an ArgumentException is thrown. This class is thread-safe and
    /// intended for utility use in applications requiring mass or weight conversions.</remarks>
    public static class ShortTons
    {
        /// <summary>
        /// Converts a value in kilograms to its equivalent in tons.
        /// </summary>
        /// <remarks>One ton is defined as 1,102.3 kilograms. This method performs a direct conversion
        /// using this factor.</remarks>
        /// <param name="val">The value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in tons as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.1023;
            return result;
        }

        /// <summary>
        /// Converts a weight value from short tons to kilograms.
        /// </summary>
        /// <param name="val">The weight value, in short tons, to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0011023;
            return result;
        }

        /// <summary>
        /// Converts a value in tons to its equivalent weight in grams.
        /// </summary>
        /// <param name="val">The weight in tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in grams as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000011023;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value, in ounces, to convert to milligrams. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000011023;
            return result;
        }

        /// <summary>
        /// Converts a mass value from short tons to micrograms.
        /// </summary>
        /// <param name="val">The mass value, in short tons, to convert to micrograms. Must not be NaN.</param>
        /// <returns>The equivalent mass in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000000011023;
            return result;
        }

        /// <summary>
        /// Converts a mass value from metric tons to long tons (imperial tons).
        /// </summary>
        /// <remarks>A long ton, also known as an imperial ton, is equal to 2,240 pounds. This method uses
        /// a fixed conversion factor of 0.89286 to convert metric tons to long tons.</remarks>
        /// <param name="val">The mass value in metric tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons. The result is calculated as metric tons multiplied by 0.89286.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.89286;
            return result;
        }

        /// <summary>
        /// Converts a weight value in grams to stones.
        /// </summary>
        /// <remarks>One stone is equal to 142.86 grams. The conversion does not round the
        /// result.</remarks>
        /// <param name="val">The weight value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 142.86;
            return result;
        }

        /// <summary>
        /// Converts a weight value from tons to pounds.
        /// </summary>
        /// <remarks>One ton is considered equal to 2,000 pounds. This method does not perform range
        /// validation on the input value.</remarks>
        /// <param name="val">The weight in tons to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2000;
            return result;
        }

        /// <summary>
        /// Converts a value in metric tons to ounces.
        /// </summary>
        /// <param name="val">The value, in metric tons, to convert to ounces. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 32000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting between various units of mass, including stones, kilograms, tons, carats,
    /// grams, milligrams, micrograms, pounds, and ounces.
    /// </summary>
    /// <remarks>All conversion methods validate input values to ensure they are valid numbers and will throw
    /// an exception if a value is NaN. This class is intended for use in scenarios where precise mass unit conversions
    /// are required, such as scientific calculations or weight measurement applications. All methods are thread-safe
    /// and can be used concurrently.</remarks>
    public static class Stones
    {
        /// <summary>
        /// Converts a value in kilograms to metric tons.
        /// </summary>
        /// <param name="val">The mass in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 157.47;
            return result;
        }

        /// <summary>
        /// Converts a value in stones to its equivalent weight in kilograms.
        /// </summary>
        /// <remarks>One stone is equal to approximately 6.35029 kilograms. This method uses a conversion
        /// factor of 0.15747 stones per kilogram.</remarks>
        /// <param name="val">The weight in stones to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.15747;
            return result;
        }

        /// <summary>
        /// Converts a value from carats to grams.
        /// </summary>
        /// <param name="val">The value in carats to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00015747;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000015747;
            return result;
        }

        /// <summary>
        /// Converts a value from grams to micrograms.
        /// </summary>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000015747;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to long tons (imperial tons).
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0062500;
            return result;
        }

        /// <summary>
        /// Converts a mass value from kilograms to short tons (U.S. tons).
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0070000;
            return result;
        }

        /// <summary>
        /// Converts a value in stones to its equivalent weight in pounds.
        /// </summary>
        /// <remarks>One stone is equal to 14 pounds. This method multiplies the input value by 14 to
        /// perform the conversion.</remarks>
        /// <param name="val">The weight in stones to convert. Must be a valid number.</param>
        /// <returns>The equivalent weight in pounds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 14;
            return result;
        }

        /// <summary>
        /// Converts a value in grams to ounces using a fixed conversion factor.
        /// </summary>
        /// <remarks>This method uses a conversion factor of 224 to convert grams to ounces. Ensure that
        /// the input value is a valid number.</remarks>
        /// <param name="val">The value in grams to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 224;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting mass and weight values between pounds and other common units, including
    /// metric tons, kilograms, grams, milligrams, micrograms, long tons, short tons, stones, and ounces.
    /// </summary>
    /// <remarks>All conversion methods validate that input values are numeric and will throw an exception if
    /// a non-numeric value (NaN) is provided. This class is thread-safe and intended for use in scenarios where
    /// accurate unit conversion between pounds and other mass or weight units is required.</remarks>
    public static class Pounds
    {
        /// <summary>
        /// Converts a mass value from pounds to metric tons.
        /// </summary>
        /// <param name="val">The mass value in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in metric tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2204.6;
            return result;
        }

        /// <summary>
        /// Converts a weight value from pounds to kilograms.
        /// </summary>
        /// <param name="val">The weight in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2.2046;
            return result;
        }

        /// <summary>
        /// Converts a weight value from pounds to grams.
        /// </summary>
        /// <param name="val">The weight in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0022046;
            return result;
        }

        /// <summary>
        /// Converts a value in pounds to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000022046;
            return result;
        }

        /// <summary>
        /// Converts a mass value from pounds to micrograms.
        /// </summary>
        /// <param name="val">The mass value in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000022046;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to long tons (imperial tons).
        /// </summary>
        /// <remarks>One long ton is equal to 1,016.0469088 kilograms. This method uses a conversion
        /// factor of 0.00044643 for approximate conversion.</remarks>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00044643;
            return result;
        }

        /// <summary>
        /// Converts a mass value from kilograms to short tons (U.S. tons).
        /// </summary>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in short tons. One short ton is equal to 2,000 pounds or approximately 907.185
        /// kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00050000;
            return result;
        }

        /// <summary>
        /// Converts a weight value from kilograms to stones.
        /// </summary>
        /// <param name="val">The weight in kilograms to convert. Must be a valid numeric value.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.071429;
            return result;
        }

        /// <summary>
        /// Converts a value in pounds to its equivalent in ounces.
        /// </summary>
        /// <remarks>One pound is equal to 16 ounces. This method multiplies the input value by 16 to
        /// perform the conversion.</remarks>
        /// <param name="val">The value in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in ounces.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 16;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting weight and mass values between ounces and other common units, including
    /// grams, kilograms, tons, pounds, stones, milligrams, and micrograms.
    /// </summary>
    /// <remarks>All conversion methods validate that input values are numeric and will throw an exception if
    /// a non-numeric value (NaN) is provided. This class is intended for use in scenarios where precise unit
    /// conversions are required, such as scientific calculations or data processing. Methods do not check for negative
    /// values unless specified; callers should ensure input values are appropriate for their use case.</remarks>
    public static class Ounces
    {
        /// <summary>
        /// Converts a weight value from grams to tons.
        /// </summary>
        /// <remarks>One ton is equal to 35,274 grams. This method performs a direct conversion using this
        /// factor.</remarks>
        /// <param name="val">The weight in grams to convert. Must be a valid numeric value.</param>
        /// <returns>The equivalent weight in tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 35274;
            return result;
        }

        /// <summary>
        /// Converts a weight value from ounces to kilograms.
        /// </summary>
        /// <param name="val">The weight in ounces to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in kilograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 35.274;
            return result;
        }

        /// <summary>
        /// Converts a weight value from ounces to grams.
        /// </summary>
        /// <param name="val">The weight in ounces to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in grams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.035274;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to its equivalent in milligrams.
        /// </summary>
        /// <param name="val">The value in ounces to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in milligrams.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.000035274;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to micrograms.
        /// </summary>
        /// <param name="val">The value in ounces to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in micrograms.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.000000035274;
            return result;
        }

        /// <summary>
        /// Converts a value in kilograms to long tons (imperial tons).
        /// </summary>
        /// <remarks>One long ton is equal to 1,016.0469088 kilograms. This method uses a conversion
        /// factor of 0.000027902 for the calculation.</remarks>
        /// <param name="val">The mass value in kilograms to convert. Must not be NaN.</param>
        /// <returns>The equivalent mass in long tons. Returns 0 if the input is 0.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000027902;
            return result;
        }

        /// <summary>
        /// Converts a value in pounds to its equivalent in short tons.
        /// </summary>
        /// <param name="val">The weight in pounds to convert. Must not be NaN.</param>
        /// <returns>The equivalent weight in short tons.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000031250;
            return result;
        }

        /// <summary>
        /// Converts a weight value from kilograms to stones.
        /// </summary>
        /// <remarks>One stone is equal to approximately 6.35029 kilograms. This method does not validate
        /// whether the input is negative.</remarks>
        /// <param name="val">The weight in kilograms to convert. Must be a valid numeric value.</param>
        /// <returns>The equivalent weight in stones.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0044643;
            return result;
        }

        /// <summary>
        /// Converts a value in ounces to its equivalent in pounds.
        /// </summary>
        /// <param name="val">The value in ounces to convert. Must be a valid number.</param>
        /// <returns>The equivalent weight in pounds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a number (NaN).</exception>
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.062500;
            return result;
        }
    }
}
namespace Calcify.Math.Conversion.Temperature
{
    /// <summary>
    /// Provides static methods for converting temperature values between a custom scale used by the application and
    /// standard temperature units such as Fahrenheit, Celsius, Kelvin, and Rankine.
    /// </summary>
    /// <remarks>The conversion methods assume input values are expressed in a custom scale where 0.8 units
    /// correspond to 1 degree Celsius. Ensure that temperature values are in the expected scale before using these
    /// methods. These methods are intended for scenarios where interoperability between the application's custom
    /// temperature scale and standard units is required.</remarks>
    public static class Reaumur
    {
        /// <summary>
        /// Converts a temperature value from the custom scale used by the application to degrees Fahrenheit.
        /// </summary>
        /// <remarks>The conversion assumes the input value is in a custom scale where 0.8 units
        /// correspond to 1 degree Celsius. Use this method only with values measured in that scale.</remarks>
        /// <param name="val">The temperature value to convert, expressed in the application's custom scale.</param>
        /// <returns>The equivalent temperature in degrees Fahrenheit.</returns>
        public static double ToFahrenheit(double val)
        {
            double result = ((val / 0.8) * 1.8) + 32;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from a scale where 0.8 units equal 1 degree Celsius to degrees Celsius.
        /// </summary>
        /// <param name="val">The temperature value to convert, expressed in units where 0.8 units equal 1 degree Celsius.</param>
        /// <returns>The equivalent temperature in degrees Celsius.</returns>
        public static double ToCelsius(double val)
        {
            double result = val / 0.8;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from an unspecified scale to Kelvin using a linear transformation.
        /// </summary>
        /// <remarks>This method assumes the input value is in a scale where dividing by 0.8 and adding
        /// 273.15 yields the Kelvin temperature. Ensure the input value is in the expected scale before calling this
        /// method.</remarks>
        /// <param name="val">The temperature value to convert. Represents a value in a scale where 0.8 units correspond to 1 Kelvin.</param>
        /// <returns>The equivalent temperature in Kelvin.</returns>
        public static double ToKelvin(double val)
        {
            double result = (val / 0.8) + 273.15;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from Celsius to Rankine.
        /// </summary>
        /// <remarks>Use this method when working with thermodynamic calculations that require
        /// temperatures in the Rankine scale. The conversion uses the formula: Rankine = Celsius × 2.25 +
        /// 491.67.</remarks>
        /// <param name="val">The temperature in degrees Celsius to convert. Typically represents an absolute temperature; negative values
        /// are allowed.</param>
        /// <returns>The equivalent temperature in degrees Rankine.</returns>
        public static double ToRankine(double val)
        {
            double result = val * 2.2500 + 491.67;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting temperatures from degrees Rankine to other temperature scales, including
    /// Fahrenheit, Celsius, Kelvin, and Réaumur.
    /// </summary>
    /// <remarks>All conversion methods assume the input value is a finite number representing a temperature
    /// in degrees Rankine. The methods perform direct mathematical conversions and do not validate the physical
    /// plausibility of the input. Negative or extremely large values are converted according to the respective formulas
    /// and may represent temperatures below absolute zero or outside typical ranges.</remarks>
    public static class Rankine
    {

        /// <summary>
        /// Converts a temperature value from degrees Rankine to degrees Fahrenheit.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the formula: Fahrenheit = Rankine -
        /// 459.67. If the input value is not a valid number, the result may be undefined (such as NaN or
        /// Infinity).</remarks>
        /// <param name="val">The temperature in degrees Rankine to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in degrees Fahrenheit.</returns>
        public static double ToFahrenheit(double val)
        {
            double result = (val - 491.67) + 32.00;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Rankine to degrees Celsius.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the formula: (Rankine - 491.67) / 1.8.
        /// The result may be negative for temperatures below absolute zero in Rankine.</remarks>
        /// <param name="val">The temperature value in degrees Rankine to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in degrees Celsius.</returns>
        public static double ToCelsius(double val)
        {
            double result = (val - 491.67) / 1.8;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from degrees Rankine to kelvins.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the standard formula for Rankine to
        /// kelvin. Negative values are valid and represent temperatures below absolute zero in the Rankine
        /// scale.</remarks>
        /// <param name="val">The temperature in degrees Rankine to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in kelvins.</returns>
        public static double ToKelvin(double val)
        {
            double result = ((val - 491.67) / 1.8) + 273.15;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Rankine to degrees Réaumur.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the formula: Réaumur = (Rankine -
        /// 491.67) / 2.25. The input value is not validated for physical plausibility; negative or extremely large
        /// values will be converted mathematically.</remarks>
        /// <param name="val">The temperature value in degrees Rankine to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in degrees Réaumur.</returns>
        public static double ToReaumur(double val)
        {
            double result = (val - 491.67) / 2.25;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting temperature values between Kelvin and other temperature scales.
    /// </summary>
    /// <remarks>This class includes methods for converting Kelvin temperatures to Celsius, Fahrenheit,
    /// Réaumur, and for converting Celsius to Rankine. All methods are static and do not perform validation for
    /// physically meaningful temperature ranges; callers should ensure input values are appropriate for the desired
    /// conversion. The class is intended for use in scientific, engineering, or educational applications where
    /// temperature conversions are required.</remarks>
    public static class Kelvin
    {

        /// <summary>
        /// Converts a temperature value from Kelvin to Celsius.
        /// </summary>
        /// <param name="val">The temperature in Kelvin to convert. Must be greater than or equal to 0.</param>
        /// <returns>The equivalent temperature in Celsius.</returns>
        public static double ToCelsius(double val)
        {
            double result = val - 273.15;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from Kelvin to Fahrenheit.
        /// </summary>
        /// <remarks>This method performs a direct conversion using the standard formula. Negative Kelvin
        /// values are not physically meaningful and may result in unexpected output.</remarks>
        /// <param name="val">The temperature in Kelvin to convert. Must be greater than or equal to 0.</param>
        /// <returns>The equivalent temperature in Fahrenheit.</returns>
        public static double ToFahrenheit(double val)
        {
            double result = (val - 273.15) * 1.8 + 32.00;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Celsius to degrees Rankine.
        /// </summary>
        /// <param name="val">The temperature value in degrees Celsius to convert.</param>
        /// <returns>The equivalent temperature in degrees Rankine.</returns>
        public static double ToRankine(double val)
        {
            double result = val * 1.8;
            return result;
        }

        /// <summary>
        /// Converts a temperature from Kelvin to Réaumur.
        /// </summary>
        /// <remarks>The Réaumur scale sets the freezing point of water at 0° and the boiling point at
        /// 80°. This method does not validate that the input is above absolute zero; passing a value less than 0 may
        /// result in nonsensical results.</remarks>
        /// <param name="val">The temperature value in Kelvin to convert. Must be greater than or equal to absolute zero (0 K).</param>
        /// <returns>The equivalent temperature in degrees Réaumur.</returns>
        public static double ToReaumur(double val)
        {
            double result = (val - 273.15) * 0.8;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting temperatures from degrees Celsius to other temperature scales, including
    /// Kelvin, Fahrenheit, Rankine, and Réaumur.
    /// </summary>
    /// <remarks>This class is intended for use in scientific, engineering, and general applications where
    /// temperature conversions from the Celsius scale are required. All methods are static and do not require
    /// instantiation. The conversion formulas used are based on standard definitions for each temperature
    /// scale.</remarks>
    public static class Celsius
    {

        /// <summary>
        /// Converts a temperature from degrees Celsius to Kelvin.
        /// </summary>
        /// <param name="val">The temperature value in degrees Celsius to convert. Can be any real number.</param>
        /// <returns>The equivalent temperature in Kelvin.</returns>
        public static double ToKelvin(double val)
        {
            double result = val + 273.15;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from degrees Celsius to degrees Fahrenheit.
        /// </summary>
        /// <param name="val">The temperature in degrees Celsius to convert.</param>
        /// <returns>The equivalent temperature in degrees Fahrenheit.</returns>
        public static double ToFahrenheit(double val)
        {
            double result = (val * 1.8) + 32;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Celsius to degrees Rankine.
        /// </summary>
        /// <remarks>Use this method when working with thermodynamic calculations that require
        /// temperatures in the Rankine scale. The conversion uses the formula: Rankine = (Celsius × 1.8) +
        /// 491.67.</remarks>
        /// <param name="val">The temperature value in degrees Celsius to convert. Typically represents an absolute or relative
        /// temperature measurement.</param>
        /// <returns>The equivalent temperature in degrees Rankine.</returns>
        public static double ToRankine(double val)
        {
            double result = (val * 1.8) + 491.67;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Celsius to degrees Réaumur.
        /// </summary>
        /// <param name="val">The temperature value in degrees Celsius to convert.</param>
        /// <returns>The equivalent temperature in degrees Réaumur.</returns>
        public static double ToReaumur(double val)
        {
            double result = val * 0.8;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting temperatures from degrees Fahrenheit to other temperature scales,
    /// including Kelvin, Celsius, Rankine, and Réaumur.
    /// </summary>
    /// <remarks>All conversion methods use standard formulas for temperature conversion and do not perform
    /// input validation. These methods are suitable for scientific and engineering calculations where precise
    /// temperature conversions are required. The class is static and cannot be instantiated.</remarks>
    public static class Fahrenheit
    {
        /// <summary>
        /// Converts a temperature from degrees Fahrenheit to Kelvin.
        /// </summary>
        /// <remarks>This method uses the standard conversion formula: K = ((F - 32) × 5/9) + 273.15. The
        /// result may be less than zero for sufficiently low input values.</remarks>
        /// <param name="val">The temperature value in degrees Fahrenheit to convert. Must be a finite number.</param>
        /// <returns>The equivalent temperature in Kelvin.</returns>
        public static double ToKelvin(double val)
        {
            double x = 5; double y = 9; double z = (val - (double)32) * (x / y) + (double)273.15;
            double result = z;
            return result;
        }

        /// <summary>
        /// Converts a temperature value from degrees Fahrenheit to degrees Celsius.
        /// </summary>
        /// <param name="val">The temperature in degrees Fahrenheit to convert.</param>
        /// <returns>The equivalent temperature in degrees Celsius.</returns>
        public static double ToCelsius(double val)
        {
            double result = (val - 32) / 1.8;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Fahrenheit to degrees Rankine.
        /// </summary>
        /// <remarks>Degrees Rankine is an absolute temperature scale used primarily in engineering
        /// fields. The conversion adds 459.67 to the Fahrenheit value to obtain the Rankine temperature.</remarks>
        /// <param name="val">The temperature value in degrees Fahrenheit to convert. Typically represents an absolute temperature
        /// measurement.</param>
        /// <returns>The equivalent temperature in degrees Rankine.</returns>
        public static double ToRankine(double val)
        {
            double z = val + (double)459.67;
            double result = z;
            return result;
        }

        /// <summary>
        /// Converts a temperature from degrees Fahrenheit to degrees Réaumur.
        /// </summary>
        /// <remarks>The Réaumur scale is primarily used in some scientific contexts and historical
        /// references. This method does not perform range validation on the input value.</remarks>
        /// <param name="val">The temperature value in degrees Fahrenheit to convert.</param>
        /// <returns>The equivalent temperature in degrees Réaumur.</returns>
        public static double ToReaumur(double val)
        {
            double result = (val - (double)32) / (double)1.8 * (double)0.8;
            return result;
        }
    }
}
namespace Calcify.Math.Conversion.Time
{
    /// <summary>
    /// Provides static methods for converting between centuries, millennia, years, and other time units using fixed
    /// conversion factors.
    /// </summary>
    /// <remarks>All conversion methods assume standard calendar years and do not account for leap years or
    /// calendar variations. Each method throws an ArgumentException if the input value is NaN.</remarks>
    public static class Centuries
    {
        /// <summary>
        /// Converts a value representing years to its equivalent in decades.
        /// </summary>
        /// <param name="val">The number of years to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of decades.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in years by multiplying it by 100.
        /// </summary>
        /// <param name="val">The value to convert to years. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the input value converted to years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 100;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in months.
        /// </summary>
        /// <param name="val">The value to convert. Must be a valid number; cannot be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the converted value in months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1200;
            return result;
        }

        /// <summary>
        /// Converts the specified value to an equivalent number of weeks using a fixed conversion factor.
        /// </summary>
        /// <param name="val">The value to convert to weeks. Must be a valid number; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of weeks for the specified value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 5214.29;
            return result;
        }

        /// <summary>
        /// Converts a value representing centuries to the equivalent number of days.
        /// </summary>
        /// <param name="val">The number of centuries to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The number of days equivalent to the specified number of centuries.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 36500;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing centuries, to the equivalent number of hours.
        /// </summary>
        /// <param name="val">The number of centuries to convert to hours. Must not be NaN.</param>
        /// <returns>The equivalent number of hours for the specified number of centuries.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 876000;
            return result;
        }

        /// <summary>
        /// Converts a value representing centuries to the equivalent number of minutes.
        /// </summary>
        /// <param name="val">The number of centuries to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The total number of minutes in the specified number of centuries.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 52560000;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing millennia, to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of millennia to convert to seconds. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the equivalent number of seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000;
            return result;
        }

        /// <summary>
        /// Converts a value representing millennia to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The number of millennia to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of milliseconds for the specified number of millennia.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing millennia to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of millennia to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the equivalent number of microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in nanoseconds.
        /// </summary>
        /// <remarks>One year is considered as 3,153,600,000,000,000,000 nanoseconds. This method does not
        /// account for leap years or calendar variations.</remarks>
        /// <param name="val">The number of years to convert to nanoseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting between various time units, such as decades, centuries, years, months,
    /// days, hours, minutes, seconds, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume fixed conversion factors and do not account for calendar
    /// variations such as leap years unless otherwise noted. Input values must be valid numeric values and cannot be
    /// NaN; methods will throw an ArgumentException if invalid input is provided.</remarks>
    public static class Decades
    {
        /// <summary>
        /// Converts a value representing decades to its equivalent in centuries.
        /// </summary>
        /// <param name="val">The number of decades to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of decades.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in years.
        /// </summary>
        /// <param name="val">The value to convert. Must be a valid number; cannot be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the input value converted to years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 10;
            return result;
        }

        /// <summary>
        /// Converts the specified value to its equivalent in months.
        /// </summary>
        /// <param name="val">The value to convert to months. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the converted value in months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 120;
            return result;
        }

        /// <summary>
        /// Converts a value from days to weeks using a fixed conversion factor.
        /// </summary>
        /// <remarks>The conversion uses a factor of 521.429 to calculate weeks from days. This method
        /// does not validate whether the input value is within a typical range for days.</remarks>
        /// <param name="val">The number of days to convert to weeks. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of weeks for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 521.429;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing years, to the equivalent number of days.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365 days. Leap years are not accounted for in
        /// the conversion.</remarks>
        /// <param name="val">The number of years to convert to days. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the equivalent number of days for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3650;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of hours.
        /// </summary>
        /// <remarks>This method assumes a year consists of 8,760 hours (365 days). Leap years are not
        /// accounted for in the calculation.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The number of hours equivalent to the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 87600;
            return result;
        }

        /// <summary>
        /// Converts a value representing millennia to the equivalent number of minutes.
        /// </summary>
        /// <param name="val">The number of millennia to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The total number of minutes corresponding to the specified number of millennia.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 5256000;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing centuries, to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of centuries to convert to seconds. Must not be NaN.</param>
        /// <returns>The number of seconds equivalent to the specified number of centuries.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent duration in milliseconds.
        /// </summary>
        /// <param name="val">The number of years to convert to milliseconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent duration in milliseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of years to convert to microseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of microseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in nanoseconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365 days. Leap years and calendar variations
        /// are not considered.</remarks>
        /// <param name="val">The number of years to convert to nanoseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting a value representing years to equivalent durations in other time units,
    /// such as centuries, decades, months, weeks, days, hours, minutes, seconds, milliseconds, microseconds, and
    /// nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume standard calendar values (e.g., 365 days per year) and do not
    /// account for leap years or calendar variations unless otherwise noted. Methods will throw an ArgumentException if
    /// the input value is NaN.</remarks>
    public static class Years
    {
        /// <summary>
        /// Converts a value representing years to its equivalent in centuries.
        /// </summary>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 100;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in decades.
        /// </summary>
        /// <param name="val">The number of years to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the number of decades equivalent to the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 10;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in months.
        /// </summary>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of months for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 12;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of weeks.
        /// </summary>
        /// <remarks>The conversion uses an average of 52.1429 weeks per year, which accounts for leap
        /// years over a 400-year cycle.</remarks>
        /// <param name="val">The number of years to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of weeks for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 52.1429;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of days.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365 days and does not account for leap years
        /// or calendar variations.</remarks>
        /// <param name="val">The number of years to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the equivalent number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 365;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of hours.
        /// </summary>
        /// <remarks>This method assumes a year consists of 8,760 hours (365 days). Leap years are not
        /// accounted for.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of hours for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8760;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of minutes.
        /// </summary>
        /// <remarks>This method assumes a year consists of 525,600 minutes (i.e., 365 days). Leap years
        /// are not accounted for.</remarks>
        /// <param name="val">The number of years to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The number of minutes equivalent to the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 525600;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in seconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of exactly 31,536,000 seconds (365 days). Leap
        /// years and variations in calendar systems are not accounted for.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of seconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent duration in milliseconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365 days and does not account for leap years
        /// or calendar variations.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent duration in milliseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of years to convert to microseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of microseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The number of years to convert to nanoseconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting time durations expressed in months or years to other units such as
    /// centuries, decades, years, weeks, days, hours, minutes, seconds, milliseconds, microseconds, and nanoseconds.
    /// All conversions use standard or average values for each unit and are intended for approximate calculations.
    /// </summary>
    /// <remarks>The conversion methods in this class use fixed or average values for time units (e.g.,
    /// average days per month, hours per month, days per year) and may not reflect exact calendar durations. These
    /// methods are suitable for general-purpose or approximate calculations, but may not be appropriate for scenarios
    /// requiring precise date or time computations. All methods validate input values and throw an ArgumentException if
    /// the input is NaN.</remarks>
    public static class Months
    {
        /// <summary>
        /// Converts a value representing months to its equivalent in centuries.
        /// </summary>
        /// <param name="val">The number of months to convert. Must not be NaN.</param>
        /// <returns>A double value representing the number of centuries equivalent to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1200;
            return result;
        }

        /// <summary>
        /// Converts a value representing months to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is defined as 120 months. The conversion divides the input value by
        /// 120.</remarks>
        /// <param name="val">The number of months to convert. Must not be NaN.</param>
        /// <returns>A double value representing the number of decades equivalent to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 120;
            return result;
        }

        /// <summary>
        /// Converts a value in months to its equivalent in years.
        /// </summary>
        /// <param name="val">The number of months to convert. Must not be NaN.</param>
        /// <returns>The number of years equivalent to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 12;
            return result;
        }

        /// <summary>
        /// Converts a value in months to its approximate equivalent in weeks.
        /// </summary>
        /// <remarks>This method uses an average conversion factor of 4.345 weeks per month, which may not
        /// reflect the exact number of weeks in every month.</remarks>
        /// <param name="val">The number of months to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The approximate number of weeks corresponding to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 4.345;
            return result;
        }

        /// <summary>
        /// Converts a value representing months to the equivalent number of days using an average month length.
        /// </summary>
        /// <remarks>This method uses an average month length of 30.417 days for the conversion. The
        /// result may not be precise for calendar calculations that require exact day counts.</remarks>
        /// <param name="val">The number of months to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the approximate number of days corresponding to the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 30.417;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing months, to the equivalent number of hours.
        /// </summary>
        /// <remarks>This method assumes a fixed value of 730 hours per month, which may not reflect
        /// actual calendar month durations. Use this conversion for approximate calculations where such precision is
        /// acceptable.</remarks>
        /// <param name="val">The number of months to convert to hours. Must not be NaN.</param>
        /// <returns>A double value representing the total number of hours in the specified number of months, assuming each month
        /// has 730 hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 730;
            return result;
        }

        /// <summary>
        /// Converts a value representing years to the equivalent number of minutes.
        /// </summary>
        /// <remarks>This method assumes a year consists of 43,800 minutes, based on a 365-day year. Leap
        /// years are not accounted for.</remarks>
        /// <param name="val">The number of years to convert to minutes. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent number of minutes for the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 43800;
            return result;
        }

        /// <summary>
        /// Converts a value representing months into the equivalent number of seconds.
        /// </summary>
        /// <remarks>This method assumes a fixed conversion rate of 2,628,000 seconds per month, which may
        /// not reflect the exact number of seconds in all calendar months.</remarks>
        /// <param name="val">The number of months to convert to seconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent number of seconds for the specified number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000;
            return result;
        }

        /// <summary>
        /// Converts a value representing months into the equivalent number of milliseconds.
        /// </summary>
        /// <remarks>This method assumes a fixed month length of 30.44 days (the average length of a month
        /// in the Gregorian calendar) when performing the conversion.</remarks>
        /// <param name="val">The number of months to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the total number of milliseconds equivalent to the specified
        /// number of months.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from years to microseconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365.25 days to account for leap
        /// years.</remarks>
        /// <param name="val">The number of years to convert. Must not be NaN.</param>
        /// <returns>The equivalent number of microseconds represented by the specified number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in years to its equivalent duration in nanoseconds.
        /// </summary>
        /// <remarks>This method assumes a year consists of 365.25 days for conversion purposes.</remarks>
        /// <param name="val">The number of years to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent duration in nanoseconds as a double-precision floating-point value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting time values between weeks and other units, including days, hours,
    /// minutes, seconds, months, years, decades, centuries, and various time intervals.
    /// </summary>
    /// <remarks>All conversion methods require valid numeric input values and will throw an ArgumentException
    /// if the provided value is NaN. Conversion factors are based on standard or average values and may result in
    /// approximate results for units such as months, years, or decades. This class is thread-safe and intended for
    /// utility use in time-related calculations.</remarks>
    public static class Weeks
    {
        /// <summary>
        /// Converts a value representing days to its equivalent in centuries.
        /// </summary>
        /// <param name="val">The number of days to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 5214.3;
            return result;
        }

        /// <summary>
        /// Converts a value from years to decades using a fixed conversion factor.
        /// </summary>
        /// <remarks>This method uses a conversion factor of 521.43 years per decade. The result may not
        /// reflect standard calendar decades and is based on the specified factor.</remarks>
        /// <param name="val">The number of years to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of decades.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 521.43;
            return result;
        }
        /// <summary>
        /// Converts a value representing weeks to its equivalent in years.
        /// </summary>
        /// <remarks>The conversion uses 52.143 weeks per year as the basis for calculation.</remarks>
        /// <param name="val">The number of weeks to convert. Must be a valid numeric value.</param>
        /// <returns>A double representing the equivalent number of years for the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 52.143;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of months using an average month length.
        /// </summary>
        /// <remarks>This method uses an average month length of 4.345 weeks (approximately 30.44 days)
        /// for the conversion. The result is an approximation and may not reflect calendar month boundaries.</remarks>
        /// <param name="val">The number of days to convert to months. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the approximate number of months corresponding to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 4.345;
            return result;
        }

        /// <summary>
        /// Converts the specified number of weeks to the equivalent number of days.
        /// </summary>
        /// <param name="val">The number of weeks to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the total number of days corresponding to the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 7;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing weeks, to the equivalent number of hours.
        /// </summary>
        /// <param name="val">The number of weeks to convert to hours. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the total number of hours in the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 168;
            return result;
        }

        /// <summary>
        /// Converts a value representing weeks to the equivalent number of minutes.
        /// </summary>
        /// <param name="val">The number of weeks to convert to minutes. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The equivalent number of minutes for the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 10080;
            return result;
        }

        /// <summary>
        /// Converts a value representing weeks to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of weeks to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>The number of seconds equivalent to the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800;
            return result;
        }

        /// <summary>
        /// Converts a value representing weeks to its equivalent duration in milliseconds.
        /// </summary>
        /// <param name="val">The number of weeks to convert. Must be a valid numeric value; cannot be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the specified number of weeks in milliseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800000;
            return result;
        }

        /// <summary>
        /// Converts a value representing weeks to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of weeks to convert to microseconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of microseconds equivalent to the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800000000;
            return result;
        }

        /// <summary>
        /// Converts the specified value, representing weeks, to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The number of weeks to convert to nanoseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of weeks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting a number of days to equivalent values in other time units, such as
    /// centuries, decades, years, months, weeks, hours, minutes, seconds, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume standard time unit lengths and do not account for leap years or
    /// calendar irregularities. Methods throw an ArgumentException if the input value is not a valid number
    /// (NaN).</remarks>
    public static class Days
    {
        /// <summary>
        /// Converts a number of days to the equivalent number of centuries.
        /// </summary>
        /// <remarks>One century is considered to be 36,500 days.</remarks>
        /// <param name="val">The number of days to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 36500;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in decades.
        /// </summary>
        /// <remarks>A decade is considered as 3,650 days (10 years of 365 days each). This method does
        /// not account for leap years.</remarks>
        /// <param name="val">The number of days to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3650;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of years.
        /// </summary>
        /// <param name="val">The number of days to convert. Must not be NaN.</param>
        /// <returns>A double value representing the equivalent number of years.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 365;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of months.
        /// </summary>
        /// <remarks>The conversion uses an average month length of 30.417 days. The result is an
        /// approximation and may not reflect calendar month boundaries.</remarks>
        /// <param name="val">The number of days to convert to months. Must be a valid numeric value.</param>
        /// <returns>A double representing the approximate number of months corresponding to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 30.417;
            return result;
        }

        /// <summary>
        /// Converts a number of days to the equivalent number of weeks.
        /// </summary>
        /// <param name="val">The number of days to convert. Must be a valid numeric value.</param>
        /// <returns>The number of weeks equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 7;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in hours.
        /// </summary>
        /// <param name="val">The number of days to convert to hours. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of hours for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 24;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of minutes.
        /// </summary>
        /// <param name="val">The number of days to convert to minutes. Must not be NaN.</param>
        /// <returns>The equivalent number of minutes for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1440;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of days to convert to seconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the total number of seconds equivalent to the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The number of days to convert to milliseconds. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> value representing the specified number of days in milliseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400000;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of days to convert to microseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of microseconds for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The number of days to convert to nanoseconds. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400000000000;
            return result;
        }
    }
    /// <summary>
    /// Provides static methods for converting time values between hours and other units, including centuries, decades,
    /// years, months, weeks, days, minutes, seconds, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume fixed conversion factors and do not account for calendar
    /// variations such as leap years or differing month lengths. Each method throws an ArgumentException if the input
    /// value is not a valid number (NaN). These methods are intended for approximate calculations and should not be
    /// used where precise calendar-based conversions are required.</remarks>
    public static class Hours
    {
        /// <summary>
        /// Converts a time value, specified in hours, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is considered to be 876,000 hours. The conversion divides the input value
        /// by this constant.</remarks>
        /// <param name="val">The time value in hours to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 876000;
            return result;
        }

        /// <summary>
        /// Converts a time value from hours to decades.
        /// </summary>
        /// <remarks>One decade is considered to be 87,600 hours. This method performs a direct division
        /// without rounding.</remarks>
        /// <param name="val">The time value, in hours, to convert to decades. Must not be NaN.</param>
        /// <returns>The equivalent time in decades as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 87600;
            return result;
        }

        /// <summary>
        /// Converts a time value from hours to years.
        /// </summary>
        /// <remarks>This method assumes a year consists of 8,760 hours (365 days). For leap years or more
        /// precise calculations, consider adjusting the conversion factor.</remarks>
        /// <param name="val">The time value, in hours, to convert to years. Must not be NaN.</param>
        /// <returns>The equivalent time in years, calculated by dividing the input value by 8,760.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 8760;
            return result;
        }

        /// <summary>
        /// Converts a value representing days to the equivalent number of months using a fixed average month length.
        /// </summary>
        /// <remarks>This method uses 730.001 days as the average length of a month for conversion. The
        /// result may not correspond to calendar months and is intended for approximate calculations.</remarks>
        /// <param name="val">The number of days to convert to months. Must be a valid numeric value.</param>
        /// <returns>A double representing the equivalent number of months for the specified number of days.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 730.001;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in hours, to its equivalent in weeks.
        /// </summary>
        /// <remarks>One week is considered to be 168 hours.</remarks>
        /// <param name="val">The time value in hours to convert. Must not be NaN.</param>
        /// <returns>The number of weeks equivalent to the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 168;
            return result;
        }

        /// <summary>
        /// Converts a time value from hours to days.
        /// </summary>
        /// <param name="val">The time value, in hours, to convert to days. Must not be NaN.</param>
        /// <returns>The equivalent time in days, calculated as the input value divided by 24.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 24;
            return result;
        }

        /// <summary>
        /// Converts a value in hours to its equivalent in minutes.
        /// </summary>
        /// <param name="val">The number of hours to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of minutes for the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60;
            return result;
        }

        /// <summary>
        /// Converts a value representing hours to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of hours to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of seconds for the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600;
            return result;
        }

        /// <summary>
        /// Converts a value representing hours to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The number of hours to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of milliseconds for the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600000;
            return result;
        }

        /// <summary>
        /// Converts a value in hours to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The number of hours to convert to microseconds. Must not be NaN.</param>
        /// <returns>The equivalent value in microseconds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600000000;
            return result;
        }

        /// <summary>
        /// Converts the specified value in hours to nanoseconds.
        /// </summary>
        /// <param name="val">The value, in hours, to convert to nanoseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds for the specified value in hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600000000000;
            return result;
        }
    }
    /// <summary>
    /// Provides static methods for converting time values expressed in minutes to various other units, including
    /// centuries, decades, years, months, weeks, days, hours, seconds, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods assume fixed conversion factors and do not account for leap years,
    /// calendar variations, or time zone differences. Each method throws an ArgumentException if the input value is not
    /// a valid number (NaN). These methods are intended for straightforward time unit conversions and may not be
    /// suitable for precise calendrical calculations.</remarks>
    public static class Minutes
    {
        /// <summary>
        /// Converts a time value, specified in minutes, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is considered to be 52,560,000 minutes.</remarks>
        /// <param name="val">The time value in minutes to convert. Must be a valid number.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified number of minutes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is not a valid number (NaN).</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 52560000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in minutes, to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is considered to be 5,256,000 minutes. This method performs a simple
        /// division and does not account for leap years or calendar variations.</remarks>
        /// <param name="val">The time value in minutes to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified number of minutes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 5256000;
            return result;
        }

        /// <summary>
        /// Converts a time value from minutes to years.
        /// </summary>
        /// <remarks>This method assumes a year consists of 525,600 minutes (365 days).</remarks>
        /// <param name="val">The time value, in minutes, to convert to years. Must not be NaN.</param>
        /// <returns>The equivalent time in years, calculated as the input value divided by 525,600.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 525600;
            return result;
        }

        /// <summary>
        /// Converts a time value from hours to months using a fixed conversion factor.
        /// </summary>
        /// <remarks>This method uses a fixed conversion factor of 43,800 hours per month. The result may
        /// not reflect calendar month variations.</remarks>
        /// <param name="val">The time value in hours to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A double representing the equivalent number of months for the specified number of hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 43800;
            return result;
        }

        /// <summary>
        /// Converts a time value from minutes to weeks.
        /// </summary>
        /// <remarks>One week is considered to be 10,080 minutes. The conversion divides the input value
        /// by 10,080.</remarks>
        /// <param name="val">The time value, in minutes, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent time in weeks, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 10080;
            return result;
        }

        /// <summary>
        /// Converts a time value from minutes to days.
        /// </summary>
        /// <param name="val">The time value, in minutes, to convert to days. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of days for the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1440;
            return result;
        }

        /// <summary>
        /// Converts a time value from minutes to hours.
        /// </summary>
        /// <param name="val">The time value, in minutes, to convert to hours. Must not be NaN.</param>
        /// <returns>The equivalent time in hours as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60;
            return result;
        }

        /// <summary>
        /// Converts a value in minutes to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The number of minutes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60;
            return result;
        }

        /// <summary>
        /// Converts a value representing minutes to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The number of minutes to convert. Must be a valid numeric value; cannot be NaN.</param>
        /// <returns>A double representing the equivalent number of milliseconds for the specified number of minutes.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from minutes to microseconds.
        /// </summary>
        /// <param name="val">The value, in minutes, to convert to microseconds. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of microseconds for the specified value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60000000;
            return result;
        }

        /// <summary>
        /// Converts a value in minutes to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The number of minutes to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting time values specified in seconds to various other time units, including
    /// centuries, decades, years, months, weeks, days, hours, minutes, milliseconds, microseconds, and nanoseconds.
    /// </summary>
    /// <remarks>All conversion methods require the input value to be a valid double that is not <see
    /// cref="double.NaN"/>. If an invalid value is provided, an <see cref="ArgumentException"/> is thrown. The
    /// conversions use fixed values for the length of each time unit, which may not account for calendar variations
    /// (such as leap years or differing month lengths). These methods are intended for approximate calculations and
    /// should not be used where precise calendar accuracy is required.</remarks>
    public static class Seconds
    {
        /// <summary>
        /// Converts a time value, specified in seconds, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is defined as 3,153,600,000 seconds.</remarks>
        /// <param name="val">The time value in seconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the number of centuries equivalent to the specified time in seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to decades.
        /// </summary>
        /// <remarks>One decade is defined as 315,360,000 seconds (10 years of 365 days each).</remarks>
        /// <param name="val">The time value, in seconds, to convert to decades. Must not be NaN.</param>
        /// <returns>The equivalent time in decades, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to years.
        /// </summary>
        /// <remarks>One year is considered to be 31,536,000 seconds (365 days).</remarks>
        /// <param name="val">The time value, in seconds, to convert to years. Must not be NaN.</param>
        /// <returns>The equivalent time in years as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to months using a fixed average month length.
        /// </summary>
        /// <remarks>This method uses 2,628,000 seconds as the average length of a month, which may not
        /// reflect calendar month variations. The result is a fractional value representing months.</remarks>
        /// <param name="val">The time value in seconds to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in months, calculated by dividing the input value by 2,628,000 (the average number of
        /// seconds in a month).</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to weeks.
        /// </summary>
        /// <param name="val">The time interval, in seconds, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent time in weeks, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to days.
        /// </summary>
        /// <param name="val">The time value, in seconds, to convert to days. Must not be NaN.</param>
        /// <returns>The equivalent time in days, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to hours.
        /// </summary>
        /// <param name="val">The time value, in seconds, to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in hours, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600;
            return result;
        }

        /// <summary>
        /// Converts a time value from seconds to minutes.
        /// </summary>
        /// <param name="val">The time value, in seconds, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent time in minutes as a <see cref="double"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60;
            return result;
        }

        /// <summary>
        /// Converts a value in seconds to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The value in seconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent number of milliseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from seconds to microseconds.
        /// </summary>
        /// <param name="val">The value in seconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent value in microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in seconds to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The time interval in seconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the specified time interval in nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting time values between milliseconds and other time units, including
    /// nanoseconds, microseconds, seconds, minutes, hours, days, weeks, months, years, decades, and centuries.
    /// </summary>
    /// <remarks>All conversion methods require input values that are not <see cref="double.NaN"/> and will
    /// throw an <see cref="ArgumentException"/> if a NaN value is provided. The conversions use fixed factors and do
    /// not account for calendar variations, leap years, or time zone differences. These methods are intended for
    /// general-purpose time unit conversions and may not be suitable for precise calendrical calculations.</remarks>
    public static class Milliseconds
    {
        /// <summary>
        /// Converts a time value, specified in nanoseconds, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is considered to be 3,153,600,000,000 nanoseconds. The conversion is
        /// performed using this constant factor.</remarks>
        /// <param name="val">The time value in nanoseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in nanoseconds, to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is defined as 315,360,000,000 nanoseconds. This method does not validate
        /// whether the input is within a realistic range for time values.</remarks>
        /// <param name="val">The time value in nanoseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to years.
        /// </summary>
        /// <remarks>One year is considered to be 31,536,000,000 milliseconds. This method does not
        /// account for leap years or calendar variations.</remarks>
        /// <param name="val">The time value, in milliseconds, to convert to years. Must not be NaN.</param>
        /// <returns>The equivalent time in years, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to months.
        /// </summary>
        /// <remarks>This method assumes one month is equal to 2,628,000,000 milliseconds (approximately
        /// 30.44 days).</remarks>
        /// <param name="val">The time value, in milliseconds, to convert to months. Must not be NaN.</param>
        /// <returns>The equivalent number of months represented by the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to weeks.
        /// </summary>
        /// <param name="val">The time value, in milliseconds, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent number of weeks represented by the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to days.
        /// </summary>
        /// <param name="val">The time value, in milliseconds, to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in days, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to hours.
        /// </summary>
        /// <param name="val">The time value in milliseconds to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in hours as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600000;
            return result;
        }

        /// <summary>
        /// Converts a time value from milliseconds to minutes.
        /// </summary>
        /// <param name="val">The time value, in milliseconds, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent time in minutes as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60000;
            return result;
        }

        /// <summary>
        /// Converts a value from milliseconds to seconds.
        /// </summary>
        /// <param name="val">The value in milliseconds to convert. Must not be NaN.</param>
        /// <returns>The equivalent value in seconds as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in milliseconds to its equivalent in microseconds.
        /// </summary>
        /// <param name="val">The value in milliseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in milliseconds to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The value in milliseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the equivalent number of nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
    }
    /// <summary>
    /// Provides static methods for converting time values between microseconds and other time units, including
    /// nanoseconds, milliseconds, seconds, minutes, hours, days, weeks, months, years, decades, and centuries.
    /// </summary>
    /// <remarks>All conversion methods validate that the input value is not <see cref="double.NaN"/> and
    /// throw an <see cref="ArgumentException"/> if this condition is not met. The conversions use fixed values for unit
    /// lengths, which may not account for calendar variations or leap years. These methods are intended for
    /// general-purpose time unit conversions and do not perform additional range or overflow checks.</remarks>
    public static class Microseconds
    {
        /// <summary>
        /// Converts a time value, specified in femtoseconds, to its equivalent in centuries.
        /// </summary>
        /// <remarks>One century is considered to be 3,153,600,000,000,000 femtoseconds.</remarks>
        /// <param name="val">The time value in femtoseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of centuries equivalent to the specified femtoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in femtoseconds, to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is defined as 315,360,000,000,000 femtoseconds. This method does not
        /// validate the range of the input value beyond checking for NaN.</remarks>
        /// <param name="val">The time value to convert, in femtoseconds. Must not be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified femtoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from femtoseconds to years.
        /// </summary>
        /// <remarks>One year is considered to be 31,536,000,000,000 femtoseconds. This method does not
        /// perform range checking beyond NaN validation.</remarks>
        /// <param name="val">The time interval to convert, specified in femtoseconds. Must not be NaN.</param>
        /// <returns>The equivalent time in years as a double-precision floating-point value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from nanoseconds to months.
        /// </summary>
        /// <remarks>One month is considered to be 2,628,000,000,000 nanoseconds. This conversion uses a
        /// fixed average month length and may not account for variations in calendar months.</remarks>
        /// <param name="val">The time value, in nanoseconds, to convert. Must not be NaN.</param>
        /// <returns>The equivalent time in months, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from ticks to weeks.
        /// </summary>
        /// <remarks>One week is defined as 604,800,000,000 ticks. This method does not validate that the
        /// input represents a whole number of weeks.</remarks>
        /// <param name="val">The time value, in ticks, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent number of weeks represented by the specified tick value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from 100-nanosecond intervals to days.
        /// </summary>
        /// <remarks>This method is useful for converting time values commonly used in Windows file times
        /// or .NET ticks to a day-based representation.</remarks>
        /// <param name="val">The time value, in 100-nanosecond intervals, to convert to days. Must not be NaN.</param>
        /// <returns>The equivalent number of days represented by the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from ticks to hours.
        /// </summary>
        /// <param name="val">The time value, in ticks, to convert to hours. Must not be NaN.</param>
        /// <returns>A double representing the equivalent time in hours.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600000000;
            return result;
        }

        /// <summary>
        /// Converts a value representing microseconds to its equivalent in minutes.
        /// </summary>
        /// <param name="val">The value, in microseconds, to convert to minutes. Must not be NaN.</param>
        /// <returns>A double representing the number of minutes equivalent to the specified microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60000000;
            return result;
        }

        /// <summary>
        /// Converts a value from microseconds to seconds.
        /// </summary>
        /// <param name="val">The value in microseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts the specified value from microseconds to milliseconds.
        /// </summary>
        /// <param name="val">The value, in microseconds, to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent value in milliseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }

        /// <summary>
        /// Converts a value in microseconds to its equivalent in nanoseconds.
        /// </summary>
        /// <param name="val">The value in microseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent value in nanoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
    }

    /// <summary>
    /// Provides static methods for converting time values between nanoseconds and other time units, such as
    /// microseconds, milliseconds, seconds, minutes, hours, days, weeks, months, years, decades, and centuries.
    /// </summary>
    /// <remarks>This class offers utility methods for time conversions commonly needed when working with
    /// high-precision time intervals. All methods perform direct conversions based on fixed unit definitions and do not
    /// validate whether the input values represent meaningful or typical time spans. Each method throws an
    /// ArgumentException if the input value is NaN. The class is thread-safe and intended for use in scenarios
    /// requiring precise time unit conversions.</remarks>
    public static class Nanoseconds
    {
        /// <summary>
        /// Converts a time value, specified in ticks, to its equivalent number of centuries.
        /// </summary>
        /// <remarks>One century is defined as 3,153,600,000,000,000,000 ticks. This method does not
        /// validate whether the input represents a meaningful time span; it performs a direct conversion.</remarks>
        /// <param name="val">The time value in ticks to convert. Must not be NaN.</param>
        /// <returns>The number of centuries represented by the specified time value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in femtoseconds, to its equivalent in decades.
        /// </summary>
        /// <remarks>One decade is defined as 315,360,000,000,000,000 femtoseconds. This method does not
        /// validate for negative or infinite values.</remarks>
        /// <param name="val">The time value in femtoseconds to convert. Must not be NaN.</param>
        /// <returns>A double representing the number of decades equivalent to the specified femtoseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from femtoseconds to years.
        /// </summary>
        /// <remarks>One year is considered to be 31,536,000,000,000,000 femtoseconds. This method does
        /// not perform range checking beyond NaN validation.</remarks>
        /// <param name="val">The time interval to convert, specified in femtoseconds. Must not be NaN.</param>
        /// <returns>The equivalent time in years as a double-precision floating-point value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value, specified in picoseconds, to the equivalent number of months.
        /// </summary>
        /// <remarks>One month is considered to be 2,628,000,000,000,000 picoseconds. The conversion may
        /// result in a fractional value if the input does not represent an exact number of months.</remarks>
        /// <param name="val">The time value in picoseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The number of months equivalent to the specified time value. The result may be fractional.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from ticks to weeks.
        /// </summary>
        /// <remarks>One week is defined as 604,800,000,000,000 ticks. This method does not validate that
        /// the input is within a typical range for time values.</remarks>
        /// <param name="val">The time value, in ticks, to convert to weeks. Must not be NaN.</param>
        /// <returns>The equivalent number of weeks represented by the specified tick value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800000000000;
            return result;
        }

        /// <summary>
        /// Converts a time interval specified in ticks to its equivalent value in days.
        /// </summary>
        /// <remarks>One day is defined as 86,400,000,000,000 ticks. This method does not validate whether
        /// the input represents a valid time interval; it simply performs the conversion.</remarks>
        /// <param name="val">The time interval, in ticks, to convert to days. Must not be NaN.</param>
        /// <returns>The number of days that corresponds to the specified number of ticks.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from ticks to hours.
        /// </summary>
        /// <remarks>One tick represents 100 nanoseconds. Use this method to convert tick-based time
        /// values to hours for calculations or display.</remarks>
        /// <param name="val">The time value, in ticks, to convert to hours. Must not be NaN.</param>
        /// <returns>The equivalent time in hours, represented as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600000000000;
            return result;
        }

        /// <summary>
        /// Converts a time value from 100-nanosecond units to minutes.
        /// </summary>
        /// <remarks>This method is useful for converting time values represented in .NET ticks (where one
        /// tick equals 100 nanoseconds) to minutes. The conversion is performed by dividing the input value by
        /// 60,000,000,000.</remarks>
        /// <param name="val">The time value to convert, specified in 100-nanosecond units. Must not be NaN.</param>
        /// <returns>The equivalent time in minutes as a double-precision floating-point number.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is NaN.</exception>
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanoseconds to its equivalent in seconds.
        /// </summary>
        /// <param name="val">The time interval in nanoseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>A <see cref="double"/> representing the equivalent time in seconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanoseconds to its equivalent in milliseconds.
        /// </summary>
        /// <param name="val">The value in nanoseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in milliseconds as a <see cref="double"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }

        /// <summary>
        /// Converts a value in nanoseconds to microseconds.
        /// </summary>
        /// <param name="val">The value in nanoseconds to convert. Must not be <see cref="double.NaN"/>.</param>
        /// <returns>The equivalent value in microseconds.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="val"/> is <see cref="double.NaN"/>.</exception>
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
    }
}
namespace Calcify.Math
{
    /// <summary>
    /// Provides mathematical utility methods for calculating factorials and combinations.
    /// </summary>
    /// <remarks>The static methods in the Functions class support common combinatorial calculations, such as
    /// computing the factorial of a non-negative number and determining the number of possible combinations for a given
    /// set size. All methods validate input parameters and throw exceptions for invalid arguments. These methods are
    /// thread-safe as they do not maintain any internal state.</remarks>
    class Functions
    {
        /// <summary>
        /// Returns the factorial value of number greater than zero.
        /// </summary>
        /// <param name="d">A number greater than or equal to 0, but less than or equal to System.Double.MaxValue.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double Factorial(double d)
        {
            if (d < 0)
                throw new ArgumentOutOfRangeException();
            else if (d == 0)
                return 1;
            else
            {
                double result = 0;
                for (double n = d; n > 0; n--)
                {
                    if (result == 0) result = n;
                    else result *= n;
                }
                return result;
            }

        }

        /// <summary>
        /// Calculates the number of combinations that can be made by selecting a subset of size r from a set of size n.
        /// </summary>
        /// <param name="n">The total number of items in the set. Must be greater than or equal to <paramref name="r"/>.</param>
        /// <param name="r">The number of items to select from the set. Must be less than or equal to <paramref name="n"/>.</param>
        /// <returns>The number of possible combinations as a double-precision floating-point value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="n"/> is less than <paramref name="r"/>.</exception>
        public static double nCr(int n, int r)
        {
            if (n < r)
                throw new ArgumentException();
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }
    }

    /// <summary>
    /// Provides static methods for performing mathematical calculations, including conversion between Unix timestamps
    /// and DateTime values, and evaluating mathematical expressions represented as strings.
    /// </summary>
    /// <remarks>The Calculator class includes utility methods for converting Unix timestamps to and from
    /// DateTime, generating regular expressions for parsing mathematical expressions, and evaluating string-based math
    /// tasks that support brackets, exponentials, factorials, and standard arithmetic operations. All methods are
    /// static and can be used without instantiating the class.</remarks>
    class Calculator
    {
        /// <summary>
        /// Converts a Unix timestamp to a DateTime.
        /// </summary>
        /// <param name="unixTimeStamp">The Unix timestamp to convert to a DateTime.</param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            if (unixTimeStamp < 0)
                throw new ArgumentException();

            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        /// <summary>
        /// Converts a DateTime to a Unix timestamp.
        /// </summary>
        /// <param name="dateTime">The DateTime to convert to a Unix timestamp.</param>
        /// <returns></returns>
        public static double DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            double unixTimeStamp = dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTimeStamp;
        }

        /// <summary>
        /// To save some time we create all Regex' at the beginning and give them to the calculator later
        /// </summary>
        /// <returns>A dictionary with all Regex'</returns>
        public static Dictionary<string, Regex> RegexDict()
        {
            Dictionary<string, Regex> dict = new Dictionary<string, Regex>();
            dict.Add("Abs", new Regex(@"\|((\d+(\.\d+)?)|\||(\+|-|\*|\/|\^)(?!\+|\*|\/|\^|\!)|(|\(|\)|\!))*\|"));
            dict.Add("Arithmetics", new Regex(@"(^-)?\d+(\.\d+)?(\+|-)\d+(\.\d+)?"));
            dict.Add("Brackets", new Regex(@"\(-?\d+(\.\d+)?(((\+|-|\*|\:)\d+(\.\d+)?)+)\)"));
            dict.Add("Factorial", new Regex(@"\d+(\.\d+)?\!"));
            dict.Add("Geometrics", new Regex(@"(\(-\d+(\.\d+)?\)|(^-)?\d+(\.\d+)?)(\*|\/)(\(-\d+(\.\d+)?\)|\d+(\.\d+)?)"));
            dict.Add("GeoOperators", new Regex(@"(\*|\/)"));
            dict.Add("MinusInBrackets", new Regex(@"^\(-\d+(\.\d+)?\)"));
            dict.Add("Negatives", new Regex(@"(\+|-)\(-?\d+(\.\d+)?\)"));
            dict.Add("Numbers", new Regex(@"^-?\d+(\.\d+)?$"));
            dict.Add("NumbersInAbs", new Regex(@"\|\d+(\.\d+)?\|"));
            dict.Add("NumbersInBetween", new Regex(@"(^-)?\d+(\.\d+)?"));
            dict.Add("NumbersInBrackets", new Regex(@"\(\d+(\.\d+)?\)"));
            dict.Add("Powers", new Regex(@"((\d+\.)?\d+-?\^\d+(\.\d+)?)"));
            dict.Add("Syntax", new Regex(@"^((\d+(\.\d+)?)|\||(\+|-|\*|\/|\^)(?!\+|\*|\/|\^|\!)|(|\(|\)|\!))*$"));
            dict.Add("WrongBrackets", new Regex(@"\(\D*\)"));
            dict.Add("WrongAbs", new Regex(@"\|\D*\|"));
            return dict;
        }

        /// <summary>
        /// Calculates a string based math task. Accepts brackets, exponentials and obeys math rules.
        /// </summary>
        /// <param name="task">The task string to be calculated</param>
        /// <returns></returns>
        public static double CalculateString(string task)
        {
            Dictionary<string, Regex> givenRegex = RegexDict();

            // Check if it is just a number and save some steps
            if (givenRegex["Numbers"].IsMatch(task)) return double.Parse(task, CultureInfo.InvariantCulture);

            // Throw a new Argument Exception when there is a wrong syntax
            if (!givenRegex["Syntax"].IsMatch(task)) throw new ArgumentException();

            // Detect empty brackets
            if (givenRegex["WrongBrackets"].IsMatch(task)) return double.NaN;

            // Detect empty abs
            if (givenRegex["WrongAbs"].IsMatch(task)) return double.NaN;

            // Trim the end and beginning
            task = task.Trim();

            // Remove useless brackets
            foreach (Match match in givenRegex["NumbersInBrackets"].Matches(task))
                task = task.Replace(match.Value, match.Value.Substring(1, match.Value.Length - 2));

            // Remove useless abs
            foreach (Match match in givenRegex["NumbersInAbs"].Matches(task))
                task = task.Replace(match.Value, match.Value.Substring(1, match.Value.Length - 2));

            // Remove brackets from negatives at the beginning
            if (givenRegex["MinusInBrackets"].IsMatch(task))
            {
                int sequenceLength = givenRegex["MinusInBrackets"].Match(task).Value.Length;
                task = task.Substring(1, sequenceLength - 2) + task.Substring(sequenceLength);
            }

            // Remove double spaces
            while (task.Contains("  "))
                task = task.Replace("  ", "");

            // Detect unclosed brackets
            if (task.Count(c => c == '(') != task.Count(c => c == ')'))
                return double.NaN;

            // Detect unclosed abs
            if (task.Count(c => c == '|') % 2 != 0)
                return double.NaN;

            // Factorial
            MatchCollection FactorialMatches = givenRegex["Factorial"].Matches(task);
            foreach (Match match in FactorialMatches)
            {
                string factSubTask = match.Value;
                double factResult = double.Parse(factSubTask.Substring(0, factSubTask.Length - 1), CultureInfo.InvariantCulture);
                factResult = Functions.Factorial(factResult);
                task = givenRegex["Factorial"].Replace(task, factResult.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""), 1);
            }

            // Remove useless brackets again...
            foreach (Match match in givenRegex["NumbersInBrackets"].Matches(task))
                task = task.Replace(match.Value, match.Value.Substring(1, match.Value.Length - 2));

            // Power
            while (givenRegex["Powers"].IsMatch(new string(task.Reverse().ToArray())))
            {
                string powSubTask = new string(givenRegex["Powers"].Match(new string(task.Reverse().ToArray())).Value.Reverse().ToArray());
                string powFirstPart = powSubTask.Split('^')[0];
                string powSecondPart = powSubTask.Split('^')[1];
                double powBase = double.Parse(powFirstPart, CultureInfo.InvariantCulture);
                double powExponent = double.Parse(powSecondPart, CultureInfo.InvariantCulture);
                double powResult = System.Math.Pow(powBase, powExponent);
                task = new string(givenRegex["Powers"].Replace(new string(task.Reverse().ToArray()), new string(powResult.ToString("N10", CultureInfo.InvariantCulture).Replace(",", "").Reverse().ToArray()), 1).Reverse().ToArray());
            }

            // Abs
            while (givenRegex["Abs"].IsMatch(task))
            {
                string match = givenRegex["Abs"].Match(task).Value;
                if (match != "")
                {
                    double bracketResult = System.Math.Abs(CalculateString(match.Substring(1, match.Length - 2)));
                    task = task.Replace(match, bracketResult.ToString("N10", CultureInfo.InvariantCulture));
                }
            }

            // Brackets
            while (givenRegex["Brackets"].IsMatch(task) || givenRegex["Negatives"].IsMatch(task))
            {
                string match = givenRegex["Negatives"].Match(task).Value;
                if (match != "")
                {
                    if ((match.StartsWith("+") || match.StartsWith("-")) && match.Substring(2, 1) == "-")
                        task = givenRegex["Negatives"].Replace(task, match.StartsWith("+") ? "-" + match.Substring(3, match.Length - 4) : "+" + match.Substring(3, match.Length - 4));
                    else
                        task = givenRegex["Negatives"].Replace(task, match.Substring(0, 1) + match.Substring(2, match.Length - 3));
                }

                match = givenRegex["Brackets"].Match(task).Value;
                if (match != "")
                {
                    double bracketResult = CalculateString(match.Substring(1, match.Length - 2));
                    task = task.Replace(match, bracketResult < 0 ? "(" + bracketResult.ToString("N10", CultureInfo.InvariantCulture) + ")" : bracketResult.ToString("N10", CultureInfo.InvariantCulture));
                }
            }

            // Geometrics
            while (givenRegex["Geometrics"].IsMatch(task))
            {
                string geoSubTask = givenRegex["Geometrics"].Match(task).Value;
                string[] geoParts = givenRegex["GeoOperators"].Split(geoSubTask);
                double geoFirstPart = double.Parse(geoParts[0], CultureInfo.InvariantCulture);
                double geoSecondPart = geoParts[2].StartsWith("(") ? double.Parse(geoParts[2].Substring(1, geoParts[2].Length - 2), CultureInfo.InvariantCulture) : double.Parse(geoParts[2], CultureInfo.InvariantCulture);
                if (geoSecondPart == 0) return double.NaN;
                double geoResult = geoParts[1] == "*" ? geoFirstPart * geoSecondPart : geoFirstPart / geoSecondPart;
                task = givenRegex["Geometrics"].Replace(task, geoResult.ToString("N10", CultureInfo.InvariantCulture), 1);
            }

            // Arithmetics
            while (givenRegex["Arithmetics"].IsMatch(task))
            {
                string aritSubTask = givenRegex["Arithmetics"].Match(task).Value;
                MatchCollection aritParts = givenRegex["NumbersInBetween"].Matches(aritSubTask);
                task = givenRegex["Arithmetics"].Replace(task, aritSubTask.Substring(aritParts[0].Value.Length, 1) == "+" ? (double.Parse(aritParts[0].Value, CultureInfo.InvariantCulture) + double.Parse(aritParts[1].Value, CultureInfo.InvariantCulture)).ToString("N10", CultureInfo.InvariantCulture) : (double.Parse(aritParts[0].Value, CultureInfo.InvariantCulture) - double.Parse(aritParts[1].Value, CultureInfo.InvariantCulture)).ToString("N10", CultureInfo.InvariantCulture), 1);
            }

            if (task.StartsWith("+")) task = task.Substring(1);
            return givenRegex["Numbers"].IsMatch(task.Replace(",", "")) ? double.Parse(task, CultureInfo.InvariantCulture) : double.NaN;
        }

        /// <summary>
        /// Calculates a string based math task. Accepts brackets, exponentials and obeys math rules.
        /// </summary>
        /// <param name="task">The task string to be calculated</param>
        /// <returns></returns>
        public static double CalculateString2(string task)
        {
            if (!new Regex(@"^(\d+(\.\d+)?|\+|\-|\*|\/|\^|\(|\)|\!)*$").IsMatch(task) && !new Regex(@"^\-?\d+(\.\d+)?$").IsMatch(task))
                throw new ArgumentException();

            task = task.Trim();
            while (task.Contains("  "))
                task = task.Replace("  ", "");

            bool unclosedBrackets = task.Count(c => c == '(') != task.Count(c => c == ')');
            bool onlyValidCharacters = new Regex(@"^(\d+(\.\d+)?|\+|\-|\*|\/|\^|\(|\)|\!)*$").IsMatch(task);
            bool wrongFormat = new Regex(@"((\+|\-|\*|\/|\(|^)(!|\^|\)|$)|(\^|\/|\()($|!|\+|\*|\/|\))|(\/|\*)(\/|\*)|\d\(|\)\d|\($)").IsMatch(task);
            bool rightSyntax = onlyValidCharacters && !wrongFormat && !unclosedBrackets;
            if (rightSyntax)
            {
                // Factorial
                foreach (Match match in new Regex(@"(\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)!").Matches(task))
                {
                    string subTask = match.Value.Substring(0, match.Value.Length - 1);
                    if (subTask.StartsWith("("))
                        subTask.Substring(1);
                    if (subTask.StartsWith("-"))
                        task = "0";
                    else
                        task = task.Replace(match.Value, Functions.Factorial(double.Parse(subTask, CultureInfo.InvariantCulture)).ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
                }

                // Powers
                foreach (Match match in new Regex(@"(\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)\^(\(\-\d+(\.\d+)?\)|\-?\d+(\.\d+)?)").Matches(task))
                {
                    string[] splittedTask = match.Value.Split('^');
                    double firstNumber = splittedTask[0].StartsWith("(") && splittedTask[0].EndsWith(")") ? double.Parse(splittedTask[0].Substring(1, splittedTask[0].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    double secondNumber = splittedTask[1].StartsWith("(") && splittedTask[1].EndsWith(")") ? double.Parse(splittedTask[1].Substring(1, splittedTask[1].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[1], CultureInfo.InvariantCulture);
                    double result = System.Math.Pow(firstNumber, secondNumber);
                    if ((firstNumber < 0 && secondNumber < 0) || (firstNumber > 0 && secondNumber < 0 && secondNumber % 2 != 0))
                        result = result * -1;

                    task = task.Replace(match.Value, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
                }

                // Brackets
                while (task.Contains('('))
                {
                    string subtask = new Regex(@"\((\d|\.|\+|\-|\*|\/)*\)").Match(task).Value;
                    task = task.Replace(subtask, CalculateString2(subtask.Substring(1, subtask.Length - 2)).ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
                }

                // Multiply / Divide
                while (task.Contains('*') || task.Contains('/'))
                {
                    string subtask = new Regex(@"((\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)(\*|\/)(\(\-\d+(\.\d+)?\)|\-?\d+(\.\d+)?)){1}").Match(task).Value;
                    char op = subtask.Contains("*") ? '*' : '/';
                    string[] splittedTask = subtask.Split(op);
                    double firstNumber = splittedTask[0].StartsWith("(") && splittedTask[0].EndsWith(")") ? double.Parse(splittedTask[0].Substring(1, splittedTask[0].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    double secondNumber = splittedTask[1].StartsWith("(") && splittedTask[1].EndsWith(")") ? double.Parse(splittedTask[1].Substring(1, splittedTask[1].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[1], CultureInfo.InvariantCulture);
                    double result = op == '*' ? firstNumber * secondNumber : firstNumber / secondNumber;
                    //task = task.Replace(subtask, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
                    char[] subtask2Chars = subtask.ToCharArray();
                    string newPattern = "";
                    foreach (char c in subtask2Chars)
                    {
                        if (new Regex(@"\d").IsMatch(c.ToString()))
                            newPattern = newPattern + c;
                        else
                            newPattern = newPattern + "\\" + c;
                    }
                    task = new Regex(newPattern).Replace(task, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""), 1);
                }

                // Summation / Substraction
                while ((task.Contains('+') || task.Contains('-')) && !(new Regex(@"^\-\d+(\.\d+)?$").IsMatch(task)))
                {
                    string subtask = new Regex(@"((\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)(\+|\-)(\(\-\d+(\.\d+)?\)|\-?\d+(\.\d+)?)){1}").Match(task).Value;
                    char op = subtask.Contains("+") ? '+' : '-';
                    string[] splittedTask = subtask.Split(op);
                    double firstNumber = splittedTask[0].StartsWith("(") && splittedTask[0].EndsWith(")") ? double.Parse(splittedTask[0].Substring(1, splittedTask[0].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    double secondNumber = splittedTask[1].StartsWith("(") && splittedTask[1].EndsWith(")") ? double.Parse(splittedTask[1].Substring(1, splittedTask[1].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[1], CultureInfo.InvariantCulture);
                    double result = op == '+' ? firstNumber + secondNumber : firstNumber - secondNumber;
                    //task = task.Replace(subtask, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
                    char[] subtask2Chars = subtask.ToCharArray();
                    string newPattern = "";
                    foreach (char c in subtask2Chars)
                    {
                        if (new Regex(@"\d").IsMatch(c.ToString()))
                            newPattern = newPattern + c;
                        else
                            newPattern = newPattern + "\\" + c;
                    }
                    task = new Regex(newPattern).Replace(task, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""), 1);
                }


                if (new Regex(@"^\-?\d+(\.\d+)?$").IsMatch(task))
                    return double.Parse(task, CultureInfo.InvariantCulture);
                else
                    return double.NaN;
            }
            else
                return double.NaN;
        }
    }
}
