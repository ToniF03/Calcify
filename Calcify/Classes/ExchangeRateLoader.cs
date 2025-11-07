using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calcify.Classes
{
    internal class ExchangeRateLoader
    {
        // By https://www.frankfurter.app/
        private static string exchangeRateLink = "https://api.frankfurter.app/latest";

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

        /// <summary>
        /// Loads the exchange rate
        /// </summary>
        public static void LoadExchangeRate(out String currencyPattern, out Regex currencyRegex, out Dictionary<string, double> currencyDict)
        {
            // Initialize out parameters with default values
            currencyPattern = string.Empty;
            currencyRegex = new Regex(@"^$");
            currencyDict = new Dictionary<string, double>();

            // Creates an dictionary that contains the ISO-4217 codes and the exchange rate to USD
            Dictionary<string, double> newCurrencyDict = new Dictionary<string, double>();
            string filePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "exchangerate.json");
            if (File.Exists(filePath))
            {
                JObject exchangerate = JObject.Parse(File.ReadAllText(filePath));
                foreach (JProperty child in exchangerate["rates"].Children())
                {
                    newCurrencyDict.Add(child.Name, double.Parse(child.Value.ToString()));
                }
                currencyDict = newCurrencyDict;
                currencyPattern = "(EUR|" + string.Join("|", currencyDict.Keys) + ")";

                // Re-create currency regex with updated pattern
                currencyRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + currencyPattern + ") (in(to)?|to|as) (?<targetUnit>" + currencyPattern + ")$");
            }
        }

        /// <summary>
        /// Downloads the current exchange rate of the day
        /// </summary>
        /// <returns>Returns success as bool.</returns>
        public static bool DownloadExchangeRate()
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
    }
}
