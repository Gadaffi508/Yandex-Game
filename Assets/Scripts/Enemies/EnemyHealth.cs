using System;
using UnityEngine;

namespace Ducktastic
{
    [RequireComponent(typeof(MeshDestroy))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public int health = 100;

        private MeshDestroy _destroy;

        private void Start() =>
            _destroy = GetComponent<MeshDestroy>();

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
            _destroy.DestroyMesh();
        }
    }
}
