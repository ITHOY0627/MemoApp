using MemoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MemoApp.ViewModels
{
    public class MemoItemViewModel : ViewModelBase
    {
        public MemoItemViewModel()
        {

        }

        //private ObservableRangeCollection<MemoItem> _users = new ObservableRangeCollection<MemoItem>();

        //변수
        //private int _ID;
        //private string _title;
        //private string _notes;
        //private string _regDate;
        //private DateTime? _registDateTime;

        //public int ID { get => this._ID; set => SetProperty(ref this._ID, value); }
        //public string Title {  get => this._title; set =>  SetProperty(ref this._title, value);}
        //public string Notes { get => this._notes; set => SetProperty(ref this._notes, value);}
        //public String RegDate { get => this._regDate; set => SetProperty(ref this._regDate, value); }
        //public DateTime? RegDateTime { get => this._registDateTime; set => SetProperty(ref this._registDateTime, value); }



        //private void SelectUser(Models.MemoItem item)
        //{
        //    //IsControlEnable = false;
        //    //IsBusy = true;
        //    (SelectUserCommand as Command).ChangeCanExecute();

        //    if (item != null)
        //    {
        //        this.ID = item.ID;
        //        this.Title = item.Title;
        //        this.Email = item.Notes;
        //        this.Telephone = item.RegDate;
        //        this.RegistDate = item.RegDateTime;
        //    }

        //    //IsControlEnable = true;
        //    //IsBusy = false;
        //    (SelectUserCommand as Command).ChangeCanExecute();
        //}



    }
}
