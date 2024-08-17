using UnityEngine;

namespace Ducktastic
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "Scriptable Objects/BulletData")]
    public class BulletData : ScriptableObject
    {
        public float speed = 100;

        public GameObject fireEffect;

        public int damage = 20;

        public string currentJetName = string.Empty;
        
        public string targetName = string.Empty;
    }
}
