namespace MUG_App.Shared.Common
{
    public abstract class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        #region IsBusy

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                Set(ref _isBusy, value);
                OnIsBusyChanged();
            }
        }

        protected virtual void OnIsBusyChanged()
        {
        }

        #endregion
    }
}