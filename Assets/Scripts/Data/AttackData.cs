using UnityEngine;
using System.Collections.Generic;

namespace Ducktastic
{
    [CreateAssetMenu(fileName = "AttackData", menuName = "Scriptable Objects/AttackData")]
    public class AttackData : ScriptableObject
    {
        [Header("References")] public Transform[] firePos;
        
        public Transform poolPos;
        
        public GameObject bullet;
        
        public float fireRepeatTime;
        
        public int poolSize;
        
        public Queue<GameObject> objectPool;
    }
}
