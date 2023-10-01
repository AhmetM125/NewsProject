using BusinessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace M_News.Controllers
{
    [AllowAnonymous]
    public class ClientController : Controller
    {
        private readonly INewService _newService;

        public ClientController(INewService newService)
        {
            _newService = newService;
        }
        public IActionResult Index()
        {
            List<News> values = _newService.GetLast4News();
            return View(values);
        }


        [HttpGet]
        public IActionResult DetailsOfNews(int Id)
        {
            return View(_newService.GetNews(Id));
        }
        public async Task<IActionResult> AllNews(int page = 1)
        {
            var AllNews = await _newService.GetAllNews();
            return View(AllNews.ToPagedList(page, 6));
        }
        public PartialViewResult _LatestPosts()
        {
            return PartialView(_newService.GetLast4News());
        }
    }
}
