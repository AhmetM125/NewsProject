using BusinessLayer.DapperRepository;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IFilesDA : IRepositoryDAP<EntityLayer.File>
    {
        Task<IEnumerable<EntityLayer.File>> GetAllFiles();
        Task<EntityLayer.File> GetFileById(Guid id);
        Task<bool> DeleteFile(Guid id);
        
        Task<bool> InsertFile(EntityLayer.File file);
        Task<bool> UpdateFile(EntityLayer.File file);
    }
}
