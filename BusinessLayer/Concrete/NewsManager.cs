using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer.Concrete
{
    public class NewsManager : INewService
    {
        INewDal _NewDal;

        public NewsManager(INewDal NewDal)
        {

            _NewDal = NewDal;
        }

        public void CreateNews(News value, Guid id)
        {
            value.PublishDate = DateTime.Today.ToString("dd/MM/yyyy"); // Change the data type of PublishDate as needed
            value.FilesId = id;
            _NewDal.Insert(value);
            
            

            /*if (Image != null && Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Image.CopyTo(memoryStream);
                    value = memoryStream.ToArray();
                }
            }*/

        }

        public void DeleteNews(int id)
        {
            var value = GetNews(id);
            _NewDal.Delete(value);
        }

        public List<News> GetAllNews() => _NewDal.List();

        public List<News> GetLast4News()
        {
            var value = _NewDal.List().OrderByDescending(x => x.PublishDate).Take(4).ToList();
            return value;
        }

        public News GetNews(int id) => _NewDal.Get(x => x.New_Id == id);
    }
}
