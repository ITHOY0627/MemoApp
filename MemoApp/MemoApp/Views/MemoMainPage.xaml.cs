using MemoApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemoMainPage : ContentPage
    {
        public MemoMainPage()
        {
            InitializeComponent();

        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MemoItemPage
            {
                BindingContext = new MemoItem()
            });
        }

        private void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}