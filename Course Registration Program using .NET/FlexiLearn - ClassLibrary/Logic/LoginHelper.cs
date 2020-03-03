/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: Login Helper Class
 * December 5, 2019
*/

using FlexiLearn___ClassLibrary.DAL;

namespace FlexiLearn___ClassLibrary.Logic
{
    public class LoginHelper
    {
        //Declaring any objects needed
        private static readonly UserDao UserDao = new UserDao(Properties.Settings.Default.conString);

        /// <summary>
        /// Method that returns true if the user given exists
        /// within the users table
        /// </summary>
        /// <param name="name">username</param>
        /// <param name="password">user password</param>
        /// <returns></returns>
        public static bool IsUserAuthentic(string name, string password)
        {
            //Checks to see if the user from the database is equal to the info
            //given by the user through the login page 
            var user = UserDao.VerifyUser(name, password);
            return name.Equals(user.Name) && password.Equals(user.Password);
        }

        /// <summary>
        /// Method that gets the users role based on their user name
        /// and password.
        /// </summary>
        /// <param name="name">username</param>
        /// <param name="password">user password</param>
        /// <returns></returns>
        public static string GetUserRole(string name, string password)
        {
            //Returns a different string based on the role from the table in the database
            var user = UserDao.VerifyUser(name, password);
            if (user.Role.Equals("user"))
                return "user";
            return user.Role.Equals("admin") ? "admin" : "";
        }
    }
}
