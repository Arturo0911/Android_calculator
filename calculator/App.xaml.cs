using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace calculator
{
    public partial class App : Application
    {

        public static string FilePath;

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("00BB2D"),
                BarTextColor = Color.White
            };
        }

        public App(string filePath)
        {
            InitializeComponent();


            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("00BB2D"),
                BarTextColor = Color.White
            };
            FilePath = filePath;
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
