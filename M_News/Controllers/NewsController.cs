﻿using BusinessLayer.Concrete;
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

        public async Task<IActionResult> Index(int page = 1)
        {
            var AllNews = await _newService.GetAllNews();
            return View(AllNews.ToPagedList(page, 10));
        }
        [HttpGet]
        public IActionResult CreateNews() => View();
        [HttpPost]
        public async Task<IActionResult> CreateNews(News value, IFormFile Image)
        {
            await _newService.CreateNews(value, Image);
            return RedirectToAction("Index", "News");
        }

        [HttpGet]
        public async Task<IActionResult> EditNews(int Id)
        {
            var News = await _newService.GetNews(Id);
            return View(News);
        }
        [HttpPost]
        public async Task<IActionResult> EditNews(News value, IFormFile Image)
        {
            await _newService.UpdateNews(value, Image);
            return RedirectToAction("Index", "News");
        }
        public async Task<IActionResult> DeleteNews(int Id)
        {
            await _newService.DeleteNews(Id);
            return RedirectToAction("Index", "News");
        }
    }
}
