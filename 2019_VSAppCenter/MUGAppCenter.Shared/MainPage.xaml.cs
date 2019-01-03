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

        private async void DoOnShowPopupPressed(object sender, EventArgs eventArgs)
        {
            await DisplayAlert(string.Empty, "Hallo MUG-Members!", "Ok");
        }

        private void DoOnTrackEventPressed(object sender, EventArgs eventArgs)
        {
            // TODO Event Tracking einbauen
        }

        private void DoOnTrackExceptionPressed(object sender, EventArgs eventArgs)
        {
            // TODO Exception Tracking einbauen
        }

        private void DoOnSimulateCrashPressed(object sender, EventArgs eventArgs)
        {
            // TODO App Crash einbauen
        }
    }
}
