using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace joelthebergman
{
    [CreateAssetMenu(fileName = "CraftableObject", menuName = "Craftable Object")]
    public class CraftableObject : ScriptableObject
    {
        [SerializeField]
        private PickupableResource resourceToSpawn;
        public PickupableResource ResourceToSpawn { get { return resourceToSpawn; } }
        [SerializeField]
        private List<PickupableResource> recipe;
        public List<PickupableResource> Recipe { get { return recipe; } }  
        [SerializeField]
        private float staminaCost;
        public float StaminaCost { get { return staminaCost; } }
        public List<ResourceData> RecepieResourceList
        {
            get
            {
                List<ResourceData> resources = new List<ResourceData>();
                foreach (PickupableResource r in recipe)
                {
                    resources.Add(r.ResourceData);
                }
                return resources;
            }
        }
    }
}

