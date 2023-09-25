using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
    public class RoleController : Controller
    {
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        [HttpGet]
        public IActionResult Index()
        {
            var Roles = roleManager.GetAllRoles();
            return View(Roles);
        }
        [HttpGet]
        public IActionResult EditRole(int RoleId)
        {
            return View(roleManager.GetRoleById(RoleId));
        }
        [HttpPost]
        public IActionResult EditRole(Role p)
        {
            roleManager.UpdateRole(p);
            return RedirectToAction("Index", "Role");
        }
        public IActionResult DeleteRole(int RoleId)
        {
            var RoleValue = roleManager.GetRoleById(RoleId);
            roleManager.DeleteRole(RoleValue);
            return RedirectToAction("Index","Role");
        }
        [HttpGet]
        public IActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewRole(Role p)
        {
            roleManager.NewRole(p);
            return RedirectToAction("Index", "Role");
        }

    }
}
