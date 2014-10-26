using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomUser;
using Xunit;

namespace RandomUserTest
{
    public class Class1
    {

        [Fact]
        public async Task Abc()
        {
            Assert.True(true);
//            User user = new User();
//            user.Random();

            var user = await User.RandomAsync();
            Assert.Equal("user name", user.Name);



        }

        [Fact]
        public void ATest()
        {
            Assert.True(true);
        }
    }
}
