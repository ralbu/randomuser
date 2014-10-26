using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomUser;
using Xunit;

namespace RandomUserTest
{
    public class IntegrationTest
    {

        [Fact]
        public async Task Abc()
        {
            Assert.True(true);
//            User user = new User();
//            user.Random();

            var user = await User.RandomAsync();
            Assert.Equal("user name", user.Name);

//            RandomUser.GetUserAsync();



        }

        [Fact]
        public void ATest()
        {
            Assert.True(true);
        }
    }
}
