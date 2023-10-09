using EntityLayer;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
    public interface INewService
    {
        Task<List<New>> GetAllNews();
        Task<New> GetNews(int id);
        Task CreateNews(New value, IFormFile img);
        Task DeleteNews(int id);
        Task UpdateNews(New newsVal, IFormFile Image);
        Task<List<New>> GetLast4News();

        Task<IEnumerable<New>> GetNewsByCategoryId(string C_Id);
    }
}
