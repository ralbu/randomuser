using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

[assembly:InternalsVisibleTo("RandomUserTest")]
namespace RandomUser.Models
{
    public class User
    {
        public UserName Name { get; set; }
        public UserLocation Location { get; set; }
        public UserPicture Picture { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public UserRegistered Registered { get; set; }
        public UserDob Dob { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string Ssn { get; set; }
        public string Version { get; set; }
        public UserLogin Login { get; set; }

        internal static User Create(string json)
        {
            if (String.IsNullOrEmpty(json))
            {
                return null;
            }

            dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic userObject = jsonObject.results[0];

            var user = JsonConvert.DeserializeObject<User>(userObject.ToString());

            return user;
        }

        public class UserLogin
        {
            public string Uuid { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Salt { get; set; }
            public string Md5 { get; set; }
            public string Sha1 { get; set; }
            public string Sha256 { get; set; }
        }
        
        public class UserName
        {
            public string Title { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
        }

        public class UserLocation
        {
            public Street Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Postcode { get; set; }
        }

        public class Street
        {
            public string Number { get; set; }
            public string  Name { get; set; }
        }

        public class UserPicture
        {
            public string Large { get; set; }
            public string Medium { get; set; }
            public string Thumbnail { get; set; }
        }
        public class UserDob
        {
            public DateTime DateTime { get; set; }
            public int Age { get; set; }
        }

        public class UserRegistered
        {
            public DateTime DateTime { get; set; }
            public int Age { get; set; }
        }
    }
}