using MUG_App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUG_App.Event
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        private readonly EventPageViewModel _viewModel;

        public EventPage()
        {
            InitializeComponent();
            _viewModel = new EventPageViewModel(new RESTLoaderService());
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.RefreshDataCommand.Execute(null);
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            await Navigation.PushAsync(new EventDetailPage(e));

            //Deselect Event
            ((ListView)sender).SelectedItem = null;
        }
    }
}
