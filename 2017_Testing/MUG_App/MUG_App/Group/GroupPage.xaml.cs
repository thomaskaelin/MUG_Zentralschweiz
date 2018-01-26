﻿using MUG_App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUG_App.Group
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupPage : ContentPage
    {
        private readonly GroupPageViewModel _viewModel;

        public GroupPage()
        {
            InitializeComponent();
            _viewModel = new GroupPageViewModel(new RESTLoaderService());
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            _viewModel.RefreshDataCommand.Execute(null);
        }
    }
}