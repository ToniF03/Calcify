using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Calcify
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            // Application is running
            // Process command line args
            bool startMinimized = false;
            bool openFile = false;
            string filePath = "";
            for (int i = 0; i != e.Args.Length; ++i)
            {
                if (e.Args[i] == "-minimized")
                {
                    startMinimized = true;
                }
                else if (e.Args[i] == "-dev")
                {

                }
                else if (System.IO.File.Exists(e.Args[i]))
                {
                    openFile = true;
                    filePath = e.Args[i];
                }
            }

            // Create main application window, starting minimized if specified
            MainWindow mainWindow = new MainWindow();
            if (startMinimized)
                mainWindow.WindowState = WindowState.Minimized;
            mainWindow.Show();



            if (!File.Exists(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "exchangerate.json")))
                mainWindow.DownloadExchangeRate();
            else
            {
                JObject exchangerate = JObject.Parse(System.IO.File.ReadAllText(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "exchangerate.json")));
                string[] dateArray = exchangerate["date"].ToString().Split('-');
                double unixtimestamp = Math.Calculator.DateTimeToUnixTimeStamp(new DateTime(int.Parse(dateArray[0]), int.Parse(dateArray[1]), int.Parse(dateArray[2])));
                DateTime timestamp = Math.Calculator.UnixTimeStampToDateTime(unixtimestamp);
                DateTime now = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 12, 0, 0);
                if (timestamp < now)
                {
                    mainWindow.DownloadExchangeRate();
                }
            }
            mainWindow.LoadExchangeRate();

            if (openFile)
                mainWindow.openFile(filePath);
        }
    }
}
