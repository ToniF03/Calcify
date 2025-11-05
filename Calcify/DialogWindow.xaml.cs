using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaktionslogik für DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public MainWindow mWindow;
        public int returnState = 0;

        #region "Hotkeys/Keybindings"
        public static RoutedCommand Enter = new RoutedCommand();
        public static RoutedCommand Space = new RoutedCommand();
        public static RoutedCommand Esc = new RoutedCommand();
        #endregion

        public DialogWindow()
        {
            InitializeComponent();
            Enter.InputGestures.Add(new KeyGesture(Key.Enter));
            Space.InputGestures.Add(new KeyGesture(Key.Space));
            Esc.InputGestures.Add(new KeyGesture(Key.Escape));

            CancelButton.Click += Cancel;
            SaveButton.Click += Save;
            NotSaveButton.Click += DoNotSave;
        }

        private void Esc_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
            returnState = 1;
        }

        private void Enter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
            returnState = 3;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            returnState = 1;
        }

        private void DoNotSave(object sender, RoutedEventArgs e)
        {
            this.Close();
            returnState = 2;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            this.Close();
            returnState = 3;
        }
    }
}
