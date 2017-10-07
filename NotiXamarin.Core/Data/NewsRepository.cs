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
using NotiXamarin.Core.Models;
using NotiXamarin.Core.Services;

namespace NotiXamarin.Core.Data
{
    internal class NewsRepository
    {
        private WebServices _webServices;

        public NewsRepository()
        {
            _webServices = new WebServices();
        }

        public List<News> GetNews(int page)
        {
            var queryString = "?page=" + page;
            var response = _webServices.Get(ValuesService.NewsApiUrl + queryString);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<News>>(response.Content);
        }

        public News GetNewsById(int Id)
        {
            var response = _webServices.Get(ValuesService.NewsApiUrl + Id);

            if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ApplicationException("news not found");
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<News>(response.Content);

        }
    }
}