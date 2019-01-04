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
            // TODO Push Notifications: Event für eingehende Meldungen abonnieren
            // TODO SDK: App Center initialisieren
        }
    }
}
