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
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Xml;
using static Calcify.SyntaxFile;

namespace Calcify
{
    public partial class MainWindow : Window
    {
        #region Variables
        #region Pattern
        string AnglePattern = Math.Units.Patterns.AnglePattern;
        public string CurrencyPattern = @"\b(EUR|AED|AFN|ALL|AMD|ANG|AOA|ARS|AUD|AWG|AZN|BAM|BBD|BDT|BGN|BHD|BIF|BMD|BND|BOB|BRL|BSD|BTC|BTN|BWP|BYN|BYR|BZD|CAD|CDF|CHF|CLF|CLP|CNY|COP|CRC|CUC|CUP|CVE|CZK|DJF|DKK|DOP|DZD|EGP|ERN|ETB|EUR|FJD|FKP|GBP|GEL|GGP|GHS|GIP|GMD|GNF|GTQ|GYD|HKD|HNL|HRK|HTG|HUF|IDR|ILS|IMP|INR|IQD|IRR|ISK|JEP|JMD|JOD|JPY|KES|KGS|KHR|KMF|KPW|KRW|KWD|KYD|KZT|LAK|LBP|LKR|LRD|LSL|LTL|LVL|LYD|MAD|MDL|MGA|MKD|MMK|MNT|MOP|MRO|MUR|MVR|MWK|MXN|MYR|MZN|NAD|NGN|NIO|NOK|NPR|NZD|OMR|PAB|PEN|PGK|PHP|PKR|PLN|PYG|QAR|RON|RSD|RUB|RWF|SAR|SBD|SCR|SDG|SEK|SGD|SHP|SLL|SOS|SRD|STD|SVC|SYP|SZL|THB|TJS|TMT|TND|TOP|TRY|TTD|TWD|TZS|UAH|UGX|USD|UYU|UZS|VEF|VND|VUV|WST|XAF|XAG|XAU|XCD|XDR|XOF|XPF|YER|ZAR|ZMK|ZMW|ZWL)\b";
        string DataSizePattern = Math.Units.Patterns.DataSizePattern;
        string FrequencyPattern = Math.Units.Patterns.FrequencyPattern;
        string LengthPattern = Math.Units.Patterns.LengthPattern;
        string MassPattern = Math.Units.Patterns.MassPattern;
        string TemperaturePattern = Math.Units.Patterns.TemperaturePattern;
        string TimePattern = Math.Units.Patterns.TimePattern;
        string ConstantsPattern = @"(π|\b(p(h)?i|e)\b)";
        #endregion
        #region Regex
        Regex prevRegex = new Regex(@"\b(previous|prev|answer|ans)\b");

        Regex sqrtRegex = new Regex(@"\b(?<func>sqrt)\((?<variable1>(-)?\d+(\.\d+)?)\)(( )?|$)");

        Regex dateTimeKeyWordsRegex = new Regex(@"\b(?i)(((now|time)(\.(hour|minute|second))?)|(yesterday|date|today|tomorrow)(\.(day|month|year|weekday|dayofyear|weekofyear))?)(?-i)\b");
        Regex dateTimeRegex = new Regex(@"^(\d{2}(\d{2})?\/\d{1,2}\/\d{1,2}( \d{1,2}:\d{1,2}(:\d{1,2})?)?|\d{1,2}:\d{1,2}(:\d{1,2})?)$");
        Regex PermutationRegex = new Regex(@"(?<n>\d+)C(?<r>\d+)");
        Regex calculatorRegex = new Regex(@"^((\d+(\.\d+)?)|\||(\+|\-|\*|\/|\^)(?!\+|\*|\/|\^|\!)|(|\(|\)|\!))*$");
        Regex directRegex = new Regex(@"^(-?((\d{1,3},)*\d{3}|\d+)(\.\d+)?( (" + Math.Units.Patterns.allUnitPatterns + "))?|\\d{4}\\/\\d{2}\\/\\d{2}( \\d{2}:\\d{2}:\\d{2})?|\\d{2}:\\d{2}(:\\d{2})?)$");
        Regex constantsRegex;
        Regex sumAvgRegex;
        Regex inlineCalculationRegex = new Regex(@"(?<=\{)(?<subtask>[^{}]*)(?=\})", RegexOptions.RightToLeft);
        public Regex currencyRegex;

