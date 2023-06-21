using MemoApp.Helpers;
using MemoApp.Interfaces;
using MemoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MemoApp.Data
{
    public class IDAndPWItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<IDAndPWItemDatabase> Instance = new AsyncLazy<IDAndPWItemDatabase>(async () =>
        {
            var instance = new IDAndPWItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<IDAndPWItem>();
            return instance;
        });

        public IDAndPWItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<List<IDAndPWItem>> GetItemsAsync()
        {
            return Database.Table<IDAndPWItem>().ToListAsync();
        }

        public Task<List<IDAndPWItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<IDAndPWItem>("SELECT * FROM [IDAndPWItem]");
        }

        public Task<IDAndPWItem> GetItemAsync(int Req)
        {
            return Database.Table<IDAndPWItem>().Where(i => i.Req == Req).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(IDAndPWItem item)
        {

            if (item.Req != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                item.RegDate = DateTime.Now.ToString("yyyy년 MM월 dd일");
                item.RegDateTime = DateTime.Now;
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(IDAndPWItem item)
        {
            return Database.DeleteAsync(item);
        }


        public async Task<string> DBToExport()
        {
            var result = await PermissionMethods.AskForRequiredStoragePermission();
            if (!result)
            {
                IPermissionSettingsService service = DependencyService.Get<IPermissionSettingsService>();
                service.OpenAppSettings();

                return string.Empty;
            }

            var backupPath = Path.Combine(FileSystem.CacheDirectory, Constants.DatabaseFilename);
            await Database.BackupAsync(backupPath);

            return backupPath;
        }



    }
}
