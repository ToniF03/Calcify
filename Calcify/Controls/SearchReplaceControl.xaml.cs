using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Calcify.Controls
{
    public partial class SearchReplaceControl : UserControl
    {
        private TextEditor editor;
        private Regex searchRegex;
        private Match currentMatch;
        private SearchResultBackgroundRenderer resultRenderer;
        private SearchResultOverview overview;

        public SearchResultOverview Overview
        {
            get { return overview; }
            set
            {
                if (overview != null)
                    overview.MatchSelected -= Overview_MatchSelected;

                overview = value;
                if (overview != null)
                    overview.MatchSelected += Overview_MatchSelected;

                UpdateOverview(null);
                UpdateMatches();
            }
        }

        public SearchReplaceControl()
        {
            InitializeComponent();
            Visibility = Visibility.Collapsed;
        }

        public TextEditor Editor
        {
            get { return editor; }
            set
            {
                if (editor != null && resultRenderer != null)
                {
                    editor.TextArea.TextView.BackgroundRenderers.Remove(resultRenderer);
                    editor.TextChanged -= Editor_TextChanged;
                }

                editor = value;
                if (editor != null)
                {
                    resultRenderer = new SearchResultBackgroundRenderer();
                    editor.TextArea.TextView.BackgroundRenderers.Add(resultRenderer);
                    editor.TextChanged += Editor_TextChanged;
                }
                UpdateMatches();
            }
        }

        public void ShowSearch(bool showReplace)
        {
            Visibility = Visibility.Visible;
            SetReplaceVisible(showReplace);
            string selectedText = editor != null ? editor.SelectedText : string.Empty;
            if (!string.IsNullOrEmpty(selectedText) && selectedText.IndexOfAny(new[] { '\r', '\n' }) < 0)
                FindTextBox.Text = selectedText;
            UpdateMatches();
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
            {
                if (Visibility == Visibility.Visible)
                {
                    FindTextBox.Focus();
                    Keyboard.Focus(FindTextBox);
                    FindTextBox.SelectAll();
                }
            }));
        }

        public void CloseSearch()
        {
            Visibility = Visibility.Collapsed;
            currentMatch = null;
            UpdateHighlights(null);
            UpdateOverview(null);
            if (editor != null)
                editor.Focus();
        }

        private Regex BuildSearchRegex()
        {
            if (string.IsNullOrEmpty(FindTextBox.Text))
                return null;

            string pattern = UseRegexCheckBox.IsChecked == true
                ? FindTextBox.Text
                : Regex.Escape(FindTextBox.Text);
            if (WholeWordCheckBox.IsChecked == true)
                pattern = @"\b(?:" + pattern + @")\b";

            RegexOptions options = RegexOptions.Multiline;
            if (MatchCaseCheckBox.IsChecked != true)
                options |= RegexOptions.IgnoreCase;

            searchRegex = new Regex(pattern, options, TimeSpan.FromSeconds(1));
            return searchRegex;
        }

        private MatchCollection GetMatches(string text)
        {
            Regex regex = BuildSearchRegex();
            return regex == null ? null : regex.Matches(text);
        }

        private void UpdateMatches()
        {
            if (editor == null || string.IsNullOrEmpty(FindTextBox.Text))
            {
                currentMatch = null;
                MatchStatusText.Text = string.Empty;
                FindTextBox.ClearValue(Control.BorderBrushProperty);
                UpdateHighlights(null);
                UpdateOverview(null);
                return;
            }

            try
            {
                MatchCollection matches = GetMatches(editor.Text);
                FindTextBox.ClearValue(Control.BorderBrushProperty);
                UpdateHighlights(matches);
                UpdateOverview(matches);
                if (matches.Count == 0)
                {
                    currentMatch = null;
                    MatchStatusText.Text = "No results";
                }
                else
                    MatchStatusText.Text = matches.Count + " results";
            }
            catch (ArgumentException)
            {
                currentMatch = null;
                UpdateHighlights(null);
                UpdateOverview(null);
                FindTextBox.BorderBrush = Brushes.IndianRed;
                MatchStatusText.Text = "Invalid pattern";
            }
            catch (RegexMatchTimeoutException)
            {
                currentMatch = null;
                UpdateHighlights(null);
                UpdateOverview(null);
                FindTextBox.BorderBrush = Brushes.IndianRed;
                MatchStatusText.Text = "Search timed out";
            }
        }

        private void Find(bool forward)
        {
            if (editor == null)
                return;

            try
            {
                MatchCollection matches = GetMatches(editor.Text);
                if (matches == null || matches.Count == 0)
                {
                    UpdateMatches();
                    return;
                }

                int startOffset;
                if (forward)
                {
                    startOffset = currentMatch != null
                        ? currentMatch.Index + currentMatch.Length
                        : editor.SelectionLength > 0
                            ? editor.SelectionStart + editor.SelectionLength
                            : editor.TextArea.Caret.Offset;
                }
                else
                {
                    startOffset = currentMatch != null
                        ? currentMatch.Index
                        : editor.SelectionLength > 0
                            ? editor.SelectionStart
                            : editor.TextArea.Caret.Offset;
                }

                SelectMatch(matches, startOffset, forward);
            }
            catch (ArgumentException)
            {
                UpdateMatches();
            }
            catch (RegexMatchTimeoutException)
            {
                UpdateMatches();
            }
        }

        private void SelectMatch(MatchCollection matches, int startOffset, bool forward)
        {
            Match selectedMatch = null;
            if (forward)
            {
                foreach (Match match in matches)
                {
                    if (match.Index >= startOffset)
                    {
                        selectedMatch = match;
                        break;
                    }
                }
                if (selectedMatch == null)
                    selectedMatch = matches[0];
            }
            else
            {
                for (int i = matches.Count - 1; i >= 0; i--)
                {
                    if (matches[i].Index < startOffset)
                    {
                        selectedMatch = matches[i];
                        break;
                    }
                }
                if (selectedMatch == null)
                    selectedMatch = matches[matches.Count - 1];
            }

            currentMatch = selectedMatch;
            UpdateHighlights(matches);
            UpdateOverview(matches);
            editor.Select(selectedMatch.Index, selectedMatch.Length);
            MatchStatusText.Text = (GetMatchIndex(matches, selectedMatch) + 1) + " of " + matches.Count;
        }

        private void UpdateOverview(MatchCollection matches)
        {
            if (Overview != null)
                Overview.SetMatches(editor != null ? editor.Document : null, matches, currentMatch, true);
        }

        private void Overview_MatchSelected(Match match)
        {
            if (editor == null || match == null)
                return;

            try
            {
                MatchCollection matches = GetMatches(editor.Text);
                if (matches == null)
                    return;

                Match selectedMatch = null;
                foreach (Match candidate in matches)
                {
                    if (candidate.Index == match.Index && candidate.Length == match.Length)
                    {
                        selectedMatch = candidate;
                        break;
                    }
                }

                if (selectedMatch != null)
                {
                    SelectMatch(matches, selectedMatch.Index, true);
                    editor.TextArea.Caret.Offset = selectedMatch.Index;
                    editor.ScrollToLine(editor.Document.GetLineByOffset(selectedMatch.Index).LineNumber);
                    editor.Focus();
                }
            }
            catch (ArgumentException)
            {
                UpdateMatches();
            }
            catch (RegexMatchTimeoutException)
            {
                UpdateMatches();
            }
        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            UpdateMatches();
        }

        private void UpdateHighlights(MatchCollection matches)
        {
            if (resultRenderer == null)
                return;

            resultRenderer.SetMatches(matches, currentMatch);
            if (editor != null)
                editor.TextArea.TextView.Redraw();
        }

        private static int GetMatchIndex(MatchCollection matches, Match target)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Index == target.Index && matches[i].Length == target.Length)
                    return i;
            }
            return 0;
        }

        private void SetReplaceVisible(bool visible)
        {
            Visibility replacementVisibility = visible ? Visibility.Visible : Visibility.Collapsed;
            ReplaceTextBox.Visibility = replacementVisibility;
            ReplaceRow.Visibility = replacementVisibility;
            ReplaceCurrentButton.Visibility = replacementVisibility;
            ReplaceAllButton.Visibility = replacementVisibility;
        }

        private void FindTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int startOffset = currentMatch != null
                ? currentMatch.Index
                : editor != null && editor.SelectionLength > 0
                    ? editor.SelectionStart
                    : editor != null ? editor.TextArea.Caret.Offset : 0;
            UpdateMatches();
            if (editor != null && !string.IsNullOrEmpty(FindTextBox.Text))
            {
                try
                {
                    MatchCollection matches = GetMatches(editor.Text);
                    if (matches != null && matches.Count > 0)
                        SelectMatch(matches, startOffset, true);
                }
                catch (ArgumentException)
                {
                    UpdateMatches();
                }
                catch (RegexMatchTimeoutException)
                {
                    UpdateMatches();
                }
            }
        }

        private void SearchOption_Changed(object sender, RoutedEventArgs e)
        {
            UpdateMatches();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Find(false);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Find(true);
        }

        private void ToggleReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            SetReplaceVisible(ReplaceTextBox.Visibility != Visibility.Visible);
        }

        private void ReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (editor == null || editor.SelectionLength == 0)
                return;

            try
            {
                MatchCollection matches = GetMatches(editor.Text);
                Match selectedMatch = FindSelectedMatch(matches);
                if (selectedMatch == null)
                    return;

                string replacement = UseRegexCheckBox.IsChecked == true
                    ? selectedMatch.Result(ReplaceTextBox.Text)
                    : ReplaceTextBox.Text;
                editor.Document.Replace(selectedMatch.Index, selectedMatch.Length, replacement);
                editor.TextArea.Caret.Offset = selectedMatch.Index + replacement.Length;
                editor.Select(editor.TextArea.Caret.Offset, 0);
                Find(true);
            }
            catch (ArgumentException)
            {
                UpdateMatches();
            }
            catch (RegexMatchTimeoutException)
            {
                UpdateMatches();
            }
        }

        private void ReplaceAllButton_Click(object sender, RoutedEventArgs e)
        {
            if (editor == null)
                return;

            try
            {
                Regex regex = BuildSearchRegex();
                if (regex == null)
                    return;

                string text = editor.Text;
                string replaced = regex.Replace(text, ReplaceTextBox.Text);
                if (text == replaced)
                    return;

                editor.Document.BeginUpdate();
                try
                {
                    editor.Document.Replace(0, editor.Document.TextLength, replaced);
                }
                finally
                {
                    editor.Document.EndUpdate();
                }
                UpdateMatches();
            }
            catch (ArgumentException)
            {
                UpdateMatches();
            }
            catch (RegexMatchTimeoutException)
            {
                UpdateMatches();
            }
        }

        private Match FindSelectedMatch(MatchCollection matches)
        {
            if (matches == null)
                return null;

            int selectionStart = editor.SelectionStart;
            int selectionLength = editor.SelectionLength;
            foreach (Match match in matches)
            {
                if (match.Index == selectionStart && match.Length == selectionLength)
                    return match;
            }
            return null;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseSearch();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Escape)
            {
                CloseSearch();
                e.Handled = true;
            }
            else if (e.Key == Key.Enter && FindTextBox.IsKeyboardFocusWithin)
            {
                Find((Keyboard.Modifiers & ModifierKeys.Shift) == 0);
                e.Handled = true;
            }
        }
    }
}
