using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace M_News.Configuration
{
    public static class ConfigurationServices
    {
        public static void AddConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IAdminService, AdminManager>();
            service.AddScoped<INewService, NewsManager>();
            service.AddScoped<IFileService,FileManager>();
            service.AddScoped<IPermissionService, PermissionManager>();
            service.AddScoped<IRolePermissionService, RolePermissionManager>();
            service.AddScoped<IRoleService,RoleManager>();
            service.AddScoped<IUserRoleService, UserRoleManager>();
            service.AddScoped<IAdminDal, EfAdminDal>();
            service.AddScoped<INewDal, EfNewDal>();
            service.AddScoped<IFilesDal, EfFilesDal>();
            service.AddScoped<IPermissionDal, EfPermissionDal>();
            service.AddScoped<IRoleDal, EfRoleDal>();
            service.AddScoped<IRolePermissionDal, EfRolePermissionDal>();
            service.AddScoped<IUserRoleDal, EfUserRoleDal>();
        }
    }
}
