using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Calcify
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// This window displays application information and bundled component licenses.
    /// </summary>
    public partial class About : Window
    {
        // Currently selected license (default: None)
        License selectedLicense = License.None;

        // Reference to the main window so we can notify it when this window closes
        public MainWindow _mainWindow = null;

        /// <summary>
        /// Constructor: initializes components and wires event handlers.
        /// </summary>
        public About()
        {
            InitializeComponent();

            // Close button handler
            closeButton.Click += CloseButton_Click;

            // Make AvalonEdit caret invisible to present the license text as a read-only view
            LicenseDisplay.TextArea.Caret.CaretBrush = System.Windows.Media.Brushes.Transparent;

            // License overview buttons open the license overview animation
            CalcifyLicenseButton.Click += CalcifyLicenseButton_Click;
            JsonLicenseButton.Click += CalcifyLicenseButton_Click;
            AvalonEditLicenseButton.Click += CalcifyLicenseButton_Click;
            RobotoFontLicenseButton.Click += CalcifyLicenseButton_Click;
            LicenseButton.Click += LicenseButton_Click;

            // Back button handler for navigation
            BackButton.Click += BackButton_Click;

            // External links for release notes, website, repository and issue tracker
            ReleaseNotesButton.Click += WebsiteButton_Click;
            WebsiteButton.Click += WebsiteButton_Click;
            RepositoryButton.Click += WebsiteButton_Click;
            BugsButton.Click += WebsiteButton_Click;

            // Handle mouse wheel for the license scroll viewer to enable smooth scrolling
            LicenseScroller.PreviewMouseWheel += LicenseScroller_PreviewMouseWheel;
        }

        /// <summary>
        /// Closes the About window and clears the reference in the main window.
        /// </summary>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _mainWindow.aboutWindow = null;
        }

        /// <summary>
        /// Opens the appropriate website depending on which button was clicked.
        /// </summary>
        private void WebsiteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "ReleaseNotesButton":
                    System.Diagnostics.Process.Start("https://tonif03.github.io/projects/calcify/#release-notes");
                    break;
                case "WebsiteButton":
                    System.Diagnostics.Process.Start("https://tonif03.github.io/projects/calcify/");
                    break;
                case "RepositoryButton":
                    System.Diagnostics.Process.Start("https://github.com/ToniF03/Calcify");
                    break;
                case "BugsButton":
                    System.Diagnostics.Process.Start("https://github.com/ToniF03/Calcify/issues");
                    break;
            }
        }

        /// <summary>
        /// Opens the license overview animation and reveals the Back button.
        /// </summary>
        private void LicenseButton_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (this.Resources["OpenLicenseOverview"] as Storyboard);
            sb.Begin();
            BackButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles Back navigation depending on the current frame offset.
        /// Uses storyboards to animate transitions.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.RenderTransform.Value.OffsetX == -500)
            {
                Storyboard sb = (this.Resources["BackToAbout"] as Storyboard);
                sb.Begin();
                BackButton.Visibility = Visibility.Hidden;
            }
            else if (mainFrame.RenderTransform.Value.OffsetX == -1000)
            {
                Storyboard sb = (this.Resources["BackToLicenseOverview"] as Storyboard);
                sb.Begin();
            }
        }

        /// <summary>
        /// Custom mouse wheel handling for the license ScrollViewer.
        /// This ensures wheel delta scrolls the viewer even when inner controls have focus.
        /// </summary>
        private void LicenseScroller_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - (double)e.Delta);
            e.Handled = true;
        }

        /// <summary>
        /// Called when a specific license button is clicked.
        /// Determines which license resource to load and opens the license screen.
        /// </summary>
        private void CalcifyLicenseButton_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "CalcifyLicenseButton":
                    selectedLicense = License.ToniF03_Calcify_LICENSE;
                    break;
                case "JsonLicenseButton":
                    selectedLicense = License.Newtonsoft_Json_LICENSE;
                    break;
                case "AvalonEditLicenseButton":
                    selectedLicense = License.ICSharpCode_AvalonEdit_LICENSE;
                    break;
                case "RobotoFontLicenseButton":
                    selectedLicense = License.ChristanRobertson_Roboto_LICENSE;
                    break;
                default:
                    selectedLicense = License.None;
                    break;
            }

            // Load the selected license text into the display and reset scroll position
            LicenseDisplay.Text = LoadLicense();
            LicenseScroller.ScrollToTop();

            // Start the animation to show the license detail screen
            Storyboard sb = (this.Resources["OpenLicenseScreen"] as Storyboard);
            sb.Begin();
        }

        /// <summary>
        /// Loads the selected license text from the assembly's embedded resources.
        /// Note: resourceName must match the manifest resource name.
        /// </summary>
        private string LoadLicense()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string result = "";
            string resourceName = "";

            // Map the selected license enum to a resource name
            switch (selectedLicense)
            {
                case License.ToniF03_Calcify_LICENSE:
                    resourceName = assembly.GetManifestResourceNames()
                                   .Single(str => str.EndsWith("ToniF03_Calcify_LICENSE.md"));
                    break;
                case License.Newtonsoft_Json_LICENSE:
                    resourceName = assembly.GetManifestResourceNames()
                                   .Single(str => str.EndsWith("Newtonsoft_Json_LICENSE.md"));
                    break;
                case License.ICSharpCode_AvalonEdit_LICENSE:
                    resourceName = assembly.GetManifestResourceNames()
                                   .Single(str => str.EndsWith("ICSharpCode_AvalonEdit_LICENSE.md"));
                    break;
                case License.ChristanRobertson_Roboto_LICENSE:
                    resourceName = assembly.GetManifestResourceNames()
                                   .Single(str => str.EndsWith("ChristanRobertson_Roboto_LICENSE.md"));
                    break;
            }



            // Read embedded resource stream. If resourceName is invalid this will throw.
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// Prints the currently loaded license using a FlowDocument to handle pagination.
        /// Each line from the license is added as a paragraph.
        /// </summary>
        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            string result = LoadLicense();

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Build a FlowDocument to paginate the license text for printing
                FlowDocument flowDocument = new FlowDocument();
                flowDocument.PagePadding = new Thickness(94.5f);

                // Add each line of the license as a separate paragraph
                foreach (string line in result.Split('\n'))
                {
                    Paragraph paragraph = new Paragraph();
                    paragraph.Margin = new Thickness(0, 0, 0, 0);
                    paragraph.Inlines.Add(new Run(line));
                    flowDocument.Blocks.Add(paragraph);
                }

                DocumentPaginator paginator = ((IDocumentPaginatorSource)flowDocument).DocumentPaginator;
                printDialog.PrintDocument(paginator, "Calcify Component License");
            }
        }

        /// <summary>
        /// Supported license identifiers used to select embedded resources.
        /// </summary>
        private enum License
        {
            None,
            ICSharpCode_AvalonEdit_LICENSE,
            Newtonsoft_Json_LICENSE,
            ToniF03_Calcify_LICENSE,
            ChristanRobertson_Roboto_LICENSE
        }
    }
}
