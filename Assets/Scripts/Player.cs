using System;
using UnityEngine;
using InControl;
using Assets.Topher;
using System.Collections;


public enum PlayerType {LeftArm, RightArm, Head}

public class Player : MonoBehaviour
{
	public ArmActions Actions { get; set; }
	public HeadActions HeadActions { get; set; }
	public PlayerType playerType;
	public float wristExtendSpeed;
	public float wristRotateSpeed;
	public float elbowExtendSpeed;
	public float headMovementSpeed;
	public float headLeanSpeed;
	public GameObject elbow;
	public GameObject shoulder;
	public GameObject wrist;
    public GameObject rudeFinger;
    public GameObject indexFinger;
    public GameObject pinkyFinger;
    public GameObject itemHeld;
	Renderer cachedRenderer;
    //making moveable shoulder
    public GameObject shoulderObj;
    public GameObject mount;
	public GameObject mainCam;
    public bool pickupTimeoutEnabled;



	void OnDisable()
	{
		if (Actions != null)
		{
			Actions.Destroy();
		}
	}



	void Start()
	{
		
        if (playerType == PlayerType.LeftArm)
        {
            mount = GameObject.Find("LeftHand Mount");
            //shoulderObj.GetComponent<HingeJoint>().connectedBody = mount.GetComponent<Rigidbody>();
        }
		if (playerType == PlayerType.RightArm){
			mount = GameObject.Find("RightHand Mount");
			//shoulderObj.GetComponent<HingeJoint>().connectedBody = mount.GetComponent<Rigidbody>();

		}
    }

    
    void FixedUpdate()
    {

		if (Actions.Grab.IsPressed && pickupTimeoutEnabled==false) 
		{
			if (itemHeld != null)
			{

				itemHeld.transform.SetParent(null);
				itemHeld = null;
				pickupTimeoutEnabled = true;
				StartCoroutine(PickupTimer(0.5f));

			}
		}


		if(Actions!=null)
		{

			Rigidbody wristRigidbody = (Rigidbody)wrist.GetComponent("Rigidbody");
			Rigidbody elbowRigidbody = (Rigidbody)elbow.GetComponent("Rigidbody");
			
			if(playerType == PlayerType.LeftArm){
			
				wristRigidbody.AddRelativeTorque((Vector3.back * Actions.WristRotateAxis * wristRotateSpeed), ForceMode.VelocityChange);
				wristRigidbody.AddRelativeTorque((Vector3.right * Actions.WristExtendAxis * wristExtendSpeed), ForceMode.VelocityChange);

				elbowRigidbody.AddRelativeTorque((Vector3.down * Actions.ElbowExtendAxis * elbowExtendSpeed), ForceMode.VelocityChange);

			} else if (playerType == PlayerType.RightArm) {
				

                wristRigidbody.AddRelativeTorque((Vector3.back * Actions.WristRotateAxis * wristRotateSpeed), ForceMode.VelocityChange);
                wristRigidbody.AddRelativeTorque((Vector3.right * Actions.WristExtendAxis * wristExtendSpeed), ForceMode.VelocityChange);
                elbowRigidbody.AddRelativeTorque((Vector3.down * Actions.ElbowExtendAxis * elbowExtendSpeed), ForceMode.VelocityChange);
            }

            if (Actions.Grab.IsPressed && pickupTimeoutEnabled == false)
            {
                if (itemHeld != null)
                {
                    Rigidbody[] itemRigidbody = itemHeld.GetComponents<Rigidbody>();
                    itemHeld.transform.SetParent(null);

                    if (itemRigidbody.Length > 0)
                    {
                        itemRigidbody[0].useGravity = true;
                        itemRigidbody[0].isKinematic = false;
                    }
                    itemHeld = null;
                    pickupTimeoutEnabled = true;
                    StartCoroutine(PickupTimer(0.5f));

                }
            }
		}

		

		if(HeadActions != null){
			if(playerType == PlayerType.Head){

				if(HeadActions.Grab.IsPressed){

					Debug.Log("Head action button pressed!");

				}

				// Moving along floor
				transform.Translate(Vector3.forward * HeadActions.Pan.Y * headMovementSpeed * Time.deltaTime, Space.Self);
				transform.Translate(Vector3.right * HeadActions.Pan.X * headMovementSpeed * Time.deltaTime, Space.Self);

				// Rotate head 360
				transform.Rotate(Vector3.left * HeadActions.Rotate.Y * headLeanSpeed * Time.deltaTime, Space.Self);
				transform.Rotate(Vector3.forward * HeadActions.Rotate.X * headLeanSpeed * Time.deltaTime, Space.Self);

				// Raise/lower body
				transform.Translate(Vector3.up * HeadActions.Height.Value * headMovementSpeed * Time.deltaTime, Space.Self);

			}

		}
	}



    void isGrabButtonPressed(messageData data)
    {
		if(Actions!=null)
		{
	        if (Actions.Grab.IsPressed && pickupTimeoutEnabled == false && itemHeld == null)
	        {
	            data.isButtonPressed = true;
	            itemHeld = data.itemToBeHeld;
	            pickupTimeoutEnabled = true;
	            StartCoroutine(PickupTimer(0.5f));
	        }
		}
    }

    IEnumerator PickupTimer(float time)
    {
        yield return new WaitForSeconds(time);
        pickupTimeoutEnabled =false;
    }
    
}


