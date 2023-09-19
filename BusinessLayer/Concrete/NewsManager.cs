using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
    public class NewsManager : INewService
    {
        INewDal _NewDal;
        FileManager fileManager = new FileManager(new EfFilesDal());

        public NewsManager(INewDal NewDal)
        {

            _NewDal = NewDal;
        }

        public void CreateNews(News value, IFormFile img)
        {
            Guid G_Id = Guid.NewGuid();
            value.PublishDate = DateTime.Today.ToString("dd/MM/yyyy"); // Change the data type of PublishDate as needed
            value.FilesId = G_Id;
            fileManager.InsertImage(img, G_Id);
            _NewDal.Insert(value);

        }

        public void DeleteNews(int id)
        {
            var value = GetNews(id);
            fileManager.DeleteImage(value.FilesId);
            
        }



        public void UpdateNews(News newsVal, IFormFile Image)
        {
            if (Image != null)
                fileManager.UpdateImage(newsVal.FilesId, Image);

            _NewDal.Update(newsVal);
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
