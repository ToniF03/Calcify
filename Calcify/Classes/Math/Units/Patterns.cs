namespace Calcify.Math.Units
{
    /// <summary>
    /// Provides regular expression patterns for matching common measurement units such as mass, temperature, data size,
    /// time, length, angle, and frequency.
    /// </summary>
    /// <remarks>These patterns can be used to identify and extract unit names and abbreviations from text.
    /// Each pattern is designed to match a variety of formats and synonyms for the respective unit type. The patterns
    /// are intended for use in parsing or validating user input, data extraction, or similar scenarios where
    /// recognition of measurement units is required.</remarks>
    public static class Patterns
    {
        public static readonly string MassPattern = @"(\b((?i)(ton(s)?|kilogram|gram|milligram|microgram|long ton|short ton|stone(s)?|pound(s)?|ounce)(?-i)|(t|kg|g|mg|µg|μg|lt|tn|st|lb(s)?))\b|oz\.?)";
        public static readonly string TemperaturePattern = @"(\bK\b|°\b(?i)(C|F|Ra|Re|R)(?-i)\b)";
        public static readonly string DataSizePattern = @"\b((b|(K|M|G|T|P|E)?B)|(?i)(bit|(kilo|mega|giga|tera|peta|exa)?byte)(?-i))\b";
        public static readonly string TimePattern = @"(\b(c|yr|yrs|mth|wk|d|h|min|s|ms|μs|µs|ns)\b|\b(?i)(centur(y|ies)|decade(s)?|year(s)?|month(s)?|week(s)?|day(s)?|hour(s)?|minute(s)?|sec|(milli|micro|nano)?second(s)?)(?-i)\b)";
        public static readonly string LengthPattern = @"(\b(nm|mm|cm|dm|km|dam|hm|mi|m|yd|ft|in)\b|\b(?i)(nanometer|millimeter|centimeter|decimeter|kilometer|decameter|hectometer|meter|mile(s)?|yard|foot|feet|inch)(?-i)\b)";
        public static readonly string AnglePattern = @"(°|( |\b)(?i)(gon|grad|deg|mil|rad|arcmin|arcsec|gradian|degree|milliradian|radian|angular minute(s)?|angular second(s)?)(?-i)\b)";
        public static readonly string FrequencyPattern = @"((k|M|G)?Hz|(?i)((kilo|mega|giga)?hertz)(?-i))";
        public static readonly string allUnitPatterns = MassPattern + "|" + TemperaturePattern + "|" + DataSizePattern + "|" + TimePattern + "|" + LengthPattern + "|" + AnglePattern + "|" + FrequencyPattern;
    }
}