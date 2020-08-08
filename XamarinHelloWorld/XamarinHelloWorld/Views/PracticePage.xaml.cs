using System;
using System.ComponentModel;
using Xamarin.Forms;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld.Views
{
    [DesignTimeVisible(false)]
    public partial class PracticePage : ContentPage
    {
        public Painter Claude { get; }
        public PracticePage()
        {
            InitializeComponent();

            Claude = new Painter("Claude", "Monet");

            BindingContext = this;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            string newText = (sender as Button).Text;
            newText += "Cow";
            (sender as Button).Text = newText;
        }

        void Entry_Change(object sender, EventArgs e)
        {
            (sender as Entry).Text = "Focus this!";
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            dilt.Text = "old: " + oldText + " new: " + newText;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
    }
}