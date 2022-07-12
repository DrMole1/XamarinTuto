using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;
using AppAmsterdam.Repositories;

namespace AppAmsterdam
{
    public partial class App : Application
    {
        private string dbPath = Path.Combine(FileSystem.AppDataDirectory, "dataBase.db3");
        public static UserRepository UserRepository { get; private set; }

        public App()
        {
            InitializeComponent();

            UserRepository = new UserRepository(dbPath);

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            if(Current.Properties.ContainsKey("MainPageID"))
            {
                var id = Current.Properties["MainPageID"];
                Debug.WriteLine("OnStart - " + id);
            }    
            
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            if (Current.Properties.ContainsKey("MainPageID"))
            {
                var id = Current.Properties["MainPageID"];
                Debug.WriteLine("OnResume - " + id);
            }
        }
    }
}
