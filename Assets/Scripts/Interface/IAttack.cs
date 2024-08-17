using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace Ducktastic
{
    interface IAttack
    {
        void InitializeObjectPool();

        void FireBullet();

        IEnumerator DisableAfterTime(GameObject obj, float time);
    } 
}
