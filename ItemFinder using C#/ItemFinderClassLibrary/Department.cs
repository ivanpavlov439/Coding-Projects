/*
 * Author: Ivan Pavlov
 * Group Project: Department Class
 * December 9, 2019
*/

namespace ItemFinderClassLibrary
{
    public class Department
    {
        /// <summary>
        /// Constructor for a department object
        /// </summary>
        /// <param name="name">Department name</param>
        /// <param name="id">Department id</param>
        /// <param name="description">Department description</param>
        public Department(string name, int id, string description)
        {
            Name = name;
            Id = id;
            Description = description;
        }

    
        //All auto properties for the department class
        public string Name { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }
    }
}
