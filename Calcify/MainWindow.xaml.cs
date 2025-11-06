using Calcify.Math;
using Calcify.Math.Conversion;
using Calcify.Tools;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Xml;

namespace Calcify
{
    public partial class MainWindow : Window
    {
        #region Variables
        #region Pattern
        string AnglePattern = Math.Units.Patterns.AnglePattern;
        string CurrencyPattern = @"\b(EUR|AED|AFN|ALL|AMD|ANG|AOA|ARS|AUD|AWG|AZN|BAM|BBD|BDT|BGN|BHD|BIF|BMD|BND|BOB|BRL|BSD|BTC|BTN|BWP|BYN|BYR|BZD|CAD|CDF|CHF|CLF|CLP|CNY|COP|CRC|CUC|CUP|CVE|CZK|DJF|DKK|DOP|DZD|EGP|ERN|ETB|EUR|FJD|FKP|GBP|GEL|GGP|GHS|GIP|GMD|GNF|GTQ|GYD|HKD|HNL|HRK|HTG|HUF|IDR|ILS|IMP|INR|IQD|IRR|ISK|JEP|JMD|JOD|JPY|KES|KGS|KHR|KMF|KPW|KRW|KWD|KYD|KZT|LAK|LBP|LKR|LRD|LSL|LTL|LVL|LYD|MAD|MDL|MGA|MKD|MMK|MNT|MOP|MRO|MUR|MVR|MWK|MXN|MYR|MZN|NAD|NGN|NIO|NOK|NPR|NZD|OMR|PAB|PEN|PGK|PHP|PKR|PLN|PYG|QAR|RON|RSD|RUB|RWF|SAR|SBD|SCR|SDG|SEK|SGD|SHP|SLL|SOS|SRD|STD|SVC|SYP|SZL|THB|TJS|TMT|TND|TOP|TRY|TTD|TWD|TZS|UAH|UGX|USD|UYU|UZS|VEF|VND|VUV|WST|XAF|XAG|XAU|XCD|XDR|XOF|XPF|YER|ZAR|ZMK|ZMW|ZWL)\b";
        string DataSizePattern = Math.Units.Patterns.DataSizePattern;
        string FrequencyPattern = Math.Units.Patterns.FrequencyPattern;
        string LengthPattern = Math.Units.Patterns.LengthPattern;
        string MassPattern = Math.Units.Patterns.MassPattern;
        string TemperaturePattern = Math.Units.Patterns.TemperaturePattern;
        string TimePattern = Math.Units.Patterns.TimePattern;
        string ConstantsPattern = @"(π|\b(pi|e)\b)";
        #endregion
        #region Regex
        Regex prevRegex = new Regex(@"\b(previous|prev|answer|ans)\b");

        Regex randRegex = new Regex(@"(\brand\(\d+(\.\d+)?, \d+(\.\d+)?\)( |$)|\brandint\(\d+, \d+\)( |$))");
        Regex diffRegex = new Regex(@"\bdiff\(-?\d+(\.\d+)?, -?\d+(\.\d+)?\)( |$)");
        Regex roundRegex = new Regex(@"\bround\(\d+(\.\d+)?, \d+\)( |$)");

        Regex sqrtRegex = new Regex(@"\b(?<func>sqrt)\((?<variable1>(-)?\d+(\.\d+)?)\)(( )?|$)");

        Regex dateTimeKeyWordsRegex = new Regex(@"\b(?i)(now|time|yesterday|date|today|tomorrow)(?-i)\b");
        Regex dateRegex = new Regex(@"^(\d{4}|\d{2})\/(\d{2}|\d)\/(\d{2}|\d)$");
        Regex timeRegex = new Regex(@"^(\d{1,2}:\d{1,2}(:\d{1,2})?)?|\d{1,2}:\d{1,2}(:\d{1,2})$");
        Regex dateTimeRegex = new Regex(@"^(\d{2}(\d{2})?\/\d{1,2}\/\d{1,2}( \d{1,2}:\d{1,2}(:\d{1,2})?)?|\d{1,2}:\d{1,2}(:\d{1,2})?)$");
        Regex dateTimeCalculationRegex = new Regex(@"^(\d{2}(\d{2})?\/\d{1,2}\/\d{1,2}( \d{1,2}:\d{1,2}(:\d{1,2})?)?|\d{1,2}:\d{1,2}(:\d{1,2})?)( (in|add|plus|\+|minus|remove|\-) \d+ (c|yr|mth|wk|d|h|min|s|(?i)(centur(y|ies)|decade(s)?|year(s)?|month(s)?|week(s)?|day(s)?|hour(s)?|minute(s)?|second(s)?)(?-i))|)*$");
        Regex PermutationRegex = new Regex(@"(?<n>\d+)C(?<r>\d+)");
        Regex calculatorRegex = new Regex(@"^((\d+(\.\d+)?)|\||(\+|\-|\*|\/|\^)(?!\+|\*|\/|\^|\!)|(|\(|\)|\!))*$");
        Regex numberRegex = new Regex(@"^\-?\d+(\.\d+)?$");
        Regex numeralFormatRegex = new Regex(@"^(0x[0-9a-fA-F]+|\-?\d+(\.\d+)?)$");
        Regex directBinOctRegex = new Regex(@"^(bin:|oct:)?([0-7]| )+$");
        Regex constantsRegex;
        Regex sumAvgRegex;
        Regex angleRegex;
        Regex frequencyRegex;
        Regex currencyRegex;
        Regex dataSizeRegex;
        Regex lengthRegex;
        Regex temperatureRegex;
        Regex massRegex;
        Regex timeCalculationRegex;
        Regex directRegex;
        Regex directMassRegex;
        Regex directTemperatureRegex;
        Regex directTimeRegex;
        Regex directLengthRegex;
        Regex directDataSizeRegex;
        Regex directFrequencyRegex;
        Regex directAngleRegex;
        #endregion
        #region Document Informations
        public string documentPath = "";
        public string documentText = "";
        public string documentAuthor = "";
        public string documentEditedBy = "";
        public int documentCreated = 0;
        public int documentModified = 0;
        #endregion
        #region RoutedCommand
        public static RoutedCommand CtrlS = new RoutedCommand();
        public static RoutedCommand CtrlShiftS = new RoutedCommand();
        public static RoutedCommand CtrlO = new RoutedCommand();
        public static RoutedCommand CtrlN = new RoutedCommand();
        public static RoutedCommand Esc = new RoutedCommand();
        #endregion
        #region Dictionaries
        Dictionary<string, double> variable = new Dictionary<string, double>();
        Dictionary<string, AngleUnit> angleDict = new Dictionary<string, AngleUnit>();
        Dictionary<string, DataSizeUnit> dataSizeDict = new Dictionary<string, DataSizeUnit>();
        Dictionary<string, FrequencyUnit> frequencyDict = new Dictionary<string, FrequencyUnit>();
        Dictionary<string, LengthUnit> lengthDict = new Dictionary<string, LengthUnit>();
        Dictionary<string, MassUnit> massDict = new Dictionary<string, MassUnit>();
        Dictionary<string, TemperatureUnit> temperatureDict = new Dictionary<string, TemperatureUnit>();
        Dictionary<string, TimeUnit> timeDict = new Dictionary<string, TimeUnit>();
        Dictionary<AngleUnit, string> angleExt = new Dictionary<AngleUnit, string>();
        Dictionary<DataSizeUnit, string> dataSizeExt = new Dictionary<DataSizeUnit, string>();
        Dictionary<FrequencyUnit, string> frequencyExt = new Dictionary<FrequencyUnit, string>();
        Dictionary<LengthUnit, string> lengthExt = new Dictionary<LengthUnit, string>();
        Dictionary<MassUnit, string> massExt = new Dictionary<MassUnit, string>();
        Dictionary<NumeralSystemUnit, string> numeralSystemExt = new Dictionary<NumeralSystemUnit, string>();
        Dictionary<TemperatureUnit, string> temperatureExt = new Dictionary<TemperatureUnit, string>();
        Dictionary<TimeUnit, string> timeExt = new Dictionary<TimeUnit, string>();
        #endregion
        private string oldTotalValue = "";
        private string windowTitle = "";
        private bool unsavedChanges = false;
        // By https://www.frankfurter.app/
        private string exchangeRateLink = "https://api.frankfurter.app/latest";
        private Dictionary<string, double> currencyDict = new Dictionary<string, double>();
        private RegistryWatcher watcher = null;
        private SyntaxFile lightSyntax = new SyntaxFile(SyntaxFile.Theme.Light);
        private SyntaxFile darkSyntax = new SyntaxFile(SyntaxFile.Theme.Dark);

        public int returnState = -1;
        public About aboutWindow = null;
        public DialogWindow dialogWindow = null;
        public Settings settingsWindow = null;

        #endregion
        #region UI
        #region Chrome
        private void SettingsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            oldTotalValue = totalLabel.Content.ToString();
            totalLabel.Content = "Settings";
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (settingsWindow == null)
            {
                settingsWindow = new Settings();
                settingsWindow._MainWindow = this;
                settingsWindow.Show();
            }
            else settingsWindow.Focus();
        }

        private void StartNewButton_MouseEnter(object sender, MouseEventArgs e)
        {
            oldTotalValue = totalLabel.Content.ToString();
            totalLabel.Content = "Start new instance";
        }

        private void StartNewButton_MouseLeave(object sender, RoutedEventArgs e)
        {
            totalLabel.Content = oldTotalValue;
            oldTotalValue = "";
        }

