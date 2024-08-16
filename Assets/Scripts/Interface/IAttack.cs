using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace Ducktastic
{
    interface IAttack
    {
        public AttackData Data { get; set; }

        void InitializeObjectPool();

        void FireBullet();

        IEnumerator DisableAfterTime(GameObject obj, float time);
    } 
}
