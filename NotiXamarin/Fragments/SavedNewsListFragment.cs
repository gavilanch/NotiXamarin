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
    internal class SavedNewsListFragment : BaseNewsListFragment
    {
        private NewsLocalService _newsLocalService;

        public SavedNewsListFragment()
        {
            _newsLocalService = new NewsLocalService();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FillNews();

            SetupFragment();
        }

        private void FillNews()
        {
            _news = _newsLocalService.GetAllSavedForReadLater();
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            if (_selectedNews.Count > 0)
            {
                inflater.Inflate(Resource.Menu.savedNewsActionMenu, menu);
            }

            base.OnCreateOptionsMenu(menu, inflater);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.delete_saved_news:
                    DeleteSelectedNews(_selectedNews);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void DeleteSelectedNews(List<News> selectedNews)
        {
            try
            {
                foreach (var news in selectedNews)
                {
                    _newsLocalService.Delete(news.Id);
                }

                Toast.MakeText(Activity, $"{selectedNews.Count} news deleted", ToastLength.Short).Show();

                selectedNews.Clear();
                FillNews();
                SetupAdapter();
                Activity.InvalidateOptionsMenu();
            }
            catch (Exception ex)
            {
                Toast.MakeText(Activity, ex.Message, ToastLength.Long).Show();
            }
        }
    }
}