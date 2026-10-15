using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private static string exchangeRateLink = "https://api.frankfurter.dev/v2/rates";

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
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "exchangerate.json");
            if (File.Exists(filePath))
            {
                JObject exchangerate = JObject.Parse(File.ReadAllText(filePath));
                foreach (JObject child in exchangerate["data"].Children())
                {
                    string quote = child["quote"].ToString();
                    string rawRate = child["rate"].ToString().Replace(',', '.');
                    newCurrencyDict.Add(quote, double.Parse(rawRate, NumberStyles.Float, CultureInfo.InvariantCulture));
                }
                currencyDict = newCurrencyDict;
                currencyPattern = "(EUR|" + string.Join("|", currencyDict.Keys) + ")";

                // Re-create currency regex with updated pattern
                currencyRegex = new Regex(@"^(?<value>\-?\d+(\.\d+)?) (?<srcUnit>" + currencyPattern + ") (in(to)?|to|as) (?<targetUnit>" + currencyPattern + ")$");
            }
        }

        public static DateTime? GetLastUpdatedDate()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "exchangerate.json");
            if (!File.Exists(filePath))
                return null;

            try
            {
                JObject exchangeRate = JObject.Parse(File.ReadAllText(filePath));
                if (TryGetRateDate(exchangeRate, out DateTime rateDate))
                    return rateDate;
            }
            catch
            {
            }

            return null;
        }

        /// <summary>
        /// Downloads the current exchange rate of the day
        /// </summary>
        /// <returns>Returns success as bool.</returns>
        public static bool DownloadExchangeRate()
        {
            try
            {
                InternetConnectionState_e flags = 0;
                if (!InternetGetConnectedState(ref flags, 0))
                    return false;

                using (WebClient webClient = new WebClient())
                {
                    string downloadedContent = webClient.DownloadString(exchangeRateLink);
                    JObject exchangeRate = JObject.Parse("{\"data\":" + downloadedContent + "}");
                    if (!TryGetRateDate(exchangeRate, out DateTime rateDate))
                        return false;

                    File.WriteAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "exchangerate.json"), "{\"data\":" + downloadedContent + "}");
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
                Console.WriteLine($"Error occured: {e}");
                return false;
            }
        }

        private static bool TryGetRateDate(JObject exchangeRate, out DateTime rateDate)
        {
            rateDate = default(DateTime);
            JToken dateToken = exchangeRate["data"][0]["date"];
            JToken ratesToken = exchangeRate["data"];
            if (dateToken == null || !(ratesToken is JArray rates) || !rates.Children().Any())
                return false;

            foreach (JObject currency in rates)
            {
                string rateValue = currency["rate"].ToString().Replace(',', '.');
                if (!double.TryParse(rateValue, NumberStyles.Float, CultureInfo.InvariantCulture, out double value) ||
                    value <= 0 || double.IsNaN(value) || double.IsInfinity(value))
                    return false;
            }

            return DateTime.TryParseExact(dateToken.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out rateDate);
        }
    }
}
