using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Document;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace Calcify.Controls
{
    internal sealed class SearchResultBackgroundRenderer : IBackgroundRenderer
    {
        private readonly Brush matchBrush = new SolidColorBrush(Color.FromArgb(72, 255, 196, 0));
        private readonly Brush currentMatchBrush = new SolidColorBrush(Color.FromArgb(150, 255, 170, 0));
        private readonly Pen matchBorder = new Pen(new SolidColorBrush(Color.FromArgb(150, 220, 150, 0)), 1);
        private readonly Pen currentMatchBorder = new Pen(new SolidColorBrush(Color.FromArgb(230, 220, 120, 0)), 1);
        private IList<Match> matches = new List<Match>();
        private int currentMatchIndex = -1;

        public KnownLayer Layer
        {
            get { return KnownLayer.Background; }
        }

        public void SetMatches(MatchCollection searchMatches, Match currentMatch)
        {
            List<Match> updatedMatches = new List<Match>();
            currentMatchIndex = -1;
            if (searchMatches != null)
            {
                foreach (Match match in searchMatches)
                {
                    updatedMatches.Add(match);
                    if (currentMatch != null && match.Index == currentMatch.Index && match.Length == currentMatch.Length)
                        currentMatchIndex = updatedMatches.Count - 1;
                }
            }
            matches = updatedMatches;
        }

        public void Draw(TextView textView, DrawingContext drawingContext)
        {
            if (matches.Count == 0)
                return;

            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                if (match.Length == 0)
                    continue;

                bool isCurrentMatch = i == currentMatchIndex;
                foreach (Rect rect in BackgroundGeometryBuilder.GetRectsForSegment(textView, new SearchSegment(match.Index, match.Length)))
                {
                    if (!rect.IsEmpty)
                    {
                        drawingContext.DrawRoundedRectangle(
                            isCurrentMatch ? currentMatchBrush : matchBrush,
                            isCurrentMatch ? currentMatchBorder : matchBorder,
                            rect,
                            2,
                            2);
                    }
                }
            }
        }

        private sealed class SearchSegment : ISegment
        {
            public SearchSegment(int offset, int length)
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
