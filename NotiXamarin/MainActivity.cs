using Android.App;
using Android.Widget;
using Android.OS;

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

            var newsTitle = FindViewById<TextView>(Resource.Id.newsTitle);
            var newsBody = FindViewById<TextView>(Resource.Id.newsBody);
            var newsImage = FindViewById<ImageView>(Resource.Id.newsImage);

            newsTitle.Text = "Este es un título";
            newsBody.Text = "Xamarin es una compañía de software estadounidense, propiedad de Microsoft y con sede principal en San Francisco(California), fundada en mayo de 2011 por Nat Friedman y Miguel de Icaza(que iniciaron el Proyecto Mono)";
            var icon = GetDrawable(Resource.Drawable.Icon);
            newsImage.SetImageDrawable(icon);
        }
    }
}

