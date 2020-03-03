/*
 * Author: Travis Tower
 * Group Project: User Class
 * December 9, 2019
*/

namespace ItemFinderClassLibrary
{
    class User
    {
        /// <summary>
        /// Constructor for User object
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <param name="role">User role</param>
        public User(int id, string userName, string password, UserRole role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Role = role;
        }

        //All auto properties for a User object
        public int Id { get; }
        public string UserName { get; }
        public string Password { get; }
        public UserRole Role { get; }
    }

    //Enum for user roles
    enum UserRole
    {
        User,
        Admin
    }
}
