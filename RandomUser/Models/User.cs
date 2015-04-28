using System;
using Newtonsoft.Json;

namespace RandomUser.Models
{
    public class User
    {
        public UserName Name { get; set; }
        public UserLocation Location { get; set; }
        public UserPicture Picture { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }
        public string Registered { get; set; }
        public string Dob { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string Ssn { get; set; }
        public string Version { get; set; }

        internal static User Create(string json)
        {
            if (String.IsNullOrEmpty(json))
            {
                return null;
            }

            dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic userObject = jsonObject.results[0].user;

            var user = JsonConvert.DeserializeObject<User>(userObject.ToString());

            return user;
        }

        public class UserName
        {
            public string Title { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
        }

        public class UserLocation
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
        }

        public class UserPicture
        {
            public string Large { get; set; }
            public string Medium { get; set; }
            public string Thumbnail { get; set; }
        }
    }
}