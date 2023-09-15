using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
	public class NewsController : Controller
	{
		NewManager NewManager = new NewManager(new EfNewDal());
		public IActionResult Index()
		{
			var NewsValues = NewManager.GetAllNews();
			return View(NewsValues);
		}
		[HttpGet]
		public IActionResult CreateNews()
		{

			return View();
		}

		[HttpPost]
        public IActionResult CreateNews(New value)
        {
			NewManager.CreateNews(value);
            return RedirectToAction("Index", "News");
        }

    }
}
