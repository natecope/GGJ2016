using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {
    public bool grabbed;
    private Vector3 screenPoint;
    private Vector3 offset;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // if (grabbed == true)
        //{ transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); }
	}
    public void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //grabbed = true; 
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);


        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        if (Input.GetKey(KeyCode.D))
        {
            screenPoint.z += 0.1f;
            //transform.Translate(Vector3.forward * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.A))
        { //transform.Translate(Vector3.forward * -Time.deltaTime);
            screenPoint.z -= 0.1f;
        }
    }
}
