﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer.Concrete
{
    public class FileManager : IFileService
    {
        IFilesDal _filesDal;
        public FileManager(IFilesDal filesDal)
        {
            _filesDal = filesDal;
        }

        public Files GetFileById(Guid id)
        {
            return _filesDal.Get(x => x.Id == id);
        }

        public void InsertImage(IFormFile file, Guid G_Id)
        {
            var Files = new Files()
            {
                Id = G_Id,
                Content = ConvertToImage(file).ToArray(),
                Size = ((byte)file.Length),
                Extention = file.ContentType,
                ContentType = file.ContentType,
                FileName = file.FileName,
            };
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
