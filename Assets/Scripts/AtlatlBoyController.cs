using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace joelthebergman
{
    public class AtlatlBoyController : MonoBehaviour
    {
        
        [SerializeField]
        private new Rigidbody rigidbody;
        [Header("Stats")]
        [SerializeField]
        private float maxHealth;
        private float currentHealth;
        public float CurrentHealth { get { return currentHealth; } }
        [SerializeField]
        private float maxHunger;
        private float currentHunger;
        public float CurrentHunger { get { return currentHunger; } }
        [SerializeField]
        private float maxStamina;
        private float currentStamina;
        public float CurrentStamina { get { return currentStamina; } }
        [SerializeField]
        private float maxCold;
        private float currentCold;
        public float CurrentCold { get { return currentCold; } }
        [Header("Internal variables")]
        [SerializeField]
        private float baseMoveSpeed;
        [SerializeField]
        private float runMoveSpeedMultiplier;
        [Header("Tick Rates")]
        [SerializeField]
        private float hungerTickRate;
        [SerializeField]
        private float staminaTickRate;
        [SerializeField]
        private float coldTickRate;
        [Header("Damages")]
        [SerializeField]
        private float hungerDamage;
        [SerializeField]
        private float coldDamage;

        private Vector3 inputVector;


        void Update()
        {
            Move();
        }

        private void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            inputVector = new Vector3(x, y, 0f);
            float speedMultiplier = baseMoveSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedMultiplier *= runMoveSpeedMultiplier;
            }
            Vector3 speed = inputVector * speedMultiplier;
            rigidbody.AddForce(speed);

        }
    }

}
