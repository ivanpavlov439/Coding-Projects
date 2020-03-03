/*
 * Author: Travis Tower
 * Group Project: Store Class
 * December 9, 2019
*/

using System.Collections.Generic;

namespace ItemFinderClassLibrary
{
    public class Store
    {
        /// <summary>
        /// Constructor for a store object
        /// </summary>
        /// <param name="name">Store name</param>
        /// <param name="id">Store id</param>
        /// <param name="location">Store location</param>
        /// <param name="mapPath">Store map path for picture</param>
        /// <param name="departments">List of departments</param>
        public Store(string name, int id, string location, string mapPath, List<Department> departments)
        {
            Name = name;
            Id = id;
            Location = location;
            MapPath = mapPath;
            Departments = departments;
        }

        //All auto properties for a store object
        public string Name { get; set; }

        public int Id { get; set; }

        public string Location { get; set; }

        public string MapPath { get; set; }

        public List<Department> Departments { get; set; }
    }
}
