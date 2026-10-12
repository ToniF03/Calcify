using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calcify
{
    public partial class MainWindow
    {
        private void InitializeCurrentLineHighlighting()
        {
            Grid editorGrid = FindName("EditorGrid") as Grid;
            Border splitterHighlight = FindName("splitterLineHighlight") as Border;

            AddCurrentLineHighlighting(mainEditor, editorGrid, splitterHighlight);
            mainEditor.TextArea.TextView.BackgroundRenderers.Add(
                new MatchingBracketBackgroundRenderer(mainEditor));
            AddCurrentLineHighlighting(resultEditor, null, null);
        }

        internal void UpdateBracketHighlighting()
        {
            mainEditor.TextArea.TextView.InvalidateLayer(KnownLayer.Background);
        }

        internal void UpdateCurrentLineHighlighting()
        {
            mainEditor.TextArea.TextView.InvalidateLayer(KnownLayer.Background);
            resultEditor.TextArea.TextView.InvalidateLayer(KnownLayer.Background);

            for (int i = 0; i < mainEditor.TextArea.LeftMargins.Count; i++)
                mainEditor.TextArea.LeftMargins[i].InvalidateVisual();

            Border splitterHighlight = FindName("splitterLineHighlight") as Border;
            if (!Properties.Settings.Default.HighlightCurrentLine)
            {
                if (splitterHighlight != null)
                    splitterHighlight.Visibility = Visibility.Collapsed;
                return;
            }

            if (splitterHighlight != null)
                UpdateSplitterHighlight(mainEditor, FindName("EditorGrid") as Grid, splitterHighlight);
        }

        private static void AddCurrentLineHighlighting(TextEditor editor, Grid editorGrid, Border splitterHighlight)
        {
            editor.TextArea.TextView.BackgroundRenderers.Add(
                new CurrentLineBackgroundRenderer(editor));

            if (splitterHighlight != null)
            {
                splitterHighlight.Background = CurrentLineBackgroundRenderer.HighlightBrush;
                Action updateSplitterHighlight = () =>
                    UpdateSplitterHighlight(editor, editorGrid, splitterHighlight);
                editor.TextArea.TextView.VisualLinesChanged += (sender, args) => updateSplitterHighlight();
                editorGrid.SizeChanged += (sender, args) => updateSplitterHighlight();
                updateSplitterHighlight();
            }

            CurrentLineNumberMargin numberMargin = null;

            for (int i = 0; i < editor.TextArea.LeftMargins.Count; i++)
            {
                if (editor.TextArea.LeftMargins[i] is LineNumberMargin originalMargin)
                {
                    numberMargin = new CurrentLineNumberMargin(editor, originalMargin);
                    editor.TextArea.LeftMargins[i] = numberMargin;
                    break;
                }
            }

            editor.TextArea.Caret.PositionChanged += (sender, args) =>
            {
                editor.TextArea.TextView.InvalidateLayer(KnownLayer.Background);
                if (numberMargin != null)
                    numberMargin.InvalidateVisual();
                if (splitterHighlight != null)
                    UpdateSplitterHighlight(editor, editorGrid, splitterHighlight);
            };
        }

        private static void UpdateSplitterHighlight(TextEditor editor, Grid editorGrid, Border splitterHighlight)
        {
            if (!Properties.Settings.Default.HighlightCurrentLine)
            {
                splitterHighlight.Visibility = Visibility.Collapsed;
                return;
            }

            TextView textView = editor.TextArea.TextView;
            try
            {
                if (textView.VisualLines.Count == 0)
                {
                    splitterHighlight.Visibility = Visibility.Collapsed;
                    return;
                }

                DocumentLine documentLine = editor.Document.GetLineByOffset(editor.CaretOffset);
                VisualLine visualLine = textView.GetVisualLine(documentLine.LineNumber);
                if (visualLine == null)
                {
                    splitterHighlight.Visibility = Visibility.Collapsed;
                    return;
                }

                double lineTop = visualLine.VisualTop - textView.ScrollOffset.Y;
                Point lineTopInGrid = textView.TranslatePoint(new Point(0, lineTop), editorGrid);
                Point lineBottomInGrid = textView.TranslatePoint(
                    new Point(0, lineTop + visualLine.Height), editorGrid);
                double viewportTop = textView.TranslatePoint(new Point(0, 0), editorGrid).Y;
                double viewportBottom = textView.TranslatePoint(
                    new Point(0, textView.ActualHeight), editorGrid).Y;
                double highlightTop = System.Math.Max(lineTopInGrid.Y, viewportTop);
                double highlightBottom = System.Math.Min(lineBottomInGrid.Y, viewportBottom);

                if (highlightBottom <= highlightTop)
                {
                    splitterHighlight.Visibility = Visibility.Collapsed;
                    return;
                }

                splitterHighlight.Margin = new Thickness(0, highlightTop, 0, 0);
                splitterHighlight.Height = highlightBottom - highlightTop;
                splitterHighlight.Visibility = Visibility.Visible;
            }
            catch (VisualLinesInvalidException)
            {
                splitterHighlight.Visibility = Visibility.Collapsed;
            }
        }

        private sealed class CurrentLineNumberMargin : LineNumberMargin
        {
            private readonly TextEditor editor;

            public CurrentLineNumberMargin(TextEditor editor, LineNumberMargin originalMargin)
            {
                this.editor = editor;

                // Keep AvalonEdit's original line-number color and spacing.
                Style = originalMargin.Style;
                Margin = new Thickness(originalMargin.Margin.Left, 
                                       originalMargin.Margin.Top,
                                       originalMargin.Margin.Right + 5,
                                       originalMargin.Margin.Bottom);
                SetValue(
                    TextBlock.ForegroundProperty,
                    originalMargin.GetValue(TextBlock.ForegroundProperty));
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                TextView textView = editor.TextArea.TextView;

                try
                {
                    if (Properties.Settings.Default.HighlightCurrentLine && textView.VisualLines.Count > 0)
                    {
                        DocumentLine documentLine =
                            editor.Document.GetLineByOffset(editor.CaretOffset);
                        VisualLine visualLine =
                            textView.GetVisualLine(documentLine.LineNumber);

                        if (visualLine != null)
                        {
                            double top = visualLine.VisualTop - textView.ScrollOffset.Y;

                            drawingContext.DrawRectangle(
                                CurrentLineBackgroundRenderer.HighlightBrush,
                                null,
                                new Rect(0, top, ActualWidth, visualLine.Height));
                        }
                    }
                }
                catch (VisualLinesInvalidException)
                {
                    // Visual lines can be temporarily invalid during layout.
                }

                base.OnRender(drawingContext);
            }
        }

        private sealed class CurrentLineBackgroundRenderer : IBackgroundRenderer
        {
            public static readonly Brush HighlightBrush = CreateHighlightBrush();
            private readonly TextEditor editor;

            public CurrentLineBackgroundRenderer(TextEditor editor)
            {
                this.editor = editor;
            }

            public KnownLayer Layer
            {
                get { return KnownLayer.Background; }
            }

            public void Draw(TextView textView, DrawingContext drawingContext)
            {
                if (!Properties.Settings.Default.HighlightCurrentLine ||
                    textView.VisualLines.Count == 0 || textView.ActualWidth <= 0)
                    return;

                DocumentLine documentLine =
                    editor.Document.GetLineByOffset(editor.CaretOffset);
                VisualLine visualLine = textView.GetVisualLine(documentLine.LineNumber);

                if (visualLine == null)
                    return;

                double top = visualLine.VisualTop - textView.ScrollOffset.Y;
                if (top + visualLine.Height < 0 || top > textView.ActualHeight)
                    return;

                drawingContext.DrawRectangle(
                    HighlightBrush,
                    null,
                    new Rect(0, top, textView.ActualWidth, visualLine.Height));
            }

            private static Brush CreateHighlightBrush()
            {
                SolidColorBrush brush =
                    new SolidColorBrush(Color.FromArgb(20, 0, 0, 0));
                brush.Freeze();
                return brush;
            }
        }

        private sealed class MatchingBracketBackgroundRenderer : IBackgroundRenderer
        {
            private static readonly Brush HighlightBrush = CreateHighlightBrush();
            private static readonly Pen HighlightPen = CreateHighlightPen();
            private readonly TextEditor editor;

            public MatchingBracketBackgroundRenderer(TextEditor editor)
            {
                this.editor = editor;
            }

            public KnownLayer Layer
            {
                get { return KnownLayer.Background; }
            }

            public void Draw(TextView textView, DrawingContext drawingContext)
            {
                if (!Properties.Settings.Default.ShowMatchingBrackets ||
                    textView.VisualLines.Count == 0)
                    return;

                int bracketOffset = editor.CaretOffset;
                if (!IsBracketAt(bracketOffset) && !IsBracketAt(bracketOffset - 1))
                    return;
                if (!IsBracketAt(bracketOffset))
                    bracketOffset--;

                int matchingOffset = FindMatchingBracket(bracketOffset);
                if (matchingOffset < 0)
                    return;

                DrawBracket(textView, drawingContext, bracketOffset);
                DrawBracket(textView, drawingContext, matchingOffset);
            }

            private bool IsBracketAt(int offset)
            {
                return offset >= 0 && offset < editor.Document.TextLength &&
                    IsOpeningBracket(editor.Document.GetCharAt(offset), out _) ||
                    offset >= 0 && offset < editor.Document.TextLength &&
                    IsClosingBracket(editor.Document.GetCharAt(offset), out _);
            }

            private int FindMatchingBracket(int offset)
            {
                char bracket = editor.Document.GetCharAt(offset);
                List<char> expectedBrackets = new List<char>();

                if (IsOpeningBracket(bracket, out char closingBracket))
                {
                    expectedBrackets.Add(closingBracket);
                    for (int i = offset + 1; i < editor.Document.TextLength; i++)
                    {
                        char current = editor.Document.GetCharAt(i);
                        if (IsOpeningBracket(current, out char nestedClosingBracket))
                            expectedBrackets.Add(nestedClosingBracket);
                        else if (IsClosingBracket(current, out _) )
                        {
                            if (current != expectedBrackets[expectedBrackets.Count - 1])
                                return -1;
                            expectedBrackets.RemoveAt(expectedBrackets.Count - 1);
                            if (expectedBrackets.Count == 0)
                                return i;
                        }
                    }
                }
                else if (IsClosingBracket(bracket, out char openingBracket))
                {
                    expectedBrackets.Add(openingBracket);
                    for (int i = offset - 1; i >= 0; i--)
                    {
                        char current = editor.Document.GetCharAt(i);
                        if (IsClosingBracket(current, out char nestedOpeningBracket))
                            expectedBrackets.Add(nestedOpeningBracket);
                        else if (IsOpeningBracket(current, out _))
                        {
                            if (current != expectedBrackets[expectedBrackets.Count - 1])
                                return -1;
                            expectedBrackets.RemoveAt(expectedBrackets.Count - 1);
                            if (expectedBrackets.Count == 0)
                                return i;
                        }
                    }
                }

                return -1;
            }

            private static bool IsOpeningBracket(char value, out char closingBracket)
            {
                switch (value)
                {
                    case '(': closingBracket = ')'; return true;
                    case '[': closingBracket = ']'; return true;
                    case '{': closingBracket = '}'; return true;
                    default: closingBracket = '\0'; return false;
                }
            }

            private static bool IsClosingBracket(char value, out char openingBracket)
            {
                switch (value)
                {
                    case ')': openingBracket = '('; return true;
                    case ']': openingBracket = '['; return true;
                    case '}': openingBracket = '{'; return true;
                    default: openingBracket = '\0'; return false;
                }
            }

            private static void DrawBracket(TextView textView, DrawingContext drawingContext, int offset)
            {
                foreach (Rect rect in BackgroundGeometryBuilder.GetRectsForSegment(
                    textView, new BracketSegment(offset, 1)))
                {
                    if (!rect.IsEmpty)
                        drawingContext.DrawRoundedRectangle(HighlightBrush, HighlightPen, rect, 2, 2);
                }
            }

            private static Brush CreateHighlightBrush()
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(75, 0, 120, 215));
                brush.Freeze();
                return brush;
            }

            private static Pen CreateHighlightPen()
            {
                Pen pen = new Pen(new SolidColorBrush(Color.FromArgb(210, 0, 95, 180)), 1);
                pen.Brush.Freeze();
                pen.Freeze();
                return pen;
            }

            private sealed class BracketSegment : ISegment
            {
                public BracketSegment(int offset, int length)
                {
                    Offset = offset;
                    Length = length;
                }

                public int Offset { get; private set; }
                public int Length { get; private set; }
                public int EndOffset { get { return Offset + Length; } }
            }
        }
    }
}
