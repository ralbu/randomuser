using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using RandomUser.Models;
using Xunit;

namespace RandomUserTest
{
    public class UserTest
    {
        [Fact]
        public void UserCreate_WhenNoJsonProvided_ShouldReturnNull()
        {
            Assert.Null(User.Create(""));
        }

        [Fact]
        public void UserCreate_ShouldParseJsonAndCreateUser()
        {
            GetUserAsJsonFromResource();

            var json = GetUserAsJsonFromResource();
            Assert.True(json.Length > 3);
        }

        [Fact]
        public void UserCreate_ShouldParseJsonAndCreateUserWithValues()
        {
            var userJson = GetUserAsJsonFromResource();
            var user = User.Create(userJson);

            Assert.Equal("ms", user.Name.Title);
            Assert.Equal("lois", user.Name.First);
            Assert.Equal("williams", user.Name.Last);

            Assert.Equal("female", user.Gender);

            Assert.Equal("Ullevålsveien", user.Location.Street.Name);
            Assert.Equal("Tomra", user.Location.City);
            Assert.Equal("Buskerud", user.Location.State);
            Assert.Equal("3726", user.Location.Postcode);

            Assert.Equal("lois.williams50@example.com", user.Email);
            Assert.Equal("heavybutterfly920", user.Login.UserName);
            Assert.Equal("republic", user.Login.Password);
            Assert.Equal("1cnb5GHy", user.Login.Salt);
            Assert.Equal("cbe55c7cfa3f9029e7e374ca5434ba48", user.Login.Md5);
            Assert.Equal("93f1b4fc33cdb148529239c94d18a97a625b11d2", user.Login.Sha1);
            Assert.Equal("c2b2b3d19a9c0f78231cc5172b73525d3b45341a7cd2b62b004f32e1292b7571", user.Login.Sha256);
            Assert.Equal(10, user.Registered.Age);
            Assert.Equal(60, user.Dob.Age);
            Assert.Equal("(555)-942-1322", user.Phone);
            Assert.Equal("(178)-341-1520", user.Cell);
            Assert.Equal("137-37-8866", user.Ssn);
            Assert.Equal("http://api.randomuser.me/portraits/women/55.jpg", user.Picture.Large);
            Assert.Equal("http://api.randomuser.me/portraits/med/women/55.jpg", user.Picture.Medium);
            Assert.Equal("http://api.randomuser.me/portraits/thumb/women/55.jpg", user.Picture.Thumbnail);
            Assert.Equal("0.4.1", user.Version);
        }

        private string GetUserAsJsonFromResource()
        {
            using (var reader = new StreamReader(GetResourceStream("User.json")))
            {
                var json = reader.ReadToEnd();
                return json;
            }
        }

        private Stream GetResourceStream(string resourceName)
        {
            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("RandomUserTest." + resourceName);

            Debug.Assert(resource != null, "resource is null");

            return resource;
        }
    }
}