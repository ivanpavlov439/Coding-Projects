/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: CourseDao Class
 * December 5, 2019
*/

using System.Data;
using System.Data.SqlClient;

namespace FlexiLearn___ClassLibrary.DAL
{
    public class CourseDao
    {
        //Declaring the connection string for the database
        private readonly string _conString;

        /// <summary>
        /// Constructor for a CourseDao object
        /// </summary>
        /// <param name="conString">connection string for a database</param>
        public CourseDao(string conString)
        {
            _conString = conString;
        }

        /// <summary>
        /// Method that returns a DataTable of all the courses in the database.
        /// </summary>
        /// <returns>DataTable of all the courses in the table</returns>
        public DataTable PullData()
        {
            //Setting up query
            var table = new DataTable();
            var query = "select * from [Course]";

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

    }
}
