using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MUG_App.Common;
using Xamarin.Forms;

namespace MUG_App.Event
{
    public class EventPageViewModel : ViewModelBase
    {
        private readonly IEventLoaderService _loaderService;

        public EventPageViewModel(IEventLoaderService loaderService)
        {
            _loaderService = loaderService;
            Events = new ObservableCollection<Event>();
            RefreshDataCommand = new Command(async () => await RefreshData(), () => !IsBusy);
        }

        public ObservableCollection<Event> Events { get; }

        public Command RefreshDataCommand { get; }

        protected override void OnIsBusyChanged()
        {
            base.OnIsBusyChanged();
            RefreshDataCommand.ChangeCanExecute();
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