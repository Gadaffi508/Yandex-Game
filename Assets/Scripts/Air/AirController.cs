using System;
using UnityEngine;

namespace Ducktastic
{
    [RequireComponent(typeof(Rigidbody))]
    public class AirController : MonoBehaviour
    {
        [Header("Plane Stats")] public float throttleIncrement = 0.1f;
        public float maxThrust = 200f;
        public float responsive = 10f;

        private float throttle,
            roll,
            pitch,
            yaw;

        private float responseModifier
        {
            get
            {
                return (rb.mass / 10f) * responsive;
            }
        }

        private Rigidbody rb = null;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            HandleInputs();
        }

        void FixedUpdate()
        {
            rb.AddForce(transform.forward * maxThrust * throttle);
            rb.AddTorque(transform.up * yaw * responseModifier);
            rb.AddTorque(transform.right * pitch * responseModifier);
            rb.AddTorque(-transform.forward * roll * responseModifier);
            
            rb.AddForce(Vector3.up * rb.linearVelocity.magnitude * 150f);
        }

        void HandleInputs()
        {
            roll = Input.GetAxis("Horizontal");
            pitch = Input.GetAxis("Vertical");
            yaw = Input.GetAxis("Yaw");

            if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
            else if(Input.GetKey(KeyCode.LeftControl))  throttle -= throttleIncrement;

            throttle = Mathf.Clamp(throttle, 0f, 100f);
        }
    }
}