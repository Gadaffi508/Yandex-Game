using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ducktastic
{
    public class AirShootController : MonoBehaviour, IAttack
    {
        public AttackData Data
        {
            get { return data; }
            set
            {
                Data.firePos[0] = firePos[0];
                Data.firePos[1] = firePos[1];
                Data.poolPos = poolPos;
            }
        }
        
        public Transform[] firePos;
        
        public Transform poolPos;

        public AttackData data;

        private PlayerInput _ınputManager;

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
            Data.objectPool = new Queue<GameObject>();

            for (int i = 0; i < 2; i++)
            {
                GameObject obj = Instantiate(Data.bullet, Data.poolPos);
                obj.SetActive(false);
                Data.objectPool.Enqueue(obj);
            }
        }

        void FireEvent(bool fireClick)
        {
            FireBullet();
        }

        public void FireBullet()
        {
            if (Data.objectPool.Count > 0)
            {
                GameObject bullet = Data.objectPool.Dequeue();
                Transform firePosition = Data.firePos[Random.Range(0, 1)];
                bullet.transform.position = firePosition.position;
                bullet.transform.rotation = firePosition.rotation;
                bullet.SetActive(true);
                StartCoroutine(DisableAfterTime(bullet, Data.fireRepeatTime));
            }
        }

        public IEnumerator DisableAfterTime(GameObject obj, float time)
        {
            yield return new WaitForSeconds(time);
            obj.SetActive(false);
            Data.objectPool.Enqueue(obj);
        }
    }
}