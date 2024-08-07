using System;
using UnityEngine;

namespace Ducktastic
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AirShootController))]
    public class AirController : MonoBehaviour
    {
        [Header("Plane Stats")] public float throttleIncrement = 0.1f;
        public float maxThrust = 200f;

        public float rotationSpeed = 2f;

        private float throttle, pitch;
        
        private float mouseX, mouseY;

        private bool sprint = false;
        
        private PlayerInput ınputManager;
        
        private Rigidbody rb = null;

        private Vector3 targetRotation;

        private Quaternion targetQuat;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();

            Cursor.lockState = CursorLockMode.Locked;
        }

        void Start()
        {
            ınputManager = GetComponent<PlayerInput>();
        }

        void Update()
        {
            HandleInputs();
            UpdateTargetRotation();
        }

        void FixedUpdate()
        {
            AirForce();
            
            targetQuat = Quaternion.Euler(targetRotation);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetQuat, Time.fixedDeltaTime * rotationSpeed));
        }

        void HandleInputs()
        {
            if (ınputManager.CurrentMovement.y > 0.01f) throttle += throttleIncrement;
            else if (ınputManager.CurrentMovement.y < 0.01f) throttle -= throttleIncrement;

            sprint = ınputManager.SprintClick;

            throttle = Mathf.Clamp(throttle, 0f, 100f);
        }

        void UpdateTargetRotation()
        {
            targetRotation.y += ınputManager.MouseMovement.x * rotationSpeed * Time.deltaTime;
            targetRotation.x -= ınputManager.MouseMovement.y * rotationSpeed * Time.deltaTime;

            targetRotation.x = Mathf.Clamp(targetRotation.x, -90f, 90f);
        }

        void AirForce()
        {
            int maxThrottle = sprint ? 1000 : 200;
            
            rb.AddForce(transform.forward * maxThrottle * throttle);

            rb.AddForce(Vector3.up * rb.linearVelocity.magnitude * 150f);
        }
    }
}