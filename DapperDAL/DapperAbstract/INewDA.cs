using BusinessLayer.DapperRepository;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface INewDA : IRepositoryDAP<New>
    {
        Task<IEnumerable<New>> GetAllNewsAsync();
        Task<New> GetNewsByIdAsync(int id);
        Task<bool> DeleteNewsById(int id);
        Task<bool> UpdateNews(New news);
        Task<bool> CreateNewsAsync(New news);
        Task<IEnumerable<New>> GetNewsByCategoryId(string categoryId);

    }
}
