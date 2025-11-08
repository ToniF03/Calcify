namespace Calcify
{
    /// <summary>
    /// Represents a syntax definition file that generates XML content for syntax highlighting rules, supporting
    /// customizable themes and rule elements.
    /// </summary>
    /// <remarks>Use the SyntaxFile class to construct and manage XML-based syntax definitions for
    /// applications requiring configurable syntax highlighting. The class provides methods to append various rule
    /// elements, comments, and color settings, with appearance determined by the selected theme. The generated content
    /// is suitable for exporting or saving syntax configurations. This type is not thread-safe.</remarks>
    internal class SyntaxFile
    {
        /// <summary>
        /// Specifies the available visual themes for an application interface.
        /// </summary>
        /// <remarks>Use this enumeration to select between predefined appearance modes, such as light or
        /// dark, for user interface elements. The selected theme may affect colors, backgrounds, and overall styling
        /// throughout the application.</remarks>
        public enum Theme
        {
            Light, 
            Dark
        }

        private Theme _theme = Theme.Dark;

        string _content = "";
        /// <summary>
        /// Gets the XML content representing the syntax definition and rule set.
        /// </summary>
        /// <remarks>The returned string includes closing tags for the rule set and syntax definition. The
        /// content is intended for use in scenarios where a complete XML representation of the syntax rules is
        /// required, such as exporting or saving configuration data.</remarks>
        public string Content
        {
            get { return _content.Substring(0, _content.Length - 1) + "</RuleSet>\n</SyntaxDefinition>"; }
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxFile class using the specified theme for syntax highlighting.
        /// </summary>
        /// <remarks>The constructed SyntaxFile instance generates a syntax definition with color settings
        /// based on the provided theme. The theme affects the foreground color of keyword rules in the syntax
        /// definition.</remarks>
        /// <param name="theme">The theme to apply to syntax highlighting elements. Determines the color scheme used in the generated syntax
        /// definition.</param>
        public SyntaxFile(Theme theme)
        {
            _theme = theme;
            _content = "<SyntaxDefinition xmlns=\"http://icsharpcode.net/sharpdevelop/syntaxdefinition/2008\">\n\t";
            _content += "<Color name=\"Comment\" foreground=\"#9B9B9B\" />\n\t";
            _content += "<RuleSet>\n\t\t";
            _content += "<Span color=\"Comment\" begin=\"#\" />\n\t\t";
            AddComment("Keywords");
            _content += "<Rule foreground=\"#" + (_theme == Theme.Dark ? "569CD6" : "2B91AF") + "\">(\\brand(int)?\\b|\\(|\\)|,|!|\\bround\\b|\\bsqrt\\b|\\b(in(to)?|as|plus|add|minus|of(f)?|remove|prev(ious)?|avg|sum|to)\\b|\\d+C\\d+)</Rule>\n\t\t";
        }

        /// <summary>
        /// Appends an XML comment to the content using the specified text.
        /// </summary>
        /// <remarks>The comment is added in XML comment syntax (`<!-- ... -->`) and is followed by a
        /// newline and indentation. This method does not validate the content of the comment; callers should ensure
        /// that the text does not contain characters that would invalidate the XML structure.</remarks>
        /// <param name="Comment">The text to include within the XML comment. Cannot be null.</param>
        public void AddComment(string Comment)
        {
            _content += $"<!--{Comment}-->\n\t\t";
        }

        /// <summary>
        /// Adds a custom color rule to the content, associating the specified rule text with the given foreground
        /// color.
        /// </summary>
        /// <param name="Rule">The rule text to be displayed with the specified color. Cannot be null.</param>
        /// <param name="color">The hexadecimal color code (without the leading '#') to use as the foreground color for the rule. Must be a
        /// valid 6-digit or 8-digit hexadecimal string.</param>
        public void AddCustomColor(string Rule, string color)
        {
            _content += $"<Rule foreground=\"#{color}\">{Rule}</Rule>\n\t\t";
        }

        /// <summary>
        /// Adds a rule operator to the internal content, formatting it as an XML element with a specified foreground
        /// color.
        /// </summary>
        /// <remarks>The rule is wrapped in a <Rule> element with a foreground color attribute. This
        /// method appends the formatted rule to the internal content; it does not validate or escape the
        /// input.</remarks>
        /// <param name="Rule">The rule operator to be added. This value is inserted as the content of the XML element and should not be
        /// null.</param>
        public void AddOperator(string Rule)
        {
            _content += $"<Rule foreground=\"#9CDCFE\">{Rule}</Rule>\n\t\t";
        }

        /// <summary>
        /// Appends a formatted rule element to the internal content, using the specified rule text.
        /// </summary>
        /// <remarks>The rule is wrapped in a formatted XML element with a foreground color that depends
        /// on the current theme. If <paramref name="Rule"/> is null, a runtime exception may occur.</remarks>
        /// <param name="Rule">The rule text to be added. Cannot be null.</param>
        public void AddNumbers(string Rule)
        {
            _content += $"<Rule foreground=\"#" + (_theme == Theme.Dark ? "B5CEA8" : "2B91AF") + "\">{Rule}</Rule>\n\t\t";
        }

        /// <summary>
        /// Adds a rule to the content with syntax highlighting based on the current theme.
        /// </summary>
        /// <remarks>The rule is wrapped in a markup element with a foreground color that reflects the
        /// current theme. This method appends the rule to the internal content and does not validate the input
        /// string.</remarks>
        /// <param name="Rule">The rule to be added. This should be a valid string representing the rule to include in the content.</param>
        public void AddFunction(string Rule)
        {
            _content += $"<Rule foreground=\"#" + (_theme == Theme.Dark ? "569CD6" : "0000FF") + "\">{Rule}</Rule>\n\t\t";
        }

        /// <summary>
        /// Appends a formatted rule element to the internal content, applying a foreground color based on the current
        /// theme.
        /// </summary>
        /// <remarks>The foreground color of the rule element is determined by the current theme. If the
        /// theme is dark, a specific color is used; otherwise, a different color is applied. This method does not
        /// validate the rule text and assumes it is properly formatted for inclusion.</remarks>
        /// <param name="Rule">The rule text to be added. This value is inserted as the content of the rule element and should not be null.</param>
        public void AddConstants(string Rule)
        {
            _content += $"<Rule foreground=\"#{(_theme == Theme.Dark ? "D69D85" : "A31515")}\">{Rule}</Rule>\n\t\t";
        }

        /// <summary>
        /// Appends a formatted rule element to the internal content, applying a foreground color based on the current
        /// theme.
        /// </summary>
        /// <remarks>The foreground color of the rule element is determined by the current theme. If
        /// <paramref name="Rule"/> is null, an exception may occur.</remarks>
        /// <param name="Rule">The rule text to be added. Cannot be null.</param>
        public void AddUnits(string Rule)
        {
            _content += $"<Rule foreground=\"#{(_theme == Theme.Dark ? "8FD12D" : "A31515")}\">{Rule}</Rule>\n\t\t";
        }
    }
}
