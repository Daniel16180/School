using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace SchoolManagement
{
    public static class Initialize
    {
        //public static Start GetStartPoint(Assembly assembly)
        //{
        //    var configuration = GetConfiguration(assembly);
        //    var serviceProvider = GetServiceProvider(configuration, assembly);
        //    var start = serviceProvider.GetRequiredService<Start>();
        //    return start;
        //}

        //private static ServiceProvider GetServiceProvider(IConfigurationRoot configuration, Assembly assembly)
        //{
        //    var services = new ServiceCollection();

        //    services.AddSingleton<Start>();
        //    services.LoadInfrastructureServices(configuration);
        //    services.LoadApplicationServices(assembly);
        //    var serviceProvider = services.BuildServiceProvider();
        //    return serviceProvider;
        //}

        private static IConfigurationRoot GetConfiguration(Assembly assembly)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json")
                .AddUserSecrets(assembly);

            var configuration = configurationBuilder.Build();
            return configuration;
        }

        public static string GetConnectionString()
        {
            //lo llamo para conseguir la cadena. Como parametro paso el ensamblado.
            var configuration = GetConfiguration(Assembly.GetExecutingAssembly());
            //con esto obtenemos la conexión del archivo de config o user secrets.
            return configuration["ConnectionStrings:sqlserver"];
        }
    }
}
