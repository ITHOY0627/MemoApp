using MemoApp.Services;
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

            //DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();

            MainPage = new NavigationPage(new MemoMainPage())
            {
                BarTextColor = Color.Black,
                BarBackgroundColor = (Color)App.Current.Resources["TitleColor"]
            };


        }

        protected override void OnStart()
        {
            AppCenter.Start("android=8f0b9039-9b08-491f-895f-610a1693c0f1;" +
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
