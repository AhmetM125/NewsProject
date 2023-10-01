using BusinessLayer.DapperRepository;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IFilesDA : IRepositoryDAP<Files>
    {
        Task<IEnumerable<Files>> GetAllFiles();
        Task<Files> GetFileById(Guid id);
        Task<bool> DeleteFile(Guid id);
        
        Task<bool> InsertFile(Files file);
        Task<bool> UpdateFile(Files file);
    }
}
