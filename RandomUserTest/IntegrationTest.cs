using System.Threading.Tasks;
using RandomUser;
using Xunit;

namespace RandomUserTest
{
    public class IntegrationTest
    {
        [Fact] public async Task GetRandomUser_ShouldReturnUser()
        {
            var user = await RandomUserApi.GetUser();

            Assert.NotNull(user);
            Assert.True(user.Name.First.Length > 0);
       }
    }
}