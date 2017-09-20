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
using NotiXamarin.Adapters;

namespace NotiXamarin.Fragments
{
    public class BaseNewsListFragment : Fragment
    {
        protected ListView _newsListView;
        protected List<News> _news;

        public BaseNewsListFragment()
        {
            _news = new List<News>();
        }

        protected void SetupFragment()
        {
            SetupViews();

            SetupEvents();

            _newsListView.Adapter = new NewsListAdapter(Activity, _news);
        }

        protected void SetupViews()
        {
            _newsListView = View.FindViewById<ListView>(Resource.Id.newsListView);
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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.NewsListFragment, container, false);
        }

    }
}