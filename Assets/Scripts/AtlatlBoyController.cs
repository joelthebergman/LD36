using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace joelthebergman
{
    public class AtlatlBoyController : MonoBehaviour
    {
        
        [SerializeField]
        private Rigidbody rigidbody;
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

        private bool isMoving;
        private bool isSprinting;

        [SerializeField]
        private Inventory inventory;
        public Inventory Inventory { get { return inventory; } }
        [SerializeField]
        private UIManager uiManager;
        [SerializeField]
        private Camera camera;
        [SerializeField]
        private Transform cameraGimbal;
        [SerializeField]
        private Transform characterTransform;
        private bool rotatingCharacter;

        void Awake()
        {
            currentHealth = maxHealth;
            currentStamina = maxStamina;
            currentHunger = maxHunger;
            currentCold = maxCold;
            uiManager.Setup();
        }

        void FixedUpdate()
        {
            Move();
            StatTick();

        }

        private void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            float yRotation = Input.GetAxis("Turning");
            inputVector = Vector3.Normalize(new Vector3(x, 0f, y));
            float speedMultiplier = baseMoveSpeed;
            isSprinting = false;
            if (Input.GetButton("Run"))
            {
                speedMultiplier *= runMoveSpeedMultiplier;
                isSprinting = true;
            }
            isMoving = inputVector != Vector3.zero ? true:false;
       
            Vector3 speed = inputVector * speedMultiplier;
            Vector3 velocity = characterTransform.forward * speed.z;
            //velocity += cameraGimbal.right * speed.x;
            velocity += -transform.up;
            rigidbody.velocity = velocity;
            cameraGimbal.Rotate(new Vector3(0f, yRotation * 2f));

            if (isMoving)
            {
                if (!rotatingCharacter)
                {
                    StartCoroutine(RotateCharacterToCameraGimbalForward());
                }
            }

            transform.Rotate(0f, inputVector.x * 2f, 0f);
            //rigidbody.angularVelocity = new Vector3(0f, yRotation);
        }

        private void StatTick()
        {
            if (isMoving)
            {
                currentStamina -= staminaTickRate;
                if (isSprinting)
                {
                    currentStamina -= staminaTickRate;
                }
                if(currentStamina <= 0)
                {
                    currentStamina = 0;
                    currentHunger -= hungerTickRate;
                }
                currentHunger -= hungerTickRate;

            }
            else
            {
                currentStamina += staminaTickRate;
                if (currentStamina >= maxStamina)
                {
                    currentStamina = maxStamina;
                }
            }
            currentHunger -= hungerTickRate;
            if(currentHunger <= 0)
            {
                currentHunger = 0;
                currentHealth -= hungerDamage;
            }
            if(currentHealth <= 0)
            {
                currentHealth = 0;
                Debug.Log("YOU DIED!");
                Debug.Break();
            }

        }

        public void ExertStamina(float amount)
        {
            currentStamina -= amount;
        }

        private IEnumerator RotateCharacterToCameraGimbalForward()
        {
            yield return null;
            float rotationDuration = 0.5f;
            float currentTime = 0f;
            Quaternion original = characterTransform.rotation;
            while (currentTime < rotationDuration)
            {
                characterTransform.rotation = Quaternion.Lerp(original, cameraGimbal.rotation, currentTime/rotationDuration);
                currentTime += Time.deltaTime;
                yield return null;
            }

            rotatingCharacter = false;
            yield return null;
        }
    }

}
