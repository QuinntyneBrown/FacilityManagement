using FacilityManagement.Core;
using FacilityManagement.SharedKernel.Extensions;
using FacilityManagement.Testing;
using System.Threading.Tasks;
using Xunit;

namespace FacilityManagement.IntegrationTests
{
    public class UserControllerTests: IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _fixture;

        public UserControllerTests(ApiTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Should_Authenticate()
        {
            var client = _fixture.CreateClient();

            var request = new AuthenticateRequest("quinntyne", "P@ssw0rd");

            var response = await client.PostAsAsync<AuthenticateRequest, AuthenticateResponse>(Endpoints.Post.Authenticate, request);

            Assert.NotNull(response);

        }

        internal static class Endpoints
        {
            public static class Post
            {
                public static string Authenticate = $"api/user/token";
            }
        }

    }
}
