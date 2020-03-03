/*
 * Author: Travis Tower
 * Group Project: Login Helper Code
 * December 9, 2019
*/

using System;
using System.Security.Cryptography;

namespace ItemFinder.DAL
{
    public class LoginHelper
    {

        /// <summary>
        /// Method that generates the salt for the password hashing
        /// </summary>
        /// <returns>Salt of the password as a byte array</returns>
        public static byte[] GenerateSalt()
        {
            //Create an array of bytes
            byte[] bSalt = new byte[24];

            //Use salt generator to generate array of bytes
            RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
            saltGenerator.GetBytes(bSalt);

            //Return the randomly created byte array
            return bSalt;
        }

        /// <summary>
        /// Method that generates the hashed password to be associated to a certain user
        /// </summary>
        /// <param name="plainText">The plaintext password</param>
        /// <param name="salt">Salt byte array</param>
        /// <param name="iterations">Amount of iterations for the password</param>
        /// <returns>The password hash to be used in the database</returns>
        public static string GeneratePasswordHash(string plainText, byte[] salt, int iterations)
        {
            //Declaring empty byte array to be used later on
            byte[] encryptedPassBytes = null;

            //Generating the hashed password using a hashing algorithm
            using (var hashGenerator = new Rfc2898DeriveBytes(plainText, salt, iterations,
                HashAlgorithmName.SHA256))
            {
                encryptedPassBytes = hashGenerator.GetBytes(24);
            }

            //Returning the hashed password to be used to insert/ authenticate a user
            return "" + iterations + "|" + Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(encryptedPassBytes);
        }

        /// <summary>
        /// Method that will check to see if the user logged in with proper
        /// credentials
        /// </summary>
        /// <param name="name">UserName</param>
        /// <param name="password">Password</param>
        /// <returns>If the user used the correct login info for their account</returns>
        public static bool IsUserAuthentic(string name, string password)
        {
            //Creating the dao as well as getting the encrypted password from the DB
            var userDao = new UserDao();
            var encPassword = userDao.GetEncPassword(name);

            //Splitting the password into each of its individual parts
            string[] parts = encPassword.Split('|');
            var iterations = int.Parse(parts[0]);
            byte[] bSalt = Convert.FromBase64String(parts[1]);

            //Generating a hashed password from the split parts above
            var hashPass = GeneratePasswordHash(password, bSalt, iterations);

            //Seeing if the 2 passwords match or not. They should match for user to be authenticated
            return hashPass == encPassword;
        }

        /// <summary>
        /// Method that will return the logged in users role
        /// </summary>
        /// <param name="name">UserName</param>
        /// <returns>The role of the specified user</returns>
        public static string GetUserRole(string name)
        {
            //Declaring a UserDao object
            var dao = new UserDao();

            //Returning the role associated with that user
            return dao.GetUserRole(name);
        }
    }
}
