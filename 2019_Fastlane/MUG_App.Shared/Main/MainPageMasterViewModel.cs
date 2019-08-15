﻿using System.Collections.ObjectModel;
using MUG_App.Shared.Common;

namespace MUG_App.Shared.Main
{
    public class MainPageMasterViewModel : ViewModelBase
    {
        public MainPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
            {
                new MainPageMenuItem { Id = 0, Title = "Group" },
                new MainPageMenuItem { Id = 1, Title = "Organizers" },
                new MainPageMenuItem { Id = 2, Title = "Events" }
            });
        }

        public ObservableCollection<MainPageMenuItem> MenuItems { get; }
    }
}