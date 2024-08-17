using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ducktastic
{
    public class EnemyAttack : MonoBehaviour, IAttack
    {
        public Transform[] firePos;

        public Transform poolPos;

        public AttackData _data;

        private Queue<GameObject> objectPool;

        private void Start() =>
            InitializeObjectPool();

        public void Attack() =>
            FireBullet();

        public void InitializeObjectPool()
        {
            objectPool = new Queue<GameObject>();

            for (int i = 0; i < 2; i++)
            {
                GameObject obj = Instantiate(_data.bullet, poolPos);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }

        public void FireBullet()
        {
            if (objectPool.Count > 0)
            {
                GameObject bullet = objectPool.Dequeue();
                Transform firePosition = firePos[Random.Range(0, 1)];
                bullet.transform.position = firePosition.position;
                bullet.transform.rotation = firePosition.rotation;
                bullet.SetActive(true);
                StartCoroutine(DisableAfterTime(bullet, _data.fireRepeatTime));
            }
        }

        public IEnumerator DisableAfterTime(GameObject obj, float time)
        {
            yield return new WaitForSeconds(time);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }
}