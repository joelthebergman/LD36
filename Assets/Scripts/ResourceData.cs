using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace joelthebergman
{
    public enum ResourceType { Wood, Stone, Leather, Bone, Food}
    [CreateAssetMenu(fileName = "ResourceData", menuName = "Resource Data")]
    public class ResourceData : ScriptableObject
    {
        public string Name { get { return name; } }
        [SerializeField]
        private ResourceType resourceType;
        public ResourceType ResourceType { get { return resourceType; }  set { resourceType = value; } }

    }
}

