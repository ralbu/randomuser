using System.Threading.Tasks;
using RandomUser;
using Xunit;

namespace RandomUserNuGetTest
{
    public class NuGetTest
    {
        [Fact]
        public async Task GetRandomUser_ShouldReturnUser()
        {
            var user = await RandomUserApi.GetUser();

            Assert.NotNull(user);
            Assert.True(user.Name.First.Length > 0);
        }
    }
}