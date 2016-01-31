using UnityEngine;
using System.Collections;

public class CoffeeMachine : MonoBehaviour {
    public bool makeCoffee;
    public bool canMakeCoffee;
    public GameObject coffee;
    public GameObject gun;
	// Use this for initialization
	void Start () {
        makeCoffee = false;
        canMakeCoffee = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter(Collision col)
    {
        print("hit");
        if (col.gameObject.tag != "Coffee")
        {
            if (canMakeCoffee == true)
            {
                if (makeCoffee == true)
                {

                    makeCoffee = false;
                }
                else
                {
                    GetComponent<Collider>().enabled = false;
                    makeCoffee = true;

                    StartCoroutine(TurnOn(0.05F));

                }
            }
        }
        
    }
        public void OnTriggerEnter(Collider col2)
    { if (col2.gameObject.name == "Kcup")
        {
            Destroy(col2.gameObject);
            canMakeCoffee = true;

        }
    }
        
        
    
    IEnumerator TurnOn(float waitTime)
    {
        if (makeCoffee == false)
        {
            StopCoroutine("TurnOn");
            yield break;
        }
        
            Instantiate(coffee, gun.transform.position, coffee.transform.rotation);
            yield return new WaitForSeconds(waitTime);
        GetComponent<Collider>().enabled = true;
        StartCoroutine(TurnOn(0.05F));
        
    }
}
