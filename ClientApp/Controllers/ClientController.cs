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
        public async Task<IActionResult> Index()
        {
            List<New> values = await _newService.GetLast4News();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> DetailsOfNews(int Id)
        {
            var val = await _newService.GetNews(Id);
            return View(val);
        }
        public async Task<IActionResult> AllNews(int page = 1)
        {
            var AllNews = await _newService.GetAllNews();
            return View(AllNews.ToPagedList(page, 6));
        }
        public async Task<PartialViewResult> _LatestPosts()
        {
            var Last4News = await _newService.GetLast4News();
            return PartialView(_newService.GetLast4News());
        }
    }
}
