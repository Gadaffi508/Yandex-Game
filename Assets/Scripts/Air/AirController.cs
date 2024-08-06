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
        
        private PlayerInput ınputManager;

        private float throttle, pitch;

        private Rigidbody rb = null;

        private Vector3 targetRotation;

        private Quaternion targetQuat;
        
        private float mouseX, mouseY;

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
            if (ınputManager.MoveEvent.y > 0.01f) throttle += throttleIncrement;
            else if (ınputManager.MoveEvent.y < 0.01f) throttle -= throttleIncrement;

            throttle = Mathf.Clamp(throttle, 0f, 100f);
        }

        void UpdateTargetRotation()
        {
            targetRotation.y += ınputManager.MouseEvent.x * rotationSpeed;
            targetRotation.x -= ınputManager.MouseEvent.y * rotationSpeed;

            targetRotation.x = Mathf.Clamp(targetRotation.x, -90f, 90f);
        }

        void AirForce()
        {
            rb.AddForce(transform.forward * maxThrust * throttle);

            rb.AddForce(Vector3.up * rb.linearVelocity.magnitude * 150f);
        }
    }
}