using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour 
{
    public float rotationSpeed;
	void FixedUpdate () 
    {
        GetComponent<Transform>().Rotate(0.0f, rotationSpeed, 0.0f);
	}
}
