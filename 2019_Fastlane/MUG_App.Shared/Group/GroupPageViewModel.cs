using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MUG_App.Shared.Common;

namespace MUG_App.Shared.Group
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

            RefreshDataCommand = new RelayCommand(async () => await RefreshData(), () => !IsBusy);
        }

        public string Name
        {
            get => _groupName;
            set
            {
                Set(ref _groupName, value);
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                Set(ref _description, value);
            }
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                Set(ref _imageUrl, value);
            }
        }

        public RelayCommand RefreshDataCommand { get; }

        protected override void OnIsBusyChanged()
        {
            base.OnIsBusyChanged();
            RefreshDataCommand.RaiseCanExecuteChanged();
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