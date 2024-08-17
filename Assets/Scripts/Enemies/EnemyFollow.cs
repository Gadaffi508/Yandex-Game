using System;
using UnityEngine;

namespace Ducktastic
{
    [RequireComponent(typeof(EnemyAttack))]
    public class EnemyFollow : MonoBehaviour
    {
        public Transform target;

        public float enemyDistance = 5;

        public float speed;

        private EnemyAttack _attack;

        private void Start() =>
            _attack = GetComponent<EnemyAttack>();

        private void Update()
        {
            if (Distance())
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            else
                Fire();

            transform.LookAt(target);
        }

        void Fire()
        {
            _attack.Attack();
        }

        bool Distance()
        {
            return Vector3.Distance(transform.position, target.position) > enemyDistance;
        }
    }
}