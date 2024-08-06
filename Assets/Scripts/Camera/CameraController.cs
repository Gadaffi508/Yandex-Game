using System;
using UnityEngine;

namespace Ducktastic
{
    public class CameraController : MonoBehaviour
    {
        public Transform povs = null;

        public float speed = 5f;
        private Vector3 target => povs.position;

        void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            transform.forward = povs.forward;
        }
    }
}