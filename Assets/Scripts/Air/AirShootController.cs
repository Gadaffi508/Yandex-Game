using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ducktastic
{
    public class AirShootController : MonoBehaviour
    {
        [Header("References")]
        public Transform[] firePos = null;

        public Transform poolPos;
        
        public GameObject bullet = null;

        public float fireRepeatTime = 0.5f;
        
        public int poolSize = 20;

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

        void InitializeObjectPool()
        {
            objectPool = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(bullet,poolPos);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }

        void FireEvent(bool fireClick)
        {
            FireBullet();
        }
        
        void FireBullet()
        {
            if (objectPool.Count > 0)
            {
                GameObject bullet = objectPool.Dequeue();
                Transform firePosition = firePos[Random.Range(0, firePos.Length)];
                bullet.transform.position = firePosition.position;
                bullet.transform.rotation = firePosition.rotation;
                bullet.SetActive(true);
                StartCoroutine(DisableAfterTime(bullet, fireRepeatTime));
            }
        }
        
        IEnumerator DisableAfterTime(GameObject obj, float time)
        {
            yield return new WaitForSeconds(time);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }
}
