using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace Calcify
{
    public partial class MainWindow
    {
        public static RoutedCommand CtrlS = new RoutedCommand();
        public static RoutedCommand CtrlShiftS = new RoutedCommand();
        public static RoutedCommand CtrlO = new RoutedCommand();
        public static RoutedCommand Ctrl0 = new RoutedCommand();
        public static RoutedCommand CtrlPlus = new RoutedCommand();
        public static RoutedCommand CtrlMinus = new RoutedCommand();
        public static RoutedCommand CtrlN = new RoutedCommand();
        public static RoutedCommand CtrlD = new RoutedCommand();
        public static RoutedCommand CtrlFind = new RoutedCommand();
        public static RoutedCommand CtrlReplace = new RoutedCommand();
        public static RoutedCommand CtrlL = new RoutedCommand();
        public static RoutedCommand CtrlSlash = new RoutedCommand();
        public static RoutedCommand CtrlComma = new RoutedCommand();
        public static RoutedCommand Esc = new RoutedCommand();
        public static RoutedCommand F1 = new RoutedCommand();

        /// <summary>
        /// Handles the execution of the Ctrl+N command, prompting the user to save unsaved changes before creating a
        /// new document.
        /// </summary>
        /// <remarks>If there are unsaved changes, the method displays a dialog to allow the user to save,
        /// discard, or cancel before proceeding. If no changes are pending, a new document is created
        /// immediately.</remarks>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void CtrlN_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ConfirmSaveChanges())
                NewDocument();
        }

        private void Ctrl0_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyZoomFromString("100%");
        }

        private void CtrlPlus_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyZoomFromString((System.Math.Min(500, Properties.Settings.Default.EditorZoom * 100 + 10)) + "%");
        }

        private void CtrlMinus_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyZoomFromString((System.Math.Max(25, Properties.Settings.Default.EditorZoom * 100 - 10)) + "%");
        }

        private void CtrlO_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
            if (openFileDialog.ShowDialog() == true)
                OpenFile(openFileDialog.FileName);
        }

        private void CtrlD_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int caretLine = mainEditor.TextArea.Caret.Line;
            int caretColumn = mainEditor.TextArea.Caret.Column;
            string lineText = mainEditor.Document.GetText(mainEditor.Document.GetLineByNumber(caretLine));
            mainEditor.Document.Insert(mainEditor.Document.GetLineByNumber(caretLine).Offset, lineText + Environment.NewLine);
            mainEditor.TextArea.Caret.Line = caretLine + 1;
            mainEditor.TextArea.Caret.Column = caretColumn;
        }

        private void CtrlSlash_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int caretLine = mainEditor.TextArea.Caret.Line;
            string lineText = mainEditor.Document.GetText(mainEditor.Document.GetLineByNumber(caretLine));
            if (lineText.TrimStart().StartsWith("# "))
                mainEditor.Document.Replace(mainEditor.Document.GetLineByNumber(caretLine).Offset, lineText.Length, lineText.Replace("# ", ""));
            else if (lineText.TrimStart().StartsWith("#"))
                mainEditor.Document.Replace(mainEditor.Document.GetLineByNumber(caretLine).Offset, lineText.Length, lineText.Replace("#", ""));
            else
                mainEditor.Document.Insert(mainEditor.Document.GetLineByNumber(caretLine).Offset, "# ");
        }

        private void CtrlL_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int caretLine = mainEditor.TextArea.Caret.Line;
            mainEditor.Document.Remove(mainEditor.Document.GetLineByNumber(caretLine));
            mainEditor.Document.Remove(mainEditor.Document.GetLineByNumber(caretLine).Offset, 1);
        }

        private void CtrlShiftS_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = documentPath != "" ? Path.GetFileNameWithoutExtension(documentPath) : "" };
            if (saveFileDialog.ShowDialog() == true)
                SaveFile(saveFileDialog.FileName);
        }

        private void CtrlS_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (documentPath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
                if (saveFileDialog.ShowDialog() == true)
                    SaveFile(saveFileDialog.FileName);
            }
            else
                SaveFile(documentPath);
        }

        private void CtrlComma_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SettingsButton_Click(this, e);
        }

        private void Esc_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (DropPanel.IsEnabled)
            {
                DropPanel.IsEnabled = false;
                DropPanel.IsHitTestVisible = false;
                EditorContainer.Effect = new BlurEffect { Radius = 0 };
            }
            else if (SearchReplacePanel.IsVisible)
                SearchReplacePanel.CloseSearch();
        }

        private void F1_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Process.Start("https://github.com/ToniF03/calcify-docs/blob/main/README.md");
        }
    }
}
