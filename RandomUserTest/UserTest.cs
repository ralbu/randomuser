using RandomUser;
using Xunit;

namespace RandomUserTest
{

    public class UserTest
    {
        [Fact]
        public void UserCreate_ShouldParseJsonAndCreateUser()
        {
            Assert.NotNull(User.Create(""));
        }
    }
}
