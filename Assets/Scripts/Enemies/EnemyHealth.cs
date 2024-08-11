using System;
using UnityEngine;

namespace Ducktastic
{
    [RequireComponent(typeof(MeshDestroy))]
    public class EnemyHealth : MonoBehaviour
    {
        public int health = 100;

        private MeshDestroy _destroy;

        private void Start() =>
            _destroy = GetComponent<MeshDestroy>();

        public void TakeDamage(int _damage)
        {
            health -= _damage;
            if(health <= 0)
                Explode();
        }

        void Explode()
        {
            _destroy.DestroyMesh();
        }
    }
}
