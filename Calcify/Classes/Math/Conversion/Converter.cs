using System;

namespace Calcify.Math.Conversion
{
    /// <summary>
    /// Provides static methods for converting values between different units of measurement, including angle, data
    /// size, frequency, length, mass, numeral systems, temperature, and time.
    /// </summary>
    /// <remarks>All conversion methods require valid and distinct source and target units. If either unit is
    /// set to None or both units are the same, an exception is thrown. These methods are intended for direct, one-step
    /// conversions and do not perform validation on the input value beyond unit checks. Thread safety is guaranteed as
    /// all methods are static and stateless.</remarks>
    public static class Converter
    {
        /// <summary>
        /// Converts an angle value from one unit of measurement to another.
        /// </summary>
        /// <remarks>Use this method to convert between supported angle units, such as degrees, radians,
        /// gradians, milliradians, angular minutes, and angular seconds. The method does not perform validation on the
        /// value of <paramref name="val"/>; ensure that the input is appropriate for the specified units.</remarks>
        /// <param name="val">The angle value to convert, expressed in the unit specified by <paramref name="currentUnit"/>.</param>
        /// <param name="currentUnit">The unit of measurement of <paramref name="val"/>. Must be a valid <see cref="AngleUnit"/> value other than
        /// <see cref="AngleUnit.None"/>.</param>
        /// <param name="targetUnit">The unit of measurement to convert <paramref name="val"/> to. Must be a valid <see cref="AngleUnit"/> value
        /// other than <see cref="AngleUnit.None"/> and different from <paramref name="currentUnit"/>.</param>
        /// <returns>The converted angle value expressed in the unit specified by <paramref name="targetUnit"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="currentUnit"/> or <paramref name="targetUnit"/> is <see cref="AngleUnit.None"/>,
        /// or if <paramref name="targetUnit"/> is the same as <paramref name="currentUnit"/>.</exception>
        public static double AngleConverter(double val, AngleUnit currentUnit, AngleUnit targetUnit)
        {
            if (currentUnit == AngleUnit.None || targetUnit == AngleUnit.None || targetUnit == currentUnit)
                throw new ArgumentException();
            double result = 0;
            switch (targetUnit)
            {
                case AngleUnit.Gradian:
                    if (currentUnit == AngleUnit.Degree)
                        result = Angle.Degree.ToGradian(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.Milliradian.ToGradian(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.Radian.ToGradian(val);
                    else if (currentUnit == AngleUnit.AngularMinute)
                        result = Angle.AngularMinute.ToGradian(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.AngularSecond.ToGradian(val);
                    break;
                case AngleUnit.Degree:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.Gradian.ToDegree(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.Milliradian.ToDegree(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.Radian.ToDegree(val);
                    else if (currentUnit == AngleUnit.AngularMinute)
                        result = Angle.AngularMinute.ToDegree(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.AngularSecond.ToDegree(val);
                    break;
                case AngleUnit.Milliradian:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.Gradian.ToMilliradian(val);
                    else if (currentUnit == AngleUnit.Degree)
                        result = Angle.Degree.ToMilliradian(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.Radian.ToMilliradian(val);
                    else if (currentUnit == AngleUnit.AngularMinute)
                        result = Angle.AngularMinute.ToMilliradian(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.AngularSecond.ToMilliradian(val);
                    break;
                case AngleUnit.Radian:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.Gradian.ToRadian(val);
                    else if (currentUnit == AngleUnit.Degree)
                        result = Angle.Degree.ToRadian(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.Milliradian.ToRadian(val);
                    else if (currentUnit == AngleUnit.AngularMinute)
                        result = Angle.AngularMinute.ToRadian(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.AngularSecond.ToRadian(val);
                    break;
                case AngleUnit.AngularMinute:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.Gradian.ToAngularMinute(val);
                    else if (currentUnit == AngleUnit.Degree)
                        result = Angle.Degree.ToAngularMinute(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.Milliradian.ToAngularMinute(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.Radian.ToAngularMinute(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.AngularSecond.ToAngularMinute(val);
                    break;
                case AngleUnit.AngularSecond:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.Gradian.ToAngularSecond(val);
                    else if (currentUnit == AngleUnit.Degree)
                        result = Angle.Degree.ToAngularSecond(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.Milliradian.ToAngularSecond(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.Radian.ToAngularSecond(val);
                    else if (currentUnit == AngleUnit.AngularMinute)
                        result = Angle.AngularMinute.ToAngularSecond(val);
                    break;
            }
            return result;
        }
        /// <summary>
        /// Converts a data size value from one unit to another.
        /// </summary>
        /// <remarks>This method supports conversion between common data size units, including bits,
        /// bytes, kilobytes, megabytes, gigabytes, terabytes, petabytes, and exabytes. The conversion is performed
        /// using standard binary unit relationships.</remarks>
        /// <param name="val">The numeric value representing the data size to convert.</param>
        /// <param name="currentUnit">The unit of measurement for the input value. Must be a valid <see cref="DataSizeUnit"/> value other than
        /// <see cref="DataSizeUnit.None"/>.</param>
        /// <param name="targetUnit">The unit of measurement to convert the value to. Must be a valid <see cref="DataSizeUnit"/> value other than
        /// <see cref="DataSizeUnit.None"/> and different from <paramref name="currentUnit"/>.</param>
        /// <returns>A <see cref="double"/> representing the converted data size in the specified target unit.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="currentUnit"/> or <paramref name="targetUnit"/> is <see
        /// cref="DataSizeUnit.None"/>, or if <paramref name="currentUnit"/> and <paramref name="targetUnit"/> are the
        /// same.</exception>
        public static double DataSizeConverter(double val, DataSizeUnit currentUnit, DataSizeUnit targetUnit)
        {
            if (currentUnit == DataSizeUnit.None || targetUnit == DataSizeUnit.None || currentUnit == targetUnit)
                throw new ArgumentException();
            double result = 0;

            if (targetUnit == DataSizeUnit.Bit)
            {
                if (currentUnit == DataSizeUnit.Byte)
                    result = Math.Conversion.DataSize.Byte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToBit(val);
            }
            else if (targetUnit == DataSizeUnit.Byte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToByte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToByte(val);
            }
            else if (targetUnit == DataSizeUnit.Kilobyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToKilobyte(val);
            }
            else if (targetUnit == DataSizeUnit.Megabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToMegabyte(val);
            }
            else if (targetUnit == DataSizeUnit.Gigabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToGigabyte(val);
            }
            else if (targetUnit == DataSizeUnit.Terabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToTerabyte(val);
            }
            else if (targetUnit == DataSizeUnit.Petabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToPetabyte(val);
            }
            else if (targetUnit == DataSizeUnit.Exabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToExabyte(val);
            }
            return result;
        }
        /// <summary>
        /// Converts a frequency value from one unit to another.
        /// </summary>
        /// <param name="val">The frequency value to convert.</param>
        /// <param name="currentUnit">The unit of the input frequency value.</param>
        /// <param name="targetUnit">The unit to which the frequency value will be converted.</param>
        /// <returns>The converted frequency value expressed in the target unit.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="currentUnit"/> or <paramref name="targetUnit"/> is <c>FrequencyUnit.None</c>, or
        /// if <paramref name="currentUnit"/> and <paramref name="targetUnit"/> are the same.</exception>
        public static double FrequencyConverter(double val, FrequencyUnit currentUnit, FrequencyUnit targetUnit)
        {
            double result = 0;
            if (currentUnit == FrequencyUnit.None || targetUnit == FrequencyUnit.None || targetUnit == currentUnit)
                throw new ArgumentException();

            switch (targetUnit)
            {
                case FrequencyUnit.Hertz:
                    if (currentUnit == FrequencyUnit.Kilohertz)
                        result = Frequency.Kilohertz.ToHertz(val);
                    else if (currentUnit == FrequencyUnit.Megahertz)
                        result = Frequency.Megahertz.ToHertz(val);
                    else if (currentUnit == FrequencyUnit.Gigahertz)
                        result = Frequency.Gigahertz.ToHertz(val);
                    break;
                case FrequencyUnit.Kilohertz:
                    if (currentUnit == FrequencyUnit.Hertz)
                        result = Frequency.Hertz.ToKilohertz(val);
                    else if (currentUnit == FrequencyUnit.Megahertz)
                        result = Frequency.Megahertz.ToKilohertz(val);
                    else if (currentUnit == FrequencyUnit.Gigahertz)
                        result = Frequency.Gigahertz.ToKilohertz(val);
                    break;
                case FrequencyUnit.Megahertz:
                    if (currentUnit == FrequencyUnit.Hertz)
                        result = Frequency.Hertz.ToMegahertz(val);
                    else if (currentUnit == FrequencyUnit.Kilohertz)
                        result = Frequency.Kilohertz.ToMegahertz(val);
                    else if (currentUnit == FrequencyUnit.Gigahertz)
                        result = Frequency.Gigahertz.ToMegahertz(val);
                    break;
                case FrequencyUnit.Gigahertz:
                    if (currentUnit == FrequencyUnit.Hertz)
                        result = Frequency.Hertz.ToGigahertz(val);
                    else if (currentUnit == FrequencyUnit.Kilohertz)
                        result = Frequency.Kilohertz.ToGigahertz(val);
                    else if (currentUnit == FrequencyUnit.Megahertz)
                        result = Frequency.Megahertz.ToGigahertz(val);
                    break;
            }
            return result;
        }
        /// <summary>
        /// Converts a length value from one unit of measurement to another.
        /// </summary>
        /// <remarks>Supported units include nanometers, micrometers, millimeters, centimeters,
        /// decimeters, meters, kilometers, decameters, hectometers, miles, yards, feet, and inches. The method does not
        /// perform conversions if the source and target units are the same or if either unit is unspecified.</remarks>
        /// <param name="val">The length value to convert.</param>
        /// <param name="currentUnit">The unit of measurement of the input value. Must be a valid member of <see cref="LengthUnit"/> other than
        /// <see cref="LengthUnit.None"/>.</param>
        /// <param name="targetUnit">The unit of measurement to convert the value to. Must be a valid member of <see cref="LengthUnit"/> other
        /// than <see cref="LengthUnit.None"/> and different from <paramref name="currentUnit"/>.</param>
        /// <returns>A <see cref="double"/> representing the converted length value in the specified target unit.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="currentUnit"/> or <paramref name="targetUnit"/> is <see cref="LengthUnit.None"/>,
        /// or if <paramref name="currentUnit"/> and <paramref name="targetUnit"/> are the same.</exception>
        public static double LengthConverter(double val, LengthUnit currentUnit, LengthUnit targetUnit)
        {
            if (currentUnit == LengthUnit.None || targetUnit == LengthUnit.None || currentUnit == targetUnit)
                throw new ArgumentException();

            double result = 0;

            if (targetUnit == LengthUnit.Nanometer)
            {
                if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToNanometer(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToNanometer(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToNanometer(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToNanometer(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToNanometer(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToNanometer(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToNanometer(val);
            }
            else if (targetUnit == LengthUnit.Micrometer)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToMicrometer(val);
            }
            else if (targetUnit == LengthUnit.Millimeter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToMillimeter(val);
            }
            else if (targetUnit == LengthUnit.Centimeter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToCentimeter(val);
            }
            else if (targetUnit == LengthUnit.Decimeter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToDecimeter(val);
            }
            else if (targetUnit == LengthUnit.Meter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToMeter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToMeter(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToMeter(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToMeter(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToMeter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToMeter(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToMeter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToMeter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToMeter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToMeter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToMeter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToMeter(val);
            }
            else if (targetUnit == LengthUnit.Kilometer)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToKilometer(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToKilometer(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToKilometer(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToKilometer(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToKilometer(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToKilometer(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToKilometer(val);
            }
            else if (targetUnit == LengthUnit.Decameter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToDecameter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToDecameter(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToDecameter(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToDecameter(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToDecameter(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToDecameter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToDecameter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToDecameter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToDecameter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToDecameter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToDecameter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToDecameter(val);
            }
            else if (targetUnit == LengthUnit.Hectometer)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToHectometer(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToHectometer(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToHectometer(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToHectometer(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToHectometer(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToHectometer(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToHectometer(val);
            }
            else if (targetUnit == LengthUnit.Mile)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToMiles(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToMiles(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToMiles(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToMiles(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToMiles(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToMiles(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToMiles(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToMiles(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToMiles(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToMiles(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToMiles(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToMiles(val);
            }
            else if (targetUnit == LengthUnit.Yard)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToYards(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToYards(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToYards(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToYards(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToYards(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToYards(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToYards(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToYards(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToYards(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToYards(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToYards(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToYards(val);
            }
            else if (targetUnit == LengthUnit.Feet)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToFeet(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToFeet(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToFeet(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToFeet(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToFeet(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToFeet(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToFeet(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToFeet(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToFeet(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToFeet(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToFeet(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToFeet(val);
            }
            else if (targetUnit == LengthUnit.Inch)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToInches(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToInches(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToInches(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToInches(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToInches(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToInches(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToInches(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToInches(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToInches(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToInches(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToInches(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToInches(val);
            }

            return result;
        }

        /// <summary>
        /// Converts a mass value from one unit to another.
        /// </summary>
        /// <remarks>Supported mass units include ton, kilogram, gram, milligram, microgram, long ton,
        /// short ton, stone, pounds, and ounce. This method does not perform conversions if the source and target units
        /// are the same or if either unit is unspecified.</remarks>
        /// <param name="val">The mass value to convert.</param>
        /// <param name="currentUnit">The unit of the input mass value. Must be a valid member of <see cref="MassUnit"/> other than <see
        /// cref="MassUnit.None"/>.</param>
        /// <param name="targetUnit">The unit to convert the mass value to. Must be a valid member of <see cref="MassUnit"/> other than <see
        /// cref="MassUnit.None"/> and different from <paramref name="currentUnit"/>.</param>
        /// <returns>The converted mass value expressed in the target unit.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="currentUnit"/> or <paramref name="targetUnit"/> is <see cref="MassUnit.None"/>, or
        /// if <paramref name="currentUnit"/> and <paramref name="targetUnit"/> are the same.</exception>
        public static double MassConverter(double val, MassUnit currentUnit, MassUnit targetUnit)
        {
            if (currentUnit == MassUnit.None || targetUnit == MassUnit.None || currentUnit == targetUnit)
                throw new ArgumentException();

            double result = 0;

            if (currentUnit == MassUnit.Ton)
            {
                if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Tons.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Tons.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Tons.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Tons.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Tons.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Tons.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Tons.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Tons.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Tons.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Kilogram)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Kilograms.ToTons(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Kilograms.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Kilograms.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Kilograms.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Kilograms.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Kilograms.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Kilograms.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Kilograms.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Kilograms.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Gram)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Gram.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Gram.ToKilograms(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Gram.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Gram.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Gram.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Gram.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Gram.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Gram.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Gram.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Milligram)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Milligram.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Milligram.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Milligram.ToGrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Milligram.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Milligram.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Milligram.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Milligram.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Milligram.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Milligram.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Microgram)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Microgram.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Microgram.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Microgram.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Microgram.ToMilligrams(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Microgram.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Microgram.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Microgram.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Microgram.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Microgram.ToOunces(val);
            }
            else if (currentUnit == MassUnit.LongTon)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.LongTon.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.LongTon.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.LongTon.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.LongTon.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.LongTon.ToMicrograms(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.LongTon.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.LongTon.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.LongTon.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.LongTon.ToOunces(val);
            }
            else if (currentUnit == MassUnit.ShortTon)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.ShortTon.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.ShortTon.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.ShortTon.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.ShortTon.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.ShortTon.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.ShortTon.ToLongTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.ShortTon.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.ShortTon.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.ShortTon.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Stone)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Stone.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Stone.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Stone.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Stone.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Stone.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Stone.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Stone.ToShortTons(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Stone.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Stone.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Pounds)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Pound.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Pound.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Pound.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Pound.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Pound.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Pound.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Pound.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Pound.ToStones(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Pound.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Ounce)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Ounce.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Ounce.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Ounce.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Ounce.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Ounce.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Ounce.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Ounce.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Ounce.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Ounce.ToPounds(val);
            }

            return result;
        }

        /// <summary>
        /// Converts a temperature value from one unit to another using the specified source and target temperature
        /// units.
        /// </summary>
        /// <remarks>Supported temperature units include Celsius, Fahrenheit, Kelvin, Rankine, and
        /// Reaumur. This method does not perform conversions if the source and target units are the same, or if either
        /// unit is unspecified.</remarks>
        /// <param name="val">The temperature value to convert.</param>
        /// <param name="currentUnit">The unit of the input temperature value. Must be a valid member of <see cref="TemperatureUnit"/> other than
        /// <see cref="TemperatureUnit.None"/>.</param>
        /// <param name="targetUnit">The unit to which the temperature value will be converted. Must be a valid member of <see
        /// cref="TemperatureUnit"/> other than <see cref="TemperatureUnit.None"/> and different from <paramref
        /// name="currentUnit"/>.</param>
        /// <returns>The converted temperature value expressed in the target unit.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="currentUnit"/> or <paramref name="targetUnit"/> is <see
        /// cref="TemperatureUnit.None"/>, or if <paramref name="targetUnit"/> is the same as <paramref
        /// name="currentUnit"/>.</exception>
        public static double TemperatureConverter(double val, TemperatureUnit currentUnit, TemperatureUnit targetUnit)
        {
            if (currentUnit == TemperatureUnit.None || targetUnit == TemperatureUnit.None || targetUnit == currentUnit)
                throw new ArgumentException();
            double result = 0;
            switch (targetUnit)
            {
                case TemperatureUnit.Celsius:
                    if (currentUnit == TemperatureUnit.Fahrenheit)
                        result = Temperature.Fahrenheit.ToCelsius(val);
                    else if (currentUnit == TemperatureUnit.Reaumur)
                        result = Temperature.Reaumur.ToCelsius(val);
                    else if (currentUnit == TemperatureUnit.Rankine)
                        result = Temperature.Rankine.ToCelsius(val);
                    else if (currentUnit == TemperatureUnit.Kelvin)
                        result = Temperature.Kelvin.ToCelsius(val);
                    break;
                case TemperatureUnit.Fahrenheit:
                    if (currentUnit == TemperatureUnit.Celsius)
                        result = Temperature.Celsius.ToFahrenheit(val);
                    else if (currentUnit == TemperatureUnit.Reaumur)
                        result = Temperature.Reaumur.ToFahrenheit(val);
                    else if (currentUnit == TemperatureUnit.Rankine)
                        result = Temperature.Rankine.ToFahrenheit(val);
                    else if (currentUnit == TemperatureUnit.Kelvin)
                        result = Temperature.Kelvin.ToFahrenheit(val);
                    break;
                case TemperatureUnit.Reaumur:
                    if (currentUnit == TemperatureUnit.Celsius)
                        result = Temperature.Celsius.ToReaumur(val);
                    else if (currentUnit == TemperatureUnit.Fahrenheit)
                        result = Temperature.Fahrenheit.ToReaumur(val);
                    else if (currentUnit == TemperatureUnit.Rankine)
                        result = Temperature.Rankine.ToReaumur(val);
                    else if (currentUnit == TemperatureUnit.Kelvin)
                        result = Temperature.Kelvin.ToReaumur(val);
                    break;
                case TemperatureUnit.Rankine:
                    if (currentUnit == TemperatureUnit.Celsius)
                        result = Temperature.Celsius.ToRankine(val);
                    else if (currentUnit == TemperatureUnit.Fahrenheit)
                        result = Temperature.Fahrenheit.ToRankine(val);
                    else if (currentUnit == TemperatureUnit.Reaumur)
                        result = Temperature.Reaumur.ToRankine(val);
                    else if (currentUnit == TemperatureUnit.Kelvin)
                        result = Temperature.Kelvin.ToRankine(val);
                    break;
                case TemperatureUnit.Kelvin:
                    if (currentUnit == TemperatureUnit.Celsius)
                        result = Temperature.Celsius.ToKelvin(val);
                    else if (currentUnit == TemperatureUnit.Fahrenheit)
                        result = Temperature.Fahrenheit.ToKelvin(val);
                    else if (currentUnit == TemperatureUnit.Reaumur)
                        result = Temperature.Reaumur.ToKelvin(val);
                    else if (currentUnit == TemperatureUnit.Rankine)
                        result = Temperature.Rankine.ToKelvin(val);
                    break;
            }
            return result;
        }
        /// <summary>
        /// Converts a time value from one unit to another.
        /// </summary>
        /// <remarks>This method supports conversion between a wide range of time units, including
        /// centuries, decades, years, months, weeks, days, hours, minutes, seconds, milliseconds, microseconds, and
        /// nanoseconds. The conversion is performed using standard time unit relationships. The result may be subject
        /// to rounding errors for very large or very small values.</remarks>
        /// <param name="val">The numeric value representing the time to convert. Must be expressed in the unit specified by <paramref
        /// name="currentUnit"/>.</param>
        /// <param name="currentUnit">The unit of time for the input value. Cannot be <see cref="TimeUnit.None"/> and must differ from <paramref
        /// name="targetUnit"/>.</param>
        /// <param name="targetUnit">The unit of time to convert the input value to. Cannot be <see cref="TimeUnit.None"/> and must differ from
        /// <paramref name="currentUnit"/>.</param>
        /// <returns>A double representing the converted time value in the specified target unit.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="currentUnit"/> or <paramref name="targetUnit"/> is <see cref="TimeUnit.None"/>, or
        /// if <paramref name="currentUnit"/> and <paramref name="targetUnit"/> are the same.</exception>
        public static double TimeConverter(double val, TimeUnit currentUnit, TimeUnit targetUnit)
        {
            if (currentUnit == TimeUnit.None || targetUnit == TimeUnit.None || targetUnit == currentUnit)
                throw new ArgumentException();
            double result = 0;
            if (currentUnit == TimeUnit.Century)
            {
                if (targetUnit == TimeUnit.Decade)
                {
                    double value = Time.Centuries.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Centuries.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Centuries.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Centuries.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Centuries.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Centuries.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Centuries.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Centuries.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Centuries.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Time.Centuries.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Centuries.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Decade)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Decades.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Decades.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Decades.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Decades.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Decades.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Decades.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Decades.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Decades.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Decades.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Decades.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Decades.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Year)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Years.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Years.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Years.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Years.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Years.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Years.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Years.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Years.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Years.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Years.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Years.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Month)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Months.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Months.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Months.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Months.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Months.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Months.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Months.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Months.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Months.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Months.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Months.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Week)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Weeks.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Weeks.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Weeks.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Weeks.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Weeks.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Weeks.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Weeks.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Weeks.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Weeks.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Weeks.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Weeks.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Day)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Days.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Days.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Days.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Days.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Days.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Days.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Days.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Days.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Days.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Days.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Days.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Hour)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Hours.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Hours.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Hours.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Hours.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Hours.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Hours.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Hours.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Hours.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Hours.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Hours.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Hours.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Minute)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Minutes.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Minutes.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Minutes.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Minutes.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Minutes.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Minutes.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Minutes.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Minutes.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Minutes.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Minutes.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Minutes.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Second)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Seconds.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Seconds.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Seconds.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Seconds.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Seconds.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Seconds.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Seconds.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Seconds.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Seconds.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Seconds.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Seconds.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Millisecond)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Microsecond)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Microseconds.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Microseconds.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Microseconds.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Microseconds.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Microseconds.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Microseconds.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Microseconds.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Microseconds.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Nanosecond)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Microseconds.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Microseconds.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Microseconds.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Microseconds.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Microseconds.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Microseconds.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Microseconds.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Microseconds.ToNanoseconds(val);
                    result = value;
                }
            }
            return result;
        }
    }
}