        private void StartNewButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location);
        }



        private void ThemeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            oldTotalValue = totalLabel.Content.ToString();
            totalLabel.Content = "Toggle theme";
        }

        private void ThemeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            totalLabel.Content = oldTotalValue;
            oldTotalValue = "";
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.DarkMode = !Properties.Settings.Default.DarkMode;
        }



        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - (double)e.Delta);
            e.Handled = true;
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            ((ContextMenu)MenuButton.ContextMenu).IsOpen = true;
        }
        #endregion
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MaximizeButtonText.Content = this.WindowState == WindowState.Maximized ? "\uE923" : "\uE922";
            MainGrid.Margin = this.WindowState == WindowState.Maximized ? new Thickness(7) : new Thickness(0);
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (unsavedChanges && (documentPath != "" || mainEditor.Text.Split('\n').Length > 5))
            {
                dialogWindow = new DialogWindow();
                if (this.WindowState != WindowState.Maximized)
                {
                    dialogWindow.Top = this.Top + (this.Height / 2) - 90;
                    dialogWindow.Left = this.Left + (this.Width / 2) - 200;
                }
                else
                    dialogWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                returnState = 0;

                dialogWindow.mWindow = this;

                dialogWindow.ShowDialog();
                if (dialogWindow.returnState == 2)
                {
                    App.Current.Shutdown();
                }
                else if (dialogWindow.returnState == 3)
                {
                    if (documentPath != "")
                    {
                        saveFile(documentPath);
                        App.Current.Shutdown();
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.Calcify)|*.Calcify|All Files (*.*)|*.*", FileName = "" };
                        if (saveFileDialog.ShowDialog() == true)
                        {
                            saveFile(saveFileDialog.FileName);
                            App.Current.Shutdown();
                        }
                    }
                }
                dialogWindow = null;
            }
            else
            {
                App.Current.Shutdown();
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            // Set up the basics
            if (Properties.Settings.Default.UserName == "")
                Properties.Settings.Default.UserName = Environment.UserName;

            if (Properties.Settings.Default.FirstStart || Properties.Settings.Default.SystemDefinedDarkMode)
                Properties.Settings.Default.FirstStart = false;

            // A Registry Watcher (RW) to trigger the Dark Mode
            watcher = new RegistryWatcher("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme");
            watcher.ValueChanged += Watcher_ValueChanged;


            // Start the RW if it is allowed by the user
            if (Properties.Settings.Default.SystemDefinedDarkMode == true)
            {
                watcher.Start();
                Properties.Settings.Default.DarkMode = int.Parse(watcher.Value) != 1;
            }

            setUpDictionaries();
            UpdateSyntaxHighlighting();

            #region Event Handler
            Properties.Settings.Default.SettingChanging += Settings_SettingChanging;
            this.Loaded += MainWindow_Loaded;
            this.SizeChanged += MainWindow_SizeChanged;
            this.DragEnter += Window_DragEvent;
            this.DragLeave += Window_DragEvent;
            this.Drop += Window_DragEvent;

            mainEditor.TextChanged += mainEditor_TextChanged;
            mainEditor.TextArea.Caret.PositionChanged += Caret_PositionChanged;

            MinimizeButton.Click += MinimizeButton_Click;
            MaximizeButton.Click += MaximizeButton_Click;
            closeButton.Click += CloseButton_Click;

            StartNewButton.Click += StartNewButton_Click;
            StartNewButton.MouseEnter += StartNewButton_MouseEnter;
            StartNewButton.MouseLeave += StartNewButton_MouseLeave;

            themeButton.Click += ThemeButton_Click;
            themeButton.MouseEnter += ThemeButton_MouseEnter;
            themeButton.MouseLeave += ThemeButton_MouseLeave;

            settingsButton.Click += SettingsButton_Click;
            settingsButton.MouseEnter += SettingsButton_MouseEnter;
            settingsButton.MouseLeave += StartNewButton_MouseLeave;

            MenuButton.Click += Menu_Click;

            contextNewFileButton.Click += contextNewFileButton_Click;
            contextOpenButton.Click += contextOpenButton_Click;
            contextSaveButton.Click += contextSaveButton_Click;
            contextSaveAsButton.Click += contextSaveButton_Click;
            contextAboutButton.Click += contextAboutButton_Click;
            contextSettingsButton.Click += SettingsButton_Click;
            contextExitButton.Click += CloseButton_Click;
            #endregion
            #region Input Bindings
            CtrlS.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            CtrlShiftS.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift));
            CtrlO.InputGestures.Add(new KeyGesture(Key.O, ModifierKeys.Control));
            CtrlN.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
            Esc.InputGestures.Add(new KeyGesture(Key.Escape));
            #endregion
            #region RegexSettings 
            constantsRegex = new Regex(ConstantsPattern);
            sumAvgRegex = new Regex(@"\b(avg|sum)\b");
            angleRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + AnglePattern + ") (in(to)?|to|as) (?<targetUnit>" + AnglePattern + ")$");
            frequencyRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + FrequencyPattern + ") (in(to)?|to|as) (?<targetUnit>" + FrequencyPattern + ")$");
            currencyRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + CurrencyPattern + ") (in(to)?|to|as) (?<targetUnit>" + CurrencyPattern + ")$");
            dataSizeRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + DataSizePattern + ") (in(to)?|to|as) (?<targetUnit>" + DataSizePattern + ")$");
            lengthRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + LengthPattern + ") (in(to)?|to|as) (?<targetUnit>" + LengthPattern + ")$");
            massRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + MassPattern + ") (in(to)?|to|as) (?<targetUnit>" + MassPattern + ")$");
            temperatureRegex = new Regex(@"^\-?\d+(\.\d+)? " + TemperaturePattern + " (in(to)?|to|as) " + TemperaturePattern + "$");
            timeCalculationRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + TimePattern + ") (in(to)?|to|as) (?<targetUnit>" + TimePattern + ")$");
            directRegex = new Regex(@"^\-?\d+(\.\d+)? (" + CurrencyPattern + ")$");
            directTemperatureRegex = new Regex(@"^\-?\d+(\.\d+)? (" + TemperaturePattern + ")$");
            directMassRegex = new Regex(@"^\-?\d+(\.\d+)? " + MassPattern + "$");
            directTimeRegex = new Regex(@"^\-?\d+(\.\d+)? " + TimePattern + "$");
            directLengthRegex = new Regex(@"^\-?\d+(\.\d+)? " + LengthPattern + "$");
            directFrequencyRegex = new Regex(@"^\-?\d+(\.\d+)? " + FrequencyPattern + "$");
            directDataSizeRegex = new Regex(@"^\-?\d+(\.\d+)? " + DataSizePattern + "$");
            directAngleRegex = new Regex(@"^\-?\d+(\.\d+)? " + AnglePattern + "$");
            #endregion

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            DropPanel.Visibility = Visibility.Visible;
            resultEditor.TextArea.Caret.CaretBrush = Brushes.Transparent;
            Info.ToolTip = new ToolTip();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Load the font from resources
            using (Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Calcify.Fonts.RobotoMono-Regular.ttf"))
            {
                FontFamily[] f = new FontFamily[Fonts.GetFontFamilies(new Uri("pack://application:,,,/Fonts/RobotoMono-Regular.ttf")).Count];
                Fonts.GetFontFamilies(new Uri("pack://application:,,,/Fonts/RobotoMono-Regular.ttf")).CopyTo(f, 0);
                mainEditor.FontFamily = f[0];
                resultEditor.FontFamily = f[0];
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(Properties.Settings.Default.DarkMode ? darkSyntax.Content : lightSyntax.Content);
            MemoryStream stream = new MemoryStream(byteArray);

            using (Stream s = stream)
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    mainEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }

            themeButtonLabel.Content = Properties.Settings.Default.DarkMode ? "\uE708" : "\uE706";
        }

        private void Watcher_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DarkMode = watcher.Value != "1";
        }

        private void Settings_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            switch (e.SettingName)
            {
                case "DarkMode":
                    DarkModeChanged((bool)e.NewValue);
                    themeButtonLabel.Content = (bool)e.NewValue ? "\uE708" : "\uE706";
                    break;
                case "SystemDefinedDarkMode":
                    if ((bool)e.NewValue == true)
                    {
                        watcher.Start();
                        Properties.Settings.Default.DarkMode = int.Parse(watcher.Value) != 1;
                    }
                    else
                        if (watcher.IsEnabled) watcher.Stop();
                    break;
            }

        }

        private void mainEditor_TextChanged(object sender, EventArgs e)
        {
            TextDocument newDocument = new TextDocument();
            unsavedChanges = documentText != mainEditor.Text;

            for (int i = 1; i <= mainEditor.LineCount; i++)
            {
                string result = "";
                DocumentLine line = mainEditor.Document.GetLineByNumber(i);
                result = Calculate(line, newDocument);
                Console.WriteLine(Calc(mainEditor.Document.GetText(line.Offset, line.Length)));
                newDocument.Text = newDocument.Text + result + '\n';
            }
            resultEditor.Document = newDocument;
        }

        private void Caret_PositionChanged(object sender, EventArgs e)
        {
            // Keep the caret line in the viewport
            double actualLineNumber = mainEditor.Document.GetLineByOffset(mainEditor.CaretOffset).LineNumber - 1;
            double defaultLineHeight = mainEditor.TextArea.TextView.DefaultLineHeight;
            double ScrollViewerHeight = EditorContainer.ViewportHeight;
            double VerticalOffset = EditorContainer.VerticalOffset;
            double CalculatedOffset = actualLineNumber * defaultLineHeight;
            double secOffset = actualLineNumber * defaultLineHeight;
            secOffset = (VerticalOffset - secOffset) * -1;
            CalculatedOffset = (VerticalOffset + ScrollViewerHeight - defaultLineHeight - CalculatedOffset) * -1;
            if (secOffset < 0)
                EditorContainer.ScrollToVerticalOffset(VerticalOffset + secOffset);
            else if (CalculatedOffset > 0)
                EditorContainer.ScrollToVerticalOffset(VerticalOffset + CalculatedOffset);
            CalculateTotal();
        }

        #region Functions
        #region Exchange Rate
        /// <summary>
        /// Downloads the current exchange rate of the day
        /// </summary>
        /// <returns>Returns success as bool.</returns>
        public bool DownloadExchangeRate()
        {
            InternetConnectionState_e flags = 0;
            bool isConnected = InternetGetConnectedState(ref flags, 0);
            if (isConnected)
            {
                try
                {
                    string downloadedContent;
                    WebClient webClient = new WebClient();
                    downloadedContent = webClient.DownloadString(exchangeRateLink);
                    File.WriteAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "exchangerate.json"), downloadedContent);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// Loads the exchange rate
        /// </summary>
        public void LoadExchangeRate()
        {
            // Creates an dictionary that contains the ISO-4217 codes and the exchange rate to USD
            Dictionary<string, double> newCurrencyDict = new Dictionary<string, double>();
            if (File.Exists(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "exchangerate.json")))
            {
                JObject exchangerate = JObject.Parse(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "exchangerate.json")));
                foreach (JProperty child in exchangerate["rates"].Children())
                {
                    newCurrencyDict.Add(child.Name, double.Parse(child.Value.ToString()));
                }
                currencyDict = newCurrencyDict;
                CurrencyPattern = "(EUR|" + string.Join("|", currencyDict.Keys) + ")";

                // Re-create currency regex with updated pattern
                currencyRegex = new Regex(@"^\-?\d+(\.\d+)? " + CurrencyPattern + " (in(to)?|to|as) " + CurrencyPattern + "$");
                UpdateSyntaxHighlighting();
            }
        }
        #endregion
        #region Open & Save File
        /// <summary>
        /// Open a file
        /// </summary>
        /// <param name="path"></param>
        public void openFile(string path)
        {
            bool actionAllowed = false;
            if (unsavedChanges)
            {
                dialogWindow = new DialogWindow();

                // Calculate the position of the Dialog Window (DW) based on
                // the window state of the main frame.
                if (this.WindowState != WindowState.Maximized)
                {
                    dialogWindow.Top = this.Top + (this.Height / 2) - 90;
                    dialogWindow.Left = this.Left + (this.Width / 2) - 200;
                }
                else
                    dialogWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                returnState = 0;

                // Set the main window for the DW to the main frame
                dialogWindow.mWindow = this;
                // Show the DW
                dialogWindow.ShowDialog();

                // Get the return state from the DW
                // 1 = Cancel
                // 2 = Do not save
                // 3 = Save
                if (dialogWindow.returnState == 2)
                {
                    // Allow to proceed without saving
                    actionAllowed = true;
                }
                else if (dialogWindow.returnState == 3)
                {
                    // Save the file and proceed
                    // Check if the file has already a path or if it is needed to
                    // create a new file.
                    if (documentPath != "")
                    {
                        saveFile(documentPath);
                        actionAllowed = true;
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.Calcify)|*.Calcify|All Files (*.*)|*.*", FileName = "" };
                        if (saveFileDialog.ShowDialog() == true)
                        {
                            saveFile(saveFileDialog.FileName);
                            actionAllowed = true;
                        }
                    }
                }
                dialogWindow = null;
            }
            else
            {
                // Allow to open a file without saving
                actionAllowed = true;
            }

            // Proceed if the DW returned the permission to open a file
            if (actionAllowed)
            {
                documentPath = path;

                string[] lines = File.ReadAllLines(path);

                // Check if the header is empty
                if (lines.Length != 0)
                {
                    // Load the meta tags from the header
                    string[] meta = lines[0].Substring(1, lines[0].Length - 2).Split(',');
                    documentAuthor = meta[0].Split('=')[1];
                    documentEditedBy = meta[1].Split('=')[1];
                    documentCreated = int.Parse(meta[2].Split('=')[1]);
                    documentModified = int.Parse(meta[3].Split('=')[1]);

                    string joinedText = string.Join("\n", lines.Skip(1).ToArray());
                    documentText = joinedText;
                    mainEditor.Text = joinedText;
                }
                else
                {
                    // 
                    documentText = "";
                    mainEditor.Text = "";
                    documentAuthor = Properties.Settings.Default.UserName;
                    documentEditedBy = Properties.Settings.Default.UserName;
                    documentCreated = (int)Calculator.DateTimeToUnixTimeStamp(File.GetCreationTime(path));
                    documentModified = documentCreated;
                    string header = "[AUTHOR=" + Properties.Settings.Default.UserName + ",MODIFIED_BY=" + Properties.Settings.Default.UserName + ",CREATED=" + documentCreated + ",MODIFIED=" + documentModified + "]";
                    File.WriteAllText(path, header);
                }

                DocumentChanged();

                mainEditor.CaretOffset = 0;
                EditorContainer.ScrollToTop();
                mainEditor.Focus();
            }
        }

        /// <summary>
        /// Save the file to a given path
        /// </summary>
        /// <param name="path"></param>
        public void saveFile(string path)
        {
            // Save file with given meta tags
            string dAuthor = documentAuthor != "" ? documentAuthor : Properties.Settings.Default.UserName;
            int dCreated = documentCreated != 0 ? documentCreated : (int)Calculator.DateTimeToUnixTimeStamp(DateTime.UtcNow);
            int dModified = (int)Calculator.DateTimeToUnixTimeStamp(DateTime.UtcNow);
            string header = "[AUTHOR=" + dAuthor + ",MODIFIED_BY=" + Properties.Settings.Default.UserName + ",CREATED=" + dCreated + ",MODIFIED=" + dModified + "]";
            string fileContent = header + "\n" + mainEditor.Text;
            documentAuthor = dAuthor;
            documentEditedBy = Properties.Settings.Default.UserName;
            documentCreated = dCreated;
            documentModified = dModified;
            documentPath = path;
            documentText = String.Join("\n", fileContent.Split('\n').Skip(1).ToArray());
            unsavedChanges = false;
            File.WriteAllText(path, fileContent);
            DocumentChanged();
        }

        /// <summary>
        /// Change meta tags in the tooltip
        /// </summary>
        public void DocumentChanged()
        {
            if (documentPath == "")
                Info.IsEnabled = false;
            else
            {
                Info.IsEnabled = true;
                ((ToolTip)Info.ToolTip).Content = "Author: " + documentAuthor + "\nLast edited by: " + documentEditedBy + "\nCreated: " + Calculator.UnixTimeStampToDateTime(documentCreated).ToString() + "\nModified: " + Calculator.UnixTimeStampToDateTime(documentModified).ToString() + "\nPath: " + Path.GetDirectoryName(documentPath);
                if (Properties.Settings.Default.DarkMode)
                {
                    ((ToolTip)Info.ToolTip).Background = new SolidColorBrush { Color = Color.FromRgb(37, 38, 43) };
                    ((ToolTip)Info.ToolTip).Foreground = new SolidColorBrush { Color = Color.FromRgb(180, 180, 180) };
                }
                else
                {
                    ((ToolTip)Info.ToolTip).Background = new SolidColorBrush { Color = Color.FromRgb(241, 242, 247) };
                    ((ToolTip)Info.ToolTip).Foreground = new SolidColorBrush { Color = Color.FromRgb(0, 0, 0) };
                }
            }

            windowTitle = "Calcify";

            string text = mainEditor.Document.GetText(0, mainEditor.Document.GetLineByNumber(1).Length);
            if (mainEditor.Document.GetText(0, mainEditor.Document.GetLineByNumber(1).Length).StartsWith("# "))
            {
                text = text.Substring(2).Trim();
                if (text != "" && text.Replace(" ", "") != "")
                {
                    windowTitle = windowTitle + " - " + text;
                    this.Title = windowTitle + (documentText == mainEditor.Text ? "" : "  ●");
                    titleLabel.Content = windowTitle + (documentText == mainEditor.Text ? "" : "  ●");
                }
                else
                {
                    this.Title = windowTitle + (documentText == mainEditor.Text ? "" : "  ●");
                    titleLabel.Content = windowTitle + (documentText == mainEditor.Text ? "" : "  ●");
                }
            }
            else
            {
                this.Title = windowTitle + (documentText == mainEditor.Text ? "" : "  ●");
                titleLabel.Content = windowTitle + (documentText == mainEditor.Text ? "" : "  ●");
            }
        }

        /// <summary>
        /// Open a new file and reset the meta tags
        /// </summary>
        public void NewDocument()
        {
            mainEditor.Text = "";
            documentPath = "";
            documentText = "";
            documentAuthor = "";
            documentCreated = 0;
            documentModified = 0;
            DocumentChanged();
        }
        #endregion
        #region Check Internet Connection State
        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        private extern static bool InternetGetConnectedState(ref InternetConnectionState_e lpdwFlags, int dwReserved);

        [Flags]
        enum InternetConnectionState_e : int
        {
            INTERNET_CONNECTION_MODEM = 0x1,
            INTERNET_CONNECTION_LAN = 0x2,
            INTERNET_CONNECTION_PROXY = 0x4,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }
        #endregion

        /// <summary>
        /// (De)activate the dark mode
        /// </summary>
        /// <param name="newValue"></param>
        private void DarkModeChanged(bool newValue)
        {
            ((ToolTip)Info.ToolTip).Background = new SolidColorBrush { Color = (newValue ? Color.FromRgb(37, 38, 43) : Color.FromRgb(241, 242, 247)) };
            ((ToolTip)Info.ToolTip).Foreground = new SolidColorBrush { Color = (newValue ? Color.FromRgb(180, 180, 180) : Color.FromRgb(0, 0, 0)) };
            byte[] byteArray = Encoding.UTF8.GetBytes(newValue ? darkSyntax.Content : lightSyntax.Content);
            MemoryStream stream = new MemoryStream(byteArray);

            using (Stream s = stream)
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    mainEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
        }

        /// <summary>
        /// Return a random number with decimals
        /// </summary>
        /// <param name="minimum">Minimum value</param>
        /// <param name="maximum">Maximum value</param>
        /// <returns></returns>
        public double GetRandomDouble(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private void CalculateTotal()
        {
            int summedLines;
            int currentLineNumber = mainEditor.Document.GetLineByOffset(mainEditor.CaretOffset).LineNumber + 1;
            string s = CalculateSum(currentLineNumber, resultEditor.Document, out summedLines);
            if (summedLines != 0)
                totalLabel.Content = "Total: " + s;
            else
                totalLabel.Content = "";

        }

        private string Calc(string input, bool acceptPrevious = true)
        {
            string originalInput = input;

            // Comment line
            if (input.StartsWith("#"))
                return "";

            // Remove comments at the end of the line
            if (input.Contains("#"))
                input = input.Substring(0, input.IndexOf("#")).Trim();

            // Remove double spaces
            while (input.Contains("  "))
                input = input.Replace("  ", " ");

            // Find and replace 'prev', 'previous', 'ans', 'answer', 'last' with the parser keyword for the last result
            if (acceptPrevious)
                input = prevRegex.Replace(input, "{/last/}");

            // Replace all permutation expressions in the input
            input = ReplacePermutations(input);

            // Replace constants
            input = ReplaceConstants(input);

            // Replace Functions
            input = ReplaceTwoVariableFunctions(input);
            input = ReplaceOneVariableFunctions(input);

            // Replace DateTime variables
            input = DateTimeCalculation(input);

            if (acceptPrevious)
                foreach (Match match in sumAvgRegex.Matches(input))
                    input = input.Replace(match.Value, "{/" + match.Value + "/}");

            // Execute Angle Conversion
            input = AngleCalculation(input);

            // Execute Frequency Conversion
            input = FrequencyCalculation(input);

            // Execute Currency Conversion
            input = CurrencyConversion(input);

            // Execute DataSize Conversion
            input = DataSizeConversion(input);

            // Execute Length Conversion
            input = LengthConversion(input);

            // Execute Mass Conversion
            input = MassConversion(input);

            // Execute Temperature Conversion
            input = TemperatureConversion(input);

            // Execute Calculation
            input = parseCalculation(input);

            return input;
        }

        /// <summary>
        /// Replaces all permutation expressions in the specified text with their calculated values.
        /// </summary>
        /// <remarks>Permutation expressions are expected to be in the form 'nCr', where n and r are
        /// integers and n is greater than or equal to r. Only valid expressions are replaced; invalid or malformed
        /// expressions are ignored.</remarks>
        /// <param name="text">The input string containing permutation expressions in the format 'nCr', where n and r are integers.</param>
        /// <returns>A string in which all valid permutation expressions have been replaced with their computed results. If no
        /// valid expressions are found, the original text is returned unchanged.</returns>
        private string ReplacePermutations(string text)
        {
            // Materialize matches first to avoid modifying the input while iterating.
            var matches = PermutationRegex.Matches(text).Cast<Match>().ToArray();
            foreach (var match in matches)
            {
                if (!int.TryParse(match.Groups["n"].Value, out int n)) continue;
                if (!int.TryParse(match.Groups["r"].Value, out int r)) continue;

                if (n >= r)
                    text = text.Replace(match.Value, Functions.nCr(n, r).ToString());
            }
            return text;
        }

        /// <summary>
        /// Replaces recognized mathematical constant names in the specified text with their numeric values, rounded to
        /// the configured number of digits.
        /// </summary>
        /// <remarks>The numeric values for constants are rounded according to the application's digit
        /// settings. Only the first occurrence of each constant is replaced per iteration.</remarks>
        /// <param name="text">The input string containing mathematical constant names to be replaced. Supported constants are "pi", "π",
        /// and "e".</param>
        /// <returns>A string in which all supported constant names have been replaced with their corresponding numeric values.</returns>
        private string ReplaceConstants(string text)
        {
            foreach (Match match in constantsRegex.Matches(text))
            {
                if (match.Value == "pi" || match.Value == "π")
                    text = constantsRegex.Replace(text, ToNumberString(System.Math.Round(System.Math.PI, Properties.Settings.Default.Digits)), 1);
                else if (match.Value == "e")
                    text = constantsRegex.Replace(text, ToNumberString(System.Math.Round(System.Math.E, Properties.Settings.Default.Digits)), 1);
            }
            return text;
        }

        /// <summary>
        /// Replaces all recognized single-variable mathematical function expressions in the input string with their
        /// computed numeric results.
        /// </summary>
        /// <remarks>Currently supports replacement of square root expressions in the form 'sqrt(number)'.
        /// Only positive numbers are evaluated; other values are ignored. The numeric result is rounded according to
        /// the application's digit settings before replacement.</remarks>
        /// <param name="input">The input string containing mathematical function expressions to be evaluated and replaced.</param>
        /// <returns>A string in which each recognized single-variable function expression has been replaced by its calculated
        /// value. If no such expressions are found, the original input string is returned unchanged.</returns>
        private string ReplaceOneVariableFunctions(string input)
        {
            MatchCollection matches = sqrtRegex.Matches(input);
            foreach (Match match in matches)
            {
                double extractedNumber;
                string function = match.Groups["func"].Value;
                switch (function)
                {
                    case "sqrt":
                        extractedNumber = double.Parse(match.Groups["variable1"].Value, CultureInfo.InvariantCulture);
                        if (extractedNumber > 0)
                        {
                            double value = System.Math.Sqrt(extractedNumber);
                            input = input.Replace(match.Value, ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)));
                        }
                        break;
                }
            }
            return input;
        }

        /// <summary>
        /// Replaces supported two-variable function expressions in the input string with their computed results.
        /// </summary>
        /// <remarks>Supported functions include diff(min, max), rand(min, max), randint(min, max), and
        /// round(value, digits). Each function must follow the format 'functionName(number1, number2)'. If min is
        /// greater than max for diff, rand, or randint, the values are swapped automatically (except for round). The
        /// number of decimal digits in results is determined by application settings.</remarks>
        /// <param name="input">The input string containing function expressions such as diff, rand, randint, or round, each with two
        /// numeric arguments.</param>
        /// <returns>A string in which all recognized two-variable function expressions have been replaced by their evaluated
        /// numeric results.</returns>
        private string ReplaceTwoVariableFunctions(string input)
        {
            MatchCollection matches;

            Regex functionsRegex = new Regex(@"\b(?<func>(diff|rand|randint|round))\((?<variable1>-?\d+(\.\d+)?), ?(?<variable2>-?\d+(\.\d+)?)\)");
            // Replace and execute functions
            matches = functionsRegex.Matches(input);
            foreach (Match match in matches)
            {
                string function = match.Groups["func"].Value;
                double minNumber = double.Parse(match.Groups["variable1"].Value, CultureInfo.InvariantCulture);
                double maxNumber = double.Parse(match.Groups["variable2"].Value, CultureInfo.InvariantCulture);

                // Swap if min is greater than max
                if (minNumber > maxNumber && function != "round")
                {
                    double temp = minNumber;
                    minNumber = maxNumber;
                    maxNumber = temp;
                }


                double generatedNumber = 0;
                switch (function)
                {
                    // Calculate difference
                    case "diff":
                        generatedNumber = maxNumber - minNumber;
                        generatedNumber = System.Math.Round(generatedNumber, Properties.Settings.Default.Digits);
                        input = input.Replace(match.Value, ToNumberString(System.Math.Round(generatedNumber, Properties.Settings.Default.Digits)) + " ");
                        break;
                    // Generate random double
                    case "rand":
                        generatedNumber = GetRandomDouble(minNumber, maxNumber);
                        generatedNumber = System.Math.Round(generatedNumber, Properties.Settings.Default.Digits);
                        input = input.Replace(match.Value, ToNumberString(System.Math.Round(generatedNumber, Properties.Settings.Default.Digits)) + " ");
                        break;
                    // Generate random integer
                    case "randint":
                        generatedNumber = new Random().Next((int)minNumber, (int)maxNumber);
                        input = input.Replace(match.Value, ToNumberString(generatedNumber) + " ").Trim();
                        break;
                    // Round number
                    case "round":
                        generatedNumber = System.Math.Round(minNumber, (int)maxNumber);
                        input = input.Replace(match.Value, ToNumberString(generatedNumber) + " ").Trim();
                        break;
                }
            }



            return input;
        }

        /// <summary>
        /// Replaces recognized date and time keywords in the specified input string with their corresponding formatted
        /// date or time values.
        /// </summary>
        /// <remarks>The formatting of the replacement values depends on application settings. For
        /// example, if the "showDateTime" setting is enabled, both date and time are included for certain keywords.
        /// Only keywords explicitly recognized by the method are replaced.</remarks>
        /// <param name="input">The input string to process. May contain keywords such as "now", "today", "yesterday", or "tomorrow" that
        /// will be replaced with formatted date or time values.</param>
        /// <returns>A string with all recognized date and time keywords replaced by their corresponding formatted values. If no
        /// keywords are found, returns an empty string.</returns>
        private string DateTimeCalculation(string input)
        {
            // Replace keywords first (now, today, yesterday, tomorrow, etc.)
            DateTime dateTime = DateTime.Now;
            string timeString = "";
            MatchCollection matches = dateTimeKeyWordsRegex.Matches(input);
            foreach (Match match in matches.Cast<Match>().ToArray())
            {
                switch (match.Value.ToLower())
                {
                    case "now":
                    case "time":
                        if (Properties.Settings.Default.showDateTime)
                            timeString = dateTime.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                        else
                            timeString = dateTime.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
                        break;

                    case "now.hour":
                    case "time.hour":
                        timeString = dateTime.ToString("HH", CultureInfo.InvariantCulture);
                        break;
                    case "now.minute":
                    case "time.minute":
                        timeString = dateTime.ToString("mm", CultureInfo.InvariantCulture);
                        break;
                    case "now.second":
                    case "time.second":
                        timeString = dateTime.ToString("ss", CultureInfo.InvariantCulture);
                        break;

                    case "today":
                    case "date":
                        timeString = dateTime.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        break;

                    case "today.day":
                    case "date.day":
                        timeString = dateTime.ToString("dd", CultureInfo.InvariantCulture);
                        break;
                    case "today.month":
                    case "date.month":
                        timeString = dateTime.ToString("MM", CultureInfo.InvariantCulture);
                        break;
                    case "today.year":
                    case "date.year":
                        timeString = dateTime.ToString("yyyy", CultureInfo.InvariantCulture);
                        break;
                    case "today.weekday":
                    case "date.weekday":
                        timeString = dateTime.ToString("dddd", CultureInfo.InvariantCulture);
                        break;
                    case "today.dayofyear":
                    case "date.dayofyear":
                        timeString = dateTime.DayOfYear.ToString("D3", CultureInfo.InvariantCulture);
                        break;
                    case "today.weekofyear":
                    case "date.weekofyear":
                        timeString = dateTime.Month.ToString("00", CultureInfo.InvariantCulture);
                        break;

                    case "yesterday":
                    case "tomorrow":
                        timeString = dateTime
                            .AddDays(match.Value.ToLower() == "yesterday" ? -1 : 1)
                            .ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        break;

                    case "yesterday.day":
                    case "tomorrow.day":
                        timeString = dateTime
                            .AddDays(match.Value.ToLower().StartsWith("yesterday") ? -1 : 1)
                            .ToString("dd", CultureInfo.InvariantCulture);
                        break;
                    case "yesterday.month":
                    case "tomorrow.month":
                        timeString = dateTime
                            .AddDays(match.Value.ToLower().StartsWith("yesterday") ? -1 : 1)
                            .ToString("MM", CultureInfo.InvariantCulture);
                        break;
                    case "yesterday.year":
                    case "tomorrow.year":
                        timeString = dateTime
                            .AddDays(match.Value.ToLower().StartsWith("yesterday") ? -1 : 1)
                            .ToString("yyyy", CultureInfo.InvariantCulture);
                        break;
                    case "yesterday.weekday":
                    case "tomorrow.weekday":
                        timeString = dateTime
                            .AddDays(match.Value.ToLower().StartsWith("yesterday") ? -1 : 1)
                            .ToString("dddd", CultureInfo.InvariantCulture);
                        break;
                    case "yesterday.dayofyear":
                    case "tomorrow.dayofyear":
                        timeString = dateTime
                            .AddDays(match.Value.ToLower().StartsWith("yesterday") ? -1 : 1)
                            .DayOfYear
                            .ToString("D3", CultureInfo.InvariantCulture);
                        break;
                    case "yesterday.weekofyear":
                    case "tomorrow.weekofyear":
                        timeString = dateTime
                            .AddDays(match.Value.ToLower()
                            .StartsWith("yesterday") ? -1 : 1)
                            .Month
                            .ToString("00", CultureInfo.InvariantCulture);
                        break;
                }

                input = Regex.Replace(input, @"\b(?i)" + Regex.Escape(match.Value.ToLower()) + @"(?-i)\b", timeString);
            }

            // Support simple time arithmetic:
            // - "HH:mm(:ss)? (+|add|plus) HH:mm(:ss)?"
            // - "HH:mm(:ss)? (-|minus) HH:mm(:ss)?" (difference -> duration)
            // - "datetime (+|-) duration" (duration can be "HH:mm", or "N h/min/s")
            // - "(now|today|date|... ) (+|-) duration"
            var timeOpRegex = new Regex(@"(?<left>(?:\d{1,2}:\d{2}(?::\d{2})?|\d{4}\/\d{1,2}\/\d{1,2}(?: \d{1,2}:\d{2}(?::\d{2})?)?))\s*(?<op>\+|\-|add|plus|minus)\s*(?<right>(?:\d{1,2}:\d{2}(?::\d{2})?|\d+\s*(?:h(r|our(s)?)?|min(ute(s)?)?|s(ec(ond(s)?)?)?)))");

            while (timeOpRegex.IsMatch(input))
            {
                Match m = timeOpRegex.Match(input);
                string leftRaw = m.Groups["left"].Value;
                string opRaw = m.Groups["op"].Value.ToLower();
                string rightRaw = m.Groups["right"].Value;

                bool opIsAdd = opRaw == "+" || opRaw == "add" || opRaw == "plus";
                bool opIsSub = opRaw == "-" || opRaw == "minus";

                // Try parse left as DateTime (date or time-only)
                bool leftIsDateTime = DateTime.TryParse(leftRaw, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime leftDt);
                // Try parse right as time-of-day (HH:mm[:ss])
                TimeSpan rightSpan = TimeSpan.Zero;
                bool rightIsTimeOfDay = TimeSpan.TryParse(rightRaw, CultureInfo.InvariantCulture, out rightSpan);
                if (!rightIsTimeOfDay)
                {
                    // Try parse as "N h/min/s"
                    var unitMatch = Regex.Match(rightRaw.Trim(), @"(?<num>\d+)\s*(?<unit>h|hr|hour|hours|m|min|minute|minutes|s|sec|second|seconds)", RegexOptions.IgnoreCase);
                    if (unitMatch.Success)
                    {
                        int num = int.Parse(unitMatch.Groups["num"].Value);
                        string unit = unitMatch.Groups["unit"].Value.ToLower();
                        switch (unit)
                        {
                            case "h":
                            case "hr":
                            case "hour":
                            case "hours":
                                rightSpan = TimeSpan.FromHours(num);
                                rightRaw = rightSpan.ToString(@"hh\:mm\:ss");
                                break;
                            case "m":
                            case "min":
                            case "minute":
                            case "minutes":
                                rightSpan = TimeSpan.FromMinutes(num);
                                rightRaw = rightSpan.ToString(@"hh\:mm\:ss");
                                break;
                            default:
                                rightSpan = TimeSpan.FromSeconds(num);
                                rightRaw = rightSpan.ToString(@"hh\:mm\:ss");
                                break;
                        }
                    }
                }

                string replacement = null;

                if (leftIsDateTime)
                {
                    // If right is a time-of-day and left is date/time, interpret right as TimeSpan
                    if (!rightIsTimeOfDay && rightRaw.Contains(":"))
                    {
                        rightIsTimeOfDay = TimeSpan.TryParse(rightRaw, CultureInfo.InvariantCulture, out rightSpan);
                    }

                    if (rightIsTimeOfDay)
                    {
                        DateTime resultDt = opIsAdd ? leftDt.Add(rightSpan) : leftDt.Subtract(rightSpan);
                        // Preserve format: if left included date and time -> full datetime, if only date -> date, if only time -> time
                        if (leftRaw.Contains("/") && leftRaw.Contains(":"))
                            replacement = resultDt.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                        else if (leftRaw.Contains("/"))
                            replacement = resultDt.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        else
                        {
                            replacement = resultDt.ToString(rightSpan.Seconds != 0 ? "HH:mm:ss" : "HH:mm", CultureInfo.InvariantCulture);
                        }
                    }
                }
                else
                {
                    // left is time-only or couldn't be parsed as DateTime, attempt TimeSpan parsing
                    bool leftIsTimeSpan = TimeSpan.TryParse(leftRaw, CultureInfo.InvariantCulture, out TimeSpan leftSpan);
                    if (leftIsTimeSpan && (rightSpan != TimeSpan.Zero || rightIsTimeOfDay))
                    {
                        if (opIsSub && rightIsTimeOfDay && !rightRaw.Contains("h") && !rightRaw.Contains("m") && !rightRaw.Contains("s"))
                        {
                            // Interpret both as time-of-day and return difference (duration)
                            TimeSpan diff = leftSpan - rightSpan;
                            if (diff < TimeSpan.Zero) diff = diff.Negate();
                            replacement = diff.ToString(diff.Seconds != 0 ? @"hh\:mm\:ss" : @"hh\:mm");
                        }
                        else
                        {
                            TimeSpan resultSpan = opIsAdd ? leftSpan.Add(rightSpan) : leftSpan.Subtract(rightSpan);
                            // normalize to 24h for time-of-day addition
                            if (opIsAdd) resultSpan = TimeSpan.FromHours((resultSpan.TotalHours) % 24);
                            replacement = resultSpan.ToString(resultSpan.Seconds != 0 ? @"hh\:mm\:ss" : @"hh\:mm");
                        }
                    }
                }

                if (!string.IsNullOrEmpty(replacement))
                {
                    input = input.Replace(m.Value, replacement);
                }
            }

            return input;
        }

        /// <summary>
        /// Converts angle expressions within the input string from one unit to another and returns the result as a
        /// formatted string.
        /// </summary>
        /// <remarks>The method supports conversion between supported angle units as defined in the
        /// application's configuration. The result is rounded to the number of digits specified in application
        /// settings.</remarks>
        /// <param name="input">The input string containing an angle expression to be converted. Leading and trailing whitespace is ignored.</param>
        /// <returns>A string representing the converted angle value in the target unit, formatted according to application
        /// settings. If no convertible angle expression is found, returns the trimmed input string.</returns>
        private string AngleCalculation(string input)
        {
            input = input.Trim();
            while (angleRegex.IsMatch(input))
            {
                Match match = angleRegex.Match(input);
                double value = double.Parse(match.Groups["value"].Value);
                AngleUnit targetUnit = angleDict[match.Groups["targetUnit"].Value];
                AngleUnit srcUnit = angleDict[match.Groups["srcUnit"].Value];
                if (targetUnit == srcUnit)
                    return input.Replace(match.Value, ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + angleExt[targetUnit]);
                value = Converter.AngleConverter(value, srcUnit, targetUnit);
                return ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + angleExt[targetUnit];

            }
            return input;
        }

        /// <summary>
        /// Calculates and converts frequency values in the input string to the specified target unit, returning the
        /// result as a formatted string.
        /// </summary>
        /// <remarks>The conversion uses application-specific formatting for numeric precision. Only the
        /// first matching frequency pattern in the input is processed; additional patterns are ignored.</remarks>
        /// <param name="input">The input string containing a frequency value and unit to be converted. The string should match the expected
        /// frequency format; otherwise, it will be returned unchanged.</param>
        /// <returns>A string representing the converted frequency value in the target unit, formatted according to application
        /// settings. If the input does not match a frequency pattern, the original input string is returned.</returns>
        private string FrequencyCalculation(string input)
        {
            input.Trim();
            while (frequencyRegex.IsMatch(input))
            {
                Match match = frequencyRegex.Match(input);
                double value = double.Parse(match.Groups["value"].Value);
                FrequencyUnit targetUnit = frequencyDict[match.Groups["targetUnit"].Value.ToLower()];
                FrequencyUnit srcUnit = frequencyDict[match.Groups["srcUnit"].Value.ToLower()];
                if (targetUnit == srcUnit)
                    return input.Replace(match.Value, ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + frequencyExt[targetUnit]);
                value = Converter.FrequencyConverter(value, srcUnit, targetUnit);
                return ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + frequencyExt[targetUnit];

            }
            return input;
        }

        /// <summary>
        /// Converts currency values found in the input string from one unit to another using predefined exchange rates.
        /// </summary>
        /// <remarks>Currency conversion is performed using exchange rates defined in the internal
        /// currency dictionary. Only recognized currency units and patterns will be converted; unrecognized formats
        /// remain unchanged. The conversion rounds results to two decimal places.</remarks>
        /// <param name="input">The input string containing currency values to be converted. Currency values should be formatted according
        /// to the expected pattern for recognition.</param>
        /// <returns>A string with all recognized currency values converted to their target units. If no convertible currency
        /// values are found, returns the original input string.</returns>
        private string CurrencyConversion(string input)
        {
            while (currencyRegex.IsMatch(input))
            {
                Match match = currencyRegex.Match(input);
                double value = double.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);
                string currentUnit = match.Groups["srcUnit"].Value.ToUpper();
                string targetUnit = match.Groups["targetUnit"].Value.ToUpper();
                if (currentUnit == targetUnit)
                    return ToNumberString(System.Math.Round(value, 2)) + " " + targetUnit;
                if (currentUnit == "EUR")
                {
                    value = System.Math.Round(value * currencyDict[targetUnit], 2);
                }
                else if (targetUnit == "EUR")
                {
                    value = System.Math.Round(value / currencyDict[currentUnit], 2);
                }
                else
                {
                    value = System.Math.Round(value / currencyDict[currentUnit] * currencyDict[targetUnit], 2);
                }
                input = input.Replace(match.Value, ToNumberString(value) + " " + targetUnit);
            }
            return input;
        }

        /// <summary>
        /// Converts a data size expression within the input string from one unit to another and returns the result as a
        /// formatted string.
        /// </summary>
        /// <remarks>The method supports conversion between recognized data size units as defined in the
        /// application's configuration. The number of decimal digits in the result is determined by the current
        /// settings. If the source and target units are the same, the value is rounded and formatted without
        /// conversion.</remarks>
        /// <param name="input">The input string containing a data size expression to convert. The expression should specify both the source
        /// and target units (e.g., "10 MB to KB").</param>
        /// <returns>A string with the converted data size value and unit. If no valid data size expression is found, returns the
        /// original input string unchanged.</returns>
        private string DataSizeConversion(string input)
        {
            input.Trim();
            while (dataSizeRegex.IsMatch(input))
            {
                Match match = dataSizeRegex.Match(input);
                double value = double.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);
                DataSizeUnit targetUnit = dataSizeDict[match.Groups["targetUnit"].Value.ToLower()];
                DataSizeUnit srcUnit = dataSizeDict[match.Groups["srcUnit"].Value.ToLower()];
                if (targetUnit == srcUnit)
                    return input.Replace(match.Value, ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + dataSizeExt[targetUnit]);
                value = Converter.DataSizeConverter(value, srcUnit, targetUnit);
                return ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + dataSizeExt[targetUnit];
            }
            return input;
        }

        /// <summary>
        /// Converts a length value in the input string from one unit to another, replacing the matched value with its
        /// converted equivalent.
        /// </summary>
        /// <remarks>If the source and target units are the same, the value is rounded and formatted
        /// without conversion. The conversion uses the number of digits specified in application settings for rounding.
        /// If no valid length conversion pattern is detected, the input is returned unchanged.</remarks>
        /// <param name="input">The input string containing a length value and units to be converted. The string must include both source
        /// and target units in a recognizable format.</param>
        /// <returns>A string with the length value converted to the target unit if a valid conversion pattern is found;
        /// otherwise, returns the original input string.</returns>
        private string LengthConversion(string input)
        {
            input.Trim();
            while (lengthRegex.IsMatch(input))
            {
                Match match = lengthRegex.Match(input);
                double value = double.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);
                LengthUnit targetUnit = lengthDict[match.Groups["targetUnit"].Value.ToLower()];
                LengthUnit srcUnit = lengthDict[match.Groups["srcUnit"].Value.ToLower()];
                if (targetUnit == srcUnit)
                    return input.Replace(match.Value, ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + lengthExt[targetUnit]);
                value = Converter.LengthConverter(value, srcUnit, targetUnit);
                return ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + lengthExt[targetUnit];
            }
            return input;
        }

        /// <summary>
        /// Converts mass values in the specified input string from one unit to another, replacing recognized mass
        /// expressions with their converted equivalents.
        /// </summary>
        /// <remarks>Only mass expressions matching the expected pattern are converted. If the source and
        /// target units are the same, the value is rounded and formatted without conversion. The method does not modify
        /// the input string if no valid mass expressions are detected.</remarks>
        /// <param name="input">The input string containing mass values and units to be converted. The string should include mass
        /// expressions in a supported format.</param>
        /// <returns>A string with mass values converted to the target units. If no mass expressions are found, returns the
        /// original input string.</returns>
        private string MassConversion(string input)
        {
            input.Trim();
            while (massRegex.IsMatch(input))
            {
                Match match = massRegex.Match(input);
                double value = double.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);
                MassUnit targetUnit = massDict[match.Groups["targetUnit"].Value.ToLower()];
                MassUnit srcUnit = massDict[match.Groups["srcUnit"].Value.ToLower()];
                if (targetUnit == srcUnit)
                    return input.Replace(match.Value, ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + massExt[targetUnit]);
                value = Converter.MassConverter(value, srcUnit, targetUnit);
                return ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + massExt[targetUnit];
            }
            return input;
        }

        /// <summary>
        /// Converts a temperature value in the input string from one unit to another, if a valid temperature conversion
        /// pattern is detected.
        /// </summary>
        /// <remarks>If the input string does not match a recognized temperature conversion pattern, the
        /// method returns the input unchanged. The conversion uses the number of digits specified in application
        /// settings for rounding. Supported units and formats depend on the application's configuration.</remarks>
        /// <param name="input">The input string containing a temperature value and units to convert. The string should match the expected
        /// temperature conversion format.</param>
        /// <returns>A string with the converted temperature value and target unit if a valid conversion pattern is found;
        /// otherwise, returns the original input string.</returns>
        private string TemperatureConversion(string input)
        {
            input.Trim();
            while (temperatureRegex.IsMatch(input))
            {
                Match match = temperatureRegex.Match(input);
                double value = double.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);
                TemperatureUnit targetUnit = temperatureDict[match.Groups["targetUnit"].Value.ToLower()];
                TemperatureUnit srcUnit = temperatureDict[match.Groups["srcUnit"].Value.ToLower()];
                if (targetUnit == srcUnit)
                    return input.Replace(match.Value, ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + temperatureExt[targetUnit]);
                value = Converter.TemperatureConverter(value, srcUnit, targetUnit);
                return ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + temperatureExt[targetUnit];
            }
            return input;
        }

        /// <summary>
        /// Parses a calculation expression from the specified input string and returns the computed result as a
        /// formatted string.
        /// </summary>
        /// <remarks>The result is rounded according to the application's digit settings. If the input
        /// cannot be parsed or evaluated, the method returns an empty string instead of throwing an
        /// exception.</remarks>
        /// <param name="input">The calculation expression to evaluate. Must be a valid mathematical expression; otherwise, an empty string
        /// is returned.</param>
        /// <returns>A string containing the formatted result of the calculation, rounded to the configured number of digits.
        /// Returns an empty string if the input is invalid or cannot be evaluated.</returns>
        private string parseCalculation(string input)
        {
            double value = Calculator.CalculateString(input);
            if (!double.IsNaN(value))
                return ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits));
            else
                return "";
        }

        /// <summary>
        /// Converts a double to a string
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string ToNumberString(double val)
        {
            string valString = val.ToString("N10", CultureInfo.InvariantCulture);
            if (valString.Contains("."))
                while (valString.EndsWith("0"))
                    valString = valString.Substring(0, valString.Length - 1);
            if (valString.EndsWith("."))
                valString = valString.Substring(0, valString.Length - 1);
            return valString;
        }

        private void setUpDictionaries()
        {
            // Temperatures
            temperatureDict.Add("K", TemperatureUnit.Kelvin);
            temperatureDict.Add("°F", TemperatureUnit.Fahrenheit);
            temperatureDict.Add("°C", TemperatureUnit.Celsius);
            temperatureDict.Add("°RE", TemperatureUnit.Reaumur);
            temperatureDict.Add("°R", TemperatureUnit.Rankine);
            temperatureDict.Add("°RA", TemperatureUnit.Rankine);

            temperatureExt.Add(TemperatureUnit.Reaumur, "°Re");
            temperatureExt.Add(TemperatureUnit.Rankine, "°Ra");
            temperatureExt.Add(TemperatureUnit.Kelvin, "K");
            temperatureExt.Add(TemperatureUnit.Celsius, "°C");
            temperatureExt.Add(TemperatureUnit.Fahrenheit, "°F");
            // Time
            timeDict.Add("c", TimeUnit.Century);
            timeDict.Add("century", TimeUnit.Century);
            timeDict.Add("centuries", TimeUnit.Century);
            timeDict.Add("decades", TimeUnit.Decade);
            timeDict.Add("decade", TimeUnit.Decade);
            timeDict.Add("years", TimeUnit.Year);
            timeDict.Add("year", TimeUnit.Year);
            timeDict.Add("yrs", TimeUnit.Year);
            timeDict.Add("yr", TimeUnit.Year);
            timeDict.Add("mth", TimeUnit.Month);
            timeDict.Add("month", TimeUnit.Month);
            timeDict.Add("months", TimeUnit.Month);
            timeDict.Add("weeks", TimeUnit.Week);
            timeDict.Add("week", TimeUnit.Week);
            timeDict.Add("wk", TimeUnit.Week);
            timeDict.Add("d", TimeUnit.Day);
            timeDict.Add("day", TimeUnit.Day);
            timeDict.Add("days", TimeUnit.Day);
            timeDict.Add("hours", TimeUnit.Hour);
            timeDict.Add("hour", TimeUnit.Hour);
            timeDict.Add("h", TimeUnit.Hour);
            timeDict.Add("min", TimeUnit.Minute);
            timeDict.Add("minute", TimeUnit.Minute);
            timeDict.Add("minutes", TimeUnit.Minute);
            timeDict.Add("seconds", TimeUnit.Second);
            timeDict.Add("second", TimeUnit.Second);
            timeDict.Add("sec", TimeUnit.Second);
            timeDict.Add("s", TimeUnit.Second);
            timeDict.Add("ms", TimeUnit.Millisecond);
            timeDict.Add("millisecond", TimeUnit.Millisecond);
            timeDict.Add("milliseconds", TimeUnit.Millisecond);
            timeDict.Add("microseconds", TimeUnit.Microsecond);
            timeDict.Add("microsecond", TimeUnit.Microsecond);
            timeDict.Add("μs", TimeUnit.Microsecond);
            timeDict.Add("µs", TimeUnit.Microsecond);
            timeDict.Add("ns", TimeUnit.Nanosecond);
            timeDict.Add("nanosecond", TimeUnit.Nanosecond);
            timeDict.Add("nanoseconds", TimeUnit.Nanosecond);

            timeExt.Add(TimeUnit.Century, "century");
            timeExt.Add(TimeUnit.Decade, "decade");
            timeExt.Add(TimeUnit.Year, "year");
            timeExt.Add(TimeUnit.Month, "month");
            timeExt.Add(TimeUnit.Week, "week");
            timeExt.Add(TimeUnit.Day, "day");
            timeExt.Add(TimeUnit.Hour, "h");
            timeExt.Add(TimeUnit.Minute, "min");
            timeExt.Add(TimeUnit.Second, "s");
            timeExt.Add(TimeUnit.Millisecond, "ms");
            timeExt.Add(TimeUnit.Microsecond, "µs");
            timeExt.Add(TimeUnit.Nanosecond, "ns");
            // Mass
            massDict.Add("tons", MassUnit.Ton);
            massDict.Add("ton", MassUnit.Ton);
            massDict.Add("t", MassUnit.Ton);
            massDict.Add("kg", MassUnit.Kilogram);
            massDict.Add("kilogram", MassUnit.Kilogram);
            massDict.Add("kilograms", MassUnit.Kilogram);
            massDict.Add("grams", MassUnit.Gram);
            massDict.Add("gram", MassUnit.Gram);
            massDict.Add("g", MassUnit.Gram);
            massDict.Add("milligrams", MassUnit.Milligram);
            massDict.Add("milligram", MassUnit.Milligram);
            massDict.Add("mg", MassUnit.Milligram);
            massDict.Add("micrograms", MassUnit.Microgram);
            massDict.Add("microgram", MassUnit.Microgram);
            massDict.Add("µg", MassUnit.Microgram);
            massDict.Add("μg", MassUnit.Microgram);
            massDict.Add("long tons", MassUnit.LongTon);
            massDict.Add("long ton", MassUnit.LongTon);
            massDict.Add("lt", MassUnit.LongTon);
            massDict.Add("short ton", MassUnit.ShortTon);
            massDict.Add("short tons", MassUnit.ShortTon);
            massDict.Add("tn", MassUnit.ShortTon);
            massDict.Add("st", MassUnit.Stone);
            massDict.Add("stone", MassUnit.Stone);
            massDict.Add("stones", MassUnit.Stone);
            massDict.Add("pounds", MassUnit.Pounds);
            massDict.Add("pound", MassUnit.Pounds);
            massDict.Add("lbs", MassUnit.Pounds);
            massDict.Add("lb", MassUnit.Pounds);
            massDict.Add("oz", MassUnit.Ounce);
            massDict.Add("oz.", MassUnit.Ounce);
            massDict.Add("ounce", MassUnit.Ounce);
            massDict.Add("ounces", MassUnit.Ounce);

            massExt.Add(MassUnit.Ton, "t");
            massExt.Add(MassUnit.Kilogram, "kg");
            massExt.Add(MassUnit.Gram, "g");
            massExt.Add(MassUnit.Milligram, "mg");
            massExt.Add(MassUnit.Microgram, "μg");
            massExt.Add(MassUnit.LongTon, "lt");
            massExt.Add(MassUnit.ShortTon, "tn");
            massExt.Add(MassUnit.Stone, "st");
            massExt.Add(MassUnit.Pounds, "lb");
            massExt.Add(MassUnit.Ounce, "oz.");
            // Length
            lengthDict.Add("nanometer", LengthUnit.Nanometer);
            lengthDict.Add("nm", LengthUnit.Nanometer);
            lengthDict.Add("μm", LengthUnit.Nanometer);
            lengthDict.Add("µm", LengthUnit.Nanometer);
            lengthDict.Add("mm", LengthUnit.Millimeter);
            lengthDict.Add("millimeter", LengthUnit.Millimeter);
            lengthDict.Add("centimeter", LengthUnit.Centimeter);
            lengthDict.Add("cm", LengthUnit.Centimeter);
            lengthDict.Add("dm", LengthUnit.Decimeter);
            lengthDict.Add("decimeter", LengthUnit.Decimeter);
            lengthDict.Add("meter", LengthUnit.Meter);
            lengthDict.Add("m", LengthUnit.Meter);
            lengthDict.Add("km", LengthUnit.Kilometer);
            lengthDict.Add("kilometer", LengthUnit.Kilometer);
            lengthDict.Add("decameter", LengthUnit.Decameter);
            lengthDict.Add("dam", LengthUnit.Decameter);
            lengthDict.Add("hm", LengthUnit.Hectometer);
            lengthDict.Add("hectometer", LengthUnit.Hectometer);
            lengthDict.Add("miles", LengthUnit.Mile);
            lengthDict.Add("mile", LengthUnit.Mile);
            lengthDict.Add("mi", LengthUnit.Mile);
            lengthDict.Add("yd", LengthUnit.Yard);
            lengthDict.Add("yard", LengthUnit.Yard);
            lengthDict.Add("foot", LengthUnit.Feet);
            lengthDict.Add("feet", LengthUnit.Feet);
            lengthDict.Add("ft", LengthUnit.Feet);
            lengthDict.Add("in", LengthUnit.Inch);
            lengthDict.Add("inch", LengthUnit.Inch);

            lengthExt.Add(LengthUnit.Nanometer, "nm");
            lengthExt.Add(LengthUnit.Micrometer, "μm");
            lengthExt.Add(LengthUnit.Millimeter, "mm");
            lengthExt.Add(LengthUnit.Centimeter, "cm");
            lengthExt.Add(LengthUnit.Decimeter, "dm");
            lengthExt.Add(LengthUnit.Meter, "m");
            lengthExt.Add(LengthUnit.Kilometer, "km");
            lengthExt.Add(LengthUnit.Decameter, "dam");
            lengthExt.Add(LengthUnit.Hectometer, "hm");
            lengthExt.Add(LengthUnit.Mile, "mi");
            lengthExt.Add(LengthUnit.Yard, "yd");
            lengthExt.Add(LengthUnit.Feet, "ft");
            lengthExt.Add(LengthUnit.Inch, "in");
            // Frequency
            frequencyDict.Add("hertz", FrequencyUnit.Hertz);
            frequencyDict.Add("hz", FrequencyUnit.Hertz);
            frequencyDict.Add("khz", FrequencyUnit.Kilohertz);
            frequencyDict.Add("kilohertz", FrequencyUnit.Kilohertz);
            frequencyDict.Add("megahertz", FrequencyUnit.Megahertz);
            frequencyDict.Add("mhz", FrequencyUnit.Megahertz);
            frequencyDict.Add("ghz", FrequencyUnit.Gigahertz);
            frequencyDict.Add("gigahertz", FrequencyUnit.Gigahertz);

            frequencyExt.Add(FrequencyUnit.Hertz, "Hz");
            frequencyExt.Add(FrequencyUnit.Kilohertz, "kHz");
            frequencyExt.Add(FrequencyUnit.Megahertz, "MHz");
            frequencyExt.Add(FrequencyUnit.Gigahertz, "GHz");
            // Data size
            dataSizeDict.Add("b", DataSizeUnit.Bit);
            dataSizeDict.Add("bit", DataSizeUnit.Bit);
            dataSizeDict.Add("B", DataSizeUnit.Byte);
            dataSizeDict.Add("byte", DataSizeUnit.Byte);
            dataSizeDict.Add("kb", DataSizeUnit.Kilobyte);
            dataSizeDict.Add("mb", DataSizeUnit.Megabyte);
            dataSizeDict.Add("gb", DataSizeUnit.Gigabyte);
            dataSizeDict.Add("tb", DataSizeUnit.Terabyte);
            dataSizeDict.Add("pb", DataSizeUnit.Petabyte);
            dataSizeDict.Add("eb", DataSizeUnit.Exabyte);
            dataSizeDict.Add("kilobyte", DataSizeUnit.Kilobyte);
            dataSizeDict.Add("megabyte", DataSizeUnit.Megabyte);
            dataSizeDict.Add("gigabyte", DataSizeUnit.Gigabyte);
            dataSizeDict.Add("terabyte", DataSizeUnit.Terabyte);
            dataSizeDict.Add("petabyte", DataSizeUnit.Petabyte);
            dataSizeDict.Add("exabyte", DataSizeUnit.Exabyte);

            dataSizeExt.Add(DataSizeUnit.Bit, "b");
            dataSizeExt.Add(DataSizeUnit.Byte, "B");
            dataSizeExt.Add(DataSizeUnit.Kilobyte, "KB");
            dataSizeExt.Add(DataSizeUnit.Megabyte, "MB");
            dataSizeExt.Add(DataSizeUnit.Gigabyte, "GB");
            dataSizeExt.Add(DataSizeUnit.Terabyte, "TB");
            dataSizeExt.Add(DataSizeUnit.Petabyte, "PB");
            dataSizeExt.Add(DataSizeUnit.Exabyte, "EB");
            // Angle
            angleDict.Add("gradian", AngleUnit.Gradian);
            angleDict.Add("gon", AngleUnit.Gradian);
            angleDict.Add("grad", AngleUnit.Gradian);
            angleDict.Add("degree", AngleUnit.Degree);
            angleDict.Add("deg", AngleUnit.Degree);
            angleDict.Add("°", AngleUnit.Degree);
            angleDict.Add("milliradian", AngleUnit.Milliradian);
            angleDict.Add("mil", AngleUnit.Milliradian);
            angleDict.Add("radian", AngleUnit.Radian);
            angleDict.Add("rad", AngleUnit.Radian);
            angleDict.Add("angular minutes", AngleUnit.AngularMinute);
            angleDict.Add("angular minute", AngleUnit.AngularMinute);
            angleDict.Add("arcmin", AngleUnit.AngularMinute);
            angleDict.Add("arcsec", AngleUnit.AngularSecond);
            angleDict.Add("angular second", AngleUnit.AngularSecond);
            angleDict.Add("angular seconds", AngleUnit.AngularSecond);

            angleExt.Add(AngleUnit.Gradian, "gon");
            angleExt.Add(AngleUnit.Degree, "deg");
            angleExt.Add(AngleUnit.Milliradian, "mil");
            angleExt.Add(AngleUnit.Radian, "rad");
            angleExt.Add(AngleUnit.AngularMinute, "arcmin");
            angleExt.Add(AngleUnit.AngularSecond, "arcsec");
        }

        private void UpdateSyntaxHighlighting()
        {
            darkSyntax.AddComment("Currency");
            darkSyntax.AddUnits(CurrencyPattern);
            darkSyntax.AddComment("Data Size Formats");
            darkSyntax.AddUnits(DataSizePattern);
            darkSyntax.AddComment("Time Keywords");
            darkSyntax.AddFunction(@"((yester|to)?day|tomorrow)");
            darkSyntax.AddComment("Frequency");
            darkSyntax.AddUnits(FrequencyPattern);
            darkSyntax.AddComment("Length");
            darkSyntax.AddUnits(LengthPattern);
            darkSyntax.AddComment("Mass");
            darkSyntax.AddUnits(MassPattern);
            darkSyntax.AddComment("Temperature");
            darkSyntax.AddUnits(TemperaturePattern);
            darkSyntax.AddComment("Angle");
            darkSyntax.AddUnits(AnglePattern);
            darkSyntax.AddComment("Time");
            darkSyntax.AddUnits(TimePattern);
            darkSyntax.AddComment("Constants");
            darkSyntax.AddConstants(ConstantsPattern);
        }
        #endregion

        #region ContextMenu
        private void contextNewFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (unsavedChanges)
            {
                dialogWindow = new DialogWindow();
                if (this.WindowState != WindowState.Maximized)
                {
                    dialogWindow.Top = this.Top + (this.Height / 2) - 90;
                    dialogWindow.Left = this.Left + (this.Width / 2) - 200;
                }
                else
                    dialogWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                returnState = 0;


                dialogWindow.mWindow = this;
                dialogWindow.ShowDialog();
                if (dialogWindow.returnState == 2)
                {
                    NewDocument();
                }
                else if (dialogWindow.returnState == 3)
                {
                    if (documentPath != "")
                    {
                        saveFile(documentPath);
                        NewDocument();
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.Calcify)|*.Calcify|All Files (*.*)|*.*", FileName = "" };
                        if (saveFileDialog.ShowDialog() == true)
                        {
                            saveFile(saveFileDialog.FileName);
                            NewDocument();
                        }
                    }
                }
                dialogWindow = null;
            }
            else
            {
                NewDocument();
            }
        }

        private void contextOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
            if (openFileDialog.ShowDialog() == true)
                openFile(openFileDialog.FileName);
        }

        private void contextSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (documentPath == "" || ((Button)sender).Name == "contextSaveAsButton")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.Calcify|All Files (*.*)|*.*", FileName = "" };
                if (saveFileDialog.ShowDialog() == true)
                    saveFile(saveFileDialog.FileName);
            }
            else
                saveFile(documentPath);
        }

        private void contextAboutButton_Click(object sender, RoutedEventArgs e)
        {
            if (aboutWindow == null)
            {
                aboutWindow = new About();
                aboutWindow._mainWindow = this;
                if (this.WindowState != WindowState.Maximized)
                {
                    aboutWindow.Top = this.Top + (this.Height / 2) - 125;
                    aboutWindow.Left = this.Left + (this.Width / 2) - 250;
                }
                else
                    aboutWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                aboutWindow.Show();
            }
            else aboutWindow.Focus();
        }
        #endregion
        #region Drag & Drop
        private void Window_DragEvent(object sender, DragEventArgs e)
        {
            if (e.RoutedEvent == UIElement.DropEvent)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files[0].ToLower().EndsWith(".calcify"))
                    openFile(files[0]);
                DropPanel.IsEnabled = false;
                DropPanel.IsHitTestVisible = false;
                EditorContainer.Effect = new BlurEffect { Radius = 0 };
                return;
            }
            bool dragEnter = e.RoutedEvent.Name == "DragEnter";
            DropPanel.IsEnabled = dragEnter;
            DropPanel.IsHitTestVisible = dragEnter;
            EditorContainer.Effect = new BlurEffect { Radius = (dragEnter ? 10 : 0) };
        }
        #endregion
        #region Hotkeys
        private void CtrlN_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (unsavedChanges)
            {
                dialogWindow = new DialogWindow();
                if (this.WindowState != WindowState.Maximized)
                {
                    dialogWindow.Top = this.Top + (this.Height / 2) - 90;
                    dialogWindow.Left = this.Left + (this.Width / 2) - 200;
                }
                else
                    dialogWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                returnState = 0;


                dialogWindow.mWindow = this;
                dialogWindow.ShowDialog();
                if (dialogWindow.returnState == 2)
                {
                    NewDocument();
                }
                else if (dialogWindow.returnState == 3)
                {
                    if (documentPath != "")
                    {
                        saveFile(documentPath);
                        NewDocument();
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.Calcify)|*.Calcify|All Files (*.*)|*.*", FileName = "" };
                        if (saveFileDialog.ShowDialog() == true)
                        {
                            saveFile(saveFileDialog.FileName);
                            NewDocument();
                        }
                    }
                }
                dialogWindow = null;
            }
            else
            {
                NewDocument();
            }
        }

        private void CtrlO_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Calcify File (*.Calcify)|*.Calcify|All Files (*.*)|*.*", FileName = "" };
            if (openFileDialog.ShowDialog() == true)
                openFile(openFileDialog.FileName);
        }

        private void CtrlShiftS_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.Calcify)|*.Calcify|All Files (*.*)|*.*", FileName = documentPath != "" ? Path.GetFileNameWithoutExtension(documentPath) : "" };
            if (saveFileDialog.ShowDialog() == true)
                saveFile(saveFileDialog.FileName);
        }

        private void CtrlS_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (documentPath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.Calcify)|*.Calcify|All Files (*.*)|*.*", FileName = "" };
                if (saveFileDialog.ShowDialog() == true)
                    saveFile(saveFileDialog.FileName);
            }
            else
                saveFile(documentPath);
        }

        private void Esc_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (DropPanel.IsEnabled)
            {
                DropPanel.IsEnabled = false;
                DropPanel.IsHitTestVisible = false;
                EditorContainer.Effect = new BlurEffect { Radius = 0 };
            }
        }
        #endregion
    }
}


