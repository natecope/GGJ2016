using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currentPoint;
    public bool clockOn;
    // Use this for initialization
    void Start () {
        //AudioSource audio = GetComponent<AudioSource>();
        clockOn = true;
        transform.position = patrolPoints[0].position;
    }
	
	// Update is called once per frame
	void Update () {
        if (clockOn == true)
        {
            if (transform.position == patrolPoints[currentPoint].position)
            {
                currentPoint++;
            }
            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
        }
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Stop();
            clockOn = false;
            StartCoroutine(StartTheGame(2.0f));
            
        }
    }
    

    IEnumerator StartTheGame(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel("DanArms");
    }
}
