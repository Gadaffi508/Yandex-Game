using System;
using System.Collections;
using UnityEngine;

namespace Ducktastic
{
    public class AirShootController : MonoBehaviour
    {
        [Header("References")]
        public Transform[] firePos = null;
        
        public GameObject bullet = null;

        public float fireRepeatTime = 0.5f;

        private PlayerInput _ınputManager;

        void Start()
        {
            _ınputManager = GetComponent<PlayerInput>();
        
            _ınputManager.OnFire += FireEvent;
        }
        void OnDisable()
        {
            _ınputManager.OnFire -= FireEvent;
        }

        void FireEvent(bool fireClick)
        {
            if (fireClick)
                StartCoroutine(FireRepeat());
            
            else
                StopAllCoroutines();
        }

        IEnumerator FireRepeat()
        {
            yield return new WaitForSeconds(fireRepeatTime);
            
            for (int i = 0; i < 2; i++)
            {
                GameObject bulletInstance = Instantiate(bullet, firePos[i].position, firePos[i].rotation);
                Destroy(bulletInstance,5f);
            }
            
            StartCoroutine(FireRepeat());
        }
    }
}
