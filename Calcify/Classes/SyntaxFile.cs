using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcify
{
    internal class SyntaxFile
    {
        public enum Theme
        {
            Light, Dark
        }

        private Theme _theme = Theme.Dark;

        string _content = "";
        public string Content
        {
            get { return _content.Substring(0, _content.Length - 1) + "</RuleSet>\n</SyntaxDefinition>"; }
        }

        public SyntaxFile(Theme theme)
        {
            _theme = theme;
            _content = "<SyntaxDefinition xmlns=\"http://icsharpcode.net/sharpdevelop/syntaxdefinition/2008\">\n\t";
            _content += "<Color name=\"Comment\" foreground=\"#9B9B9B\" />\n\t";
            _content += "<RuleSet>\n\t\t";
            _content += "<Span color=\"Comment\" begin=\"#\" />\n\t\t";
            AddComment("Operators");
            _content += "<Rule foreground=\"#9CDCFE\">(\\+|\\-|\\*|\\/|\\||\\^)</Rule>\n\t\t";
            AddComment("Keywords");
            _content += "<Rule foreground=\"#" + (_theme == Theme.Dark ? "569CD6" : "2B91AF") + "\">(\\brand(int)?\\b|\\(|\\)|,|!|\\bround\\b|\\bsqrt\\b|^(oct|dec|hex|bin):|\\b(in(to)?|as|plus|add|minus|of(f)?|remove|prev(ious)?|avg|sum|to)\\b|\\d+C\\d+)</Rule>\n\t\t";
            AddComment("Digits and hex codes");
            _content += "<Rule foreground=\"#" + (_theme == Theme.Dark ? "B5CEA8" : "2B91AF") + "\">(0x[0-9a-fA-F]+|(\\d+(\\.\\d+)?))</Rule>\n\t\t";
        }

        public void AddComment(string Comment)
        {
            _content += "<!-- ";
            _content += Comment;
            _content += "-->\n\t\t";
        }

        public void AddFunction(string Rule)
        {
            _content += "<Rule foreground=\"#" + (_theme == Theme.Dark ? "569CD6" : "0000FF") + "\">";
            _content += Rule;
            _content += "</Rule>\n\t\t";
        }

        public void AddConstants(string Rule)
        {
            _content += "<Rule foreground=\"#" + (_theme == Theme.Dark ? "D69D85" : "A31515") + "\">";
            _content += Rule;
            _content += "</Rule>\n\t\t";
        }

        public void AddUnits(string Rule)
        {
            _content += "<Rule foreground=\"#" + (_theme == Theme.Dark ? "8FD12D" : "A31515") + "\">";
            _content += Rule;
            _content += "</Rule>\n\t\t";
        }
    }
}
