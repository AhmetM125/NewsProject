using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
    public class Client : Controller
    {
        NewsManager newsManager = new NewsManager(new EfNewDal());
        public IActionResult Index()
        {
            var values = newsManager.GetLast4News();
            return View(values);
        }

    }
}
