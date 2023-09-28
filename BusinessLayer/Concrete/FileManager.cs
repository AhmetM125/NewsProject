using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
    public class FileManager : IFileService
    {
        private readonly IFilesDal _filesDal;

        public FileManager(IFilesDal filesDal)
        {
            _filesDal = filesDal;
        }

        public Files GetFileById(Guid? id)
        {
            return _filesDal.Get(x => x.Id == id);
        }

        public void InsertImage(IFormFile file,Guid? G_Id)
        {
            var Files = new Files()
            {
                Id = (Guid)G_Id,
                Content = ConvertToImage(file).ToArray(),
                Size = ((byte)file.Length),
                Extention = file.ContentType,
                ContentType = file.ContentType,
                FileName = file.FileName,
            };

            _filesDal.Insert(Files);
        }


        public MemoryStream? ConvertToImage(IFormFile files)
        {
            if (files != null && files.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    files.CopyTo(memoryStream);
                    return memoryStream;
                }
            }
            return null;
        }

      
        public void UpdateImage(Guid? FilesId, IFormFile image)
        {
            var MemoryStream = ConvertToImage(image);
            Files value = GetFileById(FilesId);
            value.Extention = image.ContentType;
            value.FileName = image.FileName;
            value.Content = ConvertToImage(image).ToArray();
            value.Size = ((byte)image.Length);
            value.ContentType = image.ContentType;
            _filesDal.Update(value);

        }

        public void DeleteImage(Guid? FilesId)
        {
           _filesDal.Delete(GetFileById(FilesId));
        }
    }
}
