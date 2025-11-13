using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calcify.Math.Conversion.Time
{
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
    }
}
