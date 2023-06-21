using MemoApp.Data;
using MemoApp.Models;
using MemoApp.ViewModels;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IDAndPWListPage : ContentPage
    {
        public IDAndPWListPage()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as IDAndPWListViewModel).OnAppearing();
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new IDAndPWItemPage
                {
                    BindingContext = new MemoItem()
                });
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);

                var properties = new Dictionary<string, string> {
                    { "Category", "Music" },
                    { "Wifi", "On" }
                };
                Crashes.TrackError(ex, properties);
            }
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new IDAndPWItemPage
                {
                    BindingContext = e.SelectedItem as IDAndPWItem
                });
            }

        }

    }
}