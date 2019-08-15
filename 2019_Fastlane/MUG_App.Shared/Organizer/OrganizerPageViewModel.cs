using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MUG_App.Shared.Common;

namespace MUG_App.Shared.Organizer
{
    public class OrganizerPageViewModel : ViewModelBase
    {
        private readonly IOrganizerLoaderService _loaderService;

        public OrganizerPageViewModel(IOrganizerLoaderService loaderService)
        {
            _loaderService = loaderService;
            Organizers = new ObservableCollection<Organizer>();
            RefreshDataCommand = new RelayCommand(async () => await RefreshData(), () => !IsBusy);
        }

        public ObservableCollection<Organizer> Organizers { get; }

        public RelayCommand RefreshDataCommand { get; }

        protected override void OnIsBusyChanged()
        {
            base.OnIsBusyChanged();

            RefreshDataCommand.RaiseCanExecuteChanged();
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