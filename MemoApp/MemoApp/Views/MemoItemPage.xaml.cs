using System;
using MemoApp.Data;
using MemoApp.Models;
using Xamarin.Forms;

namespace MemoApp.Views
{
    public partial class MemoItemPage : ContentPage
    {
        public MemoItemPage()
        {
            InitializeComponent();
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    MemoItemDatabase database = await MemoItemDatabase.Instance;
        //    listView.ItemsSource = await database.GetItemsAsync();
        //}

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var MemoItem = (MemoItem)BindingContext;
            MemoItemDatabase database = await MemoItemDatabase.Instance;
            await database.SaveItemAsync(MemoItem);
            await Navigation.PopAsync();

        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {

        }

        private void OnCancelClicked(object sender, EventArgs e)
        {

        }
    }
}