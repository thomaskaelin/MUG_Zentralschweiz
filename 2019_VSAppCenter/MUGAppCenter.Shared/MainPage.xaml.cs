using System;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace MUGAppCenter.Shared
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (await Crashes.HasCrashedInLastSessionAsync())
                await DisplayAlert(string.Empty, "Sorry für den Crash! :-(", "Ok");
        }

        private async void DoOnShowPopupPressed(object sender, EventArgs eventArgs)
        {
            await DisplayAlert(string.Empty, "Hallo MUG-Members!", "Ok");
        }

        private void DoOnTrackEventPressed(object sender, EventArgs eventArgs)
        {
            Analytics.TrackEvent("Der 'Track'-Button wurde gedrückt.");
        }

        private void DoOnTrackExceptionPressed(object sender, EventArgs eventArgs)
        {
            var exception = new Exception("Der 'Exception'-Button wurde gedrückt.");
            Crashes.TrackError(exception);
        }

        private void DoOnSimulateCrashPressed(object sender, EventArgs eventArgs)
        {
            throw new Exception("Der 'Crash'-Button wurde gedrückt.");
        }
    }
}
