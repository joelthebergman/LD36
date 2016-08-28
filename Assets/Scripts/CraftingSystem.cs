using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace joelthebergman
{
    public class CraftingSystem : MonoBehaviour
    {
        [SerializeField]
        private List<CraftableObject> craftableObjects;

        private AtlatlBoyController controller;
        private bool canCraft;
        [SerializeField]
        private GameObject craftPrompt;
        void OnTriggerStay(Collider other)
        {
            controller = other.attachedRigidbody.GetComponent<AtlatlBoyController>();
            if (controller != null)
            {
                canCraft = true;
                craftPrompt.SetActive(true);
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody.GetComponent<AtlatlBoyController>() != null)
            {
                canCraft = false;
                craftPrompt.SetActive(false);
            }
        }

        void Update()
        {
            if (canCraft)
            {
                if (Input.GetButtonDown("Craft"))
                {
                    if (controller != null)
                    {
                        Debug.Log("Craft!");
                        Craft(craftableObjects[0]);
                    }
                }

            }  
        }
        private void Craft(CraftableObject obj)
        {
            int matches = 0;
            foreach(ResourceData d in obj.RecepieResourceList)
            {
                if (controller.Inventory.InventoryResourceList.Contains(d))
                {
                    Debug.Log("Match");
                    matches++;
                }
                else
                {
                    Debug.Log("not match");
                }
            }
            if(matches == obj.Recipe.Count)
            {
                Vector3 spawnLocation = transform.position + Random.insideUnitSphere;
                spawnLocation.y = 1;
                Instantiate(obj.ResourceToSpawn, spawnLocation, Quaternion.identity);
                foreach(ResourceData data in obj.RecepieResourceList)
                {
                    controller.Inventory.RemovePickupableByResourceData(data);
                }
            }
            
        }
    }
}

