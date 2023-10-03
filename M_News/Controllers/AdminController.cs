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
            var AdminList = await _adminService.GetAllAdmins();
            return View(AdminList.ToPagedList(page, 5));
        }
        /*ModelState.Clear();*/
        [HttpGet]
        public async Task<IActionResult> RoleManagement(Guid Id)
        {
            var ListOfRoles = await _userRoleService.GetRolesOfUser(Id);
            foreach (var item in ListOfRoles)
                if (item is not null)
                {
                    item.Admin = await _adminService.GetAdmin(item.UserId.Value);
                    item.Role = await _roleService.GetRoleById(item.RoleId);
                }
            ViewBag.Id = Id;
            return View(ListOfRoles);
        }
        [HttpGet]
        public async Task<IActionResult> UserNewRole(Guid uid)
        {
            //Role
            UserRole role = new()
            {
                UserId = uid
            };
            //
            List<Role> valuesOfUser = await _roleService.GetAllRoles();

            var ValueAdmin = await _adminService.GetAdmin(uid);
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
        public async Task<IActionResult> RemoveRole(int RoleId, Guid UserId)
        {
            var UserRoleValue = await _userRoleService.GetUserRoleById(UserId, RoleId);
            await _userRoleService.DeleteRoleOfUser(UserRoleValue);
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult DeleteAdmin(Guid Id)
        {
            _adminService.DeleteAdmin(Id);
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> EditAdmin(Guid Id)
        {
            var Admin = await _adminService.GetAdmin(Id);
            return View(Admin);
        }
        [HttpPost]
        public async Task<IActionResult> EditAdmin(Admin admin)
        {
            if (ModelState.IsValid)
                await _adminService.EditAdmin(admin);

            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]

        public IActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]


        public async Task<IActionResult> CreateAdmin(Admin admin)
        {
            await _adminService.NewAdmin(admin);
            return RedirectToAction("Index", "Admin");
        }



    }
}
