using UnityEngine;
using System.Collections;

public class Toaster : MonoBehaviour
{
    public GameObject upSpot;
    public GameObject downSpot;
    public bool toasterOn;
    public bool toastDone;
    public GameObject target;
    public GameObject fitSpotOne;
    public GameObject fitSpot;
    // Use this for initialization
    void Start()
    {
        toasterOn = false;
        toastDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toasterOn == true)
        {
            float step = 2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, downSpot.transform.position, step);
        }
        if (toasterOn == false)
        {
            float step = 2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, upSpot.transform.position, step);
        }
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Toast") { target = col.gameObject; }
        if (col.gameObject.tag == "Player")
        {
            
            if (toasterOn == false)
            {
                toasterOn = true;
                StartCoroutine(toastBread(5.0f));
            }

            else
            {
                StopAllCoroutines();
                toasterOn = false;


            }
        }
        }
    IEnumerator toastBread(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        toastDone = true;
        toasterOn = false;
        yield return new WaitForSeconds(0.01f);
        if (target != null)
        { target.GetComponent<Rigidbody>().AddForce(Vector3.up * 2110);
            target.GetComponent<Rigidbody>().AddTorque(transform.up * 35);
        }
    }

}
