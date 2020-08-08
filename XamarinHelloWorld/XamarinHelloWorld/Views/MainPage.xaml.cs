using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

using XamarinHelloWorld.Models;

namespace XamarinHelloWorld.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Practice:
                        MenuPages.Add(id, new NavigationPage(new PracticePage()));
                        break;
                    case (int)MenuItemType.MoreText:
                        MenuPages.Add(id, new NavigationPage(new MoreTextPage()));
                        break;
                    case (int)MenuItemType.Grid:
                        MenuPages.Add(id, new NavigationPage(new GridPage()));
                        break;
                    case (int)MenuItemType.ListView:
                        MenuPages.Add(id, new NavigationPage(new ListViewPage()));
                        break;
                    case (int)MenuItemType.PopUp:
                        MenuPages.Add(id, new NavigationPage(new PopUpPage()));
                        break;
                    case (int)MenuItemType.Database:
                        MenuPages.Add(id, new NavigationPage(new DatabasePage()));
                        break;
                    case (int)MenuItemType.WebService:
                        MenuPages.Add(id, new NavigationPage(new WebServicePage()));
                        break;
                    case (int)MenuItemType.Notes:
                        MenuPages.Add(id, new NavigationPage(new NotesPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}