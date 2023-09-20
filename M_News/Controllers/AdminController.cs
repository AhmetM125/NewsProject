using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public IActionResult Index() => View(adminManager.GetAllAdmins());

        public IActionResult DeleteAdmin(Guid Id)
        {
            adminManager.DeleteAdmin(Id);
            return RedirectToAction("Admin", "Index");
        }
        [HttpGet]
        public IActionResult EditAdmin(Guid Id)
        {
            var Admin = adminManager.GetAdmin(Id);
            return View(Admin);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adminManager.EditAdmin(admin);

            return RedirectToAction("Admin", "Index");
        }
        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAdmin(Admin admin)
        {
            adminManager.NewAdmin(admin);
            return View();
        }

    }
}
