using Xamarin.Forms;

namespace MUG_App.UI.Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyInjection.Register();

            MainPage = new Main.MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
