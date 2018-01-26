using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MUG_App.Common
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region IsBusy

        private bool _busy;

        public bool IsBusy
        {
            get { return _busy; }
            set
            {
                _busy = value;
                OnPropertyChanged();
                OnIsBusyChanged();
            }
        }

        protected virtual void OnIsBusyChanged()
        {
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}