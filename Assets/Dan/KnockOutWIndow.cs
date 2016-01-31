using UnityEngine;
using System.Collections;

public class KnockOutWIndow : MonoBehaviour {
    public GameObject target;
    public GameObject outWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            float step = 14 * Time.deltaTime;
            target.transform.position = Vector3.MoveTowards(target.transform.position, outWindow.transform.position, step);
        }
	}
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "grab")
        {
           // float step = 40 * Time.deltaTime;
           // col.gameObject.GetComponent<Rigidbody>().AddForce((col.transform.position - outWindow.transform.position).normalized * step);

            target = col.gameObject;
            target.GetComponent<Collider>().enabled = false;
            target.GetComponent<Rigidbody>().useGravity = false;
            StartCoroutine(KillWaffle(2.0f));
        }
                }
    IEnumerator KillWaffle(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(target.gameObject);

    }
    public void OnTriggerEnter(Collider col2)
    {
        //col2.GetComponent<Rigidbody>().useGravity = true;
        
        //if (col2.gameObject == target)
        //{
        //    target.GetComponent<Rigidbody>().useGravity = true;
        //    target = null; }
    }
}
