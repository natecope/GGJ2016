using UnityEngine;
using System.Collections;

public class ButterKnife : MonoBehaviour {
    public bool buttered;
    public GameObject butterSpot;
    public GameObject patofButter;
    
	// Use this for initialization
	void Start () {
        //buttered = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "StickofButter")
        {
            //buttered = true;
           GameObject clone = Instantiate(patofButter, butterSpot.transform.position, butterSpot.transform.rotation) as GameObject;
            clone.transform.parent = transform;
        }
    }
}
