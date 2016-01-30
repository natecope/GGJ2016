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
        if (col.gameObject.name != "Kcup")
        {
            if (canMakeCoffee == true)
            {
                if (makeCoffee == true)
                {

                    makeCoffee = false;
                }
                else
                {
                    makeCoffee = true;
                    StartCoroutine(TurnOn(0.05F));

                }
            }
        }
        if (col.gameObject.name == "Kcup")
        { canMakeCoffee = true;
            Destroy(col.gameObject);
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

            StartCoroutine(TurnOn(0.05F));
        
    }
}
