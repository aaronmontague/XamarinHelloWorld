using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinHelloWorld.Models;
using XamarinHelloWorld.Services;
using XamarinHelloWorld.Views;
using XamarinHelloWorld.Data;

namespace XamarinHelloWorld
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public static bool UseMockDataStore = true;

        //Notes Functionality
        public static string FolderPath { get; private set; }

        //Notes DB
        static NoteDatabase noteDB;
        public static NoteDatabase NoteDB
        {
            get
            {
                if (noteDB == null)
                {
                    noteDB = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return noteDB;
            }
        }

        // App Tutorial Code
        const string displayText = "displayText";
        const string aaronText = "Aaron";
        const string aaron2 = "Hola Banditos";

        public string DisplayText { get; set; }
        public string AaronText { get; set; }
        public string Aaron2 { get; set; }

        // DB Tutorial Code
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            //Notes Functionality
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Console.WriteLine("OnStart() <-- YEAH!");
            if (Properties.ContainsKey(displayText))
            {
                DisplayText = (string)Properties[displayText];
            }
           
            AaronText = aaronText;
            
            if (Properties.ContainsKey(aaron2))
            {
                Aaron2 = (string)Properties[aaron2];
            }
        }

        protected override void OnSleep()
        {
            Console.WriteLine("Sleep Now");
            Properties[displayText] = DisplayText;
            (Application.Current as App).AaronText += " (Sleep)";
            string randomNumber = new Random().Next(0, 1000).ToString();
            (Application.Current as App).Aaron2 = "Gotcha Fam " + randomNumber;
            Properties[aaron2] = Aaron2;
        }

        protected override void OnResume()
        {
            Console.WriteLine("Resume on Resume");
        }
    }
}
