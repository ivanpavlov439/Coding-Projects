/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: RegistrationDao Class
 * December 5, 2019
*/

using System.Data;
using System.Data.SqlClient;

namespace FlexiLearn___ClassLibrary.DAL
{
    public class RegistrationDao
    {
        //Declaring the connection string for the database
        private readonly string _conString;

        /// <summary>
        /// Constructor for a RegistrationDao object
        /// </summary>
        /// <param name="conString">connection string for a database</param>
        public RegistrationDao(string conString)
        {
            _conString = conString;
        }

        /// <summary>
        /// Method that adds a new Registration to the table based on
        /// a RegistrationRequest object.
        /// </summary>
        /// <param name="request">RegistrationRequest object</param>
        /// <returns></returns>
        public int AddRecord(RegistrationRequest request)
        {
            var count = 0;
            try
            {
                //Setting up the SQL query to insert into the table
                var insertCommand = "Insert into [Registrations] (UserName, CourseTitle, CourseSubject, RegisteredDate, Status) Values (@UserName, @CourseTitle, @CourseSubject, @RegisteredDate, @Status)";
                using (var con = new SqlConnection(_conString))
                using (var command = new SqlCommand(insertCommand, con))
                {
                    //Opening the connection and adding parameters to the SQL command to be executed later on
                    con.Open();
                    command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = request.UserName;
                    command.Parameters.Add("@CourseTitle", SqlDbType.VarChar).Value = request.CourseTitle;
                    command.Parameters.Add("@CourseSubject", SqlDbType.VarChar).Value = request.CourseSubject;
                    command.Parameters.Add("@RegisteredDate", SqlDbType.DateTime).Value = request.RegisteredDate;
                    command.Parameters.Add("@Status", SqlDbType.VarChar).Value = request.Status;

                    //Executing the command above with all the parameters given
                    count = command.ExecuteNonQuery();
                }

            }

            //Catching exception
            catch (SqlException ex)
            {
                //Throwing the exception that was caught
                throw ex;
            }
            return count;
        }

        /// <summary>
        /// Method that pulls a specific users registration data based
        /// on their username.
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns>DataTable of the registrations that user has</returns>
        public DataTable PullUserData(string userName)
        {
            //Setting up query
            var table = new DataTable();
            var query = "select * from [Registrations] where UserName = '" + userName + "'";

            //Creating connection and command text objects
            var conn = new SqlConnection(_conString);
            var cmd = new SqlCommand(query, conn);
            conn.Open();

            //Create data adapter
            var da = new SqlDataAdapter(cmd);

            //This will query the database and return the result to the DataTable
            da.Fill(table);
            conn.Close();
            da.Dispose();
            return table;
        }

        /// <summary>
        /// Method that returns a DataTable of all the registrations in the database.
        /// </summary>
        /// <returns>DataTable of all the registrations in the table</returns>
        public DataTable PullAllData()
        {
            //Setting up query
            var table = new DataTable();
            var query = "select * from [Registrations]";

            //Creating connection and command text objects
            var conn = new SqlConnection(_conString);
            var cmd = new SqlCommand(query, conn);
            conn.Open();

            //Create data adapter
            var da = new SqlDataAdapter(cmd);

            //This will query the database and return the result to the DataTable
            da.Fill(table);
            conn.Close();
            da.Dispose();
            return table;
        }

        /// <summary>
        /// Method that updates the registration status by the id of the
        /// registration.
        /// </summary>
        /// <param name="id">registration id</param>
        /// <param name="status">registration status</param>
        public void UpdateRegistration(int id, string status)
        {
            //Creating connection, query, and adapter for the database
            var conn = new SqlConnection(_conString);
            var adapter = new SqlDataAdapter();
            var sql = "Update [Registrations] set Status = '" + status + "' where RegistrationId = '" + id + "'";

            //Creating command based on the SQL string above
            var command = new SqlCommand(sql, conn);
            conn.Open();

            //Using the adapter, data is updated in the database with the new data given by the user
            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();

            //Close the connection and kill the command
            command.Dispose();
            conn.Close();
        }
    }
}
