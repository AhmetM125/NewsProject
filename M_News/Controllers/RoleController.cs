using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer;
using M_News.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace M_News.Controllers
{
    [AuthorizeY(Permission = "Roles")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IRolePermissionService _rolepermissionService;
        private readonly IPermissionService _permissionService;
        public RoleController(IRoleService roleService, IRolePermissionService rolepermissionService, IPermissionService permissionService)
        {
            _roleService = roleService;
            _rolepermissionService = rolepermissionService;
            _permissionService = permissionService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var Roles = _roleService.GetAllRoles();
            return View(Roles);
        }
        [HttpGet]
        public IActionResult EditRole(int RoleId)
        {
            return View(_roleService.GetRoleById(RoleId));
        }
        [HttpPost]
        public IActionResult EditRole(Role p)
        {
            _roleService.UpdateRole(p);
            return RedirectToAction("Index", "Role");
        }
        public IActionResult DeleteRole(int RoleId)
        {
            var RoleValue = _roleService.GetRoleById(RoleId);
            _roleService.DeleteRole(RoleValue);
            return RedirectToAction("Index", "Role");
        }
        [HttpGet]
        public IActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewRole(Role p)
        {
            _roleService.NewRole(p);
            return RedirectToAction("Index", "Role");
        }


        //ROLEPERMISSION
        public IActionResult EditPermissions(int RoleId)
        {
            var Role = _roleService.GetRoleById(RoleId);
            var PermissionList = _rolepermissionService.GetRolePermissionById(RoleId);
            foreach (var item in PermissionList)
            {
                item.Permission = _permissionService.GetPermission(item.PermissionId);
                item.Role = _roleService.GetRoleById(item.RoleId);
            }
            ViewBag.RoleId = RoleId;
            return View(PermissionList);
        }
        [HttpGet]
        public IActionResult DeletePermissionOfRole(int RoleId, int PermissionId)
        {

            var RolePermissionValue = _rolepermissionService.GetRolePermissionById(RoleId, PermissionId);
            _rolepermissionService.DeleteRolePermission(RolePermissionValue);
            return RedirectToAction("Index", "RolePermission");
        }
        [HttpGet]
        public IActionResult NewPermissionForRole(int RoleId)
        {
            List<RolePermission> valuesToCheck = _rolepermissionService.GetAllRolePermission().Where(x => x.RoleId != RoleId).ToList();

            IEnumerable<SelectListItem> Permissions_ListItem = (from x in _permissionService.GetAllPermission()
                                                                select new SelectListItem

                                                                {
                                                                    Value = x.Id.ToString(),
                                                                    Text = x.Title
                                                                });

            ViewBag.Permissions = Permissions_ListItem;

            ViewBag.RoleId = RoleId;
            return View();
        }
        [HttpPost]
        public IActionResult NewPermissionForRole(RolePermission p)
        {
            var IsExist = _rolepermissionService.GetRolePermissionById(p.RoleId, p.PermissionId);
            if (IsExist is null)
                _rolepermissionService.CreatePermission(p);
            return RedirectToAction("Index", "Role");
        }



    }
}
