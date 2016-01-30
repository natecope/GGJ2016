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
        if (col.gameObject.name != "ButterKnife" && col.gameObject.name != "StickofButter")
        { Instantiate(spreadButter, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }
    }
