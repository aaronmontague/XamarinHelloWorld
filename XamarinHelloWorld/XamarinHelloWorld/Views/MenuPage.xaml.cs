using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.Practice, Title="Practice"},
                new HomeMenuItem {Id = MenuItemType.MoreText, Title="More Text"},
                new HomeMenuItem {Id = MenuItemType.Grid, Title="Grid Layout"},
                new HomeMenuItem {Id = MenuItemType.ListView, Title="ListView"},
                new HomeMenuItem {Id = MenuItemType.PopUp, Title="POP UP!!"},
                new HomeMenuItem {Id = MenuItemType.Database, Title="DB Smooth"},
                new HomeMenuItem {Id = MenuItemType.WebService, Title="WebService"},
                new HomeMenuItem {Id = MenuItemType.Notes, Title="Notes"}
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
        
    }
}