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
            database.CreateTableAsync<SeznamPredmetu>().Wait();
            database.CreateTableAsync<SeznamUkolu>().Wait();
            database.CreateTableAsync<PredmetyVRozvrhu>().Wait();
        }

        // seznam predmetu

        public Task<List<SeznamPredmetu>> GetItemsAsync()
        {
            return database.Table<SeznamPredmetu>().ToListAsync();
        }

        public Task<List<SeznamPredmetu>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<SeznamPredmetu>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<SeznamPredmetu> GetItemAsync(int id)
        {
            return database.Table<SeznamPredmetu>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SeznamPredmetu item)
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

        public Task<int> DeleteItemAsync(SeznamPredmetu item)
        {
            return database.DeleteAsync(item);
        }

        // predmety v rozvrhu
        public Task<int> SaveItemAsync(PredmetyVRozvrhu item)
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

    }
}

