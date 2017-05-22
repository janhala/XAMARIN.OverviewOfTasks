using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XAMARIN.OverviewOfTasks.Entity
{
    public class TodoItemDatabase
    {
        private SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<SeznamHodin>().Wait();
            database.CreateTableAsync<SeznamUkolu>().Wait();
        }

        public Task<List<SeznamHodin>> GetItemsAsync()
        {
            return database.Table<SeznamHodin>().ToListAsync();
        }

        public Task<List<SeznamUkolu>> GetItemsAsyncSeznamUkolu()
        {
            return database.Table<SeznamUkolu>().ToListAsync();
        }

        public Task<List<SeznamHodin>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<SeznamHodin>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<SeznamHodin> GetItemAsync(int id)
        {
            return database.Table<SeznamHodin>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SeznamHodin item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(SeznamHodin item)
        {
            return database.DeleteAsync(item);
        }
    }
}

