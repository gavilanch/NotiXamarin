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
    internal class BaseNewsListFragment : Fragment, ISelectedChecker
    {
        protected ListView _newsListView;
        protected List<News> _news;
        protected List<News> _selectedNews;
        protected NewsListAdapter _newsListAdapter;

        public BaseNewsListFragment()
        {
            _news = new List<News>();
            _selectedNews = new List<News>();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            _selectedNews.Clear();
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);
        }

        protected void SetupFragment()
        {
            SetupViews();

            SetupEvents();

            SetupAdapter();
        }

        protected void SetupAdapter()
        {
            _newsListAdapter = new NewsListAdapter(Activity, _news, this);
            _newsListView.Adapter = _newsListAdapter;
        }

        protected void SetupViews()
        {
            _newsListView = View.FindViewById<ListView>(Resource.Id.newsListView);
        }

        protected void SetupEvents()
        {
            _newsListView.ItemClick += NewsListView_ItemClick;
            _newsListView.ItemLongClick += _newsListView_ItemLongClick;
        }

        private void _newsListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            int id = (int)e.Id;
            View view = e.View;

            RelativeLayout rl = view.FindViewById<RelativeLayout>(Resource.Id.newsListRow_RelativeLayout);

            if (_selectedNews.Select(x => x.Id).Contains(id))
            {
                // deselect element
                var colorForUnselected = Resources.GetString(Resource.Color.listitemunselected);
                rl.SetBackgroundColor(Android.Graphics.Color.ParseColor(colorForUnselected));
                _selectedNews.Remove(_newsListAdapter[e.Position]);
            }
            else
            {
                // select element
                var colorForSelected = Resources.GetString(Resource.Color.listitemselected);
                rl.SetBackgroundColor(Android.Graphics.Color.ParseColor(colorForSelected));
                _selectedNews.Add(_newsListAdapter[e.Position]);
            }

            // Forces android to execute OnCreateOptionsMenu
            Activity.InvalidateOptionsMenu();
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

        protected void UnselectElements()
        {
            int count = _newsListView.ChildCount;

            for (int i = 0; i < count; i++)
            {
                View row = _newsListView.GetChildAt(i);
                var rl = row.FindViewById<RelativeLayout>(Resource.Id.newsListRow_RelativeLayout);
                var color = Resources.GetString(Resource.Color.listitemunselected);
                rl.SetBackgroundColor(Android.Graphics.Color.ParseColor(color));
            }
        }

        public bool IsItemSelected(int id)
        {
            return _selectedNews.Select(x => x.Id).Contains(id);
        }
    }
}