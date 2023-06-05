using MemoApp.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            //MainPage = new NavigationPage(new AppShell());

            MainPage = new NavigationPage(new MemoMainPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = (Color)App.Current.Resources["TitleColor"]
            };

        }

        protected override void OnStart()
        {
            AppCenter.Start("android=08b0a7d1-9217-415d-9e37-9d3152e358cf;" +
                    "uwp={Your UWP App secret here};" +
                    "ios={}",
                    typeof(Analytics), typeof(Crashes));
        } 

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
