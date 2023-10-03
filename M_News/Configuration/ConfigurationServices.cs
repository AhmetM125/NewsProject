using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Dapper;

namespace M_News.Configuration
{
    public static class ConfigurationServices
    {
        public static void AddConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IAdminService, AdminManager>();
            service.AddScoped<INewService, NewsManager>();
            service.AddScoped<IFileService, FileManager>();
            service.AddScoped<IPermissionService, PermissionManager>();
            service.AddScoped<IRolePermissionService, RolePermissionManager>();
            service.AddScoped<IRoleService, RoleManager>();
            service.AddScoped<IUserRoleService, UserRoleManager>();

            /*service.AddScoped<IAdminDal, EfAdminDal>();
            service.AddScoped<INewDal, EfNewDal>();
            service.AddScoped<IFilesDal, EfFilesDal>();
            service.AddScoped<IPermissionDal, EfPermissionDal>();
            service.AddScoped<IRoleDal, EfRoleDal>();
            service.AddScoped<IRolePermissionDal, EfRolePermissionDal>();
            service.AddScoped<IUserRoleDal, EfUserRoleDal>();*/


            service.AddScoped<IAdminDA, AdminDA>();
            service.AddScoped<IFilesDA, FilesDA>();
            service.AddScoped<INewDA, NewsDA>();
            service.AddScoped<IPermissionDA, PermissionDA>();
            service.AddScoped<IRoleDA, RoleDA>();
            service.AddScoped<IRolePermissionDA, RolePermissionDA>();
            service.AddScoped<IUserRoleDA, UserRoleDA>();
        }
    }
}
