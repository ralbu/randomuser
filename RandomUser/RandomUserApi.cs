using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RandomUser.Models;

namespace RandomUser
{
    public class RandomUserApi
    {
        /// <summary>
        /// Get a random user from http://api.randomuser.me
        /// </summary>
        /// <returns>Returns a random user.</returns>
        public static async Task<User> GetUser()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.GetAsync("http://api.randomuser.me");
                if (response.IsSuccessStatusCode)
                {
                    var user = User.Create(await response.Content.ReadAsStringAsync());
                    return user;
                }
            }

            return null;
        }
    }
}