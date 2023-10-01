using BusinessLayer.DapperRepository;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface INewDA : IRepositoryDAP<News>
    {
        Task<IEnumerable<News>> GetAllNewsAsync();
        Task<News> GetNewsByIdAsync(int id);
        Task<bool> DeleteNewsById(int id);
        Task<bool> UpdateNews(News news);
        Task<bool> CreateNewsAsync(News news);

    }
}
