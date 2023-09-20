using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace M_News.Controllers
{

    public class LoginController : Controller
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
        public async Task<IActionResult> Login(string Password, string Username)
        {
            var value = adminManager.Login(Password, Username); // true or false 

            if (value != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,Username)
                };
                var userIdentity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                /*HttpContext.Session.SetString("Username", Username);*/
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }


    }
}
