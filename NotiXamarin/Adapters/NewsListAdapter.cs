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
using Square.Picasso;

namespace NotiXamarin.Adapters
{
    class NewsListAdapter : BaseAdapter<News>
    {
        private Activity _context;
        private List<News> _news;
        private ISelectedChecker _selectedChecker;
        private INotify _loadObserver;

        public NewsListAdapter(Activity context, List<News> news, ISelectedChecker selectedChecker)
        {
            _context = context;
            _news = news;
            _selectedChecker = selectedChecker;
        }


        public override News this[int position] => _news[position];

        public override int Count => _news.Count;

        public override long GetItemId(int position)
        {
            return this[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.NewsListRow, null);
            }
            else
            {
                var id = (int)GetItemId(position);
                RelativeLayout rl = convertView.FindViewById<RelativeLayout>(Resource.Id.newsListRow_RelativeLayout);

                if (_selectedChecker.IsItemSelected(id))
                {
                    var colorForSelected = _context.Resources.GetString(Resource.Color.listitemselected);
                    rl.SetBackgroundColor(Android.Graphics.Color.ParseColor(colorForSelected));
                }
                else
                {
                    var colorForUnselected = _context.Resources.GetString(Resource.Color.listitemunselected);
                    rl.SetBackgroundColor(Android.Graphics.Color.ParseColor(colorForUnselected));
                }

                if (IsEndOfList(position))
                {
                    NotifyLoadObserver();
                }
            }

            convertView.FindViewById<TextView>(Resource.Id.newsTitle).Text = item.Title;
            var newsImage = convertView.FindViewById<ImageView>(Resource.Id.newsImage);

            var imageURL = string.Concat(ValuesService.ImagesBaseURL, item.ImageName);

            Picasso.With(_context)
                .Load(imageURL)
                .Placeholder(_context.GetDrawable(Resource.Drawable.Icon))
                .Into(newsImage);

            return convertView;
        }

        internal void AddNews(List<News> news)
        {
            _news = news;
        }

        private bool IsEndOfList(int position)
        {
            return position == Count - 1;
        }

        public void RegisterLoadObserver(INotify loadObserver)
        {
            _loadObserver = loadObserver;
        }

        private void NotifyLoadObserver()
        {
            if (_loadObserver != null)
            {
                _loadObserver.NotifyObserver();
            }
        }
    }
}