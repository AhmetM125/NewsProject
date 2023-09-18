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
        void CreateNews(News value,Guid id);
        void DeleteNews(int id);

        List<News> GetLast4News();
    }
}
