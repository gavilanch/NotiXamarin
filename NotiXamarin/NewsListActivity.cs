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
    [Activity(Label = "NotiXamarin", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class NewsListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewsList);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            var tabsHeaderAllNews = Resources.GetString(Resource.String.NewsListActivity_Tabs_AllNews_Header);
            var tabsHeaderSavedNews = Resources.GetString(Resource.String.NewsListActivity_Tabs_SavedNews_Header);

            AddTab(tabsHeaderAllNews, new AllNewsListFragment());
            AddTab(tabsHeaderSavedNews, new SavedNewsListFragment());
        }

        private void AddTab(string tabTitle, Fragment fragment)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(tabTitle);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var previousFragment = FragmentManager.FindFragmentById(Resource.Id.newsListFragmentContainer);
                if (previousFragment != null)
                {
                    e.FragmentTransaction.Remove(previousFragment);
                }
                e.FragmentTransaction.Add(Resource.Id.newsListFragmentContainer, fragment);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(fragment);
            };

            ActionBar.AddTab(tab);
        }
    }
}