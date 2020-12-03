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
            SpawnRandom();
            SpawnRandom();
        }

        private void SpawnRandom()
        {
            var position = gameObject.transform.position;
            Instantiate(objects[Random.Range(0, objects.Length - 1)], new Vector3(position.x, position.y, position.z),
                Quaternion.identity);
        }
    }
}