using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using M_News.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace M_News.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IAdminService _adminService;
        private readonly INewService _newService;
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;

        public DashboardController(ILogger<DashboardController> logger, IAdminService adminService, INewService newService, IRoleService roleService, IPermissionService permissionService )
        {
            _logger = logger;
            _adminService = adminService;
            _newService = newService;
            _roleService = roleService;
            _permissionService = permissionService;
        }
        [AuthorizeY(Permission = "Dashboard")]
        public async Task<IActionResult> Index()
        {
            var UserCount = await _adminService.GetAllAdmins();
            var NewsCount = await _newService.GetAllNews();
            var RolesCount = await _roleService.GetAllRoles();
            var PermissionCount = await _permissionService.GetAllPermission();
            ViewData["UserCount"] = UserCount.Count;
            ViewData["NewsCount"] = NewsCount.Count;
            ViewData["RoleCount"] = RolesCount.Count;
            ViewData["PermissionCount"] = PermissionCount.Count;

            return View();
        }
        [AuthorizeY(Permission = "Dashboard")]
       

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}