// TODO:
//
//  - REFACTORING CODE
//  - 'About' change date

//  - now syntax highlighting
//  - functions like
//    - Modulo operator (%)
//    - floor()
//    - ceil()
//    - abs()
//    - sin()
//    - asin()
//    - sinh()
//    - asinh()
//    - sinr() (sin to radians)...
//    - cos()
//    - acos()
//    - cosh()
//    - acosh()
//    - tan()
//    - atan()
//    - tanh()
//    - atanh()
//    - log()
//    - ln()
//    - clamp()
//    - pow()
//    - exp()
//    - cbrt()
//    - root(float, int)
//    - trunc()
//    - sign()
//    - min()
//    - max()
//    - fact()
//    - perm() (permutation)
//    - comb() (combination)
//    - sum()
//    - avg()
//    - mean() (average)
//    - median()
//    - mode()
//    - stdev() (standard deviation)
//    - var() (variance)
//    - randomint()
//    - random()
//  - chained operations
//  - constants like 
//    - tau
//    - phi
//    - c (speed of light) >> add to docs (math-functions.md)
//    - h (Planck constant) >> add to docs (math-functions.md)
//    - G (gravitational constant) >> add to docs (math-functions.md)
//    - R (ideal gas constant) >> add to docs (math-functions.md)
//    - Na (Avogadro constant) >> add to docs (math-functions.md)
//    - k (Boltzmann constant) >> add to docs (math-functions.md)
//    - μ0 (magnetic constant) >> add to docs (math-functions.md)
//    - ε0 (electric constant) >> add to docs (math-functions.md)
//    - σ (Stefan-Boltzmann constant) >> add to docs (math-functions.md)
//    - g (standard gravity) >> add to docs (math-functions.md)
//  - implement variables

