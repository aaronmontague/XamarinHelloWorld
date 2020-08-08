using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld.Views
{
    public partial class DatabasePage : ContentPage
    {
        public DatabasePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) 
                && !string.IsNullOrWhiteSpace(ageEntry.Text)
                && !string.IsNullOrWhiteSpace(drinkEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Age = int.Parse(ageEntry.Text),
                    DrinkOfChoice = drinkEntry.Text
                });

                ClearEntries();
                listView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }

        async void OnEditButtonClicked(object sender, EventArgs e)
        {
            // Send edits to database
            if (!string.IsNullOrWhiteSpace(nameEntry.Text)
                && !string.IsNullOrWhiteSpace(ageEntry.Text)
                && !string.IsNullOrWhiteSpace(drinkEntry.Text))
            {
                await App.Database.UpdatePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Age = int.Parse(ageEntry.Text),
                    DrinkOfChoice = drinkEntry.Text,
                    ID = int.Parse(idLabel.Text)
                });

                // Clear entrys
                ClearEntries();
                listView.ItemsSource = await App.Database.GetPeopleAsync();

                // Switch to Add Button
                buttonEditEntry.IsVisible = false;
                buttonAddToDatabase.IsVisible = true;
            }
        }

        void HandleItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Load data into entrys
            Person tempPerson = e.Item as Person;
            nameEntry.Text = tempPerson.Name;
            ageEntry.Text = tempPerson.Age.ToString();
            drinkEntry.Text = tempPerson.DrinkOfChoice;
            idLabel.Text = tempPerson.ID.ToString();

            // Switch to Edit Button
            buttonAddToDatabase.IsVisible = false;
            buttonEditEntry.IsVisible = true;
        }

        private void ClearEntries()
        {
            nameEntry.Text = ageEntry.Text = drinkEntry.Text = string.Empty;
        }
    }
}