using NotiXamarin.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotiXamarin.Api.Data
{
    public class NewsInMemoryRepository
    {
        private List<News> _news;
        private int size = 10;

        public NewsInMemoryRepository()
        {
            _news = new List<News>();

            for (int i = 1; i <= 30; i++)
            {
                var newNews = new News();

                newNews.Body = "Body " + i.ToString();
                newNews.Title = "Title " + i.ToString();
                newNews.Id = i;
                newNews.ImageName = chooseImage(i);
                _news.Add(newNews);
            }

            string chooseImage(int discriminant)
            {
                switch (discriminant % 3)
                {
                    case 0:
                        return "noticia1.png";
                    case 1:
                        return "noticia2.png";
                    case 2:
                        return "noticia3.png";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public List<News> GetNews(int page)
        {
            return _news.Skip((page - 1) * size).Take(size)
                .Select(x => new News {Id = x.Id, ImageName = x.ImageName, Title = x.Title }).ToList();
        }

        public News GetNewsById(int Id)
        {
            return _news.FirstOrDefault(x => x.Id == Id);
        }
    }
}