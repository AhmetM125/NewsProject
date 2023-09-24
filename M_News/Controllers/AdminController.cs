using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace M_News.Controllers
{

    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        UserRoleManager userRoleManager = new UserRoleManager(new EfUserRoleDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());

        public IActionResult Index(int page = 1)
        {
            return View(adminManager.GetAllAdmins().ToPagedList(page, 3));
        }
        [HttpGet]
        public IActionResult RoleManagement(Guid Id)
        {
            var ListOfRoles = userRoleManager.GetRolesOfUser(Id);
            foreach (var item in ListOfRoles)
            {
                item.Admin = adminManager.GetAdmin((Guid)item.UserId);
                item.Role = roleManager.GetRoleById(item.RoleId);
                
            }
            return View(ListOfRoles);
        }
        public IActionResult RemoveRole(int RoleId,Guid U_Id)
        {
            userRoleManager.DeleteRoleOfUser(U_Id,RoleId);
            return RedirectToAction("RoleManagement", "Admin");
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
