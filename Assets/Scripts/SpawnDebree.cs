using System;
using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Random = System.Random;

namespace DebreeManagement
{
    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }

    public class SpawnDebree : MonoBehaviour
    {
        public float speed;
        //public Boundary boundary;

        public GameObject CloneableDebreeGameObject;
        public List<Debree> activeDebree = new List<Debree>();
        public DateTime lastSpawn;
        public Transform spawnArea;
        public Vector3 spawnVector;
        public Quaternion spawnQuaternation = new Quaternion();
        private float waitTime;
        private Random rand = new Random();
        private static readonly int _spawnRadius = 65;

        public static int SpawnRadius
        {
            get { return _spawnRadius; }
        }

        void Start()
        {
            lastSpawn = DateTime.Now.AddSeconds(-waitTime);

            //Move to a more appropriate location
            new Tests().Run();
        } 

        void Update()
        {
            if ((DateTime.Now - lastSpawn).TotalSeconds > waitTime)
            {
                SpawnNext();
                lastSpawn = DateTime.Now;
                waitTime = Utilities.GenerateRandomGaussianNumber(5, .8f);
            }
            MoveDebree();

            if (activeDebree.Count > 10)
            {
                GameObject.Destroy(activeDebree.ElementAt(0).GameObject);
                activeDebree.RemoveAt(0);
            }
        }

        private void SpawnNext()
        {
            //debree.Add((GameObject)Instantiate(satelite, spawnVector, spawnQuaternation));
            //spawnVector = GenerateVector();
            var instantiatedDebree = new Debree
            {
                GameObject = (GameObject) Instantiate(CloneableDebreeGameObject, GenerateVector(), spawnQuaternation),
                SpeedModifier = Utilities.GenerateRandomGaussianNumber(0.25f, 0.11f)
            };
            //activeDebree.Add(new Debree().GetGameObject());
            activeDebree.Add(instantiatedDebree);
        }

        private Vector3 GenerateVector()
        {
            float x, y = spawnVector.y, z;

            if (rand.Next(1, 3) == 1)
            {
                x = rand.Next(1, 3) == 1 ? SpawnRadius : -SpawnRadius;
                z = rand.Next(-SpawnRadius, SpawnRadius);
            }
            else
            {
                z = rand.Next(1, 3) == 1 ? SpawnRadius : -SpawnRadius;
                x = rand.Next(-SpawnRadius, SpawnRadius);
            }

            //Debug.Log("x = " + x + ", y = " + y + ", z = " + z);
            return new Vector3(x, y, z);
        } 

        private void MoveDebree()
        {
            Rigidbody rigidbody = new Rigidbody();
            foreach (Debree item in activeDebree)
            {
                item.GameObject.transform.position = Vector3.MoveTowards(
                    item.GameObject.transform.position, new Vector3(0, 5, 0), 1.0f * item.SpeedModifier);
            }
        }
    }
}