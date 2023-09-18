using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
namespace M_News.Controllers
{
    public class NewsController : Controller
    {
        NewsManager NewsManager = new NewsManager(new EfNewDal());
        FileManager FileManager = new FileManager(new EfFilesDal());
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
        public IActionResult EditNews(News value,IFormFile Image)
        {

            return null;
        }
        public IActionResult DeleteNews(int Id)
        {
            NewsManager.DeleteNews(Id);
            return RedirectToAction("Index", "News");
        }

        [HttpPost]
        public IActionResult CreateNews(News value, IFormFile Image)
        {
            FileManager.InsertImage(value,Image); 
            return RedirectToAction("Index", "News");
        }
            
          



    }
}
