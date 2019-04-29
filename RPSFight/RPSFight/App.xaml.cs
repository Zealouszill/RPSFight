using RPSDataStorage.Data;
using RPSFight.ViewModels;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RPSFight
{
    public partial class App : Application
    {
        public static MainViewModelAsync RoshamboVM { get; private set; }
        public App()
        {
            InitializeComponent();

            // Android
            //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "data.db");
            string dbPath = null;
            string dbName = "Roshambo.db";
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
                    break;
                case Device.iOS:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", dbName);
                    SQLitePCL.Batteries_V2.Init();
                    break;
                default:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);
                    break;
            }
            //optionbuilder.UseSqlite($@"Data Source={dbPath}");
            //var dataStore = new DataStoreRepo(dbPath);
            var dataStore = new DataStoreAsyncRepo();

            //// Instantiate the view model
            //RoshamboVM = new MainViewModel(dataStore);
            RoshamboVM = new MainViewModelAsync(dataStore);

            MainPage = new MainPage();
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
