using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public interface INewService
    {
        List<News> GetAllNews();
        News GetNews(int id);
        void CreateNews(News value, IFormFile img);
        void DeleteNews(int id);
        void UpdateNews(News newsVal, IFormFile Image);
        List<News> GetLast4News();
        /* void UpdateNews(News newsVal, IFormFile Image);*/
    }
}
