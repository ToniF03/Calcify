using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Update
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebClient wc = new WebClient();
        bool UpdateSelf = false;
        public MainWindow()
        {
            InitializeComponent();
            //this.Hide();
            this.Closing += MainWindow_Closing;
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
            Task a = GetCurrentRelease();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (UpdateSelf)
            {
                string commands = "ping 127.0.0.1 -n 3 > nul\n" +
                    "copy /Y \"" + Path.GetTempPath() + "\\Calcify-update\\Update.exe\" \"" + Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + "\\update.exe\"\n" +
                    "del \"update.bat\"\n" +
                    "exit";
                File.WriteAllText("update.bat", commands);
                Process proc = new Process();
                proc.StartInfo.FileName = "update.bat";
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();
            }
        }

        public async Task GetCurrentRelease()
        {
            if (Properties.Settings.Default.LastChecked != DateTime.Today)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.github.com");
                client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("Calcify", "1"));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "default");
                var response = await client.GetAsync("/repos/ToniF03/Calcify/releases/latest");
                string content = await response.Content.ReadAsStringAsync();
                JObject releases = JObject.Parse(content);
                string s = releases["assets"].First["browser_download_url"].ToString();
                foreach (JToken token in releases["assets"])
                {
                    Console.WriteLine(token["name"].ToString());
                    if (token["name"].ToString().Contains("portable") && token["name"].ToString().EndsWith(".zip"))
                    {
                        s = token["browser_download_url"].ToString();
                        break;
                    }
                }



                if (Properties.Settings.Default.CurrentVersion == int.Parse(releases["id"].ToString()))
                {
                    Properties.Settings.Default.CurrentVersion = int.Parse(releases["id"].ToString());
                    Properties.Settings.Default.Save();
                    prog.IsIndeterminate = false;
                    wc.DownloadFileAsync(new Uri(releases["assets"].First["browser_download_url"].ToString()), Path.GetTempPath() + "\\Calcify-update.zip");
                }
                else
                {
                    Properties.Settings.Default.LastChecked = DateTime.Today;
                    Properties.Settings.Default.Save();
                    this.Close();
                }
                Properties.Settings.Default.LastChecked = DateTime.Today;
                Properties.Settings.Default.Save();
            }
            else Close();
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            prog.Value = e.ProgressPercentage;
        }

        private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Task a = FinishedDownload();
        }

        private async Task FinishedDownload()
        {
            if (Directory.Exists(Path.GetTempPath() + "\\Calcify-update")) Directory.Delete(Path.GetTempPath() + "\\Calcify-update", true);
            ZipFile.ExtractToDirectory(Path.GetTempPath() + "\\Calcify-update.zip", Path.GetTempPath() + "\\Calcify-update");
            File.Delete(Path.GetTempPath() + "\\Calcify-update.zip");
            foreach (string file in Directory.GetFiles(Path.GetTempPath() + "\\Calcify-update\\"))
            {
                if (!file.EndsWith("Update.exe"))
                {
                    try
                    {
                        if (File.Exists(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + "\\" + Path.GetFileName(file)))
                            File.Delete(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + "\\" + Path.GetFileName(file));
                        File.Move(file, Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + "\\" + Path.GetFileName(file));
                    }
                    catch { }
                }
            }
            if (File.Exists(Path.GetTempPath() + "\\Calcify-update\\Update.exe"))
            {
                UpdateSelf = true;

                Close();
            }
            else if (Directory.Exists(Path.GetTempPath() + "\\Calcify-update")) Directory.Delete(Path.GetTempPath() + "\\Calcify-update");
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelf = false;
            App.Current.Shutdown();
        }
    }
}
