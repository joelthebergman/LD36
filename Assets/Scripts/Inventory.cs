using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace joelthebergman
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private List<PickupableResource> inventoryList;
        public List<PickupableResource> InventoryList { get { return inventoryList; } }

        public void AddItem(PickupableResource item)
        {
            inventoryList.Add(item);
        }
    }
}

