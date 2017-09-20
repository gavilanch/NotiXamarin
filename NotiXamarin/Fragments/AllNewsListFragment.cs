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
using NotiXamarin.Core.Models;
using NotiXamarin.Adapters;

namespace NotiXamarin.Fragments
{
    public class AllNewsListFragment : Fragment
    {
        private NewsService _newsService;
        private List<News> _news;
        private ListView _newsListView;

        public AllNewsListFragment()
        {
            _newsService = new NewsService();
            _news = new List<News>();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            if (!_news.Any())
            {
                _news = _newsService.GetNews();
            }

            SetupViews();

            SetupEvents();

            _newsListView.Adapter = new NewsListAdapter(Activity, _news);

        }

        protected void SetupViews()
        {
            _newsListView = View.FindViewById<ListView>(Resource.Id.newsListView);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.NewsListFragment, container, false);
        }

        protected void SetupEvents()
        {
            _newsListView.ItemClick += NewsListView_ItemClick;
        }

        private void NewsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(Activity, typeof(MainActivity));
            var id = (int)e.Id;
            intent.PutExtra(MainActivity.KEY_ID, id);
            StartActivity(intent);
        }
    }
}