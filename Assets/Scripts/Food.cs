using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace joelthebergman
{
    public class Food : MonoBehaviour
    {
        [SerializeField]
        private FoodData data;

        private AtlatlBoyController controller;
        private bool inRange;
        [SerializeField]
        private GameObject buttonPrompt;
        void OnTriggerEnter(Collider other)
        {

            if (other.attachedRigidbody)
            {
                AtlatlBoyController tempController = other.attachedRigidbody.GetComponent<AtlatlBoyController>();

                if (tempController != null)
                {
                    controller = tempController;
                    buttonPrompt.SetActive(true);
                    inRange = true;
                }
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody)
            {

                if (controller != null && other.attachedRigidbody.gameObject == controller.gameObject)
                {
                    controller = null;
                    inRange = false;
                    buttonPrompt.SetActive(false);
                }
            }

        }
        void Update()
        {
            if (inRange && controller != null)
            {
                if (Input.GetButton("PickUp"))
                {
                    controller.ConsumeFood(data);
                    gameObject.SetActive(false);
                }
            }
        }
    }

}

