using FacilityManagement.Core;
using FacilityManagement.SharedKernel.Extensions;
using FacilityManagement.Testing;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FacilityManagement.IntegrationTests
{
    public class MaintenanceRequestControllerTests : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _fixture;

        public MaintenanceRequestControllerTests(ApiTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Should_Create()
        {

            var profile = _fixture.DbContext.Profiles.FirstOrDefault();

            var client = _fixture.CreateAuthenticatedClient();

            var request = new CreateMaintenanceRequestRequest()
            {

            };

            var response = await client.PostAsAsync<CreateMaintenanceRequestRequest, CreateMaintenanceRequestResponse>(Endpoints.Post.Create, request);

            Assert.NotNull(response);

        }

        internal static class Endpoints
        {
            public static class Post
            {
                public static string Create = $"api/maintenancerequest";
            }
        }

    }
}
