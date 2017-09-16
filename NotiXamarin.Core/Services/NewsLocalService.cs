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
using NotiXamarin.Core.Data;
using NotiXamarin.Core.Models;

namespace NotiXamarin.Core.Services
{
    public class NewsLocalService
    {
        private NewsLocalRepository _newsLocalRepository;

        public NewsLocalService()
        {
            _newsLocalRepository = new NewsLocalRepository(ValuesService.GetDbPath());
        }

        public void Save(News news)
        {
            _newsLocalRepository.Save(news);
        }

        public List<News> GetAllSavedForReadLater()
        {
            return _newsLocalRepository.GetAll();
        }

        public void Delete(int id)
        {
            _newsLocalRepository.Delete(id);
        }

        public void Delete(List<int> ids)
        {
            ids.ForEach(x => Delete(x));
        }

        public void DeleteAll()
        {
            _newsLocalRepository.DeleteAll();
        }
    }
}