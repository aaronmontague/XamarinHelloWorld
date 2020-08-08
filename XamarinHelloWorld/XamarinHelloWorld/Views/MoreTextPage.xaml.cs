using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoreTextPage : ContentPage
    {
        public MoreTextPage()
        {
            InitializeComponent();
        }
        void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            // same concept as entry
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEditorCompleted(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
        }
    }
}