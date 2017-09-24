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

namespace NotiXamarin.Fragments
{
    public class AllNewsListFragment : BaseNewsListFragment
    {
        private NewsService _newsService;

        public AllNewsListFragment()
        {
            _newsService = new NewsService();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            if (!_news.Any())
            {
                _news = _newsService.GetNews();
            }

            SetupFragment();
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            if (_selectedNews.Count > 0)
            {
                inflater.Inflate(Resource.Menu.newsActionMenu, menu);
            }

            base.OnCreateOptionsMenu(menu, inflater);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_read_later:
                    SaveSelectedNews(_selectedNews);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void SaveSelectedNews(List<News> selectedNews)
        {
            try
            {
                var newsLocalService = new NewsLocalService();
                foreach (var news in selectedNews)
                {
                    newsLocalService.Save(news);
                }

                Toast.MakeText(Activity, $"{selectedNews.Count} news saved", ToastLength.Short).Show();
                selectedNews.Clear();
                Activity.InvalidateOptionsMenu();
                UnselectElements();
            }
            catch (Exception ex)
            {

            }
        }
    }
}