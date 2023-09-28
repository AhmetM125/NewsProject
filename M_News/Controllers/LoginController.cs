using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace M_News.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;

        public LoginController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]

        public IActionResult Login()
        {
            

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(string Password, string Username)
        {
            var value = _adminService.Login(Password, Username);

            if (value != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,value.Username),
                    new Claim("Id",value.User_Id.ToString()),
                    new Claim(ClaimTypes.Name,value.User_Id.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new(userIdentity);
                await HttpContext.SignInAsync(principal);
                /*HttpContext.Session.SetString("Username", value.User_Id.ToString());*/
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }


    }
}
