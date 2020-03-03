using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ItemFinderClassLibrary;

namespace ItemFinderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetItems" in both code and config file together.
    [ServiceContract]
    public interface IGetItems
    {
        [OperationContract]
        List<Item> GetItems();
    }
}
