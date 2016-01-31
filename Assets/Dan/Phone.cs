using UnityEngine;
using System.Collections;

public class Phone : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
        StartCoroutine(toastBread(2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
        transform.localScale += new Vector3(1.1F, 1.1F, 1.1F);

        //transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
    }

    IEnumerator toastBread(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
