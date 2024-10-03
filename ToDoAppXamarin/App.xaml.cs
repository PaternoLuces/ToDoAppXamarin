using System;
using System.IO;
using Xamarin.Forms;
using ToDoAppXamarin.Services;

namespace ToDoAppXamarin
{
    public partial class App : Application
    {
        static TaskDatabase database;

        public App()
        {
            InitializeComponent();

            // Set the main page of your application
            MainPage = new NavigationPage(new MainPage());
        }

        // Singleton for database access
        public static TaskDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TaskDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tasks.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
