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

namespace NotiXamarin.Fragments
{
    public class SavedNewsListFragment : BaseNewsListFragment
    {
        private NewsLocalService _newsLocalService;

        public SavedNewsListFragment()
        {
            _newsLocalService = new NewsLocalService();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            _news = _newsLocalService.GetAllSavedForReadLater();

            SetupFragment();
        }
    }
}