using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer.Concrete
{
    public class FileManager : IFileService
    {
        IFilesDal _filesDal;
        readonly NewsManager newsManager = new NewsManager(new EfNewDal());
        public FileManager(IFilesDal filesDal)
        {
            _filesDal = filesDal;
        }

        public Files GetFileById(Guid id)
        {
            return _filesDal.Get(x => x.Id == id);
        }

        public void InsertImage(News value,IFormFile file)
        {
            Guid Id = Guid.NewGuid();
            var Files = new Files()
            {
                Id = Id,
                Content = ConvertToImage(file).ToArray(),
                Size = ((byte)file.Length),
                Extention = file.ContentType,
                ContentType = file.ContentType,
                FileName = file.FileName,
            };

            _filesDal.Update();
            newsManager.CreateNews(value, Id);
            _filesDal.Insert(Files);
        }
        public MemoryStream ConvertToImage(IFormFile files)
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
    }
}
