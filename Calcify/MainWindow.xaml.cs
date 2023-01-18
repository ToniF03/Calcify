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
using Calcify.Math;
using Calcify.Math.Conversion;
using Calcify.Math.Conversion.Temperature;
using Calcify.Tools;
using static System.Net.Mime.MediaTypeNames;

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
        Regex prevRegex = new Regex(@"(?i)\b(previous|prev|answer|ans)\b(?-i)");
        Regex randRegex = new Regex(@"(\brand\(\d+(\.\d+)?, \d+(\.\d+)?\)( |$)|\brandint\(\d+, \d+\)( |$))");
        Regex diffRegex = new Regex(@"\bdiff\(-?\d+(\.\d+)?, -?\d+(\.\d+)?\)( |$)");
        Regex roundRegex = new Regex(@"\bround\(\d+(\.\d+)?, \d+\)( |$)");
        Regex sqrtRegex = new Regex(@"\bsqrt\((-)?\d+(\.\d+)?\)(( )?|$)");
        Regex dateTimeKeyWordsRegex = new Regex(@"\b(?i)(now|time|yesterday|date|today|tomorrow)(?-i)\b");
        Regex dateTimeRegex = new Regex(@"^(\d{2}(\d{2})?\/\d{1,2}\/\d{1,2}( \d{1,2}:\d{1,2}(:\d{1,2})?)?|\d{1,2}:\d{1,2}(:\d{1,2})?)( (in|add|plus|\+|minus|remove|\-) \d+ (c|yr|mth|wk|d|h|min|s|(?i)(centur(y|ies)|decade(s)?|year(s)?|month(s)?|week(s)?|day(s)?|hour(s)?|minute(s)?|second(s)?)(?-i))|)*$");
        Regex numeralSystemRegex = new Regex(@"^((bin|dec|oct|hex):)?(0x[a-fA-F0-9]+|[0-7]{4}( [0-7]{4})*) (in(to)?|to|as) (bin(ary)?|dec(imal)?|oct(al)?|hex(adecimal)?)$");
        Regex decimalRegex = new Regex(@"^\d+");
        Regex binaryRegex = new Regex(@"^[0-1]{1,4}(( [0-1]{4}|[0-1])+)");
        Regex octalRegex = new Regex(@"^[0-7]{1,4}(( [0-7]{4}|[0-7])+)");
        Regex hexadecimalRegex = new Regex(@"^0x[0-9a-fA-F]+");
        // Regex calculatorRegex = new Regex(@"^(\d+(\.\d+)?|\+|\-|\*|\/|\^|\(|\)|\!)*$");
        Regex PermutationRegex = new Regex(@"\d+C\d+");
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
        Regex massRegex;
        Regex timeRegex;
        Regex directRegex;
        Regex directMassRegex;
        Regex directTemperatureRegex;
        Regex directTimeRegex;
        Regex directLengthRegex;
        Regex directDataSizeRegex;
        Regex directFrequencyRegex;
        Regex directAngleRegex;
        Dictionary<string, Regex> givenRegex;
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
        Dictionary<string, NumeralSystemUnit> numeralSystemDict = new Dictionary<string, NumeralSystemUnit>();
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
        string oldTotalValue = "";
        string windowTitle = "";
        public int returnState = -1;
        bool unsavedChanges = false;
        int CaretOffset = 0;
        public About aboutWindow = null;
        public DialogWindow dialogWindow = null;
        public Settings settingsWindow = null;
        RegistryWatcher watcher = null;

        SyntaxFile lightSyntax = new SyntaxFile(SyntaxFile.Theme.Light);
        SyntaxFile darkSyntax = new SyntaxFile(SyntaxFile.Theme.Dark);

        Dictionary<string, double> currencyDict = new Dictionary<string, double>();
        // By http://exchangerateapi.io
        string exchangeRateLink = "https://api.exchangerate.host/latest";
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

        private void StartNewButton_MouseLeave(object sender, MouseEventArgs e)
        {
            totalLabel.Content = oldTotalValue;
            oldTotalValue = "";
        }

        private void StartNewButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - (double)e.Delta);
            e.Handled = true;
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            ((ContextMenu)Menu.ContextMenu).IsOpen = true;
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
            mainEditor.TextChanged += mainEditor_TextChanged;
            mainEditor.TextArea.Caret.PositionChanged += Caret_PositionChanged; ;
            MinimizeButton.Click += MinimizeButton_Click;
            MaximizeButton.Click += MaximizeButton_Click;
            closeButton.Click += CloseButton_Click;
            StartNewButton.Click += StartNewButton_Click;
            StartNewButton.MouseEnter += StartNewButton_MouseEnter;
            StartNewButton.MouseLeave += StartNewButton_MouseLeave;
            settingsButton.Click += SettingsButton_Click;
            settingsButton.MouseEnter += SettingsButton_MouseEnter;
            settingsButton.MouseLeave += StartNewButton_MouseLeave;
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
            sumAvgRegex = new Regex(@"\b(avg\b|sum(\b| (in(to)?|to|as) (" + TemperaturePattern + "|" + LengthPattern + "|" + AnglePattern + "|" + MassPattern + "|" + FrequencyPattern + "|" + CurrencyPattern + "|" + DataSizePattern + "|" + TimePattern + @"))?)");
            angleRegex = new Regex(@"^\-?\d+(\.\d+)?" + AnglePattern + " (in(to)?|to|as) " + AnglePattern + "$");
            frequencyRegex = new Regex(@"^\-?\d+(\.\d+)? " + FrequencyPattern + " (in(to)?|to|as) " + FrequencyPattern + "$");
            currencyRegex = new Regex(@"^\-?\d+(\.\d+)? " + CurrencyPattern + " (in(to)?|to|as) " + CurrencyPattern + "$");
            dataSizeRegex = new Regex(@"^\-?\d+(\.\d+)? " + DataSizePattern + " (in(to)?|to|as) " + DataSizePattern + "$");
            lengthRegex = new Regex(@"^\-?\d+(\.\d+)? " + LengthPattern + " (in(to)?|to|as) " + LengthPattern + "$");
            massRegex = new Regex(@"^\-?\d+(\.\d+)? " + MassPattern + " (in(to)?|to|as) " + MassPattern + "$");
            timeRegex = new Regex(@"^\-?\d+(\.\d+)? " + TimePattern + @" (in(to)?|to|as) " + TimePattern + @"$");
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
            givenRegex = Calcify.Math.Calculator.RegexDict();
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
        }

        private void Watcher_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DarkMode = watcher.Value != "1";
        }

        private void Settings_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            switch (e.SettingName) {
                case "DarkMode":
                    DarkModeChanged((bool)e.NewValue);
                    break;
                case "SystemDefinedDarkMode":
                    if ((bool)e.NewValue == true)
                    {
                        //watcher = new RegistryWatcher("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme");
                        //watcher.ValueChanged += Watcher_ValueChanged;
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
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            TextDocument newDocument = new TextDocument();
            unsavedChanges = documentText != mainEditor.Text;

            for (int i = 1; i <= mainEditor.LineCount; i++)
            {
                string result = "";
                DocumentLine line = mainEditor.Document.GetLineByNumber(i);
                result = Calculate(line, newDocument);
                newDocument.Text = newDocument.Text + result + '\n';
            }
            resultEditor.Document = newDocument;
            sw.Stop();
            Console.WriteLine("Elapsed time for calculation: " + sw.Elapsed);
        }

        private void Caret_PositionChanged(object sender, EventArgs e)
        {
            #region Offset calculation
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
            #endregion
            CalculateTotal();
            CaretOffset = mainEditor.CaretOffset;
        }

        #region "Functions"
        #region "Exchange Rate"
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
                currencyRegex = new Regex(@"^\-?\d+(\.\d+)? " + CurrencyPattern + " (in(to)?|to|as) " + CurrencyPattern + "$");
                UpdateSyntaxHighlighting();
            }
        }
        #endregion
        #region "Open & Save File"
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

        private string CalculateSum(int CurrentLineNumber, TextDocument newDoc, out int summedLineCount, string targetUnitString = "")
        {
            double value = 0;
            string previousLine = "";
            bool firstLineEncountered = false;
            int lineCount = 0;

            if (CurrentLineNumber != 1)
            {
                while (newDoc.GetText(newDoc.GetLineByNumber(CurrentLineNumber - 1)) == "" && CurrentLineNumber - 1 != 1)
                    CurrentLineNumber--;
                for (int i = CurrentLineNumber - 1; i > 0; i--)
                {
                    previousLine = newDoc.GetText(newDoc.GetLineByNumber(i));
                    if (previousLine == "" && firstLineEncountered)
                        break;
                    else if (new Regex(@"^-?\d+(\.\d+)?$").IsMatch(previousLine) && (targetUnitString == "" || targetUnitString == "digits"))
                    {
                        double exVal = double.Parse(new Regex(@"^-?\d+(\.\d+)?").Match(previousLine).Value, CultureInfo.InvariantCulture);
                        firstLineEncountered = true;
                        lineCount++;
                        if (targetUnitString == "")
                            targetUnitString = "digits";
                        value += exVal;
                    }
                    else if (new Regex(@"^\-?\d+(\.\d+)? " + CurrencyPattern + "$").IsMatch(previousLine) && (targetUnitString == "" || new Regex(CurrencyPattern).IsMatch(targetUnitString)))
                    {
                        lineCount++;
                        firstLineEncountered = true;
                        if (targetUnitString == "")
                        {
                            targetUnitString = new Regex(CurrencyPattern + "$").Match(previousLine).Value;
                            string exVal = new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value;
                            value = double.Parse(exVal, CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            string currentUnit = new Regex(CurrencyPattern + @"$").Match(previousLine).Value;
                            if (currentUnit == targetUnitString)
                            {
                                string exVal = new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value;
                                value = value + double.Parse(exVal, CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                string extractedString = new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value;
                                double exVal = double.Parse(extractedString, CultureInfo.InvariantCulture);
                                exVal = exVal / currencyDict[currentUnit];
                                if (targetUnitString != "EUR")
                                    exVal = exVal * currencyDict[targetUnitString];
                                exVal = System.Math.Round(exVal, 2);
                                value = value + exVal;
                            }
                        }
                    }
                    else if (new Regex(@"^\-?\d+(\.\d+)? " + MassPattern + "$").IsMatch(previousLine) && (targetUnitString == "" || new Regex(MassPattern).IsMatch(targetUnitString)))
                    {
                        lineCount++;
                        firstLineEncountered = true;
                        string currentUnitString = new Regex(MassPattern + "$").Match(previousLine).Value.ToLower();
                        double exVal = double.Parse(new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value);
                        MassUnit currentUnit = MassUnit.None;
                        MassUnit targetUnit = MassUnit.None;
                        if (targetUnitString == "")
                        {
                            targetUnitString = currentUnitString;
                            value += exVal;
                        }
                        else
                        {
                            targetUnit = massDict[targetUnitString];
                            targetUnitString = massExt[targetUnit];
                            currentUnit = massDict[currentUnitString];
                            if (currentUnit != targetUnit)
                                exVal = Converter.MassConverter(exVal, currentUnit, targetUnit);
                            if (targetUnit == MassUnit.Pounds)
                                targetUnitString = exVal == 1 || exVal == -1 ? "lb" : "lbs";
                            value += exVal;

                        }
                    }
                    else if (new Regex(@"^\-?\d+(\.\d+)? " + TemperaturePattern + "$").IsMatch(previousLine) && (targetUnitString == "" || new Regex(TemperaturePattern).IsMatch(targetUnitString)))
                    {
                        lineCount++;
                        firstLineEncountered = true;
                        string currentUnitString = new Regex(TemperaturePattern + "$").Match(previousLine).Value;
                        double exVal = double.Parse(new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value, CultureInfo.InvariantCulture);
                        TemperatureUnit currentUnit = TemperatureUnit.None;
                        TemperatureUnit targetUnit = TemperatureUnit.None;
                        if (targetUnitString == "")
                        {
                            targetUnitString = currentUnitString;
                            value = exVal;
                        }
                        else
                        {
                            currentUnit = temperatureDict[currentUnitString];
                            targetUnit = temperatureDict[targetUnitString];
                            targetUnitString = temperatureExt[targetUnit];
                            if (currentUnit != targetUnit)
                                exVal = Converter.TemperatureConverter(exVal, currentUnit, targetUnit);
                            value += exVal;
                        }
                    }
                    else if (new Regex(@"^\-?\d+(\.\d+)? " + DataSizePattern + "$").IsMatch(previousLine) && (targetUnitString == "" || new Regex(DataSizePattern).IsMatch(targetUnitString)))
                    {
                        lineCount++;
                        firstLineEncountered = true;
                        string currentUnitString = new Regex(DataSizePattern + "$").Match(previousLine).Value;
                        double exVal = double.Parse(new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value, CultureInfo.InvariantCulture);
                        DataSizeUnit currentUnit = DataSizeUnit.None;
                        DataSizeUnit targetUnit = DataSizeUnit.None;
                        if (currentUnitString != "b" && currentUnitString != "B")
                            currentUnitString = currentUnitString.ToLower();
                        if (targetUnitString != "b" && targetUnitString != "B")
                            targetUnitString = targetUnitString.ToLower();
                        if (targetUnitString == "")
                        {
                            targetUnitString = currentUnitString;
                            value += exVal;
                            targetUnit = dataSizeDict[targetUnitString];
                            targetUnitString = dataSizeExt[targetUnit];
                        }
                        else
                        {
                            targetUnit = dataSizeDict[targetUnitString];
                            targetUnitString = dataSizeExt[targetUnit];
                            currentUnit = dataSizeDict[currentUnitString];
                            if (targetUnit != currentUnit)
                                exVal = Converter.DataSizeConverter(exVal, currentUnit, targetUnit);
                            value += exVal;
                        }
                    }
                    else if (new Regex(@"^\-?\d+(\.\d+)? " + TimePattern + "$").IsMatch(previousLine) && (targetUnitString == "" || new Regex(TimePattern).IsMatch(targetUnitString)))
                    {
                        lineCount++;
                        firstLineEncountered = true;
                        string currentUnitString = new Regex(TimePattern + "$").Match(previousLine).Value;
                        double exVal = double.Parse(new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value, CultureInfo.InvariantCulture);
                        TimeUnit currentUnit = TimeUnit.None;
                        TimeUnit targetUnit = TimeUnit.None;
                        if (targetUnitString == "")
                        {
                            targetUnitString = currentUnitString;
                            value += exVal;
                        }
                        else
                        {
                            targetUnit = timeDict[targetUnitString];
                            targetUnitString = timeExt[targetUnit];
                            currentUnit = timeDict[currentUnitString];
                            if (targetUnit != currentUnit)
                                exVal = Converter.TimeConverter(exVal, currentUnit, targetUnit);
                            value += exVal;
                        }
                    }
                    else if (new Regex(@"^\-?\d+(\.\d+)? " + FrequencyPattern + "$").IsMatch(previousLine) && (targetUnitString == "" || new Regex(FrequencyPattern).IsMatch(targetUnitString)))
                    {
                        lineCount++;
                        firstLineEncountered = true;
                        double exVal = double.Parse(new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value, CultureInfo.InvariantCulture);
                        string currentUnitString = new Regex(FrequencyPattern).Match(new Regex(@"^\-?\d+(\.\d+)? " + FrequencyPattern).Match(previousLine).Value).Value.ToLower().Trim();
                        if (targetUnitString == "")
                            targetUnitString = currentUnitString;
                        FrequencyUnit targetUnit = FrequencyUnit.None;
                        FrequencyUnit currentUnit = FrequencyUnit.None;
                        targetUnitString = targetUnitString.ToLower();
                        targetUnit = frequencyDict[targetUnitString];
                        targetUnitString = frequencyExt[targetUnit];
                        currentUnit = frequencyDict[currentUnitString];
                        if (targetUnit != currentUnit)
                            exVal = Converter.FrequencyConverter(exVal, currentUnit, targetUnit);
                        value += exVal;
                    }
                    else if (new Regex(@"^\-?\d+(\.\d+)?" + AnglePattern + "$").IsMatch(previousLine) && (targetUnitString == "" || new Regex(AnglePattern).IsMatch(targetUnitString)))
                    {
                        lineCount++;
                        firstLineEncountered = true;
                        double exVal = double.Parse(new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value, CultureInfo.InvariantCulture);
                        string currentUnitString = new Regex(AnglePattern).Match(previousLine).Value.ToLower().Trim();
                        if (targetUnitString == "")
                            targetUnitString = currentUnitString;
                        AngleUnit targetUnit = AngleUnit.None;
                        AngleUnit currentUnit = AngleUnit.None;
                        targetUnit = angleDict[targetUnitString];
                        targetUnitString = angleExt[targetUnit];
                        currentUnit = angleDict[currentUnitString];
                        if (currentUnit != targetUnit)
                            exVal = Converter.AngleConverter(exVal, currentUnit, targetUnit);
                        value += exVal;
                    }
                    else if (new Regex(@"^\-?\d+(\.\d+)? " + LengthPattern + "$").IsMatch(previousLine) && (targetUnitString == "" || new Regex(LengthPattern).IsMatch(targetUnitString)))
                    {
                        lineCount++;
                        firstLineEncountered = true;
                        string currentUnitString = new Regex(LengthPattern + "$").Match(previousLine).Value;
                        double exVal = double.Parse(new Regex(@"^\-?\d+(\.\d+)?").Match(previousLine).Value, CultureInfo.InvariantCulture);
                        targetUnitString = targetUnitString == "" ? currentUnitString : targetUnitString;
                        LengthUnit currentUnit = LengthUnit.None;
                        LengthUnit targetUnit = LengthUnit.None;
                        targetUnit = lengthDict[targetUnitString];
                        targetUnitString = lengthExt[targetUnit];
                        currentUnit = lengthDict[currentUnitString];
                        if (targetUnit != currentUnit)
                            exVal = Converter.LengthConverter(exVal, currentUnit, targetUnit);
                        value += exVal;
                    }
                    else
                        break;
                }

                summedLineCount = lineCount;
                if (targetUnitString != "digits")
                {
                    if (System.Math.Round(value, Properties.Settings.Default.Digits) != 0)
                        return ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)) + " " + targetUnitString;
                    else
                        return ToNumberString(value) + " " + targetUnitString;
                }
                else
                {
                    if (System.Math.Round(value, Properties.Settings.Default.Digits) != 0)
                        return ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits));
                    else
                        return ToNumberString(value);
                }
            }
            else
                summedLineCount = 0;
            return "";
        }

        private string Calculate(DocumentLine input, TextDocument newDoc)
        {
            string result = "";

            string currentLine = mainEditor.Document.GetText(input.Offset, input.Length);
            string uneditedCurrentLine = currentLine;
            windowTitle = "Calcify";
            if (input.LineNumber == 1)
            {
                if (currentLine.StartsWith("# "))
                {
                    string text = mainEditor.Document.GetText(input.Offset, input.Length).Substring(2).Trim();
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

            if (!currentLine.StartsWith("#"))
            {
                if (currentLine.Contains("#"))
                    currentLine = currentLine.Split('#')[0];

                while (currentLine.Contains("  "))
                    currentLine = currentLine.Replace("  ", " ");
                currentLine = currentLine.Trim();

                if (prevRegex.IsMatch(currentLine))
                {
                    if (input.LineNumber != 1)
                    {
                        string previousLine = "";
                        for (int i = 1; input.LineNumber - i != 0; i++)
                        {
                            previousLine = newDoc.GetText(newDoc.GetLineByNumber(input.LineNumber - i));
                            if (previousLine != "")
                                break;
                        }

                        currentLine = prevRegex.Replace(currentLine, previousLine);
                    }
                }

                #region Permutation
                if (PermutationRegex.IsMatch(currentLine))
                {
                    foreach (Match match in PermutationRegex.Matches(currentLine))
                    {
                        int n = 0;
                        int r = 0;
                        string[] m = match.Value.Split('C');
                        n = int.Parse(m[0]);
                        r = int.Parse(m[1]);
                        if (n >= r)
                        {
                            currentLine = currentLine.Replace(match.Value, Functions.nCr(n, r).ToString());
                        }
                    }
                }
                #endregion
                #region Constants
                if (constantsRegex.IsMatch(currentLine))
                {
                    foreach (Match match in constantsRegex.Matches(currentLine))
                    {
                        if (match.Value == "pi" || match.Value == "π")
                            currentLine = constantsRegex.Replace(currentLine, ToNumberString(System.Math.Round(System.Math.PI, Properties.Settings.Default.Digits)), 1);
                        else if (match.Value == "e")
                            currentLine = constantsRegex.Replace(currentLine, ToNumberString(System.Math.Round(System.Math.E, Properties.Settings.Default.Digits)), 1);
                    }
                }
                #endregion
                #region Functions
                if (randRegex.IsMatch(currentLine))
                {
                    MatchCollection matches = randRegex.Matches(currentLine);
                    foreach (Match match in matches)
                    {
                        string text = match.Value;
                        string[] numbersString = text.Split(',');
                        double minNumber = double.Parse(numbersString[0].Split('(')[1], CultureInfo.InvariantCulture);
                        double maxNumber = double.Parse(numbersString[1].Split(')')[0], CultureInfo.InvariantCulture);
                        if (minNumber < maxNumber)
                        {
                            if (text.StartsWith("rand("))
                            {
                                double generatedNumber = GetRandomDouble(minNumber, maxNumber);
                                generatedNumber = System.Math.Round(generatedNumber, Properties.Settings.Default.Digits);
                                currentLine = currentLine.Replace(text, ToNumberString(System.Math.Round(generatedNumber, Properties.Settings.Default.Digits)) + " ");
                            }
                            else if (text.StartsWith("randint("))
                            {
                                int generatedNumber = new Random().Next((int)minNumber, (int)maxNumber);
                                currentLine = currentLine.Replace(text, ToNumberString(generatedNumber) + " ");
                            }
                        }
                    }
                }

                if (diffRegex.IsMatch(currentLine))
                {
                    foreach (Match match in diffRegex.Matches(currentLine))
                    {
                        string text = match.Value;
                        string[] numbersString = text.Split(',');
                        double minNumber = double.Parse(numbersString[0].Split('(')[1], CultureInfo.InvariantCulture);
                        double maxNumber = double.Parse(numbersString[1].Split(')')[0], CultureInfo.InvariantCulture);
                        double diff = System.Math.Abs(maxNumber - minNumber);
                        currentLine = currentLine.Replace(text, ToNumberString(System.Math.Round(diff, Properties.Settings.Default.Digits)) + " ");
                    }
                }

                if (roundRegex.IsMatch(currentLine))
                {
                    MatchCollection matches = roundRegex.Matches(currentLine);
                    foreach (Match match in matches)
                    {
                        string text = match.Value;
                        string[] numbersString = text.Split(',');
                        double minNumber = double.Parse(numbersString[0].Split('(')[1], CultureInfo.InvariantCulture);
                        int digits = int.Parse(numbersString[1].Split(')')[0]);
                        if (0 <= digits)
                        {
                            double roundedNumber = System.Math.Round(minNumber, digits);
                            currentLine = currentLine.Replace(text, ToNumberString(roundedNumber));
                        }
                    }
                }

                if (sqrtRegex.IsMatch(currentLine))
                {
                    MatchCollection matches = sqrtRegex.Matches(currentLine);
                    foreach (Match match in matches)
                    {
                        double extractedNumber = double.Parse(match.Value.Split('(')[1].Split(')')[0], CultureInfo.InvariantCulture);
                        if (extractedNumber > 0)
                        {
                            double value = System.Math.Sqrt(extractedNumber);
                            if (System.Math.Round(value, Properties.Settings.Default.Digits) != 0)
                                currentLine = currentLine.Replace(match.Value, ToNumberString(System.Math.Round(value, Properties.Settings.Default.Digits)));
                            else
                                currentLine = currentLine.Replace(match.Value, ToNumberString(value));
                        }
                    }
                }
                #region Sum
                if (sumAvgRegex.IsMatch(currentLine))
                {
                    MatchCollection matches = sumAvgRegex.Matches(currentLine);
                    string targetUnitString = "";
                    foreach (Match match in matches)
                    {
                        targetUnitString = "";
                        string text = match.Value.ToLower();
                        if (text.Contains(" "))
                            targetUnitString = string.Join(" ", targetUnitString.Split(' ').Skip(2));
                        int summedLines;
                        string s = CalculateSum(input.LineNumber, newDoc, out summedLines, targetUnitString) + " ";
                        if (text == "avg")
                        {
                            string[] splittedResult = s.Split(' ');
                            splittedResult = new string[] { splittedResult[0], String.Join(" ", splittedResult.Skip(1)) };
                            double value = double.Parse(splittedResult[0], CultureInfo.InvariantCulture);
                            value /= summedLines;
                            s = ToNumberString(value) + " " + splittedResult[1];
                        }
                        currentLine = Regex.Replace(currentLine, @"\b" + match.Value + @"( |$)", s);
                        currentLine = currentLine.Replace("  ", " ").Trim();
                    }

                }
                #endregion
                #endregion

                if (dateTimeKeyWordsRegex.IsMatch(currentLine))
                {
                    DateTime dateTime = DateTime.Now;
                    string timeString = "";
                    MatchCollection matches = dateTimeKeyWordsRegex.Matches(currentLine);
                    foreach (Match match in matches)
                    {
                        if (match.Value.ToLower() == "now" || match.Value.ToLower() == "time")
                            timeString = dateTime.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
                        else if (match.Value.ToLower() == "today" || match.Value.ToLower() == "date")
                            timeString = dateTime.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        else if (match.Value.ToLower() == "yesterday")
                            timeString = dateTime.AddDays(-1).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        else if (match.Value.ToLower() == "tomorrow")
                            timeString = dateTime.AddDays(1).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        currentLine = Regex.Replace(currentLine, @"\b(?i)" + match.Value.ToLower() + @"(?-i)\b", timeString);
                    }
                }

                // Date
                #region Date
                if (dateTimeRegex.IsMatch(currentLine))
                {
                    bool dateGiven = currentLine.Contains('/');
                    bool timeGiven = currentLine.Contains(':');
                    DateTime originalDate;
                    int year = 0;
                    int month = 0;
                    int day = 0;
                    int hour = 0;
                    int minute = 0;
                    int second = 0;
                    string[] splittedTask = null;

                    if (dateGiven)
                    {
                        year = int.Parse(currentLine.Split(' ')[0].Split('/')[0]);
                        month = int.Parse(currentLine.Split(' ')[0].Split('/')[1]);
                        day = int.Parse(currentLine.Split(' ')[0].Split('/')[2]);
                    }
                    else
                    {
                        year = DateTime.Now.Year;
                        month = DateTime.Now.Month;
                        day = DateTime.Now.Day;
                    }
                    if (timeGiven)
                    {
                        if (dateGiven)
                        {
                            splittedTask = currentLine.Split(' ');
                            splittedTask = splittedTask[1].Split(':');
                        }
                        else if (!dateGiven)
                        {
                            splittedTask = currentLine.Split(' ');
                            splittedTask = splittedTask[0].Split(':');
                        }
                        hour = int.Parse(splittedTask[0]);
                        minute = int.Parse(splittedTask[1]);
                        if (splittedTask.Length == 3)
                            second = int.Parse(splittedTask[2]);
                    }
                    if (((dateGiven && !(year < 1 || month < 1 || month > 12)) || !dateGiven) && ((timeGiven && !(hour < 0 || minute < 0 || second < 0 || hour > 23 || minute > 59 || second > 59)) || !timeGiven))
                    {
                        if (day > -1 && day <= DateTime.DaysInMonth(year, month))
                        {
                            originalDate = new DateTime(year, month, day);
                            DateTime date = new DateTime(year, month, day, hour, minute, second);
                            if (Regex.IsMatch(currentLine, @"^(\d{4}|\d{2})\/\d{1,2}\/\d{1,2} \d{1,2}\:\d{1,2}(:\d{1,2})?$"))
                            {
                                if (second != 0)
                                    result = date.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                                else
                                    result = date.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                            }
                            else if (Regex.IsMatch(currentLine, @"^\d\d?\:\d\d?(:\d\d?)?$"))
                            {
                                if (second != 0)
                                    result = date.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
                                else
                                    result = date.ToString("HH:mm", CultureInfo.InvariantCulture);
                            }
                            else if (Regex.IsMatch(currentLine, @"^(\d{4}|\d{2})\/(\d{2}|\d)\/(\d{2}|\d)$"))
                                result = date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                            else
                            {
                                int exVal = 0;
                                MatchCollection matches = Regex.Matches(currentLine, @" (in|add|plus|\+|minus|remove|\-) \d+ (c|yr|mth|wk|d|h|min|s|(?i)(centur(y|ies)|decade(s)?|year(s)?|month(s)?|week(s)?|day(s)?|hour(s)?|minute(s)?|second(s)?)(?-i))");

                                foreach (Match m in matches)
                                {
                                    splittedTask = m.Value.Substring(1).Split(' ');
                                    splittedTask[0] = splittedTask[0].ToLower();
                                    exVal = int.Parse(splittedTask[1]);
                                    if (splittedTask[0] == "minus" || splittedTask[0] == "remove" || splittedTask[0] == "-")
                                        exVal *= -1;
                                    string exUnit = splittedTask[2].ToLower();
                                    switch (exUnit)
                                    {
                                        case "century":
                                        case "centuries":
                                        case "c":
                                            date = date.AddYears(exVal * 100);
                                            break;
                                        case "decade":
                                        case "decades":
                                            date = date.AddYears(exVal * 10);
                                            break;
                                        case "year":
                                        case "years":
                                        case "yr":
                                            date = date.AddYears(exVal);
                                            break;
                                        case "months":
                                        case "month":
                                        case "mth":
                                            date = date.AddMonths(exVal);
                                            break;
                                        case "weeks":
                                        case "week":
                                        case "wk":
                                            date = date.AddDays(exVal * 7);
                                            break;
                                        case "days":
                                        case "day":
                                        case "d":
                                            date = date.AddDays(exVal);
                                            break;
                                    }
                                    if (timeGiven)
                                    {
                                        switch (exUnit)
                                        {
                                            case "hours":
                                            case "hour":
                                            case "h":
                                                date = date.AddHours(exVal);
                                                break;
                                            case "minutes":
                                            case "minute":
                                            case "min":
                                                date = date.AddMinutes(exVal);
                                                break;
                                            case "seconds":
                                            case "second":
                                            case "s":
                                                date = date.AddSeconds(exVal);
                                                break;
                                        }
                                    }
                                }

                                if (originalDate.Date == date.Date || dateGiven && timeGiven)
                                    result = date.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                                else if (timeGiven && !dateGiven)
                                    result = date.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
                                else if (dateGiven && !timeGiven)
                                    result = date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                            }
                        }
                    }
                }
                #endregion
                // Angle
                #region Angle Units
                else if (angleRegex.IsMatch(currentLine))
                {
                    double extractedValue = double.Parse(currentLine.Split(' ')[0], CultureInfo.InvariantCulture);
                    string[] splittedTask = currentLine.Split(' ');
                    string currentUnitString = (splittedTask[1].ToLower() == "angular" ? splittedTask[1] + " " + splittedTask[2] : splittedTask[1]).ToLower();
                    string targetUnitString = splittedTask[splittedTask.Length - 1];
                    AngleUnit targetUnit = AngleUnit.None;
                    AngleUnit currentUnit = AngleUnit.None;
                    targetUnit = angleDict[targetUnitString];
                    targetUnitString = angleExt[targetUnit];
                    currentUnit = angleDict[currentUnitString];
                    if (targetUnit != currentUnit)
                        extractedValue = Converter.AngleConverter(extractedValue, currentUnit, targetUnit);
                    if (System.Math.Round(extractedValue, Properties.Settings.Default.Digits) != 0)
                        result = ToNumberString(System.Math.Round(extractedValue, Properties.Settings.Default.Digits)) + " " + targetUnitString;
                    else
                        result = ToNumberString(extractedValue) + " " + targetUnitString;
                }
                #endregion
                // Frequency
                #region Frequency
                else if (frequencyRegex.IsMatch(currentLine))
                {
                    double extractedValue = double.Parse(currentLine.Split(' ')[0], CultureInfo.InvariantCulture);
                    string currentUnitString = currentLine.Split(' ')[1].ToLower().Trim();
                    string targetUnitString = currentLine.Split(' ')[3].ToLower().Trim();
                    FrequencyUnit targetUnit = FrequencyUnit.None;
                    FrequencyUnit currentUnit = FrequencyUnit.None;
                    targetUnit = frequencyDict[targetUnitString];
                    targetUnitString = frequencyExt[targetUnit];
                    currentUnit = frequencyDict[currentUnitString];
                    if (targetUnit != currentUnit)
                        extractedValue = Converter.FrequencyConverter(extractedValue, currentUnit, targetUnit);
                    if (System.Math.Round(extractedValue, Properties.Settings.Default.Digits) != 0)
                        result = ToNumberString(System.Math.Round(extractedValue, Properties.Settings.Default.Digits)) + " " + targetUnitString;
                    else
                        result = ToNumberString(extractedValue) + " " + targetUnitString;
                }
                #endregion
                // Currency
                #region Currency Units
                else if (currencyRegex.IsMatch(currentLine))
                {
                    string valueString = currentLine.Split(' ')[0];
                    double value = double.Parse(valueString, CultureInfo.InvariantCulture);
                    string currentUnit = currentLine.Substring(valueString.Length + 1, 3).ToUpper();
                    string targetUnit = currentLine.Substring(currentLine.Length - 3).ToUpper();
                    if (currentUnit != targetUnit)
                    {
                        if (currentUnit == "EUR")
                        {
                            value = System.Math.Round(value * currencyDict[targetUnit], 2);
                            result = value.ToString(CultureInfo.InvariantCulture).Replace(',', '.') + " " + targetUnit;
                        }
                        else if (targetUnit == "EUR")
                        {
                            value = System.Math.Round(value / currencyDict[currentUnit], 2);
                            result = value.ToString(CultureInfo.InvariantCulture).Replace(',', '.') + " " + targetUnit;
                        }
                        else
                        {
                            value = System.Math.Round(value / currencyDict[currentUnit] * currencyDict[targetUnit], 2);
                            result = value.ToString(CultureInfo.InvariantCulture).Replace(',', '.') + " " + targetUnit;
                        }
                    }
                }
                #endregion
                // Data size
                #region Data Size Units
                else if (dataSizeRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    double extractedValue = double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    string currentUnitString = splittedTask[1];
                    string targetUnitString = splittedTask[3];
                    DataSizeUnit targetUnit = DataSizeUnit.None;
                    DataSizeUnit currentUnit = DataSizeUnit.None;
                    targetUnitString = targetUnitString != "b" && targetUnitString != "B" ? targetUnitString.ToLower() : targetUnitString;
                    currentUnitString = currentUnitString != "b" && currentUnitString != "B" ? currentUnitString.ToLower() : currentUnitString;
                    targetUnit = dataSizeDict[targetUnitString];
                    targetUnitString = dataSizeExt[targetUnit];
                    currentUnit = dataSizeDict[currentUnitString];
                    if (currentUnit != targetUnit)
                    {
                        double res = Converter.DataSizeConverter(extractedValue, currentUnit, targetUnit);
                        string valString = ToNumberString(res);
                        result = valString + " " + targetUnitString;
                    }
                }
                #endregion
                // Length
                #region Length Units
                else if (lengthRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    double extractedValue = double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    string currentUnitString = splittedTask[1];
                    string targetUnitString = splittedTask[3];
                    LengthUnit targetUnit = LengthUnit.None;
                    LengthUnit currentUnit = LengthUnit.None;
                    targetUnit = lengthDict[targetUnitString];
                    targetUnitString = lengthExt[targetUnit];
                    currentUnit = lengthDict[currentUnitString];
                    if (currentUnit != targetUnit)
                        extractedValue = Converter.LengthConverter(extractedValue, currentUnit, targetUnit);
                    if (System.Math.Round(extractedValue, Properties.Settings.Default.Digits) != 0)
                        result = ToNumberString(System.Math.Round(extractedValue, Properties.Settings.Default.Digits)) + " " + targetUnitString;
                    else
                        result = ToNumberString(extractedValue) + " " + targetUnitString;
                }
                #endregion
                // Mass
                #region Mass Units
                else if (massRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    double exVal = double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    string currentUnitString = splittedTask[1].ToLower() == "long" || splittedTask[1].ToLower() == "short" ? splittedTask[1] + " " + splittedTask[2] : splittedTask[1];
                    string targetUnitString = splittedTask[splittedTask.Length - 2] == "long" || splittedTask[splittedTask.Length - 2] == "short" ? splittedTask[splittedTask.Length - 2] + " " + splittedTask[splittedTask.Length - 1] : splittedTask[splittedTask.Length - 1];
                    MassUnit currentUnit = MassUnit.None;
                    MassUnit targetUnit = MassUnit.None;
                    targetUnit = massDict[targetUnitString];
                    targetUnitString = massExt[targetUnit];
                    currentUnit = massDict[currentUnitString];
                    if (currentUnit != targetUnit)
                    {
                        double res = Converter.MassConverter(exVal, currentUnit, targetUnit);
                        if (targetUnit == MassUnit.Pounds)
                            targetUnitString = res == 1 || res == -1 ? "lb" : "lbs";
                        if (System.Math.Round(exVal, Properties.Settings.Default.Digits) != 0)
                            result = ToNumberString(System.Math.Round(res, Properties.Settings.Default.Digits)) + " " + targetUnitString;
                        else
                            result = ToNumberString(res) + " " + targetUnitString;
                    }
                }
                #endregion
                // Numeral systems
                #region NumeralSystems
                else if (numeralSystemRegex.IsMatch(currentLine))
                {
                    string exVal = "";
                    NumeralSystemUnit currentUnit = NumeralSystemUnit.None;
                    NumeralSystemUnit targetUnit = NumeralSystemUnit.None;
                    currentLine = currentLine.Replace(" into ", " in ");
                    currentLine = currentLine.Replace(" to ", " in ");
                    string[] splittedTask = currentLine.Split(new string[] { " in " }, 2, StringSplitOptions.None);
                    if (currentLine.StartsWith("bin:") || binaryRegex.IsMatch(splittedTask[0]))
                        currentUnit = NumeralSystemUnit.Binary;
                    else if (currentLine.StartsWith("oct:") || octalRegex.IsMatch(splittedTask[0]))
                        currentUnit = NumeralSystemUnit.Octal;
                    else if (currentLine.StartsWith("hex:") || hexadecimalRegex.IsMatch(splittedTask[0]))
                        currentUnit = NumeralSystemUnit.Hexadecimal;
                    else if (currentLine.StartsWith("dec:") || decimalRegex.IsMatch(splittedTask[0]))
                        currentUnit = NumeralSystemUnit.Decimal;
                    if (currentLine.EndsWith("bin") || currentLine.EndsWith("binary"))
                        targetUnit = NumeralSystemUnit.Binary;
                    else if (currentLine.EndsWith("hex") || currentLine.EndsWith("hexadecimal"))
                        targetUnit = NumeralSystemUnit.Hexadecimal;
                    else if (currentLine.EndsWith("oct") || currentLine.EndsWith("octal"))
                        targetUnit = NumeralSystemUnit.Octal;
                    else if (currentLine.EndsWith("dec") || currentLine.EndsWith("decimal"))
                        targetUnit = NumeralSystemUnit.Decimal;
                    if (currentLine.StartsWith("bin:") || currentLine.StartsWith("hex:") || currentLine.StartsWith("oct:") || currentLine.StartsWith("dec:"))
                        currentLine = currentLine.Substring(4);
                    exVal = Regex.Match(currentLine, "^(0x)?([0-9a-fA-F]+| )").Value;
                    result = Converter.NumeralSystemConverter(exVal, currentUnit, targetUnit);
                }
                #endregion
                // Temperature
                #region Temperature Units
                else if (Regex.IsMatch(currentLine, @"^\-?\d+(\.\d+)? " + TemperaturePattern + " (in(to)?|to|as) " + TemperaturePattern + "$"))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    double extractedValue = double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    string targetUnitString = splittedTask[3];
                    string currentUnitString = splittedTask[1];
                    TemperatureUnit currentUnit = TemperatureUnit.None;
                    TemperatureUnit targetUnit = TemperatureUnit.None;
                    targetUnit = temperatureDict[targetUnitString.ToUpper()];
                    targetUnitString = temperatureExt[targetUnit];
                    currentUnit = temperatureDict[currentUnitString.ToUpper()];
                    if (currentUnit != targetUnit)
                    {
                        double res = Converter.TemperatureConverter(extractedValue, currentUnit, targetUnit);
                        if (System.Math.Round(res, Properties.Settings.Default.Digits) != 0)
                            result = ToNumberString(System.Math.Round(res, Properties.Settings.Default.Digits)) + " " + targetUnitString;
                        else
                            result = ToNumberString(res) + " " + targetUnitString;
                    }
                }
                #endregion
                // Time
                #region Time Units
                else if (timeRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    double extractedValue = double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    string currentUnitString = splittedTask[1];
                    string targetUnitString = splittedTask[splittedTask.Length - 1];
                    TimeUnit currentUnit = TimeUnit.None;
                    TimeUnit targetUnit = TimeUnit.None;
                    targetUnit = timeDict[targetUnitString];
                    targetUnitString = timeExt[targetUnit];
                    currentUnit = timeDict[currentUnitString];
                    if (currentUnit != targetUnit)
                    {
                        double res = Converter.TimeConverter(extractedValue, currentUnit, targetUnit);
                        if (res != 1 && res != -1)
                        {
                            switch (targetUnitString)
                            {
                                case "century":
                                    targetUnitString = "centuries";
                                    break;
                                case "decade":
                                case "year":
                                case "month":
                                case "week":
                                case "day":
                                    targetUnitString = targetUnitString + "s";
                                    break;
                            }
                        }
                        if (System.Math.Round(res, Properties.Settings.Default.Digits) != 0)
                            result = ToNumberString(System.Math.Round(res, Properties.Settings.Default.Digits)) + " " + targetUnitString;
                        else
                            result = ToNumberString(res) + " " + targetUnitString;
                    }
                }
                #endregion

                #region Result
                if (result == "" && calculatorRegex.IsMatch(currentLine) && !numberRegex.IsMatch(currentLine) && numberRegex.IsMatch(currentLine.Substring(currentLine.Length - 1)))
                {
                    double val = Calculator.CalculateString(currentLine, givenRegex);
                    if (!double.IsNaN(val))
                        result = ToNumberString(val);
                }
                else if (Regex.IsMatch(currentLine, @"^(hex:)?(0x[0-9a-fA-F]+)$"))
                    if (currentLine.StartsWith("hex:"))
                        result = "0x" + currentLine.Substring(6).ToUpper();
                    else
                        result = "0x" + currentLine.Substring(2).ToUpper();
                else if (result == "" && numeralFormatRegex.IsMatch(currentLine))
                    result = currentLine;
                else if (result == "" && directRegex.IsMatch(currentLine))
                    result = currentLine;
                else if (result == "" && directTemperatureRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    splittedTask[1] = temperatureExt[temperatureDict[splittedTask[1].ToUpper()]];
                    result = string.Join(" ", splittedTask);
                }
                else if (result == "" && directMassRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    splittedTask = new string[] { splittedTask[0], String.Join(" ", splittedTask.Skip(1)) };
                    string exUnit = splittedTask[1];
                    double exVal = double.Parse(currentLine.Split(' ')[0], CultureInfo.InvariantCulture);
                    exUnit = massExt[massDict[exUnit]];
                    if (exUnit == "lb")
                        exUnit = exVal == 1 || exVal == -1 ? "lb" : "lbs";
                    result = ToNumberString(exVal) + " " + exUnit;
                }
                else if (result == "" && directFrequencyRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    splittedTask = new string[] { splittedTask[0], string.Join(" ", splittedTask.Skip(1)) };
                    splittedTask[1] = frequencyExt[frequencyDict[splittedTask[1]]];
                    result = string.Join(" ", splittedTask);
                }
                else if (result == "" && directTimeRegex.IsMatch(currentLine))
                {
                    double exVal = double.Parse(currentLine.Split(' ')[0]);
                    string exUnit = currentLine.Split(' ')[1];
                    exUnit = timeExt[timeDict[exUnit]];
                    result = ToNumberString(exVal) + " " + exUnit;
                }
                else if (result == "" && directLengthRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    splittedTask = new string[] { splittedTask[0], string.Join(" ", splittedTask.Skip(1)) };
                    string exUnit = splittedTask[1];
                    double exVal = double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    exUnit = lengthExt[lengthDict[exUnit]];
                    result = ToNumberString(exVal) + " " + exUnit;

                }
                else if (result == "" && directDataSizeRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    splittedTask = new string[] { splittedTask[0], string.Join(" ", splittedTask.Skip(1)) };
                    string exUnit = splittedTask[1];
                    double exVal = double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    if (exUnit != "b" && exUnit != "B")
                        exUnit = exUnit.ToLower();
                    exUnit = dataSizeExt[dataSizeDict[exUnit]];
                    result = ToNumberString(exVal) + " " + exUnit;
                }
                else if (result == "" && numberRegex.IsMatch(currentLine.Trim()))
                {
                    result = currentLine;
                }
                else if (result == "" && directBinOctRegex.IsMatch(currentLine))
                {
                    if (!(currentLine.StartsWith("bin:") && Regex.IsMatch(currentLine, @"[2-7]")))
                    {
                        result = currentLine.Substring((currentLine.StartsWith("oct:") || currentLine.StartsWith("bin:")) ? 4 : 0);
                        result = result.Replace(" ", "");
                        if (result.Length % 4 != 0)
                            result = result.PadLeft(result.Length + (4 - (result.Length % 4)), '0');
                        result = string.Join(" ", result.Split(4));
                    }
                }
                else if (result == "" && directAngleRegex.IsMatch(currentLine))
                {
                    string[] splittedTask = currentLine.Split(' ');
                    splittedTask = new string[] { splittedTask[0], string.Join(" ", splittedTask.Skip(1)) };
                    double exVal = double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    string currentUnitString = splittedTask[1].ToLower().Trim();
                    currentUnitString = angleExt[angleDict[currentUnitString]];
                    result = ToNumberString(exVal) + " " + currentUnitString;
                }
                #endregion
            }
            return result;
        }

        /// <summary>
        /// Converts a double to a string
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string ToNumberString(double val)
        {
            string valString = val.ToString("N10", CultureInfo.InvariantCulture).Replace(",", "");
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
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Calcify File (*.Calcify)|*.Calcify|All Files (*.*)|*.*", FileName = "" };
            if (openFileDialog.ShowDialog() == true)
                openFile(openFileDialog.FileName);
        }

        private void contextSaveButton_Click(object sender, RoutedEventArgs e)
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

        private void contextSaveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.Calcify)|*.Calcify|All Files (*.*)|*.*", FileName = documentPath != "" ? Path.GetFileNameWithoutExtension(documentPath) : "" };
            if (saveFileDialog.ShowDialog() == true)
                saveFile(saveFileDialog.FileName);
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

        private void contextExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Drag & Drop
        private void Window_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files[0].ToLower().EndsWith(".Calcify"))
                openFile(files[0]);
            DropPanel.IsEnabled = false;
            DropPanel.IsHitTestVisible = false;
            EditorContainer.Effect = new BlurEffect { Radius = 0 };
        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            DropPanel.IsEnabled = true;
            DropPanel.IsHitTestVisible = true;
            EditorContainer.Effect = new BlurEffect { Radius = 10 };
        }

        private void Window_DragLeave(object sender, DragEventArgs e)
        {
            DropPanel.IsEnabled = false;
            DropPanel.IsHitTestVisible = false;
            EditorContainer.Effect = new BlurEffect { Radius = 0 };
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
//  - write docs
//  - 'About' change date


// Future TODO:
//  - Plugin Support
//  - Plugin Marketplace
//  - volume units
//  - pressure units
//  - equations
