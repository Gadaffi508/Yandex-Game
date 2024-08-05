using System;
using UnityEngine;

namespace Ducktastic
{
    public class CameraController : MonoBehaviour
    {
        public Transform[] povs = null;

        public float speed = 5f;

        private int index = 0;
        private Vector3 target;

        void Update()
        {
            CalculateIndex();
            target = povs[index].position;
        }

        void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            transform.forward = povs[index].forward;
        }

        void CalculateIndex()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)) index ++;
            if (index > 3)
                index = 0;
        }
    }
}