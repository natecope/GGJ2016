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
    private int rndNumber;
    public GameObject explosion;
    public GameObject gun;
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
        if (col.gameObject.tag == "grab") { target = col.gameObject; }
        if (col.gameObject.tag == "Player")
        {
            
            if (toasterOn == false)
            {
                toasterOn = true;
                GetComponent<Collider>().enabled = false;
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
        yield return new WaitForSeconds(0.5f);
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(waitTime);
        toastDone = true;
        toasterOn = false;
        yield return new WaitForSeconds(0.01f);
        rndNumber = Random.Range(0, 10);
        if (target != null)
        {
            if (target.gameObject.name == "Phone")
            {
                Instantiate(explosion, gun.transform.position, explosion.transform.rotation);
                Destroy(target.gameObject);
                target = null;
                yield break;
            }
            target.GetComponent<Rigidbody>().AddForce(Vector3.up * 3710);
            target.GetComponent<Rigidbody>().AddTorque(transform.up * (52 ));
            target.GetComponent<Rigidbody>().AddTorque(transform.right * (12));
            target.GetComponent<Object>().isToast = true;
            target = null;
        }
    }

}
