using MemoApp.Views;
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
        } 

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
