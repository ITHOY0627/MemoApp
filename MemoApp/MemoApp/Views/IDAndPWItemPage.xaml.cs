using MemoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IDAndPWItemPage : ContentPage
    {
        public IDAndPWItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var IDAndPWItem = (IDAndPWItem)BindingContext;
            IDAndPWItemDatabase database = await IDAndPWItemDatabase.Instance;
            await database.SaveItemAsync(IDAndPWItem);

            await Navigation.PopAsync();  
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            //var MemoItem = (MemoItem)BindingContext;
            //MemoItemDatabase database = await MemoItemDatabase.Instance;
            //await database.SaveItemAsync(MemoItem);

            //await Navigation.PopAsync();
        }
    }
}