using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {
    public bool grabbed;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody rb;
    public int speed;
    public bool noGravity;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 6;
	}
	
	// Update is called once per frame
	void Update () {
        if (noGravity == true)
        { rb.useGravity = false; }
       // if (grabbed == true)
        //{ transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); }
	}
    public void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //grabbed = true; 
    }
    void OnMouseDrag()
    {
        rb.useGravity = false;
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);


        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
       // transform.position = curPosition;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, curPosition, step);
        if (Input.GetKey(KeyCode.D))
        {
            screenPoint.z += 0.1f;
            //transform.Translate(Vector3.forward * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.A))
        { //transform.Translate(Vector3.forward * -Time.deltaTime);
            screenPoint.z -= 0.1f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(Vector3.forward * speed*Time.deltaTime);
        }
    }
    void OnMouseUp()
    {
        rb.useGravity = true;
    }
    }
