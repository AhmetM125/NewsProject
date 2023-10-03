using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Dapper;

namespace ClientApp.Configuration
{
    public static class ConfigurationServices
    {
        public static void AddConfiguration(this IServiceCollection service)
        {
            service.AddScoped<INewService, NewsManager>();
            service.AddScoped<INewDal, EfNewDal>();
            service.AddScoped<IFileService, FileManager>();
            service.AddScoped<IFilesDal, EfFilesDal>();

            service.AddScoped<IFilesDA, FilesDA>();
            service.AddScoped<INewDA, NewsDA>();

        }
    }
}
