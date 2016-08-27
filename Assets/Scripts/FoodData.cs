using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace joelthebergman
{
    [CreateAssetMenu(fileName = "FoodData", menuName = "Food Data")]
    public class FoodData : ResourceData
    {
        [SerializeField]
        private float healthRecoveryAmount;
        public float HealthRecoveyAmount { get { return healthRecoveryAmount;} }
        [SerializeField]
        private float staminaRecoveryAmount;
        public float StaminaRecoveryAmount { get { return staminaRecoveryAmount; } }
        [SerializeField]
        private float coldRecoveryAmount;
        public float ColdRecoveryAmount { get { return coldRecoveryAmount; } }
        
       
    }
}

