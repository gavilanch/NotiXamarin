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
using NotiXamarin.Core.Services;
using NotiXamarin.Adapters;

namespace NotiXamarin
{
    [Activity(Label = "NotiXamarin", MainLauncher = true)]
    public class NewsListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewsList);

            var newsListView = FindViewById<ListView>(Resource.Id.newsListView);

            var newsService = new NewsService();
            var news = newsService.GetNews();
            newsListView.Adapter = new NewsListAdapter(this, news);
        }
    }
}