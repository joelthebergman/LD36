using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace joelthebergman
{
    public class HarvestableFood : MonoBehaviour
    {
        [SerializeField]
        private float harvestStaminaCost;
        [SerializeField]
        private float harvestHealth;
        [SerializeField]
        private Food resource;
        [SerializeField]
        private Transform spawn;
        private bool canBeHarvested;
        private AtlatlBoyController controller;
        [SerializeField]
        private GameObject harvestPrompt;
        void OnTriggerStay(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                AtlatlBoyController tempController = other.attachedRigidbody.GetComponent<AtlatlBoyController>();

                if (tempController != null)
                {
                    controller = tempController;
                    canBeHarvested = true;
                    harvestPrompt.SetActive(true);
                }
            }

        }
        void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                if (controller != null && other.attachedRigidbody.gameObject == controller.gameObject)
                {
                    canBeHarvested = false;
                    harvestPrompt.SetActive(false);
                }
            }

        }

        void Update()
        {
            if (canBeHarvested)
            {
                if (Input.GetButtonDown("Harvest"))
                {

                    if (controller != null && controller.CurrentStamina >= harvestStaminaCost)
                    {
                        Debug.Log("Hunted " + resource.name);
                        controller.ExertStamina(harvestStaminaCost);
                        controller.TakeDamate(harvestHealth);
                        Vector3 randomSpawn = transform.position + (Random.insideUnitSphere * 2);
                        randomSpawn.y = spawn.position.y;
                        Instantiate(resource, randomSpawn, Quaternion.identity);
                    }

                }
            }
        }

    }
}