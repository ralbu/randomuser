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
        public void Random()
        {
            HttpClient client = new HttpClient();

        }

        public static async Task RandomAsync()
        {
            await Task.Delay(0);
        }
    }
}
