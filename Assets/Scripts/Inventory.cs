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
        private Dictionary<ResourceData, PickupableResource> resourceDictionary;
        public Dictionary<ResourceData, PickupableResource> ResourceDictionary { get { return resourceDictionary; } }

        public void AddItem(PickupableResource item)
        {
            inventoryList.Add(item);
            //resourceDictionary.Add(item.ResourceData, item);
        }
        public void RemoveItem(PickupableResource item)
        {
            inventoryList.Remove(item);
           // resourceDictionary.Remove(item.ResourceData);
        }

        public void RemovePickupableByResourceData(ResourceData data)
        {
            foreach(PickupableResource r in inventoryList)
            {
                if (r.ResourceData == data)
                {
                    RemoveItem(r);
                    break;
                }
            }
        }

        public List<ResourceData> InventoryResourceList
        {
            get
            {
                List<ResourceData> resources = new List<ResourceData>();
                foreach (PickupableResource r in inventoryList)
                {
                    resources.Add(r.ResourceData);
                }
                return resources;
            }
        }
    }
}

