using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calcify
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public MainWindow _MainWindow;

        public Settings()
        {
            InitializeComponent();
            closeButton.Click += CloseButton_Click;
            LessDecimalsButton.Click += DecimalsButton_Click;
            MoreDecimalsButton.Click += DecimalsButton_Click;
            DecreaseFontSizeButton.Click += FontSizeButton_Click;
            IncreaseFontSizeButton.Click += FontSizeButton_Click;

            DecimalPlacesTextBox.PreviewTextInput += (sender, e) =>
            {
                if (!new Regex(@"\d+").IsMatch(e.Text))
                    e.Handled = true;
            };

            DecimalPlacesTextBox.TextChanged += DecimalPlacesTextBox_TextChanged;
            DecimalPlacesTextBox.LostFocus += DecimalPlacesTextBox_LostFocus;
            EditorFontSizeTextBox.PreviewTextInput += (sender, e) =>
            {
                if (!new Regex(@"\d+").IsMatch(e.Text))
                    e.Handled = true;
            };
            EditorFontSizeTextBox.TextChanged += EditorFontSizeTextBox_TextChanged;
            EditorFontSizeTextBox.LostFocus += EditorFontSizeTextBox_LostFocus;
            DarkModeRadioButton.Checked += DarkModeRadioButtons_CheckedChanged;
            LightModeRadioButton.Checked += DarkModeRadioButtons_CheckedChanged;
            SystemDefinedDarkModeRadioButton.Checked += DarkModeRadioButtons_CheckedChanged;
            DocumentAutorName.TextChanged += DocumentAutorName_TextChanged;
            ShowLineNumbersCheckBox.Checked += ShowLineNumbersCheckBox_Checked;
            ShowLineNumbersCheckBox.Unchecked += ShowLineNumbersCheckBox_Checked;
            HighlightCurrentLineCheckBox.Checked += HighlightCurrentLineCheckBox_Checked;
            HighlightCurrentLineCheckBox.Unchecked += HighlightCurrentLineCheckBox_Checked;
            this.Loaded += Settings_Loaded;
        }

        private void ShowLineNumbersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowLineNumbers = (bool)ShowLineNumbersCheckBox.IsChecked;
            _MainWindow.UpdateTextBoxLineNumbers();
        }

        private void HighlightCurrentLineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.HighlightCurrentLine = HighlightCurrentLineCheckBox.IsChecked == true;
            Properties.Settings.Default.Save();
            _MainWindow.UpdateCurrentLineHighlighting();
        }

        private void Settings_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SystemDefinedDarkMode)
                SystemDefinedDarkModeRadioButton.IsChecked = true;
            else
            {
                if (Properties.Settings.Default.DarkMode)
                    DarkModeRadioButton.IsChecked = true;
                else
                    LightModeRadioButton.IsChecked = true;
            }
            DocumentAutorName.Text = Properties.Settings.Default.UserName;
            DecimalPlacesTextBox.Text = Properties.Settings.Default.Digits.ToString();
            EditorFontSizeTextBox.Text = Properties.Settings.Default.EditorFontSize.ToString();
            ShowLineNumbersCheckBox.IsChecked = Properties.Settings.Default.ShowLineNumbers;
            HighlightCurrentLineCheckBox.IsChecked = Properties.Settings.Default.HighlightCurrentLine;
        }

        private void DocumentAutorName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DocumentAutorName.Text != "")
                Properties.Settings.Default.UserName = DocumentAutorName.Text;
            Properties.Settings.Default.Save();
        }

        private void DecimalPlacesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DecimalPlacesTextBox.Text == "")
                return;

            if (int.TryParse(DecimalPlacesTextBox.Text, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out int digits) && digits > 0)
            {
                Properties.Settings.Default.Digits = digits;
                Properties.Settings.Default.Save();
            }
            else
                DecimalPlacesTextBox.Text = Properties.Settings.Default.Digits.ToString();
        }

        private void DecimalPlacesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DecimalPlacesTextBox.Text == "")
                DecimalPlacesTextBox.Text = Properties.Settings.Default.Digits.ToString();
        }

        private void EditorFontSizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(EditorFontSizeTextBox.Text, out int fontSize) && fontSize >= 8 && fontSize <= 32)
            {
                Properties.Settings.Default.EditorFontSize = fontSize;
                Properties.Settings.Default.Save();
                _MainWindow.ApplyEditorFontSize(fontSize);
            }
        }

        private void EditorFontSizeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(EditorFontSizeTextBox.Text, out int fontSize) || fontSize < 8 || fontSize > 32)
                EditorFontSizeTextBox.Text = Properties.Settings.Default.EditorFontSize.ToString();
        }

        private void DarkModeRadioButtons_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (SystemDefinedDarkModeRadioButton.IsChecked.Value)
                Properties.Settings.Default.SystemDefinedDarkMode = true;
            else
            {
                Properties.Settings.Default.SystemDefinedDarkMode = false;
                Properties.Settings.Default.DarkMode = DarkModeRadioButton.IsChecked.Value;
            }
            Properties.Settings.Default.Save();
        }

        private void FontSizeButton_Click(object sender, RoutedEventArgs e)
        {
            int adjustment = ((Button)sender).Name == "DecreaseFontSizeButton" ? -1 : 1;
            int fontSize = System.Math.Max(8, System.Math.Min(32, Properties.Settings.Default.EditorFontSize + adjustment));
            EditorFontSizeTextBox.Text = fontSize.ToString();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _MainWindow.settingsWindow = null;
        }

        private void DecimalsButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == "LessDecimalsButton")
            {
                if (Properties.Settings.Default.Digits - 1 != 0)
                    DecimalPlacesTextBox.Text = (Properties.Settings.Default.Digits - 1).ToString();
            }
            else
                DecimalPlacesTextBox.Text = (Properties.Settings.Default.Digits + 1).ToString();
            Properties.Settings.Default.Save();
        }
    }
}
