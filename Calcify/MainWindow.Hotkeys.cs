using ICSharpCode.AvalonEdit;
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
        public static RoutedCommand CtrlF = new RoutedCommand();
        public static RoutedCommand CtrlH = new RoutedCommand();
        public static RoutedCommand CtrlL = new RoutedCommand();
        public static RoutedCommand CtrlSlash = new RoutedCommand();
        public static RoutedCommand CtrlComma = new RoutedCommand();
        public static RoutedCommand Esc = new RoutedCommand();
        public static RoutedCommand F1 = new RoutedCommand();

        public static void RegisterHotkeys()
        {
            CtrlS.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            CtrlShiftS.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift));
            CtrlO.InputGestures.Add(new KeyGesture(Key.O, ModifierKeys.Control));
            CtrlN.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
            Ctrl0.InputGestures.Add(new KeyGesture(Key.D0, ModifierKeys.Control));
            Ctrl0.InputGestures.Add(new KeyGesture(Key.NumPad0, ModifierKeys.Control));
            CtrlPlus.InputGestures.Add(new KeyGesture(Key.OemPlus, ModifierKeys.Control));
            CtrlMinus.InputGestures.Add(new KeyGesture(Key.OemMinus, ModifierKeys.Control));
            CtrlD.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Control));
            CtrlF.InputGestures.Add(new KeyGesture(Key.F, ModifierKeys.Control));
            CtrlH.InputGestures.Add(new KeyGesture(Key.H, ModifierKeys.Control));
            CtrlL.InputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control));
            CtrlSlash.InputGestures.Add(new KeyGesture(Key.Oem2, ModifierKeys.Control));
            CtrlComma.InputGestures.Add(new KeyGesture(Key.OemComma, ModifierKeys.Control));
            Esc.InputGestures.Add(new KeyGesture(Key.Escape));
            F1.InputGestures.Add(new KeyGesture(Key.F1));
        }

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

        /// <summary>
        /// Handles the execution of the Ctrl+0 command, resetting the editor zoom level to 100%.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void Ctrl0_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyZoomFromString("100%");
        }

        /// <summary>
        /// Handles the execution of the Ctrl++ command, increasing the editor zoom level by 10%, up to a maximum of 500%.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void CtrlPlus_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyZoomFromString((System.Math.Min(500, Properties.Settings.Default.EditorZoom * 100 + 10)) + "%");
        }

        /// <summary>
        /// Handles the execution of the Ctrl+- command, decreasing the editor zoom level by 10%, down to a minimum of 25%.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void CtrlMinus_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ApplyZoomFromString((System.Math.Max(25, Properties.Settings.Default.EditorZoom * 100 - 10)) + "%");
        }

        /// <summary>
        /// Handles the execution of the Ctrl+O command, opening a file dialog to allow the user to select a Calcify file to open.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void CtrlO_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = "" };
            if (openFileDialog.ShowDialog() == true)
                OpenFile(openFileDialog.FileName);
        }

        /// <summary>
        /// Handles the execution of the Ctrl+D command, duplicating the current line in the editor and placing the caret on the duplicated line.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void CtrlD_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int caretLine = mainEditor.TextArea.Caret.Line;
            int caretColumn = mainEditor.TextArea.Caret.Column;
            string lineText = mainEditor.Document.GetText(mainEditor.Document.GetLineByNumber(caretLine));
            mainEditor.Document.Insert(mainEditor.Document.GetLineByNumber(caretLine).Offset, lineText + Environment.NewLine);
            mainEditor.TextArea.Caret.Line = caretLine + 1;
            mainEditor.TextArea.Caret.Column = caretColumn;
        }

        /// <summary>
        /// Handles the execution of the Ctrl+/ command, toggling a comment on the current line in the editor. If the line starts with a comment symbol,
        /// it removes it; otherwise, it adds a comment symbol at the beginning of the line.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
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

        /// <summary>
        /// Handles the execution of the Ctrl+L command, deleting the current line in the editor. The caret is moved to the beginning of the next line after deletion.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void CtrlL_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int caretLine = mainEditor.TextArea.Caret.Line;
            var line = mainEditor.Document.GetLineByNumber(caretLine);
            if (caretLine == mainEditor.Document.LineCount)
                mainEditor.Document.Remove(line.Offset - 1, line.TotalLength + 1);
            else
                mainEditor.Document.Remove(line.Offset, line.TotalLength);
        }

        /// <summary>
        /// Handles the execution of the Ctrl+Shift+S command, prompting the user to save the current document with a new name or location. If the document 
        /// has not been saved before, it opens a SaveFileDialog to allow the user to specify the file name and location.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void CtrlShiftS_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Calcify File (*.calcify)|*.calcify|All Files (*.*)|*.*", FileName = documentPath != "" ? Path.GetFileNameWithoutExtension(documentPath) : "" };
            if (saveFileDialog.ShowDialog() == true)
                SaveFile(saveFileDialog.FileName);
        }

        /// <summary>
        /// Handles the execution of the Ctrl+S command, saving the current document. If the document has not been saved before, it opens a SaveFileDialog 
        /// to allow the user to specify the file name and location.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
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

        /// <summary>
        /// Handles the execution of the Ctrl+, command, opening the settings panel for the application. This allows users to quickly access and modify application settings.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void CtrlComma_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SettingsButton_Click(this, e);
        }

        /// <summary>
        /// Handles the execution of the Esc command, closing any open panels or dialogs in the application. If the drop panel is enabled, it will be disabled and the editor 
        /// will be restored to its normal state. If the search/replace panel is visible, it will be closed.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
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

        /// <summary>
        /// Handles the execution of the F1 command, opening the Calcify documentation in the default web browser. 
        /// This provides users with quick access to help and guidance on using the application.
        /// </summary>
        /// <param name="sender">The source of the command event, typically the control that initiated the command.</param>
        /// <param name="e">The event data associated with the command execution.</param>
        private void F1_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Process.Start("https://github.com/ToniF03/calcify-docs/blob/main/README.md");
        }
    }
}
