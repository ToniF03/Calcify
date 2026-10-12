using Calcify.Math.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcify
{
    public partial class MainWindow
    {
        private readonly SyntaxFile lightSyntax = new SyntaxFile(SyntaxFile.Theme.Light);
        private readonly SyntaxFile darkSyntax = new SyntaxFile(SyntaxFile.Theme.Dark);

        /// <summary>
        /// Updates the syntax highlighting rules for various domain-specific patterns, including currency, data size
        /// formats, time keywords, frequency, and other measurement units.
        /// </summary>
        /// <remarks>This method refreshes the highlighting configuration by adding comments, units,
        /// functions, and constants to the underlying syntax engine. It should be called whenever the relevant patterns
        /// or highlighting rules need to be reapplied, such as after changes to pattern definitions or initialization
        /// of the syntax engine.</remarks>
        private void UpdateSyntaxHighlighting()
        {
            // Add support for strings enclosed in double quotes and single quotes
            darkSyntax.AddComment("Strings");
            darkSyntax.AddConstants("\".*\"");
            darkSyntax.AddConstants("\'.*\'");

            // Add syntax highlighting rules for various domain-specific patterns, including currency, data size formats, time keywords, frequency, and other measurement units.
            darkSyntax.AddComment("Currency");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + CurrencyPattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + CurrencyPattern + "\\x20"+ convertKeywords + "\\x20)" + CurrencyPattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20"+ convertKeywords + "\\x20)" + CurrencyPattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + CurrencyPattern + "\\x20)" + convertKeywords + "(?=\\x20" + CurrencyPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + CurrencyPattern + ")");
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + CurrencyPattern + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + CurrencyPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + CurrencyPattern + ")");

            darkSyntax.AddComment("Data Size Formats");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + DataSizePattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + DataSizePattern + "\\x20" + convertKeywords + "\\x20)" + DataSizePattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + DataSizePattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + DataSizePattern + "\\x20)" + convertKeywords + "(?=\\x20" + DataSizePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + DataSizePattern + ")");
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + DataSizePattern + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + DataSizePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + DataSizePattern + ")");

            darkSyntax.AddComment("Frequency");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + FrequencyPattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + FrequencyPattern + "\\x20" + convertKeywords + "\\x20)" + FrequencyPattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + FrequencyPattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + FrequencyPattern + "\\x20)" + convertKeywords + "(?=\\x20" + FrequencyPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + FrequencyPattern + ")");
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + FrequencyPattern + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + FrequencyPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + FrequencyPattern + ")");

            darkSyntax.AddComment("Length");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + LengthPattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + LengthPattern + "\\x20" + convertKeywords + "\\x20)" + LengthPattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + LengthPattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + LengthPattern + "\\x20)" + convertKeywords + "(?=\\x20" + LengthPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + LengthPattern + ")");
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + LengthPattern + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + LengthPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + LengthPattern + ")");

            darkSyntax.AddComment("Mass");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + MassPattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + MassPattern + "\\x20" + convertKeywords + "\\x20)" + MassPattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + MassPattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + MassPattern + "\\x20)" + convertKeywords + "(?=\\x20" + MassPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + MassPattern + ")");
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + MassPattern + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + MassPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + MassPattern + ")");

            darkSyntax.AddComment("Temperature");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + TemperaturePattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + TemperaturePattern + "\\x20" + convertKeywords + "\\x20)" + TemperaturePattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + TemperaturePattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + TemperaturePattern + "\\x20)" + convertKeywords + "(?=\\x20" + TemperaturePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + TemperaturePattern + ")");
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + TemperaturePattern + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + TemperaturePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + TemperaturePattern + ")");

            darkSyntax.AddComment("Angle");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + AnglePattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + AnglePattern + "\\x20" + convertKeywords + "\\x20)" + AnglePattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + AnglePattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + AnglePattern + "\\x20)" + convertKeywords + "(?=\\x20" + AnglePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + AnglePattern + ")");
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + AnglePattern + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + AnglePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + AnglePattern + ")");

            darkSyntax.AddComment("Time");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + TimePattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + TimePattern + "\\x20" + convertKeywords + "\\x20)" + TimePattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + TimePattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + TimePattern + "\\x20)" + convertKeywords + "(?=\\x20" + TimePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + TimePattern + ")");
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + TimePattern + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + TimePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + TimePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + dateFunctionKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + TimePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + timeFunctionKeywords + "\\x20)" + operatorKeywords + "(?=\\x20-?\\d+(\\.\\d+)?\\x20" + TimePattern + ")");

            // Add support for time-related keywords like "yesterday", "today", "tomorrow", and "now"
            darkSyntax.AddComment("Time Keywords");
            darkSyntax.AddFunction(dateFunctionKeywords);
            darkSyntax.AddFunction("\\b(?&lt;=" + dateFunctionKeywords + ")(" + dateFunctionSubKeywords + "|" + timeFunctionSubKeywords + "|\\.format(?=\\(\".*\"\\))|\\.format(?=\\('.*'\\)))");
            darkSyntax.AddFunction(timeFunctionKeywords);
            darkSyntax.AddFunction("\\b(?&lt;=" + timeFunctionKeywords + ")(" + timeFunctionSubKeywords + "|\\.format(?=\\(\".*\"\\))|\\.format(?=\\(\'.*\'\\)))");

            // Add support for constants like "pi", "e", "tau", "c", "R", "Na", and "g"
            darkSyntax.AddComment("Constants");
            darkSyntax.AddConstants(ConstantsPattern);

            // Add support for one-word functions like "ans", "last", "avg", and "sum"
            darkSyntax.AddComment("One Word Functions");
            darkSyntax.AddFunction(noValueFunctionKeywords);

            // Add support for one-value functions like "exp", "sqrt", "sign", "abs", "floor", "ceil", "cbrt", "fact", trigonometric functions, "ln", and "trunc"
            darkSyntax.AddComment("One Value Functions");
            darkSyntax.AddFunction("\\b" + oneValueFunctionKeywords + "(?=\\(-?\\d+(\\.\\d+)?\\))");

            // Add support for two-value functions like "diff", "rand", "randint", "round", "root", "mod", "log", "pow", "perm", and "comb(a)?"
            darkSyntax.AddComment("Two Value Functions");
            darkSyntax.AddFunction("\\b" + twoValueFunctionKeywords + "(?=\\(\\s*-?\\d+(?:\\.\\d+)?\\s*,\\s*-?\\d+(?:\\.\\d+)?\\s*\\))");

            // Add support for three-value functions like "clamp"
            darkSyntax.AddComment("Three Value Functions");
            darkSyntax.AddFunction("\\b" + threeValueFunctionKeywords + "(?=\\(\\s*-?\\d+(?:\\.\\d+)?\\s*,\\s*-?\\d+(?:\\.\\d+)?\\s*,\\s*-?\\d+(?:\\.\\d+)?\\s*\\))");

            // Add support for multiple-value functions like "median", "mean", "var", "stdev", "min", "max", "sum", and "avg"
            darkSyntax.AddComment("Multiple Value Functions");
            darkSyntax.AddFunction("\\b" + multipleValueFunctionKeywords + "(?=\\(\\s*-?\\d+(?:\\.\\d+)?(?:\\s*,\\s*-?\\d+(?:\\.\\d+)?)*\\s*\\))");

            // Add support for permutation operator (C) between two numbers, e.g., 5C3
            darkSyntax.AddComment("Permutation Operator");
            darkSyntax.AddFunction("(?&lt;=\\d)C(?=\\d)");

            // Add support for modulus operator (%) between two numbers, e.g., 10%3
            darkSyntax.AddComment("Modulus Operator");
            darkSyntax.AddFunction("(?&lt;=\\-?\\d+(\\.\\d+)?)%(?=\\-?\\d+(\\.\\d+)?)");

            // Add support for brackets, signs, and operators
            darkSyntax.AddComment("Brackets and signs");
            darkSyntax.AddFunction("\\(|\\{|\\)|\\}|,|!");

            // Add support for operators like +, -, *, /, |, and ^
            darkSyntax.AddComment("Operators");
            darkSyntax.AddOperator("(\\+|\\-|\\*|\\/|\\||\\^)");

            // Add support for numbers, including integers and decimals, with optional commas for thousands separators
            darkSyntax.AddComment("Numbers");
            darkSyntax.AddNumbers("(-?((\\d{1,3},)*\\d{3}|\\d+)(\\.\\d+)?)");
        }

        /// <summary>
        /// Initializes the unit dictionaries and conversion delegates for supported measurement types.
        /// </summary>
        /// <remarks>This method sets up internal mappings between unit types, their string
        /// representations, and conversion functions. It should be called before performing any unit conversions to
        /// ensure all supported units and their aliases are recognized.</remarks>
        private void SetUpDictionaries()
        {
            // Temperatures
            AddUnit(TemperatureUnit.Kelvin, "K", "K");
            AddUnit(TemperatureUnit.Fahrenheit, "°F", "°F");
            AddUnit(TemperatureUnit.Celsius, "°C", "°C");
            AddUnit(TemperatureUnit.Reaumur, "°Re", "°RE");
            AddUnit(TemperatureUnit.Rankine, "°R", "°R", "°RA");

            // Time
            AddUnit(TimeUnit.Century, "century", "c", "century", "centuries");
            AddUnit(TimeUnit.Decade, "decade", "decade", "decades");
            AddUnit(TimeUnit.Year, "year", "year", "years", "yr", "yrs");
            AddUnit(TimeUnit.Month, "month", "month", "months", "mth");
            AddUnit(TimeUnit.Week, "week", "week", "weeks", "wk");
            AddUnit(TimeUnit.Day, "day", "day", "days", "d");
            AddUnit(TimeUnit.Hour, "h", "h", "hour", "hours");
            AddUnit(TimeUnit.Minute, "min", "min", "minute", "minutes");
            AddUnit(TimeUnit.Second, "s", "s", "sec", "second", "seconds");
            AddUnit(TimeUnit.Millisecond, "ms", "ms", "millisecond", "milliseconds");
            AddUnit(TimeUnit.Microsecond, "µs", "µs", "μs", "microsecond", "microseconds");
            AddUnit(TimeUnit.Nanosecond, "ns", "ns", "nanosecond", "nanoseconds");

            // Mass
            AddUnit(MassUnit.Ton, "t", "tons", "ton", "t");
            AddUnit(MassUnit.Kilogram, "kg", "kg", "kilogram", "kilograms");
            AddUnit(MassUnit.Gram, "g", "grams", "gram", "g");
            AddUnit(MassUnit.Milligram, "mg", "milligrams", "milligram", "mg");
            AddUnit(MassUnit.Microgram, "μg", "micrograms", "microgram", "µg", "μg");
            AddUnit(MassUnit.LongTon, "lt", "long tons", "long ton", "lt");
            AddUnit(MassUnit.ShortTon, "tn", "short ton", "short tons", "tn");
            AddUnit(MassUnit.Stone, "st", "st", "stone", "stones");
            AddUnit(MassUnit.Pounds, "lb", "pounds", "pound", "lbs", "lb");
            AddUnit(MassUnit.Ounce, "oz.", "oz", "oz.", "ounce", "ounces");

            // Length
            AddUnit(LengthUnit.Nanometer, "nm", "nanometer", "nm");
            AddUnit(LengthUnit.Micrometer, "μm", "micrometer", "μm", "µm");
            AddUnit(LengthUnit.Millimeter, "mm", "millimeter", "mm");
            AddUnit(LengthUnit.Centimeter, "cm", "centimeter", "cm");
            AddUnit(LengthUnit.Decimeter, "dm", "decimeter", "dm");
            AddUnit(LengthUnit.Meter, "m", "meter", "m");
            AddUnit(LengthUnit.Kilometer, "km", "kilometer", "km");
            AddUnit(LengthUnit.Decameter, "dam", "decameter", "dam");
            AddUnit(LengthUnit.Hectometer, "hm", "hectometer", "hm");
            AddUnit(LengthUnit.Mile, "mi", "mile", "miles", "mi");
            AddUnit(LengthUnit.Yard, "yd", "yard", "yd");
            AddUnit(LengthUnit.Feet, "ft", "foot", "feet", "ft");
            AddUnit(LengthUnit.Inch, "in", "inch", "in");

            // Frequency
            AddUnit(FrequencyUnit.Hertz, "Hz", "hz", "hertz");
            AddUnit(FrequencyUnit.Kilohertz, "kHz", "khz", "kilohertz");
            AddUnit(FrequencyUnit.Megahertz, "MHz", "mhz", "megahertz");
            AddUnit(FrequencyUnit.Gigahertz, "GHz", "ghz", "gigahertz");

            // Data size
            AddUnit(DataSizeUnit.Bit, "b", "b", "bit", "bits");
            AddUnit(DataSizeUnit.Byte, "B", "B", "byte", "bytes");
            AddUnit(DataSizeUnit.Kilobyte, "KB", "kb", "kilobyte", "kilobytes");
            AddUnit(DataSizeUnit.Megabyte, "MB", "mb", "megabyte", "megabytes");
            AddUnit(DataSizeUnit.Gigabyte, "GB", "gb", "gigabyte", "gigabytes");
            AddUnit(DataSizeUnit.Terabyte, "TB", "tb", "terabyte", "terabytes");
            AddUnit(DataSizeUnit.Petabyte, "PB", "pb", "petabyte", "petabytes");
            AddUnit(DataSizeUnit.Exabyte, "EB", "eb", "exabyte", "exabytes");

            // Angle
            AddUnit(AngleUnit.Gradian, "gon", "gradian", "gon", "grad");
            AddUnit(AngleUnit.Degree, "deg", "degree", "deg", "°");
            AddUnit(AngleUnit.Milliradian, "mil", "milliradian", "mil");
            AddUnit(AngleUnit.Radian, "rad", "radian", "rad");
            AddUnit(AngleUnit.AngularMinute, "arcmin", "angular minutes", "angular minute", "arcmin");
            AddUnit(AngleUnit.AngularSecond, "arcsec", "arcsec", "angular second", "angular seconds");

            converterDict = new Dictionary<Type, Func<double, Enum, Enum, double>>
            {
                { typeof(MassUnit), (val, current, target) => Converter.MassConverter(val, (MassUnit)current, (MassUnit)target) },
                { typeof(DataSizeUnit), (val, current, target) => Converter.DataSizeConverter(val, (DataSizeUnit)current, (DataSizeUnit)target) },
                { typeof(FrequencyUnit), (val, current, target) => Converter.FrequencyConverter(val, (FrequencyUnit)current, (FrequencyUnit)target) },
                { typeof(LengthUnit), (val, current, target) => Converter.LengthConverter(val, (LengthUnit)current, (LengthUnit)target) },
                { typeof(AngleUnit), (val, current, target) => Converter.AngleConverter(val, (AngleUnit)current, (AngleUnit)target) },
                { typeof(TimeUnit), (val, current, target) => Converter.TimeConverter(val, (TimeUnit)current, (TimeUnit)target) },
                { typeof(TemperatureUnit), (val, current, target) => Converter.TemperatureConverter(val, (TemperatureUnit)current, (TemperatureUnit)target) }
            };

        }
    }
}
