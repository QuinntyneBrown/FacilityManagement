using FacilityManagement.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FacilityManagement.Testing
{
    public class ApiTestFixture : WebApplicationFactory<Startup>, IDisposable
    {

        private IConfiguration? _configuration;

        public ApiTestFixture()
        {
            _configuration = ConfigurationFactory.Create();
        }

        public new HttpClient CreateClient()
        {
            var client = base.CreateClient();


            return client;
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    
                }
            });
        }
    }
}
