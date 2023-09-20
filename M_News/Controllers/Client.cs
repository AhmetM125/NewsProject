using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using M_News.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace M_News.Controllers
{
    [AllowAnonymous]
    public class Client : Controller
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
        public IActionResult AllNews()
        {
           
            return View(newsManager.GetAllNews());
        }
        public PartialViewResult _LatestPosts()
        {
            return PartialView(newsManager.GetLast4News());
        }
    }
}
