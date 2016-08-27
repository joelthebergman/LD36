using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace joelthebergman
{
    public class PickupableResource : MonoBehaviour
    {
        [SerializeField]
        private ResourceData resourceData;

        void OnTriggerEnter(Collider other)
        {
           
            if (other.attachedRigidbody)
            {
                AtlatlBoyController aBoy = other.attachedRigidbody.GetComponent<AtlatlBoyController>();
                if (aBoy != null)
                {
                    aBoy.Inventory.AddItem(this);
                    gameObject.SetActive(false);
                }
            }

        }


    }
}

