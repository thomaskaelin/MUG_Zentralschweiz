using MUG_App.Shared.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUG_App.UI.Forms.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public MainPageMaster()
        {
            InitializeComponent();
            BindingContext = DependencyInjection.Container.GetInstance<MainPageMasterViewModel>();
        }
    }
}
