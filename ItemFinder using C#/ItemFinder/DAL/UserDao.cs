/*
 * Author: Travis Tower
 * Group Project: User Dao Code
 * December 9, 2019
*/

using System;
using System.Data;
using System.Data.SqlClient;
using ItemFinder.ItemFinderDataSetTableAdapters;

namespace ItemFinder.DAL
{
    public class UserDao
    {
        //Declaring objects needed
        readonly UsersTableAdapter _usersAdapter = new UsersTableAdapter();

        /// <summary>
        /// Method that adds a user record to the users table inside the DB
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <param name="role">User Role</param>
        /// <returns>The User Id associated with that new user</returns>
        public (int, int) AddRecord(string userName, string password, string role = "User")
        {
            //Generating salt and encrypted password
            byte[] bSalt = LoginHelper.GenerateSalt();
            var encPassword = LoginHelper.GeneratePasswordHash(password, bSalt, 20000);

            //Creating a new SQL command using stored procedure
            var cmd = new SqlCommand("InsertUserAccount");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = _usersAdapter.Connection;


            //Sequence of parameters is as declared, count, uName, password, id
            SqlParameter pCount = cmd.CreateParameter();
            pCount.Direction = ParameterDirection.ReturnValue;
            pCount.DbType = DbType.Int32;
            cmd.Parameters.Add(pCount);

            //Adding values to each of the parameters
            cmd.Parameters.AddWithValue("@uName", userName);
            cmd.Parameters.AddWithValue("@password", encPassword);
            cmd.Parameters.AddWithValue("@role", role);

            //Setting the User Id from the parameters above
            SqlParameter pId = cmd.CreateParameter();
            pId.ParameterName = "@Id";
            pId.Direction = ParameterDirection.Output;
            pId.DbType = DbType.Int32;
            cmd.Parameters.Add(pId);

            //Opening connection as well as executing the query
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            //Return id and count.
            return (Convert.ToInt32(cmd.Parameters[4].Value), Convert.ToInt32(cmd.Parameters[0].Value));
        }

        /// <summary>
        /// Method that retrieves the encrypted password from the table based on
        /// username
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <returns>The encrypted password of the user</returns>
        public string GetEncPassword(string userName)
        {
            //Getting all rows in Users table
            ItemFinderDataSet.UsersDataTable rows = _usersAdapter.GetData();

            //Cast from DataRow to UserRow
            var filteredRows = (ItemFinderDataSet.UsersRow[])rows.Select($"UserName='{userName}'");

            //Returning the password if the returned length of rows is only 1
            return filteredRows.Length == 1 ? filteredRows[0].Password : null;
        }

        /// <summary>
        /// Method that returns a users role based on their username
        /// </summary>
        /// <param name="userName">Username</param>
        /// <returns>Current users role</returns>
        public string GetUserRole(string userName)
        {
            //Getting all rows in Users table
            ItemFinderDataSet.UsersDataTable rows = _usersAdapter.GetData();

            //Cast from DataRow to UserRow
            var filteredRows = (ItemFinderDataSet.UsersRow[])rows.Select($"UserName='{userName}'");

            //Returning the role if the returned length of rows is only 1
            return filteredRows.Length == 1 ? filteredRows[0].Role : null;
        }
    }
}
