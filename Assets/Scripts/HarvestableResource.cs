using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace joelthebergman
{
    public class HarvestableResource : MonoBehaviour
    {
        [SerializeField]
        private float harvestStaminaCost;
        [SerializeField]
        private PickupableResource resource;
        [SerializeField]
        private Transform spawn;
        private bool canBeHarvested;
        private AtlatlBoyController controller;
        [SerializeField]
        private GameObject harvestPrompt;
        void OnTriggerStay(Collider other)
        {
            controller = other.attachedRigidbody.GetComponent<AtlatlBoyController>();
            if (controller != null)
            {
                canBeHarvested = true;
                harvestPrompt.SetActive(true);
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody.GetComponent<AtlatlBoyController>() != null)
            {
                canBeHarvested = false;
                harvestPrompt.SetActive(false);
            }
        }

        void Update()
        {
            if (canBeHarvested)
            {
                if (Input.GetButtonDown("Harvest"))
                {
                   
                    if(controller != null && controller.CurrentStamina >= harvestStaminaCost)
                    {
                        Debug.Log("Harvested " + resource.name);
                        controller.ExertStamina(harvestStaminaCost);
                        Vector3 randomSpawn = transform.position + ( Random.insideUnitSphere );
                        randomSpawn.y = spawn.position.y;
                        Instantiate(resource, randomSpawn, Quaternion.identity);
                    }

                }
            }
        }

    }
}