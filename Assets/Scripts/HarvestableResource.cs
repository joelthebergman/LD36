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
        private ResourceData resourceData;
        private bool canBeHarvested;
        private AtlatlBoyController controller;
        void OnTriggerEnter(Collider other)
        {
            controller = other.attachedRigidbody.GetComponent<AtlatlBoyController>();
            if (controller != null)
            {
                canBeHarvested = true;
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody.GetComponent<AtlatlBoyController>() != null)
            {
                canBeHarvested = false;
            }
        }

        void Update()
        {
            if (canBeHarvested)
            {
                if (Input.GetButtonDown("Harvest"))
                {
                    Debug.Log("Harvested " + resourceData.name);
                    controller.ExertStamina(harvestStaminaCost);

                }
            }
        }

    }
}