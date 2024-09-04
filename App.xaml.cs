using System.Diagnostics;
using Module02Exercise01.View;
using Microsoft.Maui.ApplicationModel;
using System.Threading.Tasks;
using Module02Exercise01.Resources.Styles;
using static System.Net.WebRequestMethods;

namespace Module02Exercise01
{
    public partial class App : Application
    {
        private const string TestUrl = "https://example.com";

        public App()
        {
            InitializeComponent();

            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                this.Resources.MergedDictionaries.Add(new WindowsResources());
            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                this.Resources.MergedDictionaries.Add(new AndroidResources());
            }

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            // base.OnStart(); // No need to call base for OnStart in MAUI

            var current = Connectivity.NetworkAccess;
            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                await Shell.Current.GoToAsync("//LoginPage");
                Debug.WriteLine("Application Started (Online)");
            }
            else
            {
                await Shell.Current.GoToAsync("//OfflinePage");
                Debug.WriteLine("Application Started (Offline)");
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Application Sleeping");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Application Resumed");
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
