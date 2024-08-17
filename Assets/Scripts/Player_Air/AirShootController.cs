using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ducktastic
{
    public class AirShootController : MonoBehaviour, IAttack
    {
        public Transform[] firePos;
        
        public Transform poolPos;

        public AttackData data;

        private PlayerInput _ınputManager;
        
        private Queue<GameObject> objectPool;

        void Start()
        {
            _ınputManager = GetComponent<PlayerInput>();

            InitializeObjectPool();

            _ınputManager.OnFire += FireEvent;
        }

        void OnDisable()
        {
            _ınputManager.OnFire -= FireEvent;
        }

        public void InitializeObjectPool()
        {
            objectPool = new Queue<GameObject>();

            for (int i = 0; i < data.poolSize; i++)
            {
                GameObject obj = Instantiate(data.bullet, poolPos);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }

        void FireEvent(bool fireClick)
        {
            FireBullet();
        }

        public void FireBullet()
        {
            if (objectPool.Count > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject bullet = objectPool.Dequeue();;
                    bullet.transform.position = firePos[i].position;
                    bullet.transform.rotation = firePos[i].rotation;
                    bullet.SetActive(true);
                    StartCoroutine(DisableAfterTime(bullet, data.fireRepeatTime));
                }
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