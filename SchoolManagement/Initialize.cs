using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace SchoolManagement
{
    public static class Initialize
    {

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
            var configuration = GetConfiguration(Assembly.GetExecutingAssembly());
            return configuration["ConnectionStrings:sqlserver"];
        }
    }
}
