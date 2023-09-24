using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace M_News.Controllers
{
    [AllowAnonymous]
	public class ClientController : Controller
	{
		NewsManager newsManager = new NewsManager(new EfNewDal());
		public IActionResult Index()
		{
			List<News> values = newsManager.GetLast4News();
			return View(values);
		}


		[HttpGet]
		public IActionResult DetailsOfNews(int Id)
		{
			return View(newsManager.GetNews(Id));
		}
		public IActionResult AllNews(int page = 1)
		{
			return View(newsManager.GetAllNews().ToPagedList(page, 6));
		}
        public PartialViewResult _LatestPosts()
		{
			return PartialView(newsManager.GetLast4News());
		}
	}
}
