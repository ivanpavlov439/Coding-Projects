/*
 * Author: Ivan Pavlov
 * Group Project: Item Dao Code
 * December 9, 2019
*/

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ItemFinderClassLibrary;

namespace ItemFinder.DAL
{
    public class ItemDao
    {
        //Declaring any variables needed
        private readonly string _conString;

        /// <summary>
        /// Constructor for a Item Dao Object
        /// </summary>
        /// <param name="conString">Connection string to a database</param>
        public ItemDao(string conString)
        {
            //Initializing the connection string
            _conString = conString;
        }

        /// <summary>
        /// Method that takes an item object and inserts it into the items table
        /// </summary>
        /// <param name="item">An item object to be inserted to table</param>
        /// <returns>An int of how many rows were inserted</returns>
        public int AddItem(Item item)
        {
            //Variable to keep track how many rows inserted
            var count = 0;

            try
            {
                //Setting up the SQL query to insert into the table
                var insertCommand = "Insert into [Item] (DepartmentId, ItemName, ItemLocation, ItemDesc, ItemPrice) " +
                                    "Values (@DepartmentId, @ItemName, @ItemLocation, @ItemDesc, @ItemPrice)";
                using (var con = new SqlConnection(_conString))
                using (var command = new SqlCommand(insertCommand, con))
                {
                    //Opening the connection and adding parameters to the SQL command to be executed later on
                    con.Open();
                    command.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = item.DepartmentId;
                    command.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = item.Name;
                    command.Parameters.Add("@ItemLocation", SqlDbType.VarChar).Value = item.Location;
                    command.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = item.Description;
                    command.Parameters.Add("@ItemPrice", SqlDbType.Decimal).Value = item.Price;

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

            //Returns rows inserted
            return count;
        }

        /// <summary>
        /// Method that returns a list of item objects within the
        /// items table
        /// </summary>
        /// <returns>List of item objects within the
        /// items table</returns>
        public List<Item> GetItems()
        {
            //Creating a list of item objects to be returned later on
            List<Item> items = new List<Item>();

            //Open a DB connection
            SqlConnection con = new SqlConnection(_conString);
            con.Open();

            //Create a SQL command
            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from [Item]";
            command.Connection = con;

            //Execute command and fetch results
            var reader = command.ExecuteReader();

            //Loop till all records have not been read to populate the list
            while (reader.Read())
            {
                //Getting data than adding the new object to the list
                var departmentId = reader.GetInt32(1);
                var name = reader.GetString(2);
                var description = reader.GetString(3);
                var location = reader.GetString(4);
                var price = reader.GetDecimal(5);

                items.Add(new Item(departmentId, name,  description, location, (float)price));
            }

            //Close all connections/readers
            reader.Close();
            con.Close();

            //Return the list of item objects
            return items;
        }

        /// <summary>
        /// Method that returns an item object based on its item id
        /// </summary>
        /// <param name="id">Item Id</param>
        /// <returns>Item object based on its Id</returns>
        public Item GetItem(int id)
        {

            //Open a DB connection
            var con = new SqlConnection(_conString);
            con.Open();

            //Create a SQL command
            var command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from [Item] where ItemId = '" + id + "'";
            command.Connection = con;

            //Execute command and fetch results
            var reader = command.ExecuteReader();

            //Loop till all records have not been read to populate the list
            while (reader.Read())
            {
                //Getting data than creating a new item object based on the data recieved
                var departmentId = reader.GetInt32(1);
                var name = reader.GetString(2);
                var description = reader.GetString(3);
                var location = reader.GetString(4);
                var price = reader.GetDecimal(5);

                var item = new Item(departmentId, name, description, location, (float) price);

                //Close all connections/readers
                reader.Close();
                con.Close();

                //Return the item found
                return item;

            }

            //Return null if no item was found
            return null;
        }

        /// <summary>
        /// Method that returns a DataTable of all the Items in the database.
        /// </summary>
        /// <returns>DataTable of all the items in the table</returns>
        public DataTable PullAllData()
        {
            //Setting up query
            var table = new DataTable();
            var query = "select * from [Item]";

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

            //Return the DataTable of Items
            return table;
        }

        /// <summary>
        /// Method that updates an item in the table based on its item id
        /// </summary>
        /// <param name="item">Item Object to be updated</param>
        /// <param name="id">Item id telling which row to update</param>
        public void UpdateItem(Item item, int id)
        {
            //Creating connection, query, and adapter for the database
            var conn = new SqlConnection(_conString);
            var adapter = new SqlDataAdapter();
            var sql = "Update [Item] set DepartmentId = " + item.DepartmentId + ", ItemName = '" + item.Name + "', ItemLocation = '" + item.Location + "', ItemDesc = '" + item.Description + "', ItemPrice = " + item.Price + " where ItemId = '" + id + "'";

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
