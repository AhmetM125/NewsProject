using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace BusinessLayer.Concrete
{
    public class NewsManager : INewService
    {
        private readonly IFileService _FileService;
        private readonly INewDA _newDA;
        private readonly ILogger<NewsManager> _logger;

        public NewsManager(IFileService fileService, INewDA newDA, ILogger<NewsManager> logger)
        {
            _FileService = fileService;
            _newDA = newDA;
            _logger = logger;
        }

        public async Task CreateNews(New value, IFormFile img)
        {
            try
            {
                if (value != null)
                {
                    Guid G_Id = Guid.NewGuid();
                    value.PublishDate = DateTime.Today.ToString("dd/MM/yyyy"); // Change the data type of PublishDate as needed
                    value.FilesId = G_Id;

                    if (img is not null)
                        await _FileService.InsertImage(img, G_Id);

                    await _newDA.Insert(value);

                }

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while creating new");
                throw;
            }

        }

        public async Task DeleteNews(int id)
        {
            try
            {
                var value = await GetNews(id);
                if (value is not null)
                {
                    var newId = value.New_Id.ToString();
                    var newentity = await _newDA.GetById(newId);
                    await _newDA.DeleteByEntity(newentity);
                    await _FileService.DeleteImage(value.FilesId);

                }

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while deleting new");
                throw;
            }

        }



        public async Task UpdateNews(New newsVal, IFormFile Image)
        {
            try
            {
                if (Image != null)
                    await _FileService.UpdateImage(newsVal.FilesId, Image);
                if (newsVal is not null)
                    await _newDA.Update(newsVal);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while updating new");
                throw;
            }

        }
        public async Task<List<New>> GetAllNews()
        {
            try
            {
                var listNews = await _newDA.GetAll();
                return listNews.ToList();

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while listing news");
                throw;
            }
        }


        public async Task<List<New>> GetLast4News()
        {
            try
            {
                var value = await _newDA.GetAll();
                value.OrderByDescending(x => x.PublishDate).Take(4).ToList();
                return (List<New>)value;

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while listing news");
                throw;
            }
        }

        public async Task<New> GetNews(int id)
        {
            try
            {
                var news = await _newDA.GetById(id.ToString());
                return news;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while GetNews");
                throw;
            }
        }

        public async Task<IEnumerable<New>> GetNewsByCategoryId(string C_Id)
        {
            return await _newDA.GetNewsByCategoryId(C_Id);
        }
    }
}
