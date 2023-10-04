using BusinessLayer.Abstract;
using EntityLayer;
using M_News.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
    [AuthorizeY(Permission = "Permissions")]
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            ICollection<Permission> ListOfPermissions = await _permissionService.GetAllPermission();
            return View(ListOfPermissions);
        }
        [HttpGet]
        public async Task<IActionResult> EditPermission(int PermissionId)
        {
            Permission? PermissionObj = await _permissionService.GetPermission(PermissionId);
            return View(PermissionObj);
        }
        [HttpPost]
        public IActionResult EditPermission(Permission p)
        {
            _permissionService.UpdatePermission(p);
            return RedirectToAction("Index", "Permission");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePermission(int PermissionId)
        {
            var PermissionVal = await _permissionService.GetPermission(PermissionId);
            await _permissionService.DeletePermission(PermissionVal);
            return RedirectToAction("Index", "Permission");
        }
        [HttpGet]
        public IActionResult CreatePermission()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePermission(Permission P)
        {
            _permissionService.CreatePermission(P);
            return RedirectToAction("Index", "Permission");

        }
    }
}
