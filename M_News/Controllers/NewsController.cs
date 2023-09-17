using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
namespace M_News.Controllers
{
    public class NewsController : Controller
    {
        NewsManager NewsManager = new NewsManager(new EfNewDal());
        public IActionResult Index()
        {
            var NewsValues = NewsManager.GetAllNews();
            return View(NewsValues);
        }
        [HttpGet]
        public IActionResult CreateNews()
        {

            return View();
        }
        [HttpGet]
        public IActionResult EditNews(int Id)
        {
            var News = NewsManager.GetNews(Id);
            return View(News);
        }

        public IActionResult DeleteNews(int Id)
        {
            NewsManager.DeleteNews(Id);
            return RedirectToAction("Index", "News");
        }

        [HttpPost]
        public IActionResult CreateNews(News value, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                using(var memoryStream = new MemoryStream())
                {
                    Image.CopyTo(memoryStream);
                    value.Image = memoryStream.ToArray();
                }
            }
            value.PublishDate = DateTime.Today.ToString("dd/MM/yyyy"); // Change the data type of PublishDate as needed
            NewsManager.CreateNews(value);
            return RedirectToAction("Index", "News");
        }

    }
}