        Regex allUnitRegex;
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
        Dictionary<TemperatureUnit, string> temperatureExt = new Dictionary<TemperatureUnit, string>();
        Dictionary<TimeUnit, string> timeExt = new Dictionary<TimeUnit, string>();

        Dictionary<string, Enum> allUnitsDict = new Dictionary<string, Enum>();
        Dictionary<Enum, string> allUnitsExt = new Dictionary<Enum, string>();
        #endregion
        private string oldTotalValue = "";
        private string windowTitle = "";
        private bool unsavedChanges = false;
        private RegistryWatcher watcher = null;
        private SyntaxFile lightSyntax = new SyntaxFile(SyntaxFile.Theme.Light);
        private SyntaxFile darkSyntax = new SyntaxFile(SyntaxFile.Theme.Dark);

        public int returnState = -1;
        public About aboutWindow = null;
        public Dictionary<string, double> currencyDict = new Dictionary<string, double>();
        public DialogWindow dialogWindow = null;
        public Settings settingsWindow = null;

        private Dictionary<Type, Func<double, Enum, Enum, double>> converterDict = new Dictionary<Type, Func<double, Enum, Enum, double>>();
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
                        SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
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

            titleLabel.MouseLeftButtonDown += TitleLabel_MouseLeftButtonDown;
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
            currencyRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + CurrencyPattern + ") (in(to)?|to|as) (?<targetUnit>" + CurrencyPattern + ")$");
            allUnitRegex = new Regex(@"(?<result>(?<value>-?((\d{1,3},)*\d{3}|\d+)(\.\d+)?) (?<srcUnit>(" + Math.Units.Patterns.allUnitPatterns + "))) (in(to)?|to) (?<targetUnit>(" + Math.Units.Patterns.allUnitPatterns + "))");
            #endregion

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            DropPanel.Visibility = Visibility.Visible;
            resultEditor.TextArea.Caret.CaretBrush = Brushes.Transparent;
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

        /// <summary>
        /// Allow dragging the window when the user clicks (and drags) on the title label.
        /// Also support double-click to maximize/restore (common titlebar behavior).
        /// Tooltip continues to show on hover because we did not suppress it.
        /// </summary>
        private void TitleLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Double-click: toggle maximize/restore
            if (e.ClickCount == 2)
            {
                this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                return;
            }

