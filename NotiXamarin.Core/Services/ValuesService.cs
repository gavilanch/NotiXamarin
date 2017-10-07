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

namespace NotiXamarin.Core.Services
{
    public class ValuesService
    {
        public static readonly string ImagesBaseURL = "http://mirepogavilanch2.azurewebsites.net/images/";
        public static readonly string NewsApiUrl = "http://mirepogavilanch2.azurewebsites.net/api/NotiXamarin/";
        public static readonly string DbName = "notiXamarinDb.db";

        public static string GetDbPath()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(folder, DbName);
        }
    }
}