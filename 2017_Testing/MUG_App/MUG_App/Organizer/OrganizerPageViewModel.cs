using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MUG_App.Common;
using Xamarin.Forms;

namespace MUG_App.Organizer
{
    public class OrganizerPageViewModel : ViewModelBase
    {
        private readonly IOrganizerLoaderService _loaderService;

        public OrganizerPageViewModel(IOrganizerLoaderService loaderService)
        {
            _loaderService = loaderService;
            Organizers = new ObservableCollection<Organizer>();
            RefreshDataCommand = new Command(async () => await RefreshData(), () => !IsBusy);
        }

        public ObservableCollection<Organizer> Organizers { get; }

        public Command RefreshDataCommand { get; }

        protected override void OnIsBusyChanged()
        {
            base.OnIsBusyChanged();

            RefreshDataCommand.ChangeCanExecute();
        }

        private async Task RefreshData()
        {
            IsBusy = true;
            await LoadOrganizers();
            IsBusy = false;
        }

        private async Task LoadOrganizers()
        {
            var loadedOrganizers = await _loaderService.LoadOrganizersAsync();

            Organizers.Clear();
            
            foreach (var organizer in loadedOrganizers)
            {
                Organizers.Add(organizer);
            }
        }
    }
}