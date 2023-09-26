using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using M_News.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using X.PagedList;

namespace M_News.Controllers
{

    /*[AuthorizeY(Roles:"Admin")]*/

    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        UserRoleManager userRoleManager = new UserRoleManager(new EfUserRoleDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());

        [AuthorizeY(Permission = "Index")]
        public IActionResult Index(int page = 1)
        {
            AuthorizeYAttribute VAL = new AuthorizeYAttribute();
            var value = User.Identity.Name;
            return View(adminManager.GetAllAdmins().ToPagedList(page, 3));
        }
        [HttpGet]
        public IActionResult RoleManagement(Guid Id)
        {
            var ListOfRoles = userRoleManager.GetRolesOfUser(Id);
            foreach (var item in ListOfRoles)
                if (item is not null)
                {
                    item.Admin = adminManager.GetAdmin(item.UserId.Value);
                    item.Role = roleManager.GetRoleById(item.RoleId);
                }
            ViewBag.Id = Id;
            return View(ListOfRoles);
        }
        [HttpGet]
        public IActionResult UserNewRole(Guid uid)
        {
            UserRole role = new();
            role.UserId = uid;
            List<Role> valuesOfUser = roleManager.GetAllRoles();
            var ValueAdmin = adminManager.GetAdmin(uid);
            ViewData["NameSurname"] = $"{ValueAdmin.Name} {ValueAdmin.Surname}";
            ViewBag.RolesDropDown = new SelectList(valuesOfUser, "Id", "Title");
            ViewBag.Uid = ValueAdmin.User_Id;
            return View(role);
        }
        [HttpPost]
        public IActionResult UserNewRole(UserRole P)
        {
            try
            {
                userRoleManager.InsertNewRoleOfUser(P);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Foreign Key Error");
                return RedirectToAction("Index", "Admin");
            }

        }
        public IActionResult RemoveRole(int RoleId, Guid UserId)
        {
            var UserRoleValue = userRoleManager.GetUserRoleById(UserId, RoleId);
            userRoleManager.DeleteRoleOfUser(UserRoleValue);
            return RedirectToAction("Index", "Admin");
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