            // Single click + move: start window drag
            try
            {
                this.DragMove();
            }
            catch (InvalidOperationException)
            {
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
                result = Calculate(mainEditor.Document.GetText(line.Offset, line.Length)).Trim();
                Match m = directRegex.Match(result);
                if (directRegex.Match(result).Success || new Regex(@"^[^\d]*$").IsMatch(result))
                    newDocument.Text = newDocument.Text + result;
                newDocument.Text += "\n";
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
                        SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
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
                titleLabel.ToolTip = null;
            else
            {
                titleLabel.ToolTip = new ToolTip();
                ((ToolTip)titleLabel.ToolTip).Content = "Author: " + documentAuthor + "\nLast edited by: " + documentEditedBy + "\nCreated: " + Calculator.UnixTimeStampToDateTime(documentCreated).ToString() + "\nModified: " + Calculator.UnixTimeStampToDateTime(documentModified).ToString() + "\nPath: " + Path.GetDirectoryName(documentPath);
                if (Properties.Settings.Default.DarkMode)
                {
                    ((ToolTip)titleLabel.ToolTip).Background = new SolidColorBrush { Color = Color.FromRgb(37, 38, 43) };
                    ((ToolTip)titleLabel.ToolTip).Foreground = new SolidColorBrush { Color = Color.FromRgb(180, 180, 180) };
                }
                else
                {
                    ((ToolTip)titleLabel.ToolTip).Background = new SolidColorBrush { Color = Color.FromRgb(241, 242, 247) };
                    ((ToolTip)titleLabel.ToolTip).Foreground = new SolidColorBrush { Color = Color.FromRgb(0, 0, 0) };
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

        /// <summary>
        /// (De)activate the dark mode
        /// </summary>
        /// <param name="newValue"></param>
        private void DarkModeChanged(bool newValue)
        {
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
            /*int summedLines;
            int currentLineNumber = mainEditor.Document.GetLineByOffset(mainEditor.CaretOffset).LineNumber + 1;
            string s = CalculateSum(currentLineNumber, resultEditor.Document, out summedLines);
            if (summedLines != 0)
                totalLabel.Content = "Total: " + s;
            else
                totalLabel.Content = "";
            */
        }

        private string Calculate(string input, bool acceptPrevious = true)
        {
            string originalInput = input;
            bool dateCalculation = false;

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

            while (inlineCalculationRegex.IsMatch(input))
            {
                string subtask = inlineCalculationRegex.Match(input).Value;
                string inlineResult = Calculate(subtask, acceptPrevious);
                input = input.Replace("{" + subtask + "}", inlineResult);
            }

            // Replace all permutation expressions in the input
            input = ReplacePermutations(input);

            // Replace constants
            input = ReplaceConstants(input);

            // Replace Functions
            input = ReplaceTwoVariableFunctions(input);
            input = ReplaceOneVariableFunctions(input);

            // Replace DateTime variables
            string substep = DateTimeCalculation(input);
            if (substep != input)
            {
                input = substep;
                dateCalculation = true;
            }


            if (acceptPrevious)
                foreach (Match match in sumAvgRegex.Matches(input))
                    input = input.Replace(match.Value, "{/" + match.Value + "/}");

            if (allUnitRegex.IsMatch(input))
            {
                foreach (Match match in allUnitRegex.Matches(input))
                {
                    double value = double.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);
                    string srcUnitRaw = match.Groups["srcUnit"].Value;
                    string targetUnitRaw = match.Groups["targetUnit"].Value;
                    if (!srcUnitRaw.StartsWith("°") && srcUnitRaw.Length != 1) srcUnitRaw = srcUnitRaw.ToLower();
                    else if (srcUnitRaw.StartsWith("°")) srcUnitRaw = srcUnitRaw.ToUpper();
                    if (!targetUnitRaw.StartsWith("°") && targetUnitRaw.Length != 1) targetUnitRaw = targetUnitRaw.ToLower();
                    else if (targetUnitRaw.StartsWith("°")) targetUnitRaw = targetUnitRaw.ToUpper();
                    Enum srcUnit = allUnitsDict[srcUnitRaw];
                    Enum targetUnit = allUnitsDict[targetUnitRaw];
                    if (srcUnit.GetType() != targetUnit.GetType())
                        continue;
                    Type type = srcUnit.GetType();
                    double convertedValue = converterDict[type].Invoke(value, srcUnit, targetUnit);
                    input = input.Replace(match.Value, ToNumberString(System.Math.Round(convertedValue, Properties.Settings.Default.Digits)) + " " + allUnitsExt[targetUnit]);
                }
            }

            input = CurrencyConversion(input);

            // Execute Calculation
            if (calculatorRegex.IsMatch(input) && !dateCalculation)
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
                switch (match.Value)
                {
                    case "pi":
                    case "π":
                        text = constantsRegex.Replace(text, ToNumberString(System.Math.Round(System.Math.PI, Properties.Settings.Default.Digits)), 1);
                        break;
                    case "phi":
                        text = constantsRegex.Replace(text, ToNumberString(System.Math.Round(Constants.Phi, Properties.Settings.Default.Digits)), 1);
                        break;
                    case "e":
                        text = constantsRegex.Replace(text, ToNumberString(System.Math.Round(System.Math.E, Properties.Settings.Default.Digits)), 1);
                        break;
                }
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
            Regex functionsRegex = new Regex(@"\b(?<func>(diff|rand|randint|round))\((?<variable1>-?\d+(\.\d+)?), ?(?<variable2>-?\d+(\.\d+)?)\)", RegexOptions.RightToLeft);
            // Replace and execute functions
            while (functionsRegex.IsMatch(input))
            {
                Match match = functionsRegex.Match(input);
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
                        input = input.Replace(match.Value, ToNumberString(System.Math.Round(generatedNumber, Properties.Settings.Default.Digits)));
                        break;
                    // Generate random double
                    case "rand":
                        generatedNumber = GetRandomDouble(minNumber, maxNumber);
                        generatedNumber = System.Math.Round(generatedNumber, Properties.Settings.Default.Digits);
                        input = input.Replace(match.Value, ToNumberString(System.Math.Round(generatedNumber, Properties.Settings.Default.Digits)));
                        break;
                    // Generate random integer
                    case "randint":
                        generatedNumber = new Random().Next((int)minNumber, (int)maxNumber);
                        input = input.Replace(match.Value, ToNumberString(generatedNumber)).Trim();
                        break;
                    // Round number
                    case "round":
                        generatedNumber = System.Math.Round(minNumber, (int)maxNumber);
                        input = input.Replace(match.Value, ToNumberString(generatedNumber)).Trim();
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
                        System.Globalization.Calendar Calendar = CultureInfo.InvariantCulture.Calendar;
                        int weekNumber = Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                        timeString = weekNumber.ToString();
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

        /// <summary>
        /// Converts a double to a string
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string ToNumberString(double val)
        {
            string valString = val.ToString("N10", CultureInfo.InvariantCulture);
            while (valString.Contains(".") && (valString.EndsWith("0") || valString.EndsWith(".")))
                valString = valString.Substring(0, valString.Length - 1);
            return valString;
        }

        /// <summary>
        /// Associates an enumeration value with a display name and a set of synonym strings for lookup purposes.
        /// </summary>
        /// <remarks>This method enables flexible lookup of enumeration values by allowing multiple
        /// synonyms and a display name to be mapped to a single value. Synonyms should be unique within the context to
        /// avoid key collisions.</remarks>
        /// <typeparam name="T">The enumeration type to associate with the display name and synonyms. Must be derived from <see
        /// cref="Enum"/>.</typeparam>
        /// <param name="enumValue">The enumeration value to register.</param>
        /// <param name="display">The display name to associate with the enumeration value.</param>
        /// <param name="synonyms">An array of synonym strings that can be used to reference the enumeration value.</param>
        private void AddUnit<T>(T enumValue, string display, params string[] synonyms) where T : Enum
        {
            var e = (Enum)(object)enumValue;
            foreach (var s in synonyms)
                allUnitsDict.Add(s, e);
            allUnitsExt.Add(e, display);
        }

        /// <summary>
        /// Initializes the unit dictionaries and conversion delegates for supported measurement types.
        /// </summary>
        /// <remarks>This method sets up internal mappings between unit types, their string
        /// representations, and conversion functions. It should be called before performing any unit conversions to
        /// ensure all supported units and their aliases are recognized.</remarks>
        private void setUpDictionaries()
        {
            // Temperatures
            AddUnit(TemperatureUnit.Kelvin, "K", "K");
            AddUnit(TemperatureUnit.Fahrenheit, "°F", "°F");
            AddUnit(TemperatureUnit.Celsius, "°C", "°C");
            AddUnit(TemperatureUnit.Reaumur, "°Re", "°RE");
            AddUnit(TemperatureUnit.Rankine, "°R", "°R", "°RA");

            // Time
            AddUnit(TimeUnit.Century, "century", "c", "century", "centuries");
            AddUnit(TimeUnit.Decade, "decade", "decade", "decades");
            AddUnit(TimeUnit.Year, "year", "year", "years", "yr", "yrs");
            AddUnit(TimeUnit.Month, "month", "month", "months", "mth");
            AddUnit(TimeUnit.Week, "week", "week", "weeks", "wk");
            AddUnit(TimeUnit.Day, "day", "day", "days", "d");
            AddUnit(TimeUnit.Hour, "h", "h", "hour", "hours");
            AddUnit(TimeUnit.Minute, "min", "min", "minute", "minutes");
            AddUnit(TimeUnit.Second, "s", "s", "sec", "second", "seconds");
            AddUnit(TimeUnit.Millisecond, "ms", "ms", "millisecond", "milliseconds");
            AddUnit(TimeUnit.Microsecond, "µs", "µs", "μs", "microsecond", "microseconds");
            AddUnit(TimeUnit.Nanosecond, "ns", "ns", "nanosecond", "nanoseconds");

            // Mass
            AddUnit(MassUnit.Ton, "t", "tons", "ton", "t");
            AddUnit(MassUnit.Kilogram, "kg", "kg", "kilogram", "kilograms");
            AddUnit(MassUnit.Gram, "g", "grams", "gram", "g");
            AddUnit(MassUnit.Milligram, "mg", "milligrams", "milligram", "mg");
            AddUnit(MassUnit.Microgram, "μg", "micrograms", "microgram", "µg", "μg");
            AddUnit(MassUnit.LongTon, "lt", "long tons", "long ton", "lt");
            AddUnit(MassUnit.ShortTon, "tn", "short ton", "short tons", "tn");
            AddUnit(MassUnit.Stone, "st", "st", "stone", "stones");
            AddUnit(MassUnit.Pounds, "lb", "pounds", "pound", "lbs", "lb");
            AddUnit(MassUnit.Ounce, "oz.", "oz", "oz.", "ounce", "ounces");

            // Length
            AddUnit(LengthUnit.Nanometer, "nm", "nanometer", "nm");
            AddUnit(LengthUnit.Micrometer, "μm", "micrometer", "μm", "µm");
            AddUnit(LengthUnit.Millimeter, "mm", "millimeter", "mm");
            AddUnit(LengthUnit.Centimeter, "cm", "centimeter", "cm");
            AddUnit(LengthUnit.Decimeter, "dm", "decimeter", "dm");
            AddUnit(LengthUnit.Meter, "m", "meter", "m");
            AddUnit(LengthUnit.Kilometer, "km", "kilometer", "km");
            AddUnit(LengthUnit.Decameter, "dam", "decameter", "dam");
            AddUnit(LengthUnit.Hectometer, "hm", "hectometer", "hm");
            AddUnit(LengthUnit.Mile, "mi", "mile", "miles", "mi");
            AddUnit(LengthUnit.Yard, "yd", "yard", "yd");
            AddUnit(LengthUnit.Feet, "ft", "foot", "feet", "ft");
            AddUnit(LengthUnit.Inch, "in", "inch", "in");

            // Frequency
            AddUnit(FrequencyUnit.Hertz, "Hz", "hz", "hertz");
            AddUnit(FrequencyUnit.Kilohertz, "kHz", "khz", "kilohertz");
            AddUnit(FrequencyUnit.Megahertz, "MHz", "mhz", "megahertz");
            AddUnit(FrequencyUnit.Gigahertz, "GHz", "ghz", "gigahertz");

            // Data size
            AddUnit(DataSizeUnit.Bit, "b", "b", "bit", "bits");
            AddUnit(DataSizeUnit.Byte, "B", "B", "byte", "bytes");
            AddUnit(DataSizeUnit.Kilobyte, "KB", "kb", "kilobyte", "kilobytes");
            AddUnit(DataSizeUnit.Megabyte, "MB", "mb", "megabyte", "megabytes");
            AddUnit(DataSizeUnit.Gigabyte, "GB", "gb", "gigabyte", "gigabytes");
            AddUnit(DataSizeUnit.Terabyte, "TB", "tb", "terabyte", "terabytes");
            AddUnit(DataSizeUnit.Petabyte, "PB", "pb", "petabyte", "petabytes");
            AddUnit(DataSizeUnit.Exabyte, "EB", "eb", "exabyte", "exabytes");

            // Angle
            AddUnit(AngleUnit.Gradian, "gon", "gradian", "gon", "grad");
            AddUnit(AngleUnit.Degree, "deg", "degree", "deg", "°");
            AddUnit(AngleUnit.Milliradian, "mil", "milliradian", "mil");
            AddUnit(AngleUnit.Radian, "rad", "radian", "rad");
            AddUnit(AngleUnit.AngularMinute, "arcmin", "angular minutes", "angular minute", "arcmin");
            AddUnit(AngleUnit.AngularSecond, "arcsec", "arcsec", "angular second", "angular seconds");

            converterDict = new Dictionary<Type, Func<double, Enum, Enum, double>>
            {
                { typeof(MassUnit), (val, current, target) => Converter.MassConverter(val, (MassUnit)current, (MassUnit)target) },
                { typeof(DataSizeUnit), (val, current, target) => Converter.DataSizeConverter(val, (DataSizeUnit)current, (DataSizeUnit)target) },
                { typeof(FrequencyUnit), (val, current, target) => Converter.FrequencyConverter(val, (FrequencyUnit)current, (FrequencyUnit)target) },
                { typeof(LengthUnit), (val, current, target) => Converter.LengthConverter(val, (LengthUnit)current, (LengthUnit)target) },
                { typeof(AngleUnit), (val, current, target) => Converter.AngleConverter(val, (AngleUnit)current, (AngleUnit)target) },
                { typeof(TimeUnit), (val, current, target) => Converter.TimeConverter(val, (TimeUnit)current, (TimeUnit)target) },
                { typeof(TemperatureUnit), (val, current, target) => Converter.TemperatureConverter(val, (TemperatureUnit)current, (TemperatureUnit)target) }
            };

        }

        /// <summary>
        /// Updates the syntax highlighting rules for various domain-specific patterns, including currency, data size
        /// formats, time keywords, frequency, and other measurement units.
        /// </summary>
        /// <remarks>This method refreshes the highlighting configuration by adding comments, units,
        /// functions, and constants to the underlying syntax engine. It should be called whenever the relevant patterns
        /// or highlighting rules need to be reapplied, such as after changes to pattern definitions or initialization
        /// of the syntax engine.</remarks>
        private void UpdateSyntaxHighlighting()
        {
            darkSyntax.AddComment("Currency");
            darkSyntax.AddUnits(CurrencyPattern);
            darkSyntax.AddComment("Data Size Formats");
            darkSyntax.AddUnits(DataSizePattern);
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
            darkSyntax.AddComment("Time Keywords");
            darkSyntax.AddFunction(@"(((yester|to)?day|tomorrow)(\.(day(ofyear)?|week(day|ofyear)?|month|year))?|now(\.(hour|minute|second))?)");
            darkSyntax.AddComment("Constants");
            darkSyntax.AddConstants(ConstantsPattern);
            darkSyntax.AddComment("Keywords");
            darkSyntax.AddFunction("\\b(in(to)?|as|plus|add|minus|of(f)?|remove|prev(ious)?|last|avg|sum|to)\\b");
            darkSyntax.AddComment("Functions");
            darkSyntax.AddFunction("(\\b(diff|round|rand(int)?|sqrt|root|(?=\\d)C(?=\\d)))");
            darkSyntax.AddComment("Brackets and signs");
            darkSyntax.AddFunction("\\(|\\{|\\)|\\}|,|!");
            darkSyntax.AddComment("Operators");
            darkSyntax.AddOperator("(\\+|\\-|\\*|\\/|\\||\\^)");
            darkSyntax.AddComment("Numbers");
            darkSyntax.AddNumbers("(-?((\\d{1,3},)*\\d{3}|\\d+)(\\.\\d+)?)");

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
                        SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
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
                        SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
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
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
            if (openFileDialog.ShowDialog() == true)
                openFile(openFileDialog.FileName);
        }

        private void CtrlShiftS_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = documentPath != "" ? Path.GetFileNameWithoutExtension(documentPath) : "" };
            if (saveFileDialog.ShowDialog() == true)
                saveFile(saveFileDialog.FileName);
        }

        private void CtrlS_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (documentPath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
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
//  - calculations within functions

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

//  - accept inches, bytes, gallons, cups, speed (kmh, mh, ...), data speed (mbps, gbps, ...), tmrw, nmi (nautical miles) (1 nmi = 1852 m), carat (1 ct = 0.2 g), turn (turn, revolution) (1 turn = 360 degrees), THz, pressure, energy, Power, area, volumes (look supported-units.md) as keyword
//  - basic calculation 1024 * x does not work
//  - fix syntax color (days)
//  - multiple conversions (100 cm to m to feet)
//  - ask to save when drag and dropped
//  - currency calculation
//  - time difference (today - tomorrow, now - 09:00)
//  - maybe update architecture.md
//  - Time Formats (now.format("HH:mm:ss"), today.format("yyyy-MM-dd"))



// Future TODO:
//  - Plugin Support
//  - Plugin Marketplace
//  - equations


// Done:
//  - added theme toggle button 
//  - optimized data value conversion
//  - added Permutations and Combinations functions
//  - added time parts (today.year, today.month, today.day, today.dayOfWeek, now.hour, now.minute, now.second)
//  - added inline tasks
//  - fixed now syntax highlighting
//  - changed the way syntax files are generated to make it less static and more flexible