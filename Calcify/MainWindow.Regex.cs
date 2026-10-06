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
        readonly string ConstantsPattern = @"(π|\b(p(h)?i|e)\b)";
        readonly Regex prevRegex = new Regex(@"\b(previous|prev|answer|ans)\b");
        readonly Regex oneVariableFunctionRegex = new Regex(@"\b(?<func>(sqrt|sign|abs|floor|ceil|cbrt|fact))\((?<variable1>(-)?\d+(\.\d+)?)\)(( )?|$)");
        readonly Regex dateTimeKeyWordsRegex = new Regex(@"\b(?i)(((now|time)(\.(hour|minute|second))?)|(yesterday|date|today|tomorrow|tmrw)(\.(day|month|year|weekday|dayofyear|weekofyear))?)(?-i)\b");
        readonly Regex PermutationRegex = new Regex(@"(?<n>\d+)C(?<r>\d+)");
        readonly Regex calculatorRegex = new Regex(@"^((\d+(\.\d+)?)|\||(\+|\-|\*|\/|\^)(?!\+|\*|\/|\^|\!)|(|\(|\)|\!))*$");
        readonly Regex directRegex;
        readonly Regex constantsRegex;
        readonly Regex sumAvgRegex;
        readonly Regex inlineCalculationRegex = new Regex(@"(?<=\{)(?<subtask>[^{}]*)(?=\})", RegexOptions.RightToLeft);
        public Regex currencyRegex;
        readonly Regex allUnitRegex;
    }
}
