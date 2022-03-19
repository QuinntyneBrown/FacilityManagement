using Microsoft.Extensions.Configuration;

namespace FacilityManagement.Testing
{
    public static class ConfigurationFactory
    {
        private static IConfiguration? _configuration;

        public static IConfiguration Create()
        {
            if (_configuration == null)
            {
                var basePath = Path.GetFullPath(@$"../../../../../src/FacilityManagement.Api");

                _configuration = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json")
                    .Build();
            }

            return _configuration;
        }
    }
}
