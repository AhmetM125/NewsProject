using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer;
using M_News.Attributes;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace M_News.Controllers
{
    [AuthorizeY(Permission = "News")]
    public class NewsController : Controller
    {
        private readonly INewService _newService;
        public NewsController(INewService newService)
        {
            _newService = newService;
        }

        public IActionResult Index(int page = 1)
        {
            var AllNews = _newService.GetAllNews().ToPagedList(page, 10);
            return View(AllNews);
        }
        [HttpGet]
        public IActionResult CreateNews() => View();
        [HttpPost]
        public IActionResult CreateNews(News value, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _newService.CreateNews(value, Image);
            }
            return RedirectToAction("Index", "News");
        }

        [HttpGet]
        public IActionResult EditNews(int Id)
        {
            var News = _newService.GetNews(Id);
            return View(News);
        }
        [HttpPost]
        public IActionResult EditNews(News value, IFormFile Image)
        {
            if (ModelState.IsValid)
                _newService.UpdateNews(value, Image);
            return RedirectToAction("Index", "News");
        }
        public IActionResult DeleteNews(int Id)
        {
            _newService.DeleteNews(Id);
            return RedirectToAction("Index", "News");
        }
    }
}
