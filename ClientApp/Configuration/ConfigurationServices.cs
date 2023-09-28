using BusinessLayer.Concrete;

namespace M_News.Configuration
{
    public static class ConfigurationServices
    {
        public static void AddConfiguration(this IServiceCollection service)
        {
            service.AddScoped<INewService, NewsManager>();
        }
    }
}
