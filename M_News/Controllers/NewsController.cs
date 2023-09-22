using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace M_News.Controllers
{
   
	public class NewsController : Controller
    {
        NewsManager NewsManager = new(new EfNewDal());
        FileManager FileManager = new(new EfFilesDal());
        public IActionResult Index(int page = 1)
        {
            return View(NewsManager.GetAllNews().ToPagedList(page, 10));
        }
        [HttpGet]
        public IActionResult CreateNews() => View();
        [HttpPost]
        public IActionResult CreateNews(News value, IFormFile Image)
        {
            NewsManager.CreateNews(value, Image);
            return RedirectToAction("Index", "News");
        }

        [HttpGet]
        public IActionResult EditNews(int Id)
        {
            var News = NewsManager.GetNews(Id);
            return View(News);
        }
        [HttpPost]
        public IActionResult EditNews(News value, IFormFile Image)
        {
            NewsManager.UpdateNews(value, Image);
            return RedirectToAction("Index", "News");
        }
        public IActionResult DeleteNews(int Id)
        {
            NewsManager.DeleteNews(Id);
            return RedirectToAction("Index", "News");
        }
    }
}
