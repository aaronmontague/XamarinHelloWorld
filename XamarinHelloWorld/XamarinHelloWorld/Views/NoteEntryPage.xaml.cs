using System;
using System.IO;
using Xamarin.Forms;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld.Views
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.NoteDB.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.NoteDB.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}