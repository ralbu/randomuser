using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser
{
    public class User
    {
        public string Name { get; set; }


        internal static User Create(string json)
        {
            return new User();
        }

        public void Random()
        {
            HttpClient client = new HttpClient();

        }

        public static async Task<User> RandomAsync()
        {
            await Task.Delay(0);

            return new User {Name = "user name"};
        }
    }
}
