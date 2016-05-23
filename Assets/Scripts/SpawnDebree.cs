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

        public GameObject Satelite;
        public List<GameObject> activeDebree = new List<GameObject>();
        // public Transform debreeSpawn;
        public DateTime lastSpawn;
        public float speedRatio;
        public Transform spawnArea;
        //public Vector3 spawnVector = new Vector3(800.0f, 5.0f, 800.0f);
        public Vector3 spawnVector;// = new Vector3(65f, 5f, 65f);
        public Quaternion spawnQuaternation = new Quaternion();
        public float waitTime;
        private Random rand = new Random();
        private static readonly int _screenRadius = 65;

        public static int ScreenRadius
        {
            get { return _screenRadius; }
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
            }
            MoveDebree();

            if (activeDebree.Count > 10)
            {
                GameObject.Destroy(activeDebree.ElementAt(0));
                activeDebree.RemoveAt(0);
            }
        }

        /*
        void FixedUpdate()
        {
            if ((DateTime.Now - lastSpawn).TotalSeconds > waitTime)
            {
                SpawnNext();
            }
            MoveDebree();

            if (activeDebree.Count > 10)
            {
                GameObject.Destroy(activeDebree.ElementAt(0));
                activeDebree.RemoveAt(0);
            }
        }
        */

        private void SpawnNext()
        {
            //debree.Add((GameObject)Instantiate(satelite, spawnVector, spawnQuaternation));
            //spawnVector = GenerateVector();
            GameObject newDebree = (GameObject) Instantiate(Satelite, GenerateVector(), spawnQuaternation);
            //activeDebree.Add(new Debree().GetGameObject());
            activeDebree.Add(newDebree);
        }

        private Vector3 GenerateVector()
        {
            float x = 0, y = spawnVector.y, z = 0;

            if (rand.Next(1, 3) == 1)
            {
                x = rand.Next(1, 3) == 1 ? ScreenRadius : -ScreenRadius;
                z = rand.Next(-ScreenRadius, ScreenRadius);
            }
            else
            {
                z = rand.Next(1, 3) == 1 ? ScreenRadius : -ScreenRadius;
                x = rand.Next(-ScreenRadius, ScreenRadius);
            }

            Debug.Log("x = " + x + ", y = " + y + ", z = " + z);
            return new Vector3(x, y, z);
        } 

        private void MoveDebree()
        {
            Rigidbody rigidbody = new Rigidbody();
            foreach (GameObject item in activeDebree)
            {
                item.transform.position = Vector3.MoveTowards(
                    item.transform.position, new Vector3(0, 5, 0), 1.0f * speedRatio);
            }
        }
    }
}