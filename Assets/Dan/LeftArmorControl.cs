using UnityEngine;
using System.Collections;

public class LeftArmorControl : MonoBehaviour {
    public GameObject downObj;
    public GameObject upObj;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Y))
         //   if (Input.GetButton("joystick 1 analog 2"))
        {
            float step = 30 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, downObj.transform.position, step);

        }
       if( Input.GetKey(KeyCode.T))
       // if (Input.GetButton("joystick 1 analog 3"))
        {
            float step = 30 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, upObj.transform.position, step);

        }
    }
}
