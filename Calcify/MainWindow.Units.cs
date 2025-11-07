using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Calcify
{
    public partial class MainWindow
    {
        /// <summary>
        /// Evaluate simple arithmetic expressions made of values with compatible units.
        /// Supports addition and subtraction of the same dimension (currency, length, mass, time, data size,
        /// frequency, angle and temperature). The result is expressed in the unit of the first term.
        /// Example: "3 km + 200 m" -> "3.2 km"
        /// </summary>
        private string UnitArithmeticCalculation(string input)
        {
            // Combined unit pattern: check the main categories used throughout the app
            string unitsAll = "(" + CurrencyPattern + "|" + DataSizePattern + "|" + LengthPattern + "|" + MassPattern + "|" + TemperaturePattern + "|" + TimePattern + "|" + FrequencyPattern + "|" + AnglePattern + ")";
            // Match sequences like: <number> <unit> ( (+|-) <number> <unit> )+
            string seqPattern = "(?<expr>(?<first>-?\\d+(\\.\\d+)?)\\s+(?<unit>" + unitsAll + ")(\\s*(?<op>[+\\-])\\s*(?<num>-?\\d+(\\.\\d+)?)\\s*(?<u>" + unitsAll + "))+)";
            Regex seqRegex = new Regex(seqPattern, RegexOptions.IgnoreCase);

            while (seqRegex.IsMatch(input))
            {
                Match m = seqRegex.Match(input);
                string expr = m.Groups["expr"].Value;

                // Collect all terms with their signs
                var termPattern = "(?<sign>^|[+\\-])?\\s*(?<value>-?\\d+(\\.\\d+)?)\\s*(?<unit>" + unitsAll + ")";
                var termRegex = new Regex(termPattern, RegexOptions.IgnoreCase);
                var termMatches = termRegex.Matches(expr);
                if (termMatches.Count < 2)
                {
                    // nothing to do
                    input = input.Replace(expr, expr);
                    break;
                }

                // Determine category from first term
                string firstUnitRaw = termMatches[0].Groups["unit"].Value;
                string firstUnitKey = firstUnitRaw;
                double sum = 0;
                bool valid = true;

                // Figure out which converter/dictionary to use
                Func<double, string, string, double> convertFunc = null;
                Func<string, string> normalizeUnit = null;
                string displayUnit = firstUnitRaw;

                // Helper to map unit token to canonical keys used in dicts
                string uLower(string s) => s.ToLower();

                // Choose category
                if (new Regex("^" + CurrencyPattern + "$", RegexOptions.IgnoreCase).IsMatch(firstUnitRaw))
                {
                    // Currency: convert other currencies to firstUnitKey (uppercase codes)
                    firstUnitKey = firstUnitRaw.ToUpper();
                    normalizeUnit = (s) => s.ToUpper();
                    convertFunc = (val, src, tgt) =>
                    {
                        string srcU = src.ToUpper();
                        string tgtU = tgt.ToUpper();
                        if (srcU == tgtU) return val;
                        if (tgtU == "EUR")
                            return System.Math.Round(val / currencyDict[srcU], 2);
                        if (srcU == "EUR")
                            return System.Math.Round(val * currencyDict[tgtU], 2);
                        return System.Math.Round(val / currencyDict[srcU] * currencyDict[tgtU], 2);
                    };
                }
                else if (dataSizeRegex.IsMatch("1 " + firstUnitRaw))
                {
                    normalizeUnit = (s) => (s == "b" || s == "B") ? s : s.ToLower();
                    convertFunc = (val, src, tgt) =>
                    {
                        var srcUnit = dataSizeDict[src.ToLower()];
                        var tgtUnit = dataSizeDict[tgt.ToLower()];
                        if (srcUnit == tgtUnit) return val;
                        return Converter.DataSizeConverter(val, srcUnit, tgtUnit);
                    };
                }
                else if (lengthRegex.IsMatch("1 " + firstUnitRaw) || lengthDict.ContainsKey(uLower(firstUnitRaw)))
                {
                    normalizeUnit = (s) => s.ToLower();
                    convertFunc = (val, src, tgt) =>
                    {
                        var srcUnit = lengthDict[src.ToLower()];
                        var tgtUnit = lengthDict[tgt.ToLower()];
                        if (srcUnit == tgtUnit) return val;
                        return Converter.LengthConverter(val, srcUnit, tgtUnit);
                    };
                }
                else if (massRegex.IsMatch("1 " + firstUnitRaw) || massDict.ContainsKey(uLower(firstUnitRaw)))
                {
                    normalizeUnit = (s) => s.ToLower();
                    convertFunc = (val, src, tgt) =>
                    {
                        var srcUnit = massDict[src.ToLower()];
                        var tgtUnit = massDict[tgt.ToLower()];
                        if (srcUnit == tgtUnit) return val;
                        return Converter.MassConverter(val, srcUnit, tgtUnit);
                    };
                }
                else if (temperatureRegex.IsMatch("1 " + firstUnitRaw) || temperatureDict.ContainsKey(firstUnitRaw))
                {
                    normalizeUnit = (s) => s; // keep exact tokens like °C
                    convertFunc = (val, src, tgt) =>
                    {
                        var srcUnit = temperatureDict[src];
                        var tgtUnit = temperatureDict[tgt];
                        if (srcUnit == tgtUnit) return val;
                        return Converter.TemperatureConverter(val, srcUnit, tgtUnit);
                    };
                }
                else if (timeCalculationRegex.IsMatch("1 " + firstUnitRaw) || timeDict.ContainsKey(uLower(firstUnitRaw)))
                {
                    normalizeUnit = (s) => s.ToLower();
                    convertFunc = (val, src, tgt) =>
                    {
                        var srcUnit = timeDict[src.ToLower()];
                        var tgtUnit = timeDict[tgt.ToLower()];
                        if (srcUnit == tgtUnit) return val;
                        return Converter.TimeConverter(val, srcUnit, tgtUnit);
                    };
                }
                else if (frequencyRegex.IsMatch("1 " + firstUnitRaw) || frequencyDict.ContainsKey(uLower(firstUnitRaw)))
                {
                    normalizeUnit = (s) => s.ToLower();
                    convertFunc = (val, src, tgt) =>
                    {
                        var srcUnit = frequencyDict[src.ToLower()];
                        var tgtUnit = frequencyDict[tgt.ToLower()];
                        if (srcUnit == tgtUnit) return val;
                        return Converter.FrequencyConverter(val, srcUnit, tgtUnit);
                    };
                }
                else if (angleRegex.IsMatch("1 " + firstUnitRaw) || angleDict.ContainsKey(uLower(firstUnitRaw)))
                {
                    normalizeUnit = (s) => s.ToLower();
                    convertFunc = (val, src, tgt) =>
                    {
                        var srcUnit = angleDict[src.ToLower()];
                        var tgtUnit = angleDict[tgt.ToLower()];
                        if (srcUnit == tgtUnit) return val;
                        return Converter.AngleConverter(val, srcUnit, tgtUnit);
                    };
                }

                if (convertFunc == null)
                    valid = false;

                if (!valid)
                {
                    // can't evaluate this expression, leave it unchanged
                    input = input.Replace(expr, expr);
                    break;
                }

                // Sum terms: convert each term to the unit of the first term
                string targetUnitToken = termMatches[0].Groups["unit"].Value;
                for (int i = 0; i < termMatches.Count; i++)
                {
                    var t = termMatches[i];
                    string signGroup = t.Groups["sign"].Value;
                    double val = double.Parse(t.Groups["value"].Value, CultureInfo.InvariantCulture);
                    string unitToken = t.Groups["unit"].Value;
                    double valInTarget = val;
                    try
                    {
                        valInTarget = convertFunc(val, unitToken, targetUnitToken);
                    }
                    catch
                    {
                        valid = false;
                        break;
                    }
                    // Determine sign: first match may not have explicit +; if signGroup contains '-' then negative
                    bool negative = signGroup != "" && signGroup.Trim() == "-";
                    // For initial match, signGroup may be empty; treat as positive
                    if (i == 0 && signGroup.Trim() == "-") negative = true;

                    sum += negative ? -valInTarget : valInTarget;
                }

                if (!valid)
                {
                    input = input.Replace(expr, expr);
                    break;
                }

                // Format result and append the original unit (use presentation ext dictionaries where available)
                string resultString = ToNumberString(System.Math.Round(sum, Properties.Settings.Default.Digits)) + " " + targetUnitToken;
                // replace expression in input
                input = input.Replace(expr, resultString);
            }

            return input;
        }

        /// <summary>
        /// Detect and compute simple geometric calculations embedded in input text.
        /// Supported operations: area, perimeter (or circumference), volume for common shapes:
        /// circle, square, rectangle, triangle, sphere, cylinder.
        /// Recognizes inputs like:
        ///   "area circle 5 m" (radius=5 m)
        ///   "circumference circle 5" or "perimeter circle 5"
        ///   "area square 4 cm"
        ///   "area rectangle 3x4 m" or "area rectangle 3 x 4 m"
        ///   "area triangle 3x4 m" (base x height)
        ///   "volume sphere 2 m"
        ///   "volume cylinder 2x5 m" (radius x height)
        /// If a unit is provided, area results append unit^2 and volume unit^3.
        /// </summary>
        private string GeometricCalculation(string input)
        {
            // small helper to format value
            string fmt(double v) => ToNumberString(Math.Round(v, Properties.Settings.Default.Digits));

            // accept optional unit token (letters, %, ° and common symbols) or the app's known units
            string unitToken = "(?<unit>[a-zA-Z%°‰\\u00B0\\u00B2\\u00B3]+)?";

            // circle area / circumference
            var circleArea = new Regex("(?i)\\b(area|surface)\\s+(?:of\\s+)?circle\\s+(?<r>-?\\d+(?:\\.\\d+)?)(?:\\s*" + unitToken + ")?\\b");
            var circlePerim = new Regex("(?i)\\b(perimeter|circumference)\\s+(?:of\\s+)?circle\\s+(?<r>-?\\d+(?:\\.\\d+)?)(?:\\s*" + unitToken + ")?\\b");

            // square area / perimeter
            var square = new Regex("(?i)\\b(area|perimeter)\\s+square\\s+(?<a>-?\\d+(?:\\.\\d+)?)(?:\\s*" + unitToken + ")?\\b");

            // rectangle area / perimeter: w x h
            var rectangle = new Regex("(?i)\\b(area|perimeter)\\s+rectangle\\s+(?<w>-?\\d+(?:\\.\\d+)?)\\s*[x×*\\s]\\s*(?<h>-?\\d+(?:\\.\\d+)?)(?:\\s*" + unitToken + ")?\\b");

            // triangle area: base x height
            var triangle = new Regex("(?i)\\barea\\s+triangle\\s+(?<b>-?\\d+(?:\\.\\d+)?)\\s*[x×*\\s]\\s*(?<h>-?\\d+(?:\\.\\d+)?)(?:\\s*" + unitToken + ")?\\b");

            // sphere volume
            var sphere = new Regex("(?i)\\bvolume\\s+sphere\\s+(?<r>-?\\d+(?:\\.\\d+)?)(?:\\s*" + unitToken + ")?\\b");

            // cylinder volume: r x h
            var cylinder = new Regex("(?i)\\bvolume\\s+cylinder\\s+(?<r>-?\\d+(?:\\.\\d+)?)\\s*[x×*\\s]\\s*(?<h>-?\\d+(?:\\.\\d+)?)(?:\\s*" + unitToken + ")?\\b");

            // Try replacements for each pattern
            // Circle area
            input = circleArea.Replace(input, m =>
            {
                double r = double.Parse(m.Groups["r"].Value, CultureInfo.InvariantCulture);
                string u = m.Groups["unit"].Success ? m.Groups["unit"].Value : null;
                double area = Math.PI * r * r;
                if (!string.IsNullOrEmpty(u)) return fmt(area) + " " + u + "^2";
                return fmt(area);
            });

            // Circle perimeter / circumference
            input = circlePerim.Replace(input, m =>
            {
                double r = double.Parse(m.Groups["r"].Value, CultureInfo.InvariantCulture);
                string u = m.Groups["unit"].Success ? m.Groups["unit"].Value : null;
                double per = 2 * Math.PI * r;
                if (!string.IsNullOrEmpty(u)) return fmt(per) + " " + u;
                return fmt(per);
            });

            // Square
            input = square.Replace(input, m =>
            {
                string op = m.Groups[1].Value.ToLower();
                double a = double.Parse(m.Groups["a"].Value, CultureInfo.InvariantCulture);
                string u = m.Groups["unit"].Success ? m.Groups["unit"].Value : null;
                if (op.StartsWith("area"))
                {
                    double area = a * a;
                    if (!string.IsNullOrEmpty(u)) return fmt(area) + " " + u + "^2";
                    return fmt(area);
                }
                else
                {
                    double p = 4 * a;
                    if (!string.IsNullOrEmpty(u)) return fmt(p) + " " + u;
                    return fmt(p);
                }
            });

            // Rectangle
            input = rectangle.Replace(input, m =>
            {
                string op = m.Groups[1].Value.ToLower();
                double w = double.Parse(m.Groups["w"].Value, CultureInfo.InvariantCulture);
                double h = double.Parse(m.Groups["h"].Value, CultureInfo.InvariantCulture);
                string u = m.Groups["unit"].Success ? m.Groups["unit"].Value : null;
                if (op.StartsWith("area"))
                {
                    double area = w * h;
                    if (!string.IsNullOrEmpty(u)) return fmt(area) + " " + u + "^2";
                    return fmt(area);
                }
                else
                {
                    double p = 2 * (w + h);
                    if (!string.IsNullOrEmpty(u)) return fmt(p) + " " + u;
                    return fmt(p);
                }
            });

            // Triangle area (base x height)
            input = triangle.Replace(input, m =>
            {
                double b = double.Parse(m.Groups["b"].Value, CultureInfo.InvariantCulture);
                double h = double.Parse(m.Groups["h"].Value, CultureInfo.InvariantCulture);
                string u = m.Groups["unit"].Success ? m.Groups["unit"].Value : null;
                double area = 0.5 * b * h;
                if (!string.IsNullOrEmpty(u)) return fmt(area) + " " + u + "^2";
                return fmt(area);
            });

            // Sphere volume
            input = sphere.Replace(input, m =>
            {
                double r = double.Parse(m.Groups["r"].Value, CultureInfo.InvariantCulture);
                string u = m.Groups["unit"].Success ? m.Groups["unit"].Value : null;
                double vol = 4.0 / 3.0 * Math.PI * r * r * r;
                if (!string.IsNullOrEmpty(u)) return fmt(vol) + " " + u + "^3";
                return fmt(vol);
            });

            // Cylinder volume (r x h)
            input = cylinder.Replace(input, m =>
            {
                double r = double.Parse(m.Groups["r"].Value, CultureInfo.InvariantCulture);
                double h = double.Parse(m.Groups["h"].Value, CultureInfo.InvariantCulture);
                string u = m.Groups["unit"].Success ? m.Groups["unit"].Value : null;
                double vol = Math.PI * r * r * h;
                if (!string.IsNullOrEmpty(u)) return fmt(vol) + " " + u + "^3";
                return fmt(vol);
            });

            return input;
        }
    }
}
