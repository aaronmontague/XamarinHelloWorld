using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

using XamarinHelloWorld.Models;

namespace XamarinHelloWorld.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description.",
                Caretaker = "Who guards this item?",
                // New Items need a Guid
                Id = Guid.NewGuid().ToString()
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Entry_Focused(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/28194231/automatically-select-all-text-on-focus-xamarin
            await Task.Delay(100);
            (sender as Entry).CursorPosition = 0;
            ((Entry)sender).SelectionLength = ((Entry)sender).Text.Length;
        }
    }
}