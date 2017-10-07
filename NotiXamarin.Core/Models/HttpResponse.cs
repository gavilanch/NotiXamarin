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
using System.Net;

namespace NotiXamarin.Core.Models
{
    public class HttpResponse
    {
        public string Content { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}