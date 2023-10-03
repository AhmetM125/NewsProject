using BusinessLayer.Abstract;
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
        public async Task<IActionResult> Index()
        {
            var Roles = await _roleService.GetAllRoles();
            return View(Roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(int RoleId)
        {
            var RoleVal = await _roleService.GetRoleById(RoleId);
            return View(RoleVal);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(Role p)
        {
            await _roleService.UpdateRole(p);
            return RedirectToAction("Index", "Role");
        }
        public async Task<IActionResult> DeleteRole(int RoleId)
        {
            var RoleValue = await _roleService.GetRoleById(RoleId);
            _roleService.DeleteRole(RoleValue);
            return RedirectToAction("Index", "Role");
        }
        [HttpGet]
        public IActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewRole(Role p)
        {
            await _roleService.NewRole(p);
            return RedirectToAction("Index", "Role");
        }


        //ROLEPERMISSION
        public async Task<IActionResult> EditPermissions(int RoleId)
        {
            var Role = _roleService.GetRoleById(RoleId);
            var PermissionList = await _rolepermissionService.GetRolePermissionByIdList(RoleId);
            foreach (var item in PermissionList)
            {
                item.Permission = await _permissionService.GetPermission(item.PermissionId);
                item.Role = await _roleService.GetRoleById(item.RoleId);
            }
            ViewBag.RoleId = RoleId;
            return View(PermissionList);
        }
        [HttpGet]
        public async Task<IActionResult> DeletePermissionOfRole(int RoleId, int PermissionId)
        {

            var RolePermissionValue = await _rolepermissionService.GetRolePermissionById(RoleId, PermissionId);
            await _rolepermissionService.DeleteRolePermission(RolePermissionValue);
            return RedirectToAction("Index", "RolePermission");
        }
        [HttpGet]
        public async Task<IActionResult> NewPermissionForRole(int RoleId)
        {

            var List = await _permissionService.GetAllPermission();

            IEnumerable<SelectListItem> Permissions_ListItem = (from x in List
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
