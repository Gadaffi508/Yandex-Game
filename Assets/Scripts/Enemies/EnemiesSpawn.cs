using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ducktastic
{
    public class EnemiesSpawn : MonoBehaviour
    {
        public List<GameObject> planets = new List<GameObject>();

        public Transform planetPos;

        private void Start()
        {
            int random = Random.Range(0, planets.Count - 1);
            
            GameObject planet = Instantiate(planets[random], planetPos.position, Quaternion.identity);

            planet.transform.localScale = new Vector3(50,50,50);
            
            Destroy(planetPos.gameObject);
        }
    }
}
