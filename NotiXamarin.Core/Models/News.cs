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
using SQLite;

namespace NotiXamarin.Core.Models
{
    public class News
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        [Ignore]
        public string Body { get; set; }
        public string ImageName { get; set; }
    }
}