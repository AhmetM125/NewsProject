using EntityLayer;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
    public interface INewService
    {
        Task<List<News>> GetAllNews();
        Task<News> GetNews(int id);
        Task CreateNews(News value, IFormFile img);
        Task DeleteNews(int id);
        Task UpdateNews(News newsVal, IFormFile Image);
        Task<List<News>> GetLast4News();
        /* void UpdateNews(News newsVal, IFormFile Image);*/
    }
}
