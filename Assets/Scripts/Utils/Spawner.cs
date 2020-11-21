using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utils
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] objects;

        private void Start()
        {
            SpawnRandom();
        }

        private void SpawnRandom()
        {
            Instantiate(objects[Random.Range(0, objects.Length - 1)]);
        }
    }
}