using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using M_News.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace M_News.Controllers
{
    public class Client : Controller
    {
        NewsManager newsManager = new NewsManager(new EfNewDal());
        public IActionResult Index()
        {
            List<News> values = newsManager.GetLast4News();
            return View(values);
        }
       


    }
}
