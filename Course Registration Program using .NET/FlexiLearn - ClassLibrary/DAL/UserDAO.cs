/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: UserDao Class
 * December 5, 2019
*/

using System;
using System.Data;
using System.Data.SqlClient;

namespace FlexiLearn___ClassLibrary.DAL
{
    public class UserDao
    {
        //Declaring the connection string for the database
        private readonly string _conString;

        /// <summary>
        /// Constructor for a UserDao object
        /// </summary>
        /// <param name="conString">connection string for a database</param>
        public UserDao (string conString)
        {
            _conString = conString;
        }

        /// <summary>
        /// Method that inserts a user into the database.
        /// </summary>
        /// <param name="user">user object</param>
        /// <param name="registered">date that user registered</param>
        /// <param name="role">role for the user</param>
        /// <returns></returns>
        public int AddRecord(User user, DateTime registered, string role = "user")
        {
            var count = 0;
            try
            {
                //Setting up the SQL query to insert into the table
                var insertCommand = "Insert into [User] (Name, Email, PhoneNumber, Education, DateOfBirth, Password, Registered, Role) Values (@Name, @Email, @PhoneNumber, @Education, @DateOfBirth, @Password, @Registered, @Role)";
                using (var con = new SqlConnection(_conString))
                using (var command = new SqlCommand(insertCommand, con))
                {
                    //Opening the connection and adding parameters to the SQL command to be executed later on
                    con.Open();
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = user.Name;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                    command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = user.PhoneNumber;
                    command.Parameters.Add("@Education", SqlDbType.VarChar).Value = user.EducationLevel.ToString();
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = user.DateOfBirth;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
                    command.Parameters.Add("@Registered", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@Role", SqlDbType.VarChar).Value = role;

                    //Executing the command above with all the parameters given
                    count = command.ExecuteNonQuery();
                }

            }

            //Catching exception
            catch (SqlException)
            {
                //Creating Exception with message and throwing it to the web page
                var duplicate =
                    new Exception("User with name " + user.Name + " already exists in database!");
                throw duplicate;
            }
            return count;
        }

        /// <summary>
        /// Method that verifies user based on a user name and password. Returns a user object
        /// with the details of that specific user if it exists in the table.
        /// </summary>
        /// <param name="name">username</param>
        /// <param name="password">user password</param>
        /// <returns></returns>
        public User VerifyUser(string name, string password)
        {
            var user = new User();

            //Open a db connection
            var con = new SqlConnection(_conString);
            con.Open();

            //Create a SQL command
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "select * from [User] where Name = '" + name + "' and Password = '" + password + "'",
                Connection = con
            };

            //Execute command and fetch results
            var reader = command.ExecuteReader();

            //Loop till all records have not been read to populate the list
            while (reader.Read())
            {
                //Getting all fields from table and creating a user object from them
                var id = reader.GetInt32(0);
                var userName = reader.GetString(1);
                var pass = reader.GetString(6);
                var role = reader.GetString(8);

                user = new User(id, userName, pass, role);
            }

            //Close all
            reader.Close();
            con.Close();

            //Return the user that was found
            return user;
        }

    }
}
