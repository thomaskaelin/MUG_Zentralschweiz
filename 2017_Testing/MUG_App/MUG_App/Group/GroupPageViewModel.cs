using System.Threading.Tasks;
using MUG_App.Common;
using Xamarin.Forms;

namespace MUG_App.Group
{
    public class GroupPageViewModel : ViewModelBase
    {
        private readonly IGroupLoaderService _loaderService;
        private string _groupName;
        private string _description;
        private string _imageUrl;

        public GroupPageViewModel(IGroupLoaderService loaderService)
        {
            _loaderService = loaderService;

            _groupName = string.Empty;
            _description = string.Empty;
            _imageUrl = string.Empty;

            RefreshDataCommand = new Command(async () => await RefreshData(), () => !IsBusy);
        }

        public string Name
        {
            get { return _groupName; }
            set
            {
                _groupName = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        public Command RefreshDataCommand { get; }

        protected override void OnIsBusyChanged()
        {
            base.OnIsBusyChanged();
            RefreshDataCommand.ChangeCanExecute();
        }

        private async Task RefreshData()
        {
            IsBusy = true;
            await LoadGroupInfo();
            IsBusy = false;
        }

        private async Task LoadGroupInfo()
        {
            var group = await _loaderService.LoadGroupAsync();

            Name = group.Name;
            Description = group.Description;
            ImageUrl = group.ImageUrl;
        }
    }
}