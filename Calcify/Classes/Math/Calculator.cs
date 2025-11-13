using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calcify.Classes.Math
{
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
    }
}
