using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Abstract
{
    public interface IFileService
    {
        Task<EntityLayer.File?> GetFileById(Guid? id);
        Task InsertImage(IFormFile file, Guid? G_Id);

        Task UpdateImage(Guid? FilesId, IFormFile image);
        Task DeleteImage(Guid? FilesId);
    }
}
