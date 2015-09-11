using UnityEngine;
using System.Collections;

namespace DebreeManagement
{
    public class Debree : MonoBehaviour
    {
        public Rigidbody rigidbody;
        public const float screenEdgeRadius = 92;
        public MeshFilter image;

        void Start()
        {
            this = Instantiate()
            GetComponent<Rigidbody>().position = new Vector3(Random.Range(60.0f, 300.0f), 5.0f, Random.Range(0.0f, 300.0f));
            Vector2 coords2d = GenerateCoords(Random.Range(0.0f, 360.0f));
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SetVelocity()
        {
        }

        private Vector3 GenerateCoords(float angleDegrees)
        {
            // initialize calculation variables
            float _x = 0;
            float _y = 0;
            float angleRadians = 0;
            Vector2 _returnVector;
            // convert degrees to radians
            angleRadians = angleDegrees * Mathf.PI / 180.0f;
            // get the 2D dimensional coordinates
            _x = screenEdgeRadius + GetComponent<Collider>().bounds.size.magnitude * Mathf.Cos(angleRadians);
            _y = screenEdgeRadius + GetComponent<Collider>().bounds.size.magnitude * Mathf.Sin(angleRadians);
            // derive the 2D vector
            _returnVector = new Vector2(_x, _y);
            // return the vector info
            return _returnVector;
        }

        public GameObject GetGameObject()
        {
            return this.GetGameObject();
        }
    }
}
