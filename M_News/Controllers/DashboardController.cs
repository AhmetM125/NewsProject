using M_News.Attributes;
using M_News.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace M_News.Controllers
{
    [AuthorizeY(Permission = "Dashboard")]
    public class DashboardController : Controller
	{
		private readonly ILogger<DashboardController> _logger;

		public DashboardController(ILogger<DashboardController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

	}
}