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
using System.IO;
using NotiXamarin.Core.Models;
using System.Threading.Tasks;

namespace NotiXamarin.Core.Services
{
    public class WebServices
    {
        public HttpResponse Get(string Url)
        {
            var request = WebRequest.Create(Url);
            request.ContentType = "application/json";
            request.Method = "GET";
            using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
            {
                return BuildResponse(httpResponse);
            }
        }

        private static HttpResponse BuildResponse(HttpWebResponse httpResponse)
        {
            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var content = reader.ReadToEnd();
                var response = new HttpResponse();
                response.Content = content;
                response.HttpStatusCode = httpResponse.StatusCode;
                return response;
            }
        }

        public async Task<HttpResponse> GetAsync(string Url)
        {
            var request = WebRequest.Create(Url);
            request.ContentType = "application/json";
            request.Method = "GET";
            using (HttpWebResponse httpResponse = await request.GetResponseAsync() as HttpWebResponse)
            {
                return BuildResponse(httpResponse);
            }
        }
    }
}