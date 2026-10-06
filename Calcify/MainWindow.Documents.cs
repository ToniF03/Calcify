using Calcify.Math;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calcify
{
    public partial class MainWindow
    {
        public string documentPath = "";
        public string documentText = "";
        public string documentAuthor = "";
        public string documentEditedBy = "";
        public int documentCreated = 0;
        public int documentModified = 0;

        private bool ConfirmSaveChanges()
        {
            if (!unsavedChanges)
                return true;

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
            int dialogResult = dialogWindow.returnState;
            dialogWindow = null;

            if (dialogResult == 2)
                return true;
            if (dialogResult != 3)
                return false;

            if (documentPath != "")
            {
                SaveFile(documentPath);
                return true;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
            if (saveFileDialog.ShowDialog() != true)
                return false;

            SaveFile(saveFileDialog.FileName);
            return true;
        }

        /// <summary>
        /// Open a file
        /// </summary>
        /// <param name="path"></param>
        public void OpenFile(string path)
        {
            bool actionAllowed = ConfirmSaveChanges();

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
        public void SaveFile(string path)
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
    }
}
