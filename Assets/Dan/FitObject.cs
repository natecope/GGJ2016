using UnityEngine;
using System.Collections;

public class FitObject : MonoBehaviour {
    public GameObject fitSpot;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Toast")
        {
            col.gameObject.GetComponent<Object>().inToaster = true;
           // col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
               col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            col.gameObject.GetComponent<Rigidbody>().useGravity = true;
            col.transform.localEulerAngles = new Vector3(0, 270.0f, 90.0f);
            col.gameObject.transform.position = fitSpot.transform.position;
            //col.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }
    }
}
