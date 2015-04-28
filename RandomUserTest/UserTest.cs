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

            Assert.Equal("1969 elgin st", user.Location.Street);
            Assert.Equal("frederick", user.Location.City);
            Assert.Equal("delaware", user.Location.State);
            Assert.Equal("56298", user.Location.Zip);

            Assert.Equal("lois.williams50@example.com", user.Email);
            Assert.Equal("heavybutterfly920", user.Username);
            Assert.Equal("enterprise", user.Password);
            Assert.Equal(">egEn6YsO", user.Salt);
            Assert.Equal("2dd1894ea9d19bf5479992da95713a3a", user.Md5);
            Assert.Equal("ba230bc400723f470b68e9609ab7d0e6cf123b59", user.Sha1);
            Assert.Equal("f4f52bf8c5ad7fc759d1d4156b25a4c7b3d1e2eec6c92d80e508aa0b7946d4ba", user.Sha256);
            Assert.Equal("1288182167", user.Registered);
            Assert.Equal("146582153", user.Dob);
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