using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

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

        public GameObject satelite;
        public List<GameObject> activeDebree = new List<GameObject>();
        // public Transform debreeSpawn;
        public float lastSpawn = Time.fixedTime;
        public float speedRatio;
        public Transform spawnArea;
        public Vector3 spawnVector = new Vector3(800.0f, 5.0f, 800.0f);
        public Quaternion spawnQuaternation = new Quaternion();
        public float waitTime;

        void Update()
        {
            if (Input.GetButton("Fire1"))
            {

            }
        }

        void FixedUpdate()
        {
            if (Time.fixedTime - lastSpawn > waitTime)
            {
                SpawnNext();
            }
            MoveDebree();
        }

        private void SpawnNext()
        {
            //debree.Add((GameObject)Instantiate(satelite, spawnVector, spawnQuaternation));
            Debree newDebree = (GameObject)Instantiate(satelite, spawnVector, spawnQuaternation);
            activeDebree.Add(new Debree().GetGameObject());

            lastSpawn = Time.fixedTime;
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