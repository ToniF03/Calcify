using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calcify
{
    /// <summary>
    /// Interaktionslogik für About.xaml
    /// </summary>
    public partial class About : Window
    {
        License selectedLicense = License.None;
        public MainWindow _mainWindow = null;

        public About()
        {
            InitializeComponent();
            closeButton.Click += CloseButton_Click;
            LicenseDisplay.TextArea.Caret.CaretBrush = System.Windows.Media.Brushes.Transparent;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _mainWindow.aboutWindow = null;
        }

        private void ReleaseNotesButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tonif03.github.io/prod/Calcify#release-notes");
        }

        private void WebsiteButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tonif03.github.io/prod/Calcify/");
        }

        private void RepositoryButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ToniF03/Calcify");
        }

        private void BugsButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ToniF03/Calcify/issues");
        }

        private void LicenseButton_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (this.Resources["OpenLicenseOverview"] as Storyboard);
            sb.Begin();
            BackButton.Visibility = Visibility.Visible;
        }

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

        private void LicenseScroller_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - (double)e.Delta);
            e.Handled = true;
        }

        private void CalcifyLicenseButton_Click(object sender, RoutedEventArgs e)
        {
            selectedLicense = License.ToniF03_Calcify_LICENSE;
            LoadLicense();
            Storyboard sb = (this.Resources["OpenLicenseScreen"] as Storyboard);
            sb.Begin();
        }

        private void JsonLicenseButton_Click(object sender, RoutedEventArgs e)
        {
            selectedLicense = License.Newtonsoft_Json_LICENSE;
            LoadLicense();
            Storyboard sb = (this.Resources["OpenLicenseScreen"] as Storyboard);
            sb.Begin();
        }

        private void AvalonEditLicenseButton_Click(object sender, RoutedEventArgs e)
        {
            selectedLicense = License.ICSharpCode_AvalonEdit_LICENSE;
            LoadLicense();
            Storyboard sb = (this.Resources["OpenLicenseScreen"] as Storyboard);
            sb.Begin();
        }

        private void RobotoFontLicenseButton_Click(object sender, RoutedEventArgs e)
        {
            selectedLicense = License.ChristanRobertson_Roboto_LICENSE;
            LoadLicense();
            Storyboard sb = (this.Resources["OpenLicenseScreen"] as Storyboard);
            sb.Begin();
        }

        private void OctokitLicenseButton_Click(object sender, RoutedEventArgs e)
        {
            selectedLicense = License.GITHUB_Octokit_LICENSE;
            LoadLicense();
            Storyboard sb = (this.Resources["OpenLicenseScreen"] as Storyboard);
            sb.Begin();
        }

        private void LoadLicense()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string result = "";
            string resourceName = "";

            if (selectedLicense == License.Newtonsoft_Json_LICENSE)
                resourceName = "Calcify.Licenses.Newtonsoft_Json_LICENSE.md";
            else if (selectedLicense == License.ICSharpCode_AvalonEdit_LICENSE)
                resourceName = "Calcify.Licenses.ICSharpCode_AvalonEdit_LICENSE.md";
            else if (selectedLicense == License.ToniF03_Calcify_LICENSE)
                resourceName = "Calcify.Licenses.ToniF03_Calcify_LICENSE.md";
            else if (selectedLicense == License.ChristanRobertson_Roboto_LICENSE)
                resourceName = "Calcify.Licenses.ChristanRobertson_Roboto_LICENSE.md";
            else if (selectedLicense == License.GITHUB_Octokit_LICENSE)
                resourceName = "Calcify.Licenses.GITHUB_Octokit_LICENSE.md";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            LicenseScroller.ScrollToTop();
            LicenseDisplay.Text = result;
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string result = "";
            string resourceName = "";

            if (selectedLicense == License.Newtonsoft_Json_LICENSE)
                resourceName = "Calcify.Licenses.Newtonsoft_Json_LICENSE.md";
            else if (selectedLicense == License.ICSharpCode_AvalonEdit_LICENSE)
                resourceName = "Calcify.Licenses.ICSharpCode_AvalonEdit_LICENSE.md";
            else if (selectedLicense == License.ToniF03_Calcify_LICENSE)
                resourceName = "Calcify.Licenses.ToniF03_Calcify_LICENSE.md";
            else if (selectedLicense == License.ChristanRobertson_Roboto_LICENSE)
                resourceName = "Calcify.Licenses.ChristanRobertson_Roboto_LICENSE.md";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            //string path = System.IO.Path.GetTempPath() + "license.txt";
            //File.WriteAllText(path, result);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                FlowDocument flowDocument = new FlowDocument();
                flowDocument.PagePadding = new Thickness(94.5f);
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

        private enum License 
        {
            None,
            ICSharpCode_AvalonEdit_LICENSE,
            Newtonsoft_Json_LICENSE,
            ToniF03_Calcify_LICENSE,
            ChristanRobertson_Roboto_LICENSE,
            GITHUB_Octokit_LICENSE
        }
    }
}
