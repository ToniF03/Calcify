using Calcify.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
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
        async void App_Startup(object sender, StartupEventArgs e)
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
                else if (File.Exists(e.Args[i]))
                {
                    openFile = true;
                    filePath = e.Args[i];
                }
            }

            // Create main application window, starting minimized if specified
            MainWindow mainWindow = new MainWindow();
            mainWindow.DisableCurrencyConversion();
            if (startMinimized)
                mainWindow.WindowState = WindowState.Minimized;
            mainWindow.Show();

            await LoadExchangeRatesAsync(mainWindow);

            if (openFile)
                mainWindow.OpenFile(filePath);
        }

        private async Task LoadExchangeRatesAsync(MainWindow mainWindow)
        {
            string exchangeRatePath = Path.Combine(AppContext.BaseDirectory, "exchangerate.json");

            try
            {
                bool shouldDownload = true;
                if (File.Exists(exchangeRatePath))
                {
                    JObject exchangeRate = JObject.Parse(File.ReadAllText(exchangeRatePath));
                    DateTime rateDate = DateTime.ParseExact(exchangeRate["date"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    shouldDownload = rateDate.Date < DateTime.Today;
                }

                if (shouldDownload && !await Task.Run(() => ExchangeRateLoader.DownloadExchangeRate()))
                    throw new InvalidOperationException("Exchange rates could not be downloaded.");

                ExchangeRateLoader.LoadExchangeRate(out string currencyPattern, out Regex currencyRegex, out Dictionary<string, double> currencyRates);
                if (currencyRates.Count == 0)
                    throw new InvalidDataException("No exchange rates were loaded.");

                mainWindow.SetCurrencyRates(currencyPattern, currencyRegex, currencyRates);
            }
            catch
            {
                mainWindow.DisableCurrencyConversion();
                MessageBox.Show(mainWindow,
                    "Currency conversion is unavailable because exchange rates could not be loaded. The rest of the calculator will continue to work.",
                    "Currency conversion unavailable",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
    }
}
