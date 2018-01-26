using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MUG_App.Shared.Common;

namespace MUG_App.Shared.Event
{
    public class EventPageViewModel : ViewModelBase
    {
        private readonly IEventLoaderService _loaderService;

        public EventPageViewModel(IEventLoaderService loaderService)
        {
            _loaderService = loaderService;
            Events = new ObservableCollection<Event>();
            RefreshDataCommand = new RelayCommand(async () => await RefreshData(), () => !IsBusy);
        }

        public ObservableCollection<Event> Events { get; }

        public RelayCommand RefreshDataCommand { get; }

        protected override void OnIsBusyChanged()
        {
            base.OnIsBusyChanged();
            RefreshDataCommand.RaiseCanExecuteChanged();
        }

        private async Task RefreshData()
        {
            IsBusy = true;
            await LoadEvents();
            IsBusy = false;
        }

        private async Task LoadEvents()
        {
            var loadedEvents = await _loaderService.LoadEventsAsync();

            Events.Clear();

            foreach (var loadedEvent in loadedEvents)
            {
                Events.Add(loadedEvent);
            }
        }
    }
}