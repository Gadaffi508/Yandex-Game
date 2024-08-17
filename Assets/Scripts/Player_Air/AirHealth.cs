using System;
using UnityEngine;

namespace Ducktastic
{
    public class AirHealth : MonoBehaviour, IHealth
    {
        public int health = 100;

        private AirController _controller;
        
        private AirShootController _shootController;

        private void Start()
        {
            _controller = GetComponent<AirController>();
            
            _shootController = GetComponent<AirShootController>();
        }

        public int Health
        {
            get => health;
            set => health = value;
        }
        
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if(Health <= 0)
                Explode();
        }

        public void Explode()
        {
            Time.timeScale = 0.2f;

            _controller.enabled = false;

            _shootController.enabled = false;
        }
    }
}
