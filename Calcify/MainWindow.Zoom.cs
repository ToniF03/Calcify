using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calcify
{
    public partial class MainWindow
    {
        /// <summary>
        /// Parses a zoom value from the specified text and applies it to the editor controls if valid.
        /// </summary>
        /// <remarks>If the parsed zoom value is outside the supported range (25% to 400%), it will be
        /// clamped to the nearest valid value. The method updates the editor zoom setting and applies the zoom to the
        /// relevant editor controls.</remarks>
        /// <param name="text">A string containing the zoom value to apply. The value should be a number between 25 and 400, optionally
        /// followed by a percent sign (e.g., "150%" or "100").</param>
        private void ApplyZoomFromString(string text)
        {
            Regex parserRegex = new Regex(@"^(?<value>\d{1,3})(?<percent> ?\%?)$");
            Match m = parserRegex.Match(text);
            if (m.Success)
            {
                if (!double.TryParse(m.Groups["value"].Value.ToString(), out double scale)) return;
                string[] items = ZoomComboBox.Items.Cast<object>().Select(s => s.ToString().Split(new[] { ' ' }, 2)[1]).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
                scale /= 100;
                scale = System.Math.Max(0.25, System.Math.Min(4.0, scale));
                Properties.Settings.Default.EditorZoom = scale;
                Properties.Settings.Default.Save();
                mainEditor.LayoutTransform = new ScaleTransform(scale, scale);
                resultEditor.LayoutTransform = new ScaleTransform(scale, scale);
                ZoomComboBox.Text = (scale * 100).ToString("F0", CultureInfo.InvariantCulture) + " %";
                ZoomComboBox.SelectedIndex = Array.FindIndex(items, i => i == ZoomComboBox.Text);
            }
        }

        /// <summary>
        /// Handles the KeyDown event for the zoom combo box, applying the zoom level when the Enter key is pressed.
        /// </summary>
        /// <remarks>This method allows users to type a custom zoom value and apply it by pressing Enter.
        /// The event is marked as handled to prevent further processing of the key press.</remarks>
        /// <param name="sender">The source of the event, typically the zoom combo box control.</param>
        /// <param name="e">A KeyEventArgs that contains the event data, including information about the key pressed.</param>
        private void ZoomCombo_KeyDown(object sender, KeyEventArgs e)
        {
            // accept typed value on Enter
            if (e.Key == Key.Enter)
            {
                ApplyZoomFromString(ZoomComboBox.Text);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event for the zoom level combo box, updating the zoom level based on the user's
        /// selection.
        /// </summary>
        /// <remarks>This method is intended to be used as an event handler for the SelectionChanged event
        /// of a combo box that controls document zoom. If the selected item is valid, the zoom level is updated
        /// accordingly.</remarks>
        /// <param name="sender">The source of the event, typically the zoom level combo box control.</param>
        /// <param name="e">An object that contains information about the selection change event.</param>
        private void ZoomCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ZoomComboBox.SelectedItem != null)
            {
                ApplyZoomFromString(ZoomComboBox.SelectedItem.ToString().Split(new[] { ' ' }, 2)[1]);
            }
        }

        /// <summary>
        /// Handles the LostFocus event for the zoom level combo box, applying the zoom level specified by the user's input.
        /// </summary>
        /// <param name="sender">The source of the event, typically the zoom level combo box control.</param>
        /// <param name="e">The event data associated with the LostFocus event.</param>
        private void ZoomCombo_LostFocus(object sender, RoutedEventArgs e)
        {
            ApplyZoomFromString(ZoomComboBox.Text);
        }
    }
}
