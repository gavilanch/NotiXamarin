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
using NotiXamarin.Fragments;

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

            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.newsListFragmentContainer, new AllNewsListFragment());
            transaction.Commit();
        }

        private void NewsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            var id = (int)e.Id;
            intent.PutExtra(MainActivity.KEY_ID, id);
            StartActivity(intent);
        }
    }
}