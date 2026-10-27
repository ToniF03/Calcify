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
using Microsoft.Win32;
using System.Globalization;
using Calcify.Classes;

namespace Calcify
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private const string AppUpdateSettingsRegistryPath = @"Software\ToniF03\Calcify\UpdateSettings";
        private const string AutoUpdateEnabledValueName = "Enabled";
        private const string AutoUpdateIntervalDaysValueName = "IntervalDays";
        private bool loadingAppUpdatePreferences;
        private bool loadingAutoSavePreferences;
        private bool loadingEditorLayoutPreferences;

        public MainWindow _MainWindow;

        public Settings()
        {
            InitializeComponent();
            SourceInitialized += (_, __) => NativeWindowStyle.ApplyWindowFrame(this, canMaximize: false);
            closeButton.Click += CloseButton_Click;
            LessDecimalsButton.Click += DecimalsButton_Click;
            MoreDecimalsButton.Click += DecimalsButton_Click;
            DecreaseFontSizeButton.Click += FontSizeButton_Click;
            IncreaseFontSizeButton.Click += FontSizeButton_Click;
            DecreaseTabSpaceButton.Click += TabSpaceButton_Click;
            IncreaseTabSpaceButton.Click += TabSpaceButton_Click;
            EditorTabSpaceTextBox.TextChanged += EditorTabSpaceTextBox_TextChanged;
            
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
            ShowMatchingBracketsCheckBox.Checked += ShowMatchingBracketsCheckBox_Checked;
            ShowMatchingBracketsCheckBox.Unchecked += ShowMatchingBracketsCheckBox_Checked;
            ShowWhitespacesCheckBox.Checked += ShowWhitespacesCheckBox_Checked;
            ShowWhitespacesCheckBox.Unchecked += ShowWhitespacesCheckBox_Checked;
            WordWrapCheckBox.Checked += EditorLayoutPreferences_Changed;
            WordWrapCheckBox.Unchecked += EditorLayoutPreferences_Changed;
            LineSpacingComboBox.SelectionChanged += EditorLayoutPreferences_Changed;
            AutoSaveIntervalComboBox.SelectionChanged += AutoSaveIntervalComboBox_SelectionChanged;
            AutoUpdateApplicationCheckBox.Checked += AppUpdatePreferences_Changed;
            AutoUpdateApplicationCheckBox.Unchecked += AppUpdatePreferences_Changed;
            ApplicationUpdateIntervalComboBox.SelectionChanged += AppUpdatePreferences_Changed;
            ((Button)FindName("UpdateExchangeRatesButton")).Click += UpdateExchangeRatesButton_Click;
            this.Loaded += Settings_Loaded;
        }

        private static bool ReadAutoUpdateEnabled()
        {
            return ReadAppUpdateSetting(AutoUpdateEnabledValueName, 1) != 0;
        }

        private static int ReadAutoUpdateIntervalDays()
        {
            int intervalDays = ReadAppUpdateSetting(AutoUpdateIntervalDaysValueName, 1);
            return IsSupportedAutoUpdateInterval(intervalDays) ? intervalDays : 1;
        }

        private static int ReadAppUpdateSetting(string valueName, int defaultValue)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(AppUpdateSettingsRegistryPath))
                {
                    object value = key?.GetValue(valueName);
                    if (value != null && int.TryParse(
                        Convert.ToString(value, CultureInfo.InvariantCulture),
                        NumberStyles.Integer,
                        CultureInfo.InvariantCulture,
                        out int parsedValue))
                        return parsedValue;
                }
            }
            catch (System.Security.SecurityException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }

            return defaultValue;
        }

        private static bool IsSupportedAutoUpdateInterval(int intervalDays)
        {
            return intervalDays == 1 || intervalDays == 3 || intervalDays == 7 ||
                intervalDays == 14 || intervalDays == 30;
        }

        private static void SaveAppUpdatePreferences(bool enabled, int intervalDays)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(AppUpdateSettingsRegistryPath))
            {
                if (key == null)
                    throw new InvalidOperationException("Application update preferences could not be saved.");

                key.SetValue(AutoUpdateEnabledValueName, enabled ? 1 : 0, RegistryValueKind.DWord);
                key.SetValue(AutoUpdateIntervalDaysValueName,
                    IsSupportedAutoUpdateInterval(intervalDays) ? intervalDays : 1,
                    RegistryValueKind.DWord);
            }
        }

        private void ShowWhitespacesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowWhitespaces = (bool)ShowWhitespacesCheckBox.IsChecked;
            Properties.Settings.Default.Save();
            _MainWindow.mainEditor.Options.ShowSpaces = Properties.Settings.Default.ShowWhitespaces;
        }

        private void ShowLineNumbersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowLineNumbers = (bool)ShowLineNumbersCheckBox.IsChecked;
            Properties.Settings.Default.Save();
            _MainWindow.UpdateTextBoxLineNumbers();
        }

        private void HighlightCurrentLineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.HighlightCurrentLine = HighlightCurrentLineCheckBox.IsChecked == true;
            Properties.Settings.Default.Save();
            _MainWindow.UpdateCurrentLineHighlighting();
        }

        private void ShowMatchingBracketsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowMatchingBrackets = ShowMatchingBracketsCheckBox.IsChecked == true;
            Properties.Settings.Default.Save();
            _MainWindow.UpdateBracketHighlighting();
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
            EditorTabSpaceTextBox.Text = Properties.Settings.Default.TabSize.ToString();
            ShowLineNumbersCheckBox.IsChecked = Properties.Settings.Default.ShowLineNumbers;
            ShowWhitespacesCheckBox.IsChecked = Properties.Settings.Default.ShowWhitespaces;
            HighlightCurrentLineCheckBox.IsChecked = Properties.Settings.Default.HighlightCurrentLine;
            ShowMatchingBracketsCheckBox.IsChecked = Properties.Settings.Default.ShowMatchingBrackets;
            int autoSaveInterval = Properties.Settings.Default.AutoSaveIntervalMinutes;
            foreach (ComboBoxItem intervalItem in AutoSaveIntervalComboBox.Items)
            {
                if (int.TryParse(intervalItem.Tag.ToString(), out int intervalMinutes) &&
                    intervalMinutes == autoSaveInterval)
                {
                    AutoSaveIntervalComboBox.SelectedItem = intervalItem;
                    break;
                }
            }
            if (AutoSaveIntervalComboBox.SelectedItem == null)
                AutoSaveIntervalComboBox.SelectedIndex = 0;
            loadingEditorLayoutPreferences = true;
            WordWrapCheckBox.IsChecked = Properties.Settings.Default.WordWrapEnabled;
            double lineSpacing = Properties.Settings.Default.EditorLineSpacing;
            foreach (ComboBoxItem spacingItem in LineSpacingComboBox.Items)
            {
                if (double.TryParse(spacingItem.Tag.ToString(), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double spacing) && spacing == lineSpacing)
                {
                    LineSpacingComboBox.SelectedItem = spacingItem;
                    break;
                }
            }
            if (LineSpacingComboBox.SelectedItem == null)
                LineSpacingComboBox.SelectedIndex = 0;
            loadingEditorLayoutPreferences = false;
            loadingAppUpdatePreferences = true;
            bool autoUpdateEnabled = ReadAutoUpdateEnabled();
            AutoUpdateApplicationCheckBox.IsChecked = autoUpdateEnabled;
            ApplicationUpdateIntervalComboBox.IsEnabled = autoUpdateEnabled;
            int savedIntervalDays = ReadAutoUpdateIntervalDays();
            foreach (ComboBoxItem intervalItem in ApplicationUpdateIntervalComboBox.Items)
            {
                if (int.TryParse(intervalItem.Tag.ToString(), out int intervalDays) &&
                    intervalDays == savedIntervalDays)
                {
                    ApplicationUpdateIntervalComboBox.SelectedItem = intervalItem;
                    break;
                }
            }
            if (ApplicationUpdateIntervalComboBox.SelectedItem == null)
                ApplicationUpdateIntervalComboBox.SelectedIndex = 0;
            loadingAppUpdatePreferences = false;
            UpdateLastExchangeRateDate();
        }

        private void AppUpdatePreferences_Changed(object sender, RoutedEventArgs e)
        {
            if (loadingAppUpdatePreferences)
                return;

            bool autoUpdateEnabled = AutoUpdateApplicationCheckBox.IsChecked == true;
            ApplicationUpdateIntervalComboBox.IsEnabled = autoUpdateEnabled;
            int intervalDays = ReadAutoUpdateIntervalDays();
            if (ApplicationUpdateIntervalComboBox.SelectedItem is ComboBoxItem selectedItem &&
                int.TryParse(selectedItem.Tag.ToString(), out int selectedIntervalDays))
                intervalDays = selectedIntervalDays;

            SaveAppUpdatePreferences(autoUpdateEnabled, intervalDays);
        }

        private void EditorLayoutPreferences_Changed(object sender, RoutedEventArgs e)
        {
            if (loadingEditorLayoutPreferences)
                return;

            Properties.Settings.Default.WordWrapEnabled = WordWrapCheckBox.IsChecked == true;
            if (LineSpacingComboBox.SelectedItem is ComboBoxItem selectedItem &&
                double.TryParse(selectedItem.Tag.ToString(), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double spacing))
                Properties.Settings.Default.EditorLineSpacing = spacing;

            Properties.Settings.Default.Save();
            _MainWindow.ApplyEditorLayoutSettings();
        }

        private void AutoSaveIntervalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AutoSaveIntervalComboBox.SelectedItem is ComboBoxItem selectedItem &&
                int.TryParse(selectedItem.Tag.ToString(), out int intervalMinutes))
            {
                Properties.Settings.Default.AutoSaveIntervalMinutes = intervalMinutes;
                Properties.Settings.Default.Save();
                _MainWindow.UpdateAutoSaveInterval();
            }
        }

        internal void UpdateLastExchangeRateDate()
        {
            DateTime? rateDate = ExchangeRateLoader.GetLastUpdatedDate();
            if (!(FindName("LastExchangeRateUpdateTextBlock") is TextBlock lastUpdatedTextBlock))
                return;

            lastUpdatedTextBlock.Text = rateDate.HasValue
                ? "Rates last updated: " + rateDate.Value.ToString("D", System.Globalization.CultureInfo.CurrentCulture)
                : "Rates last updated: Not available";
        }

        private async void UpdateExchangeRatesButton_Click(object sender, RoutedEventArgs e)
        {
            Button updateButton = (Button)FindName("UpdateExchangeRatesButton");
            TextBlock statusTextBlock = (TextBlock)FindName("ExchangeRateStatusTextBlock");
            updateButton.IsEnabled = false;
            statusTextBlock.Text = "Updating exchange rates…";
            try
            {
                bool updated = await ((App)Application.Current).RefreshExchangeRatesAsync(_MainWindow);
                UpdateLastExchangeRateDate();
                statusTextBlock.Text = updated
                    ? "Exchange rates updated successfully."
                    : "Update failed. Existing rates have been kept.";
            }
            finally
            {
                updateButton.IsEnabled = true;
            }
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

        private void EditorTabSpaceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(EditorTabSpaceTextBox.Text, out int tabSpace) && tabSpace >= 1 && tabSpace <= 8)
            {
                int previousTabSize = Properties.Settings.Default.TabSize;
                Properties.Settings.Default.TabSize = tabSpace;
                Properties.Settings.Default.Save();
                _MainWindow.ApplyEditorTabSpace(previousTabSize, tabSpace);
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

        private void TabSpaceButton_Click(object sender, RoutedEventArgs e)
        {
            int adjustment = ((Button)sender).Name == "DecreaseTabSpaceButton" ? -1 : 1;
            int tabSpace = System.Math.Max(1, System.Math.Min(8, Properties.Settings.Default.TabSize + adjustment));
            EditorTabSpaceTextBox.Text = tabSpace.ToString();
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
