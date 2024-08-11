using System;
using UnityEngine;

namespace Ducktastic
{
    public class AirBullet : MonoBehaviour
    {
        public float speed = 100;

        public GameObject fireEffect;

        public int damage = 20;
        
        private Rigidbody rb;

        private bool touched = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.AddForce(transform.forward * speed);
        }

        void OnEnable()
        {
            rb.linearVelocity = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                Instantiate(fireEffect,transform.position,Quaternion.identity);
            }

            if (other.gameObject.TryGetComponent(out EnemyHealth health))
            {
                health.TakeDamage(damage);
            }
        }
    }
}
