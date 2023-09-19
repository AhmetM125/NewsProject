using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Abstract
{
    public interface IFileService
    {
        Files GetFileById(Guid id);
        void InsertImage(IFormFile file, Guid G_Id);

        void UpdateImage(Guid FilesId, IFormFile image);
        void DeleteImage(Guid FilesId);
    }
}
