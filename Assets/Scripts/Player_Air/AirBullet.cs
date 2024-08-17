using System;
using UnityEngine;

namespace Ducktastic
{
    public class AirBullet : MonoBehaviour
    {
        public BulletData _data;
        
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.AddForce(transform.forward * _data.speed);
        }

        void OnEnable()
        {
            rb.linearVelocity = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag(_data.targetName)) return;
            
            if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag(_data.currentJetName))
            {
                Instantiate(_data.fireEffect, transform.position, Quaternion.identity);
            }
            
            if (other.gameObject.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(_data.damage);
            }
        }
    }
}