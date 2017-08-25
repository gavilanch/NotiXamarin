using Android.App;
using Android.Widget;
using Android.OS;
using NotiXamarin.Core.Services;
using Square.Picasso;
using System;
using Android.Views;

namespace NotiXamarin
{
    [Activity(Label = "NotiXamarin", Icon = "@drawable/icon", ParentActivity = typeof(NewsListActivity))]
    public class MainActivity : Activity
    {
        internal static string KEY_ID = "KEY_ID";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            PrepareActionBar();

            var id = Intent.Extras.GetInt(KEY_ID);

            var newsService = new NewsService();

            var news = newsService.GetNewsById(id);

            var newsTitle = FindViewById<TextView>(Resource.Id.newsTitle);
            var newsBody = FindViewById<TextView>(Resource.Id.newsBody);
            var newsImage = FindViewById<ImageView>(Resource.Id.newsImage);

            var display = WindowManager.DefaultDisplay;
            Android.Graphics.Point point = new Android.Graphics.Point();
            display.GetSize(point);

            var imageURL = string.Concat(ValuesService.ImagesBaseURL, 
                news.ImageName);

            Picasso.With(ApplicationContext)
                .Load(imageURL)
                .Resize(point.X, 0)
                .Into(newsImage);

            newsTitle.Text = news.Title;
            newsBody.Text = news.Body;
        }

        private void PrepareActionBar()
        {
            ActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.newsActionMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_read_later:
                    HandleReadLater();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void HandleReadLater()
        {
            Toast.MakeText(this, "read later", ToastLength.Short).Show();
        }
    }
}

