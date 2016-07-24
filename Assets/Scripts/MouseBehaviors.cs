using UnityEngine;
using System.Collections;

public class MouseBehaviors : MonoBehaviour
{
    public GameObject Background;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
            /*
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Name = " + hit.collider.name);
                Debug.Log("Tag = " + hit.collider.tag);
                Debug.Log("Hit Point = " + hit.point);
                Debug.Log("Object position = " + hit.collider.gameObject.transform.position);
                Debug.Log("--------------");
            }
            */
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse clicked");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Background.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity);
        Debug.Log("(" + hit.point.x + ", " + hit.point.z + ")");
    }
}
