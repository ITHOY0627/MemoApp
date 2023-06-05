using MemoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoApp.Data
{
    public class MemoItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<MemoItemDatabase> Instance = new AsyncLazy<MemoItemDatabase>(async () =>
        {
            var instance = new MemoItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<MemoItem>();
            return instance;
        });

        public MemoItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<List<MemoItem>> GetItemsAsync()
        {
            return Database.Table<MemoItem>().ToListAsync();
        }

        public Task<List<MemoItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<MemoItem>("SELECT * FROM [MemoItem]");
        }

        public Task<MemoItem> GetItemAsync(int id)
        {
            return Database.Table<MemoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(MemoItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(MemoItem item)
        {
            return Database.DeleteAsync(item);
        }




    }
}
