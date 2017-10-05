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
    public class NewsService
    {
        private NewsRepository _newsRepository;

        public NewsService()
        {
            _newsRepository = new NewsRepository();
        }

        public List<News> GetNews(int page)
        {
            return _newsRepository.GetNews(page);
        }

        public News GetNewsById(int Id)
        {
            return _newsRepository.GetNewsById(Id);
        }
    }
}