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

            DecimalPlacesTextBox.PreviewTextInput += (sender, e) =>
            {
                if (!new Regex(@"\d+").IsMatch(e.Text))
                    e.Handled = true;
            };

            DecimalPlacesTextBox.TextChanged += DecimalPlacesTextBox_TextChanged;
            DarkModeRadioButton.Checked += DarkModeRadioButtons_CheckedChanged;
            LightModeRadioButton.Checked += DarkModeRadioButtons_CheckedChanged;
            SystemDefinedDarkModeRadioButton.Checked += DarkModeRadioButtons_CheckedChanged;
            DocumentAutorName.TextChanged += DocumentAutorName_TextChanged;
            ShowLineNumbersCheckBox.Checked += ShowLineNumbersCheckBox_Checked;
            ShowLineNumbersCheckBox.Unchecked += ShowLineNumbersCheckBox_Checked;
            this.Loaded += Settings_Loaded;
        }

        private void ShowLineNumbersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowLineNumbers = (bool)ShowLineNumbersCheckBox.IsChecked;
            _MainWindow.UpdateTextBoxLineNumbers();
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
            ShowLineNumbersCheckBox.IsChecked = Properties.Settings.Default.ShowLineNumbers;
        }

        private void DocumentAutorName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DocumentAutorName.Text != "")
                Properties.Settings.Default.UserName = DocumentAutorName.Text;
            Properties.Settings.Default.Save();
        }

        private void DecimalPlacesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DecimalPlacesTextBox.Text != "")
            {
                Properties.Settings.Default.Digits = int.Parse(DecimalPlacesTextBox.Text);
                Properties.Settings.Default.Save();
            }
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
