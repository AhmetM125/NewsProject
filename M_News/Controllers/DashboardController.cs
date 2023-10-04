using M_News.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace M_News.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }
        [AuthorizeY(Permission = "Dashboard")]
        public IActionResult Index()
        {
            var req = HttpContext.Request;
            return View();
        }
        [AuthorizeY(Permission = "Dashboard")]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}