using Android.App;
using Android.Widget;
using Android.OS;
using NotiXamarin.Core.Services;

namespace NotiXamarin
{
    [Activity(Label = "NotiXamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            var newsService = new NewsService();

            var news = newsService.GetNewsById(1);

            var newsTitle = FindViewById<TextView>(Resource.Id.newsTitle);
            var newsBody = FindViewById<TextView>(Resource.Id.newsBody);
            var newsImage = FindViewById<ImageView>(Resource.Id.newsImage);

            newsTitle.Text = news.Title;
            newsBody.Text = news.Body;
            var icon = GetDrawable(Resource.Drawable.Icon);
            newsImage.SetImageDrawable(icon);
        }
    }
}

