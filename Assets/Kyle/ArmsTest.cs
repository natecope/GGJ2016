using UnityEngine;
using System.Collections;

public class ArmsTest : MonoBehaviour {

	const float ADJUST_FACTOR = 0.1f;

	public Rigidbody wristRigidbody;
	public Transform armTarget;

	void Start () {
	
	}
	
	void Update () {
		Vector3 difference = armTarget.position - transform.position;
		wristRigidbody.AddForce(difference * ADJUST_FACTOR, ForceMode.VelocityChange);
	}
}