//  - Recent Files List
//  - toolbar
//  - zoom with ctrl + mouse wheel
//  - zoom with ctrl + '+' / '-'
//  - zoom reset with ctrl + '0'
//  - Auto Completion
//  - Line Numbers

//  - right click context menu
//    - Undo - Undo last action
//    - Redo - Redo last undone action
//    - Cut - Cut selected text
//    - Copy - Copy selected text
//    - Paste - Paste from clipboard
//    - Delete - Delete selected text
//    - Select All - Select all content
//  - Status Bar Line and column
//  - Rename settings scheme to theme
//  - disable auto updates

//  - settings > font size
//  - settings > autosave > interval
//  - settings > Word Wrap (?)
//  - settings > Line Spacing
//  - settings > tab size
//  - settings > show whitespace characters
//  - settings > bracket matching
//  - settings > highlight current line
//  - settings > currency update interval
//  - settings > thousands seperator
//  - settings > Verify rates are current in Settings

//  - editor > ctrl + D duplicate line
//  - editor > ctrl + L delete line
//  - editor > ctrl + / toggle comment line
//  - editor > shift + tab decrease indent
//  - editor > tab complete
//  - editor > ctrl + / toggle comment
//  - editor > ctrl + f find
//  - editor > ctrl + h replace
//  - editor > ctrl + , settings
//  - editor > F1 help

//  - change file ending to .calc
//  - accept inches, bytes, gallons, cups, speed (kmh, mh, ...), data speed (mbps, gbps, ...), tmrw, nmi (nautical miles) (1 nmi = 1852 m), carat (1 ct = 0.2 g), turn (turn, revolution) (1 turn = 360 degrees), THz, pressure, energy, Power, area, volumes (look supported-units.md) as keyword
//  - basic calculation 1024 * x does not work
//  - fix syntax color (days)
//  - multiple conversions (100 cm to m to feet)
//  - ask to save when drag and dropped
//  - currency calculation
//  - time parts (today.year, today.month, today.day, today.dayOfWeek, now.hour, now.minute, now.second)
//  - time difference (today - tomorrow, now - 09:00)
//  - maybe update architecture.md
//  - Time Formats (now.format("HH:mm:ss"), today.format("yyyy-MM-dd"))



// Future TODO:
//  - Plugin Support
//  - Plugin Marketplace
//  - equations


// Done:
//  - Toggle theme button toolbar
//  - Optimized data value conversion
//  - Added Permutations and Combinations functions