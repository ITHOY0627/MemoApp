using MemoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MemoApp.ViewModels
{
    public class MemoMainViewModel : ViewModelBase
    {
        INavigation Navigation => Application.Current.MainPage.Navigation;

        //멤버변수
        private ObservableRangeCollection<MemoItem> _items = new ObservableRangeCollection<MemoItem>();


        //Prop
        public ObservableRangeCollection<MemoItem> Items { get => this._items; set => SetProperty(ref this._items, value); }

        //ICommand

        public MemoMainViewModel()
        {

        }


    }
}
