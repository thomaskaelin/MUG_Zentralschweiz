using MUG_App.Shared.Group;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUG_App.UI.Forms.Group
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupPage : ContentPage
    {
        private readonly GroupPageViewModel _viewModel;

        public GroupPage()
        {
            InitializeComponent();
            _viewModel = DependencyInjection.Container.GetInstance<GroupPageViewModel>();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            _viewModel.RefreshDataCommand.Execute(null);
        }
    }
}