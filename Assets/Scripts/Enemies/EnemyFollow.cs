using System;
using UnityEngine;

namespace Ducktastic
{
    public class EnemyFollow : MonoBehaviour
    {
        public Transform target;

        public float enemyDistance = 5;

        public float speed;

        public GameObject bullet;

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
            Debug.Log("Fire Enemy");
        }

        bool Distance()
        {
            return Vector3.Distance(transform.position, target.position) > enemyDistance;
        }
    }
}
