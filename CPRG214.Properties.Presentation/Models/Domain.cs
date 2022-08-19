using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Properties.Presentation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }


    /// <summary>
    /// Class is responsible for authenticating and managing users.
    /// </summary>
    public class UserManager
    {
        private readonly static List<User> _users;

        static UserManager()
        {
            _users = new List<User>();
            _users.Add(new User { Id = 1, Username = "jdoe", Password = "password", FullName = "John Doe", Role = "Manager" });
            _users.Add(new User { Id = 2, Username = "khunter", Password = "password", FullName = "Karen Hunter", Role = "Staff" });
        }

        /// <summary>
        /// User is authenticated based on credentials and a user returned if exists or null if not.
        /// </summary>
        /// <param name="username">Username as string</param>
        /// <param name="password">Password as string</param>
        /// <returns>A user object or null.</returns>
        /// <remarks>
        /// Add additional for the docs for this application--for developers.
        /// </remarks>
        public static User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(usr => usr.Username == username 
                                                     && usr.Password == password);
            return user; //this will either be null or an object
        }
    }
}
