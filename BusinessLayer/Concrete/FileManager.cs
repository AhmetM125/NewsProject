using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace BusinessLayer.Concrete
{
    public class FileManager : IFileService
    {
        private readonly IFilesDA _filesDal;
        private readonly ILogger<FileManager> _logger;
        /* private readonly IFilesDal _filesDal;*/

        public FileManager(IFilesDA filesDal, ILogger<FileManager> logger)
        {
            _filesDal = filesDal;
            _logger = logger;
        }

        public async Task<Files?> GetFileById(Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var value = id.ToString();

                    var files = await _filesDal.GetById(value);
                    return files;
                }
                else
                {
                    _logger.LogError("Empty Guid id for file");
                    return null;
                }

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL exception for GetFileById");
                throw;
            }
        }

        public async Task InsertImage(IFormFile file, Guid? G_Id)
        {

            var Files = new Files()
            {
                Id = (Guid)G_Id,
                Content = ConvertToImage(file)?.ToArray(),
                Size = ((byte)file.Length),
                Extention = file.ContentType,
                ContentType = file.ContentType,
                FileName = file.FileName,
            };

            try
            {
                var RowAffect = await _filesDal.Insert(Files);
                await _filesDal.Insert(Files);
                return;

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, $"SQL Exception occurred in Insert Image");
                throw;
            }
        }


        public MemoryStream? ConvertToImage(IFormFile files)
        {
            var memoryStream = new MemoryStream();
            if (files != null && files.Length > 0)
            {
                files.CopyTo(memoryStream);
            }
            return memoryStream;
        }


        public async Task UpdateImage(Guid? FilesId, IFormFile image)
        {
            var MemoryStream = ConvertToImage(image);
            Files value = await GetFileById(FilesId);
            value.Extention = image.ContentType;
            value.FileName = image.FileName;
            value.Content = ConvertToImage(image).ToArray();
            value.Size = ((byte)image.Length);
            value.ContentType = image.ContentType;

            try
            {
                if (value is not null)
                    await _filesDal.Update(value);

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, $"SQL Exception occurred while updating image");
                throw;
            }

        }

        public async Task DeleteImage(Guid? FilesId)
        {
            try
            {
                var file = await GetFileById(FilesId);
                if (file is not null)
                {
                    var id = file.Id.ToString();
                    await _filesDal.Delete(id);
                }

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, $"SQL Exception occurred while Deleting image");
                throw;
            }
        }
    }
}
