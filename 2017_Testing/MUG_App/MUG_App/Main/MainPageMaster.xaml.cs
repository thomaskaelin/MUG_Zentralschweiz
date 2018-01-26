using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUG_App.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public MainPageMaster()
        {
            InitializeComponent();
            BindingContext = new MainPageMasterViewModel();
        }
    }
}
