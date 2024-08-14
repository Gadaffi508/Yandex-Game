using UnityEngine;

namespace Ducktastic
{
    public class JettEnemyHealth : MonoBehaviour, IHealth
    {
        public int Health
        {
            get => health;
            set => health = value;
        }

        public int health = 100;
        
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if(Health <= 0)
                Explode();
        }

        public void Explode()
        {
            Destroy(gameObject);
        }
    }
}
