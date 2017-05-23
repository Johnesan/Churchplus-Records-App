using Churchplus_Records.Data;
using Churchplus_Records.Views;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Churchplus_Records
{
    public partial class App : Application
    {
        static RecordRepository database;
        public App()
        {
            InitializeComponent();
            MainPage = new RootPage();
            //var mainpage = new NavigationPage(new RecordsList());
            //var noNetworkPage = new NoNetworkPage();
            //MainPage = CrossConnectivity.Current.IsConnected ? (Page)mainpage : noNetworkPage;
        }
        public static RecordRepository Database
        {
            get
            {
                if(database == null)
                {
                    database = new RecordRepository(DependencyService.Get<IFileHelper>().GetLocalFilePath("Churchplus_Records.db3"));
                }
                return database;
            }
        }

        public int ResumeAtRecordId { get; set; }

        protected override void OnStart()
        {
            base.OnStart();
            //CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;
        }

        //Handles internet connectivity change


        //void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        //{
        //    Type currentPage = this.MainPage.GetType();
        //    if (e.IsConnected && currentPage != typeof(RecordsList))
        //        this.MainPage = new RecordsList();
        //    else if (!e.IsConnected && currentPage != typeof(NoNetworkPage))
        //        this.MainPage = new NoNetworkPage();
        //}

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
