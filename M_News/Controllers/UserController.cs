using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
    public class UserController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string Password, string Username)
        {
            var value = adminManager.Login(Password, Username); // true or false 



            if (value)
            {
                HttpContext.Session.SetString("Username", Username);
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }


    }
}
