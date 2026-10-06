using ICSharpCode.AvalonEdit.Document;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calcify.Controls
{
    public sealed class SearchResultOverview : Control
    {
        private readonly Brush trackBrush = new SolidColorBrush(Color.FromArgb(32, 128, 128, 128));
        private readonly Brush markerBrush = new SolidColorBrush(Color.FromArgb(190, 255, 190, 0));
        private readonly Brush currentMarkerBrush = new SolidColorBrush(Color.FromArgb(255, 255, 125, 0));
        private readonly List<SearchMarker> markers = new List<SearchMarker>();
        private TextDocument document;
        private bool isSearchVisible;

        public event Action<Match> MatchSelected;

        public SearchResultOverview()
        {
            IsHitTestVisible = true;
            Cursor = Cursors.Hand;
        }

        public void SetMatches(TextDocument textDocument, MatchCollection matches, Match currentMatch, bool searchVisible)
        {
            document = textDocument;
            isSearchVisible = searchVisible;
            markers.Clear();

            if (document != null && matches != null)
            {
                foreach (Match match in matches)
                {
                    int lineNumber = document.GetLineByOffset(match.Index).LineNumber;
                    bool isCurrent = currentMatch != null
                        && match.Index == currentMatch.Index
                        && match.Length == currentMatch.Length;
                    markers.Add(new SearchMarker(match, lineNumber, isCurrent));
                }
            }

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (!isSearchVisible || document == null || markers.Count == 0 || ActualHeight <= 0 || ActualWidth <= 0)
                return;

            drawingContext.DrawRectangle(Background ?? trackBrush, null, new Rect(0, 0, ActualWidth, ActualHeight));
            double lineCount = System.Math.Max(1, document.LineCount);
            foreach (SearchMarker marker in markers)
            {
                double y = (marker.LineNumber - 1) / lineCount * ActualHeight;
                double markerHeight = System.Math.Max(3, System.Math.Min(5, ActualHeight / lineCount));
                Rect bounds = new Rect(0, System.Math.Min(ActualHeight - markerHeight, y), ActualWidth, markerHeight);
                drawingContext.DrawRoundedRectangle(marker.IsCurrent ? currentMarkerBrush : markerBrush, null, bounds, 1, 1);
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (!isSearchVisible || document == null || markers.Count == 0 || ActualHeight <= 0)
                return;

            double clickedLine = e.GetPosition(this).Y / ActualHeight * document.LineCount + 1;
            SearchMarker closest = null;
            double closestDistance = double.MaxValue;
            foreach (SearchMarker marker in markers)
            {
                double distance = System.Math.Abs(marker.LineNumber - clickedLine);
                if (distance < closestDistance)
                {
                    closest = marker;
                    closestDistance = distance;
                }
            }

            if (closest != null)
            {
                MatchSelected?.Invoke(closest.Match);
                e.Handled = true;
            }
        }

        private sealed class SearchMarker
        {
            public SearchMarker(Match match, int lineNumber, bool isCurrent)
            {
                Match = match;
                LineNumber = lineNumber;
                IsCurrent = isCurrent;
            }

            public Match Match { get; private set; }
            public int LineNumber { get; private set; }
            public bool IsCurrent { get; private set; }
        }
    }
}
