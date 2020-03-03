/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: User Class
 * December 5, 2019
*/

using System;

namespace FlexiLearn___ClassLibrary
{
    public class User
    {
        //Setting up readonly properties for a User object
        public int Id { get;}
        public string Name { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public Education EducationLevel { get; }
        public DateTime DateOfBirth { get; }
        public string Password { get; }
        public string Role { get; }

        /// <summary>
        /// Default constructor for a User object
        /// </summary>
        public User()
        {

        }

        /// <summary>
        /// One type of constructor for creating a User object
        /// </summary>
        /// <param name="id">id of user</param>
        /// <param name="name">name of user</param>
        /// <param name="password">users password</param>
        /// <param name="role">users role</param>
        public User(int id, string name, string password, string role )
        {
            Id = id;
            Name = name;
            Password = password;
            Role = role;
        }

        /// <summary>
        /// One type of constructor for creating a User object
        /// </summary>
        /// <param name="name">users name</param>
        /// <param name="email">users email</param>
        /// <param name="education">users education level</param>
        /// <param name="dateOfBirth">users DOB</param>
        /// <param name="password">users password</param>
        /// <param name="phoneNumber">users phone number</param>
        public User(string name, string email, Education education, DateTime dateOfBirth, string password, string phoneNumber = "")
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            EducationLevel = education;
            DateOfBirth = dateOfBirth;
            Password = password;
        }
    }
}
