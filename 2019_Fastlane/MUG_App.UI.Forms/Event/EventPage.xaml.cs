using MUG_App.Shared.Event;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUG_App.UI.Forms.Event
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        private readonly EventPageViewModel _viewModel;

        public EventPage()
        {
            InitializeComponent();
            _viewModel = DependencyInjection.Container.GetInstance<EventPageViewModel>();
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
