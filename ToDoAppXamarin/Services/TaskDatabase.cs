using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAppXamarin.Model;

namespace ToDoAppXamarin.Services
{
    public class TaskDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public TaskDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TaskItem>().Wait();
        }

        public Task<List<TaskItem>> GetTasksAsync()
        {
            return _database.Table<TaskItem>().ToListAsync();
        }

        public Task<TaskItem> GetTaskAsync(int id)
        {
            return _database.Table<TaskItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTaskAsync(TaskItem task)
        {
            if (task.Id != 0)
                return _database.UpdateAsync(task);
            else
                return _database.InsertAsync(task);
        }

        public Task<int> DeleteTaskAsync(TaskItem task)
        {
            return _database.DeleteAsync(task);
        }
    }
}