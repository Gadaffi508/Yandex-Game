using UnityEngine;
using System.Collections.Generic;

namespace Ducktastic
{
    [CreateAssetMenu(fileName = "AttackData", menuName = "Scriptable Objects/AttackData")]
    public class AttackData : ScriptableObject
    {
        [Header("References")]
        
        public GameObject bullet;
        
        public float fireRepeatTime;
        
        public int poolSize;
    }
}
