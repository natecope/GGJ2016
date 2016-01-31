using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            Application.LoadLevel("Dan"); }
    }
    public void OnMouseDown()
    { Application.LoadLevel("Dan"); }
}
