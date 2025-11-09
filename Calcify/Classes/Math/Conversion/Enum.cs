namespace Calcify.Math.Conversion
{
    /// <summary>
    /// Specifies the units of measurement for angles, such as degrees, radians, or gradians.
    /// </summary>
    /// <remarks>Use this enumeration to indicate the unit in which an angle value is expressed or to convert
    /// between different angle units. The <see cref="AngleUnit.None"/> value represents an unspecified or unknown unit
    /// and should be used when the unit is not applicable or not provided.</remarks>
    public enum AngleUnit
    {
        Gradian,
        Degree,
        Milliradian,
        Radian,
        AngularMinute,
        AngularSecond,
        None
    }
    /// <summary>
    /// Specifies units of digital data size for representing quantities such as bits, bytes, and larger multiples.
    /// </summary>
    /// <remarks>Use this enumeration to indicate the unit of measurement when working with data sizes in
    /// storage, transmission, or processing contexts. The values range from individual bits and bytes to larger units
    /// such as kilobytes, megabytes, gigabytes, terabytes, petabytes, and exabytes. The <see cref="DataSizeUnit.None"/>
    /// value represents an unspecified or unknown unit.</remarks>
    public enum DataSizeUnit
    {
        Bit,
        Byte,
        Kilobyte,
        Megabyte,
        Gigabyte,
        Terabyte,
        Petabyte,
        Exabyte,
        None
    }
    /// <summary>
    /// Specifies units of frequency measurement, such as hertz, kilohertz, megahertz, or gigahertz.
    /// </summary>
    /// <remarks>Use this enumeration to indicate the unit of frequency for values or calculations involving
    /// periodic signals, oscillations, or other frequency-based measurements. The <see cref="FrequencyUnit.None"/>
    /// value represents an unspecified or unknown unit.</remarks>
    public enum FrequencyUnit
    {
        Hertz,
        Kilohertz,
        Megahertz,
        Gigahertz,
        None
    }
    /// <summary>
    /// Specifies the units of length supported by the application.
    /// </summary>
    /// <remarks>This enumeration provides a standardized set of length units for representing and converting
    /// measurements. The values range from nanometers to miles, including both metric and imperial units. The <see
    /// cref="LengthUnit.None"/> value indicates that no unit is specified or applicable.</remarks>
    public enum LengthUnit
    {
        Nanometer,
        Micrometer,
        Millimeter,
        Centimeter,
        Decimeter,
        Meter,
        Kilometer,
        Decameter,
        Hectometer,
        Mile,
        Yard,
        Feet,
        Inch,
        None
    }
    /// <summary>
    /// Specifies units of mass for measurement and conversion operations.
    /// </summary>
    /// <remarks>Use this enumeration to indicate the unit of mass when performing calculations, conversions,
    /// or representing mass values. The <see cref="MassUnit.None"/> value indicates that no specific unit is
    /// assigned.</remarks>
    public enum MassUnit
    {
        Ton,
        Kilogram,
        Gram,
        Milligram,
        Microgram,
        LongTon,
        ShortTon,
        Stone,
        Pounds,
        Ounce,
        None
    }
    /// <summary>
    /// Specifies the supported units for numeral systems, such as binary, octal, hexadecimal, and decimal.
    /// </summary>
    /// <remarks>Use this enumeration to indicate the numeral system context for parsing, formatting, or
    /// displaying numeric values. The <see cref="NumeralSystemUnit.None"/> value represents the absence of a specific
    /// numeral system.</remarks>
    public enum NumeralSystemUnit
    {
        Binary,
        Octal,
        Hexadecimal,
        Decimal,
        None
    }
    /// <summary>
    /// Specifies the supported units of temperature measurement.
    /// </summary>
    /// <remarks>Use this enumeration to indicate the unit when converting, displaying, or interpreting
    /// temperature values. The values correspond to common temperature scales, including Celsius, Fahrenheit, Kelvin,
    /// Rankine, and Réaumur. The <see cref="TemperatureUnit.None"/> value represents an unspecified or unknown
    /// unit.</remarks>
    public enum TemperatureUnit
    {
        Reaumur,
        Rankine,
        Kelvin,
        Celsius,
        Fahrenheit,
        None
    }
    /// <summary>
    /// Specifies units of time for representing durations or intervals.
    /// </summary>
    /// <remarks>Use this enumeration to indicate the granularity of time measurements, such as when
    /// converting between time units or specifying time-based operations. The <see cref="TimeUnit.None"/> value
    /// represents an unspecified or unknown time unit.</remarks>
    public enum TimeUnit
    {
        Century,
        Decade,
        Year,
        Month,
        Week,
        Day,
        Hour,
        Minute,
        Second,
        Millisecond,
        Microsecond,
        Nanosecond,
        None
    }
}