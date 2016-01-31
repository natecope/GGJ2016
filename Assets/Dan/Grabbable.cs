using UnityEngine;
using System.Collections;

public class Grabbable : MonoBehaviour
{
    private Rigidbody rb;
    public bool grabbed;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           // col.GetComponent<WristAction>().heldObj = this.gameObject;
            //rb.GetComponent<Rigidbody>().isKinematic = true;
            //transform.parent = col.gameObject.transform;
        }

    }
    public void OnTriggerEnter(Collider col2)
    {
          //rb.GetComponent<Rigidbody>().isKinematic = false;
       // transform.parent = null;
        

    }

}
