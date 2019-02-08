using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MUGAppCenter.Shared
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Push.PushNotificationReceived += (s, e) => {
                MainPage.DisplayAlert($"Push: {e.Title}", e.Message, "Ok");
            };

            AppCenter.Start("android=2af5b46d-9096-4dc3-8ef6-675ba452f3d8;" +
                              "uwp={Your UWP App secret here};" +
                              "ios={Your iOS App secret here}",
                              typeof(Analytics),
                              typeof(Crashes),
                              typeof(Push));
        }
    }
}
