/*
 * Author: Ivan Pavlov
 * Group Project: Department Dao Code
 * December 9, 2019
*/

using System.Collections.Generic;
using System.Data.SqlClient;
using ItemFinder.ItemFinderDataSetTableAdapters;
using ItemFinderClassLibrary;

namespace ItemFinder.DAL
{
    public class DepartmentDao
    {
        //Declaring any objects/variables needed
        private readonly string _conString;
        readonly DepartmentTableAdapter _tableAdapter = new DepartmentTableAdapter();

        /// <summary>
        /// Constructor for a Department Dao Object
        /// </summary>
        /// <param name="conString">Connection string to a database</param>
        public DepartmentDao(string conString)
        {
            //Setting the connection string
            _conString = conString;
        }

        /// <summary>
        /// Method that returns a list of department objects within the
        /// departments table
        /// </summary>
        /// <returns>List of department objects within the
        /// departments table</returns>
        public List<Department> GetDepartments()
        {
            //Creating a list of department objects to be returned later on
            List<Department> departments = new List<Department>();

            //Open a DB connection
            SqlConnection con = new SqlConnection(_conString);
            con.Open();

            //Creating an SQL command
            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from [Department]";
            command.Connection = con;

            //Execute command and fetch results
            var reader = command.ExecuteReader();

            //Loop till all records have not been read to populate the list
            while (reader.Read())
            {
                //Getting data than adding the new object to the list
                var departmentId = reader.GetInt32(0);
                var name = reader.GetString(2);
                var description = reader.GetString(3);

                departments.Add(new Department(name, departmentId, description));
            }

            //Close all connections/readers
            reader.Close();
            con.Close();

            //Return list of departments
            return departments;
        }

        /// <summary>
        /// Method that gets a department ID by the name of that specific
        /// department
        /// </summary>
        /// <param name="name">Department Name</param>
        /// <returns>Id of department</returns>
        public int GetDepartmentId(string name)
        {
            //Getting all rows in department table
            ItemFinderDataSet.DepartmentDataTable rows = _tableAdapter.GetData();

            //Cast from DataRow to DepartmentRow
            var filteredRows = (ItemFinderDataSet.DepartmentRow[])rows.Select($"DepartmentName='{name}'");

            //Returning the Id if the returned length of rows is only 1
            if (filteredRows.Length == 1)
                return filteredRows[0].DepartmentId;

            return -1;
        }
    }
}
