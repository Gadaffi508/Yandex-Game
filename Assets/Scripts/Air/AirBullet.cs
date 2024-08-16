using System;
using UnityEngine;

namespace Ducktastic
{
    public class AirBullet : MonoBehaviour
    {
        public float speed = 100;

        public GameObject fireEffect;

        public int damage = 20;

        public String targetName;

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
            if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy"))
            {
                Instantiate(fireEffect, transform.position, Quaternion.identity);
            }

            if (!other.gameObject.CompareTag(targetName)) return;

            if (other.gameObject.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(damage);
            }
        }
    }
}