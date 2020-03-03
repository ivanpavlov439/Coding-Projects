/*
 * Author: Ivan Pavlov
 * Group Project: Web Service
 * December 9, 2019
*/

using System.Collections.Generic;
using ItemFinder.DAL;
using ItemFinderClassLibrary;

namespace ItemFinderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetItems" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetItems.svc or GetItems.svc.cs at the Solution Explorer and start debugging.
    public class GetItems : IGetItems
    {
        /// <summary>
        /// Service that returns all items in the table to consumer
        /// </summary>
        /// <returns>List of items in DB</returns>
        List<Item> IGetItems.GetItems()
        {
            //Getting items from table through dao, then returning it to consumer
            var itemDao = new ItemDao(Properties.Settings.Default.conString);
            var items = itemDao.GetItems();
            return items;
        }
    }
}
