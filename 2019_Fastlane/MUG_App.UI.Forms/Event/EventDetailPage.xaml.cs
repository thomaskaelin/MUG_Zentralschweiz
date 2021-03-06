﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUG_App.UI.Forms.Event
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailPage : ContentPage
    {
        private string _description;

        public EventDetailPage(SelectedItemChangedEventArgs eventArgs)
        {
            BindingContext = this;
            InitializeComponent();
            var item = (Shared.Event.Event) eventArgs.SelectedItem;
            Description = item.Description;
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
    }
}
