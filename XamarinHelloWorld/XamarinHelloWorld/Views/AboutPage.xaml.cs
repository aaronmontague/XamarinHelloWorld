using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinHelloWorld.Views
{
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        // Life Cycle Tutorial Code
        protected override void OnAppearing()
        {
            base.OnAppearing();

            App currentApp = Application.Current as App;
            entry.Text = currentApp.DisplayText;
            maybeAaron.Text = currentApp.AaronText;
            probablyAaron.Text = currentApp.Aaron2;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            (Application.Current as App).DisplayText = entry.Text;
        }
        // End Life Cycle Code
    }
}