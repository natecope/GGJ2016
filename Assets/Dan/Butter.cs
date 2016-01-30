using UnityEngine;
using System.Collections;

public class Butter : MonoBehaviour {
    public GameObject spreadButter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Waffle")
        {
            if (col.gameObject.GetComponent<Object>().isToast == true)
            {
                GameObject clone2 = Instantiate(spreadButter, transform.position, transform.rotation) as GameObject;
                    clone2.transform.parent = col.gameObject.transform;
                Destroy(this.gameObject);
            }
        }
        if (col.gameObject.name != "ButterKnife" && col.gameObject.name != "StickofButter")
        {
            GameObject clone2 = Instantiate(spreadButter, transform.position, transform.rotation) as GameObject;
            clone2.transform.parent = col.gameObject.transform;

            Destroy(this.gameObject);
        }
    }
    }
