using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calcify
{
    public partial class MainWindow
    {
        readonly string AnglePattern = Math.Units.Patterns.AnglePattern;
        public string CurrencyPattern = @"\b(EUR|AED|AFN|ALL|AMD|ANG|AOA|ARS|AUD|AWG|AZN|BAM|BBD|BDT|BGN|BHD|BIF|BMD|BND|BOB|BRL|BSD|BTC|BTN|BWP|BYN|BYR|BZD|CAD|CDF|CHF|CLF|CLP|CNY|COP|CRC|CUC|CUP|CVE|CZK|DJF|DKK|DOP|DZD|EGP|ERN|ETB|EUR|FJD|FKP|GBP|GEL|GGP|GHS|GIP|GMD|GNF|GTQ|GYD|HKD|HNL|HRK|HTG|HUF|IDR|ILS|IMP|INR|IQD|IRR|ISK|JEP|JMD|JOD|JPY|KES|KGS|KHR|KMF|KPW|KRW|KWD|KYD|KZT|LAK|LBP|LKR|LRD|LSL|LTL|LVL|LYD|MAD|MDL|MGA|MKD|MMK|MNT|MOP|MRO|MUR|MVR|MWK|MXN|MYR|MZN|NAD|NGN|NIO|NOK|NPR|NZD|OMR|PAB|PEN|PGK|PHP|PKR|PLN|PYG|QAR|RON|RSD|RUB|RWF|SAR|SBD|SCR|SDG|SEK|SGD|SHP|SLL|SOS|SRD|STD|SVC|SYP|SZL|THB|TJS|TMT|TND|TOP|TRY|TTD|TWD|TZS|UAH|UGX|USD|UYU|UZS|VEF|VND|VUV|WST|XAF|XAG|XAU|XCD|XDR|XOF|XPF|YER|ZAR|ZMK|ZMW|ZWL)\b";
        readonly string DataSizePattern = Math.Units.Patterns.DataSizePattern;
        readonly string FrequencyPattern = Math.Units.Patterns.FrequencyPattern;
        readonly string LengthPattern = Math.Units.Patterns.LengthPattern;
        readonly string MassPattern = Math.Units.Patterns.MassPattern;
        readonly string TemperaturePattern = Math.Units.Patterns.TemperaturePattern;
        readonly string TimePattern = Math.Units.Patterns.TimePattern;
        readonly string ConstantsPattern = @"(π|\b(p(h)?i|e|tau|c|R|Na|g)\b)";
        readonly Regex prevRegex = new Regex(@"\b" + lastKeywords + "\b");
        readonly Regex oneValueFunctionRegex = new Regex(@"\b(?<func>" + oneValueFunctionKeywords + @")\((?<variable1>(-)?\d+(\.\d+)?)\)(( )?|$)");
        readonly Regex twoValueFunctionRegex = new Regex(@"\b(?<func>" + twoValueFunctionKeywords + @")\((?<variable1>-?\d+(\.\d+)?), ?(?<variable2>-?\d+(\.\d+)?)\)", RegexOptions.RightToLeft);
        readonly Regex threeValueRegex = new Regex(@"\b(?<func>" + threeValueFunctionKeywords + @")\((?<variable1>-?\d+(\.\d+)?), ?(?<variable2>-?\d+(\.\d+)?), ?(?<variable3>-?\d+(\.\d+)?)\)", RegexOptions.RightToLeft);
        readonly Regex multipleValueRegex = new Regex(@"\b(?<func>" + multipleValueFunctionKeywords + @")\((?<variable1>-?\d+(\.\d+)?)(, ?(?<variable>-?\d+(\.\d+)?))+\)", RegexOptions.RightToLeft);
        readonly Regex dateTimeKeyWordsRegex = new Regex(@"\b(?i)(((now|time)(\.(hour|minute|second))?)|(yesterday|date|today|tomorrow|tmrw)(\.(day|month|year|weekday|dayofyear|weekofyear))?)(?-i)\b");
        readonly Regex PermutationRegex = new Regex(@"(?<n>\d+)C(?<r>\d+)");
        readonly Regex middleFunctionRegex = new Regex(@"(?<num1>-?\d+(\.\d+)?)(?<func>(\%))(?<num2>-?\d+(\.\d+)?)");
        readonly Regex calculatorRegex = new Regex(@"^((\d+(\.\d+)?)|\||(\+|\-|\*|\/|\^)(?!\+|\*|\/|\^|\!)|(|\(|\)|\!))*$");
        readonly Regex directRegex;
        readonly Regex constantsRegex;
        readonly Regex sumAvgRegex;
        readonly Regex inlineCalculationRegex = new Regex(@"(?<=\{)(?<subtask>[^{}]*)(?=\})", RegexOptions.RightToLeft);
        public Regex currencyRegex;
        readonly Regex allUnitRegex;

        /// <summary>
        /// Defines a regular expression pattern to match keywords related to "last" or "previous" values, as well as "answer" references, for use in syntax highlighting and parsing.
        /// </summary>
        static readonly string lastKeywords = @"(last|prev(ious)?|ans(wer)?)";
        /// <summary>
        /// Defines a regular expression pattern to match keywords related to conversion operations, such as "in", "into", and "as", for use in syntax highlighting and parsing.
        /// </summary>
        static readonly string convertKeywords = @"(in(to)?|as|to)";
        /// <summary>
        /// Defines a regular expression pattern to match keywords related to mathematical operations, such as "plus", "add", "minus", "of", and "remove", for use in syntax highlighting and parsing.
        /// </summary>
        static readonly string operatorKeywords = "(plus|add|minus|of(f)?|remove)";
        /// <summary>
        /// Defines a regular expression pattern to match keywords related to one-word functions, such as "ans", "last", "avg", and "sum", for use in syntax highlighting and parsing.
        /// </summary>
        static readonly string noValueFunctionKeywords = "(ans(wer)?|last|prev(ious)?|avg|average|sum)";
        /// <summary>
        /// Defines a regular expression pattern to match keywords related to one-value functions, such as "exp", "sqrt", "sign", "abs", "floor", "ceil", "cbrt", "fact", trigonometric functions, "ln", and "trunc", for use in syntax highlighting and parsing.
        /// </summary>
        static readonly string oneValueFunctionKeywords = @"(exp|sqrt|sign|abs|floor|ceil|cbrt|fact|(sin|cos|tan)r|((a)?(sin|cos|tan)(h)?)|ln|trunc)";
        /// <summary>
        /// Defines a regular expression pattern to match keywords related to two-value functions, such as "diff", "rand", "randint", "round", "root", "mod", "log", "pow", "perm", and "comb(a)?", for use in syntax highlighting and parsing.
        /// </summary>
        static readonly string twoValueFunctionKeywords = @"(diff|rand|randint|round|root|mod|log|pow|perm|comb(a)?)";
        /// <summary>
        /// Defines a regular expression pattern to match keywords related to three-value functions, such as "clamp", for use in syntax highlighting and parsing.
        /// </summary>
        static readonly string threeValueFunctionKeywords = @"(clamp)";
        /// <summary>
        /// Defines a regular expression pattern to match keywords related to multiple-value functions, such as "median", "mean", "var", "stdev", "min", "max", "sum", and "avg", for use in syntax highlighting and parsing.
        /// </summary>
        static readonly string multipleValueFunctionKeywords = @"(median|mean|var|stdev|min|max|sum|avg|mode)";
    }
}
