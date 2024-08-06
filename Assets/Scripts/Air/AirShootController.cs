using System;
using UnityEngine;

namespace Ducktastic
{
    public class AirShootController : MonoBehaviour
    {
        [Header("References")]
        public Transform[] firePos = null;
        
        public GameObject bullet = null;

        public float fireRepeatTime = 0.5f;

        private float duration = 0f;

        private void Update()
        {
            duration += Time.deltaTime;
            if (Input.GetMouseButton(0) && duration > fireRepeatTime)
            {
                Fire();
                duration = 0;
            }
        }

        void Fire()
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject bulletInstance = Instantiate(bullet, firePos[i].position, firePos[i].rotation);
                Destroy(bulletInstance,5f);
            }
        }
    }
}
