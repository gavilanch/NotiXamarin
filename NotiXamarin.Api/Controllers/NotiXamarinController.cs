using NotiXamarin.Api.Data;
using NotiXamarin.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NotiXamarin.Api.Controllers
{
    public class NotiXamarinController : ApiController
    {
        private NewsInMemoryRepository _repository;

        public NotiXamarinController()
        {
            _repository = new NewsInMemoryRepository();
        }

        public IEnumerable<News> Get()
        {
            var pageValue = GetQueryStringValueOrDefault("page", "1");
            int.TryParse(pageValue, out int page);
            var news = _repository.GetNews(page);
            return news;
        }

        public IHttpActionResult Get(int Id)
        {
            var news = _repository.GetNewsById(Id);

            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        private string GetQueryStringValueOrDefault(string key, string defaultValue)
        {
            var queryString = Request.GetQueryNameValuePairs().FirstOrDefault(x => x.Key == key);
            if (queryString.Key == null)
            {
                return defaultValue;
            }

            return queryString.Value;
        }

    }
}
