using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using NotiXamarin.Core.Models;

namespace NotiXamarin.Core.Data
{
    internal class NewsLocalRepository
    {
        private string _dbPath;

        public NewsLocalRepository(string dbPath)
        {
            _dbPath = dbPath;
            using (var _db = new SQLiteConnection(_dbPath))
            {
                _db.CreateTable<News>();
            }
        }

        public void Save(News news)
        {
            using (var _db = new SQLiteConnection(_dbPath))
            {
                _db.InsertOrReplace(news);
            }
        }

        public List<News> GetAll()
        {
            using (var _db = new SQLiteConnection(_dbPath))
            {
                return _db.Table<News>().ToList();
            }
        }

        public void Delete(int id)
        {
            using (var _db = new SQLiteConnection(_dbPath))
            {
                _db.Delete<News>(id);
            }
        }

        public void DeleteAll()
        {
            using (var _db = new SQLiteConnection(_dbPath))
            {
                _db.DeleteAll<News>();
            }
        }
    }
}