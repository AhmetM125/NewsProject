using AspNetCore.ReCaptcha;
using BusinessLayer.Abstract;
using M_News.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        //string Password, string Username,
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var response = model.RecaptchaResponse;
            const string secret = "6LfEfl0oAAAAAOMNGUU2yxRc8nsKuwVqyrllNcyE"; // secret key

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={response}");

                    var captchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(result);

                    if (!captchaResponse.Success)
                    {
                        ModelState.AddModelError(string.Empty, "reCAPTCHA verification failed.");
                        return View(model);
                    }
                }

                var value = _adminService.Login(model.Username, model.Password);

                if (value != null)
                {
                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.NameIdentifier, value.Username),
                    new Claim("Id", value.User_Id.ToString()),
                    new Claim(ClaimTypes.Name, value.User_Id.ToString())
                    };

                    var userIdentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index","Dashboard");
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during reCAPTCHA verification or login.
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
            }

            return View(model);
        }


    }
}
