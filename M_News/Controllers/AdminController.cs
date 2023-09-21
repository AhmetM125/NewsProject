using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace M_News.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public IActionResult Index(int page = 1)
        {
           return View(adminManager.GetAllAdmins().ToPagedList(page,3));
        }

        public IActionResult DeleteAdmin(Guid Id)
        {
            adminManager.DeleteAdmin(Id);
            return RedirectToAction("Index", "Admin");
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

            return RedirectToAction("Index", "Admin");
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
