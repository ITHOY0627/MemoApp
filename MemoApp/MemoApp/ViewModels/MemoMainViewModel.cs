using MemoApp.Data;
using MemoApp.Interfaces;
using MemoApp.Models;
using MemoApp.Views;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MemoApp.ViewModels
{
    public class MemoMainViewModel : ViewModelBase
    {
        INavigation _navigation => Application.Current.MainPage.Navigation;

        //멤버변수
        private ObservableRangeCollection<MemoItem> _items = new ObservableRangeCollection<MemoItem>();


        //Prop
        public ObservableRangeCollection<MemoItem> Items { get => this._items; set => SetProperty(ref this._items, value); }

        //ICommand
        public ICommand ExportDBCommand { get; private set; }
        public ICommand ItemAddedCommand { get; private set; }
        public ICommand ItemSelectedCommand { get; private set; }

        public MemoMainViewModel()
        {

            ExportDBCommand = new Command(() => ExportDB(), () => IsControlEnable);
            ItemAddedCommand = new Command(() => ItemAdded(), () => IsControlEnable);
            ItemSelectedCommand = new Command(() => ItemSelected(), () => IsControlEnable);
        }

        public void OnAppearing() // 화면 나올때마다 불러옴.(view에서 불러옴.)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                MemoItemDatabase database = await MemoItemDatabase.Instance;
                var result = await database.GetItemsAsync();

                Items.Clear();
                Items.AddRange(result);
            });
        }

        private async void ItemAdded()
        {
            await _navigation.PushAsync(new MemoItemPage
            {
                BindingContext = new MemoItem()
            });
        }

        private async void ItemSelected()
        {
            await _navigation.PushAsync(new MemoItemPage
            {
                BindingContext = new MemoItem()
            });
        }


        private async void ExportDB()
        {

            IsControlEnable = false;
            IsBusy = true;
            (ExportDBCommand as Command).ChangeCanExecute();

            Analytics.TrackEvent("ExportDB");

            MemoItemDatabase database = await MemoItemDatabase.Instance;
            var path = await database.DBToExport();

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    try
                    {
                        IShareFilePermission service = DependencyService.Get<IShareFilePermission>();
                        service.GrantPermission(path, "application/octet-stream");

                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Err", ex.Message, "OK");
                    }
                }
                else
                {
                    try
                    {
                        await Share.RequestAsync(new ShareFileRequest
                        {
                            Title = "DB File",
                            File = new ShareFile(path)
                        });
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine("ERROR: " + ex.Message);
                        await Application.Current.MainPage.DisplayAlert("Err", ex.Message, "OK");

                        Crashes.TrackError(ex);
                    }
                }
            }

            IsControlEnable = true;
            IsBusy = false;
            (ExportDBCommand as Command).ChangeCanExecute();
        }


    }
}
