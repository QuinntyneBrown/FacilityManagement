using FacilityManagement.Api;
using FacilityManagement.Core.Interfaces;
using FacilityManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace FacilityManagement.Testing
{
    public class ApiTestFixture : WebApplicationFactory<Startup>, IDisposable
    {

        private IConfiguration? _configuration;

        public FacilityManagementDbContext DbContext => Services.GetService<FacilityManagementDbContext>();

        public ApiTestFixture()
        {
            _configuration = ConfigurationFactory.Create();
        }

        public HttpClient CreateAuthenticatedClient(string token = null, string scheme = "Test")
        {
            if (string.IsNullOrEmpty(token))
                token = TokenFactory.CreateToken("Test User", Array.Empty<string>());

            var client = WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication(scheme)
                        .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
                            scheme, options => {

                            });
                });
            }).CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);

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

                    var context = scopedServices.GetRequiredService<FacilityManagementDbContext>();

                    SeedData.Seed(context);
                }
            });
        }
    }
}
