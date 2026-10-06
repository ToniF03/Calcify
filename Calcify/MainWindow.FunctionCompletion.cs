using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Calcify
{
    public partial class MainWindow
    {
        private FunctionCompletionRenderer functionCompletionRenderer;
        private FunctionCompletionData activeFunctionCompletion;
        private int functionCompletionStartOffset;
        private string functionCompletionPrefix = string.Empty;
        private bool functionCompletionDismissed;
        private static readonly string[] dateTimeDateMembers = { "day", "month", "year", "weekday", "dayofyear", "weekofyear" };
        private static readonly string[] dateTimeTimeMembers = { "hour", "minute", "second" };
        private readonly FunctionCompletionData[] functionCompletions =
        {
            new FunctionCompletionData("diff", "diff(min, max)"),
            new FunctionCompletionData("rand", "rand(min, max)"),
            new FunctionCompletionData("randint", "randint(min, max)"),
            new FunctionCompletionData("round", "round(value, digits)"),
            new FunctionCompletionData("sqrt", "sqrt(value)"),
            new FunctionCompletionData("cbrt", "cbrt(value)"),
            new FunctionCompletionData("avg", "avg(x, y, n...)"),
            new FunctionCompletionData("sum", "sum(x, y, n...)"),
            new FunctionCompletionData("today", "today"),
            new FunctionCompletionData("yesterday", "yesterday"),
            new FunctionCompletionData("tomorrow", "tomorrow"),
            new FunctionCompletionData("date", "date"),
            new FunctionCompletionData("now", "now"),
            new FunctionCompletionData("time", "time"),
            new FunctionCompletionData("sign", "sign(value)"),
            new FunctionCompletionData("abs", "abs(value)"),
            new FunctionCompletionData("floor", "floor(value)"),
            new FunctionCompletionData("ceil", "ceil(value)"),
        };

        private void InitializeFunctionCompletion()
        {
            functionCompletionRenderer = new FunctionCompletionRenderer(mainEditor);
            mainEditor.TextArea.TextView.BackgroundRenderers.Add(functionCompletionRenderer);
            mainEditor.TextArea.Caret.PositionChanged += FunctionCompletion_CaretPositionChanged;
            mainEditor.TextArea.TextEntered += MainEditor_TextEntered;
        }

        private bool HandleFunctionCompletionKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape && activeFunctionCompletion != null)
            {
                functionCompletionDismissed = true;
                ClearFunctionCompletion();
                e.Handled = true;
                return true;
            }

            if (e.Key == Key.Back && activeFunctionCompletion != null)
                ClearFunctionCompletion();

            if (e.Key == Key.Tab && Keyboard.Modifiers == ModifierKeys.None && activeFunctionCompletion != null)
            {
                int completionOffset = functionCompletionStartOffset + activeFunctionCompletion.Text.Length;
                mainEditor.Document.Replace(functionCompletionStartOffset, functionCompletionPrefix.Length, activeFunctionCompletion.Text);
                mainEditor.CaretOffset = completionOffset;
                ClearFunctionCompletion();
                e.Handled = true;
                return true;
            }

            return false;
        }

        private void MainEditor_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {
                functionCompletionDismissed = false;
                UpdateDateTimeMemberCompletion();
                return;
            }

            if (e.Text.Length == 0 || !e.Text.All(char.IsLetter))
            {
                functionCompletionDismissed = false;
                ClearFunctionCompletion();
                return;
            }

            if (functionCompletionDismissed)
                return;

            int caretOffset = mainEditor.CaretOffset;
            DocumentLine line = mainEditor.Document.GetLineByOffset(caretOffset);
            string textBeforeCaret = mainEditor.Document.GetText(line.Offset, caretOffset - line.Offset);
            if (textBeforeCaret.StartsWith("#"))
            {
                functionCompletionDismissed = false;
                ClearFunctionCompletion();
                return;
            }

            if (TryShowDateTimeMemberCompletion(textBeforeCaret, caretOffset))
                return;

            Match match = Regex.Match(textBeforeCaret, @"(?<![\w])(?<prefix>[a-zA-Z]+)$");
            if (!match.Success || match.Groups["prefix"].Length < 2)
            {
                ClearFunctionCompletion();
                return;
            }

            if (caretOffset < line.EndOffset && (char.IsLetterOrDigit(mainEditor.Document.GetCharAt(caretOffset)) || mainEditor.Document.GetCharAt(caretOffset) == '_' || mainEditor.Document.GetCharAt(caretOffset) == '('))
            {
                ClearFunctionCompletion();
                return;
            }

            string prefix = match.Groups["prefix"].Value;
            FunctionCompletionData matchItem = functionCompletions
                .Where(item => item.Text.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
            if (matchItem == null)
            {
                ClearFunctionCompletion();
                return;
            }

            ShowFunctionCompletion(matchItem, prefix, caretOffset);
        }

        private void UpdateDateTimeMemberCompletion()
        {
            int caretOffset = mainEditor.CaretOffset;
            DocumentLine line = mainEditor.Document.GetLineByOffset(caretOffset);
            string textBeforeCaret = mainEditor.Document.GetText(line.Offset, caretOffset - line.Offset);
            if (textBeforeCaret.StartsWith("#") || TryShowDateTimeMemberCompletion(textBeforeCaret, caretOffset))
                return;

            ClearFunctionCompletion();
        }

        private bool TryShowDateTimeMemberCompletion(string textBeforeCaret, int caretOffset)
        {
            Match match = Regex.Match(textBeforeCaret, @"(?<![\w.])(?<keyword>[a-zA-Z]+)\.(?<prefix>[a-zA-Z]*)$");
            if (!match.Success)
                return false;

            DocumentLine line = mainEditor.Document.GetLineByOffset(caretOffset);
            if (caretOffset < line.EndOffset && (char.IsLetterOrDigit(mainEditor.Document.GetCharAt(caretOffset)) || mainEditor.Document.GetCharAt(caretOffset) == '_' || mainEditor.Document.GetCharAt(caretOffset) == '('))
            {
                ClearFunctionCompletion();
                return true;
            }

            string keyword = match.Groups["keyword"].Value;
            string[] members = keyword.Equals("now", StringComparison.OrdinalIgnoreCase) || keyword.Equals("time", StringComparison.OrdinalIgnoreCase)
                ? dateTimeTimeMembers
                : keyword.Equals("today", StringComparison.OrdinalIgnoreCase) || keyword.Equals("date", StringComparison.OrdinalIgnoreCase) || keyword.Equals("yesterday", StringComparison.OrdinalIgnoreCase) || keyword.Equals("tomorrow", StringComparison.OrdinalIgnoreCase)
                    ? dateTimeDateMembers
                    : null;
            if (members == null)
            {
                ClearFunctionCompletion();
                return true;
            }

            string prefix = match.Groups["prefix"].Value;
            string member = members.FirstOrDefault(item => item.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
            if (member == null)
            {
                ClearFunctionCompletion();
                return true;
            }

            ShowFunctionCompletion(new FunctionCompletionData(member, member), prefix, caretOffset);
            return true;
        }

        private void ShowFunctionCompletion(FunctionCompletionData completion, string prefix, int caretOffset)
        {
            activeFunctionCompletion = completion;
            functionCompletionStartOffset = caretOffset - prefix.Length;
            functionCompletionPrefix = prefix;
            UpdateFunctionCompletionDisplay();
        }

        private void FunctionCompletion_CaretPositionChanged(object sender, EventArgs e)
        {
            if (activeFunctionCompletion != null && mainEditor.CaretOffset != functionCompletionStartOffset + functionCompletionPrefix.Length)
                ClearFunctionCompletion();

            UpdateFunctionCompletionDisplay();
        }

        private void ClearFunctionCompletion()
        {
            activeFunctionCompletion = null;
            functionCompletionPrefix = string.Empty;
            UpdateFunctionCompletionDisplay();
        }

        private void UpdateFunctionCompletionDisplay()
        {
            if (functionCompletionRenderer == null)
                return;

            functionCompletionRenderer.Suggestion = activeFunctionCompletion == null
                ? string.Empty
                : activeFunctionCompletion.Signature.Substring(functionCompletionPrefix.Length);
            mainEditor.TextArea.TextView.InvalidateLayer(KnownLayer.Caret);
        }

        private sealed class FunctionCompletionData
        {
            public FunctionCompletionData(string text, string signature)
            {
                Text = text;
                Signature = signature;
            }

            public string Text { get; }
            public string Signature { get; }
        }

        private sealed class FunctionCompletionRenderer : IBackgroundRenderer
        {
            private readonly TextEditor editor;
            private readonly Brush suggestionBrush = new SolidColorBrush(Color.FromArgb(150, 128, 128, 128));

            public FunctionCompletionRenderer(TextEditor editor)
            {
                this.editor = editor;
            }

            public string Suggestion { get; set; } = string.Empty;

            public KnownLayer Layer => KnownLayer.Caret;

            public void Draw(TextView textView, DrawingContext drawingContext)
            {
                if (string.IsNullOrEmpty(Suggestion) || !editor.IsKeyboardFocusWithin || textView.VisualLines.Count == 0)
                    return;

                FormattedText formattedText = new FormattedText(
                    Suggestion,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(editor.FontFamily, editor.FontStyle, editor.FontWeight, editor.FontStretch),
                    editor.FontSize,
                    suggestionBrush,
                    VisualTreeHelper.GetDpi(textView).PixelsPerDip);
                Point caretPosition = textView.GetVisualPosition(editor.TextArea.Caret.Position, VisualYPosition.LineBottom);
                if (double.IsNaN(caretPosition.X) || double.IsNaN(caretPosition.Y))
                    return;

                drawingContext.DrawText(formattedText, new Point(caretPosition.X + 2, caretPosition.Y - formattedText.Height));
            }
        }
    }
}
