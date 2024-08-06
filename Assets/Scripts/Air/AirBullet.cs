using System;
using UnityEngine;

namespace Ducktastic
{
    public class AirBullet : MonoBehaviour
    {
        public float speed = 100;

        public GameObject fireEffect;
        
        private Rigidbody rb;

        private bool touched = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if(touched == true) return;
            rb.AddForce(transform.forward * speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                touched = true;
                Instantiate(fireEffect,transform.position,Quaternion.identity);
                Destroy(rb);
            }
        }
    }
}
