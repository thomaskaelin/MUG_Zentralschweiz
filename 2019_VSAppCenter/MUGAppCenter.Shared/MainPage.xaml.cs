using System;
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

            // TODO Diagnostics: Crash-Recovery einbauen
        }

        private async void DoOnShowPopupPressed(object sender, EventArgs eventArgs)
        {
            await DisplayAlert(string.Empty, "Hallo MUG-Members!", "Ok");
        }

        private void DoOnTrackEventPressed(object sender, EventArgs eventArgs)
        {
            // TODO Analytics: Event Tracking einbauen
        }

        private void DoOnTrackExceptionPressed(object sender, EventArgs eventArgs)
        {
            // TODO Diagnostics: Exception Tracking einbauen
        }

        private void DoOnSimulateCrashPressed(object sender, EventArgs eventArgs)
        {
            // TODO Diagnostics: App Crash einbauen
        }
    }
}
