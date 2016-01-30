using UnityEngine;
using System.Collections;

public class Toaster : MonoBehaviour
{
    public GameObject upSpot;
    public GameObject downSpot;
    public bool toasterOn;

    // Use this for initialization
    void Start()
    {
        toasterOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toasterOn == true)
        {
            float step = 4 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, downSpot.transform.position, step);
        }
        if (toasterOn == false)
        {
            float step = 4 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, upSpot.transform.position, step);
        }
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (toasterOn == false)
            {
                toasterOn = true;
            }

            else
            {
                toasterOn = false;


            }
        }
        }


}
