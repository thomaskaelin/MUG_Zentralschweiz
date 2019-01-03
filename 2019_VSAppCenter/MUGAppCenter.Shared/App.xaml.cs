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
            // TODO App Center SDKs aktivieren
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
