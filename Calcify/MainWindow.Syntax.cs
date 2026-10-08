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
            // Add syntax highlighting rules for various domain-specific patterns, including currency, data size formats, time keywords, frequency, and other measurement units.
            darkSyntax.AddComment("Currency");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + CurrencyPattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + CurrencyPattern + "\\x20"+ convertKeywords + "\\x20)" + CurrencyPattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20"+ convertKeywords + "\\x20)" + CurrencyPattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + CurrencyPattern + "\\x20)" + convertKeywords + "(?=\\x20" + CurrencyPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + CurrencyPattern + ")");

            darkSyntax.AddComment("Data Size Formats");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + DataSizePattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + DataSizePattern + "\\x20" + convertKeywords + "\\x20)" + DataSizePattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + DataSizePattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + DataSizePattern + "\\x20)" + convertKeywords + "(?=\\x20" + DataSizePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + DataSizePattern + ")");

            darkSyntax.AddComment("Frequency");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + FrequencyPattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + FrequencyPattern + "\\x20" + convertKeywords + "\\x20)" + FrequencyPattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + FrequencyPattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + FrequencyPattern + "\\x20)" + convertKeywords + "(?=\\x20" + FrequencyPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + FrequencyPattern + ")");

            darkSyntax.AddComment("Length");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + LengthPattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + LengthPattern + "\\x20" + convertKeywords + "\\x20)" + LengthPattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + LengthPattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + LengthPattern + "\\x20)" + convertKeywords + "(?=\\x20" + LengthPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + LengthPattern + ")");

            darkSyntax.AddComment("Mass");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + MassPattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + MassPattern + "\\x20" + convertKeywords + "\\x20)" + MassPattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + MassPattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + MassPattern + "\\x20)" + convertKeywords + "(?=\\x20" + MassPattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + MassPattern + ")");

            darkSyntax.AddComment("Temperature");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + TemperaturePattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + TemperaturePattern + "\\x20" + convertKeywords + "\\x20)" + TemperaturePattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + TemperaturePattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + TemperaturePattern + "\\x20)" + convertKeywords + "(?=\\x20" + TemperaturePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + TemperaturePattern + ")");

            darkSyntax.AddComment("Angle");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + AnglePattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + AnglePattern + "\\x20" + convertKeywords + "\\x20)" + AnglePattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + AnglePattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + AnglePattern + "\\x20)" + convertKeywords + "(?=\\x20" + AnglePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + AnglePattern + ")");

            darkSyntax.AddComment("Time");
            darkSyntax.AddUnits("(?&lt;=\\d\\x20)" + TimePattern);
            darkSyntax.AddUnits("(?&lt;=\\d\\x20" + TimePattern + "\\x20" + convertKeywords + "\\x20)" + TimePattern);
            darkSyntax.AddUnits("(?&lt;=" + lastKeywords + "\\x20" + convertKeywords + "\\x20)" + TimePattern);
            darkSyntax.AddFunction("(?&lt;=\\d\\x20" + TimePattern + "\\x20)" + convertKeywords + "(?=\\x20" + TimePattern + ")");
            darkSyntax.AddFunction("(?&lt;=" + lastKeywords + "\\x20)" + convertKeywords + "(?=\\x20" + TimePattern + ")");

            // Add support for time-related keywords like "yesterday", "today", "tomorrow", and "now"
            darkSyntax.AddComment("Time Keywords");
            darkSyntax.AddFunction(@"(((yester|to)?day|tomorrow|tmrw)(\.(day(ofyear)?|week(day|ofyear)?|month|year))?|now(\.(hour|minute|second))?)");

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
    }
}
