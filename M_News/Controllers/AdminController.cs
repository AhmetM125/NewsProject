using BusinessLayer.Abstract;
using EntityLayer;
using M_News.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace M_News.Controllers
{

    [AuthorizeY(Permission = "Users")]

    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public AdminController(IAdminService adminService, IRoleService roleService, IUserRoleService userRoleService)
        {
            _adminService = adminService;
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var AdminList = (await _adminService.GetAllAdmins()).ToPagedList(page, 5);
            ModelState.Clear();
            return View(AdminList);
        }
        [HttpGet]
        public IActionResult RoleManagement(Guid Id)
        {
            var ListOfRoles = _userRoleService.GetRolesOfUser(Id);
            foreach (var item in ListOfRoles)
                if (item is not null)
                {
                    item.Admin = _adminService.GetAdmin(item.UserId.Value);
                    item.Role = _roleService.GetRoleById(item.RoleId);
                }
            ViewBag.Id = Id;
            return View(ListOfRoles);
        }
        [HttpGet]
        public IActionResult UserNewRole(Guid uid)
        {
            //Role
            UserRole role = new UserRole()
            {
                UserId = uid
            };
            //
            List<Role> valuesOfUser = _roleService.GetAllRoles();

            var ValueAdmin = _adminService.GetAdmin(uid);
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
                if (ModelState.IsValid)
                    _userRoleService.InsertNewRoleOfUser(P);

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Foreign Key Error");
            }
            return RedirectToAction("Index", "Admin");

        }
        public IActionResult RemoveRole(int RoleId, Guid UserId)
        {
            var UserRoleValue = _userRoleService.GetUserRoleById(UserId, RoleId);
            _userRoleService.DeleteRoleOfUser(UserRoleValue);
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult DeleteAdmin(Guid Id)
        {
            _adminService.DeleteAdmin(Id);
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public IActionResult EditAdmin(Guid Id)
        {
            var Admin = _adminService.GetAdmin(Id);
            return View(Admin);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            if (ModelState.IsValid)
                _adminService.EditAdmin(admin);

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
            if (ModelState.IsValid)
                _adminService.NewAdmin(admin);
            return RedirectToAction("Index", "Admin");
        }



    }
}
