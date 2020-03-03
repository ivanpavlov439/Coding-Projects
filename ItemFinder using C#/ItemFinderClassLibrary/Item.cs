/*
 * Author: Ivan Pavlov
 * Group Project: Item Class
 * December 9, 2019
*/

namespace ItemFinderClassLibrary
{
    public class Item
    {
        /// <summary>
        /// Constructor for an item object
        /// </summary>
        /// <param name="departmentId">Department id</param>
        /// <param name="name">Item name</param>
        /// <param name="location">Item location</param>
        /// <param name="description">Item description</param>
        /// <param name="price">Item price</param>
        public Item(int departmentId, string name, string location, 
            string description = "No description available.", float price = -1)
        {
            Name = name;
            DepartmentId = departmentId;
            Description = description;
            Price = price;
            Location = location;
        }

        //All uuto properties of an Item object
        public string Name { get; private set; }

        public int DepartmentId { get; private set; }

        public string Description { get; private set; }

        public float Price { get; private set; }

        public string Location { get; private set; }
    }
}
