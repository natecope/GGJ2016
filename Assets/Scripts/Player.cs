using System;
using UnityEngine;
using InControl;
using Assets.Topher;

public enum PlayerType {LeftArm, RightArm}

public class Player : MonoBehaviour
{
	public ArmActions Actions { get; set; }
	public PlayerType playerType;
	public float wristExtendSpeed;
	public float wristRotateSpeed;
	public float elbowExtendSpeed;
	public GameObject elbow;
	public GameObject shoulder;
	public GameObject wrist;
    public GameObject rudeFinger;
    public GameObject indexFinger;
    public GameObject pinkyFinger;
    public GameObject itemHeld;
	Renderer cachedRenderer;


	void OnDisable()
	{
		if (Actions != null)
		{
			Actions.Destroy();
		}
	}


	void Start()
	{
		cachedRenderer = GetComponent<Renderer>();
	}

    
    void FixedUpdate()
    {
        if (Actions == null)
        {
            // If no controller exists for this cube, just make it translucent.
            //cachedRenderer.material.color = new Color( 1.0f, 1.0f, 1.0f, 0.2f );
        }
        else
        {
			
			Rigidbody wristRigidbody = (Rigidbody)wrist.GetComponent("Rigidbody");
			Rigidbody elbowRigidbody = (Rigidbody)elbow.GetComponent("Rigidbody");
			
			if(playerType == PlayerType.LeftArm){
			
				wristRigidbody.AddRelativeTorque((Vector3.back * Actions.WristRotateAxis * wristRotateSpeed), ForceMode.VelocityChange);
				wristRigidbody.AddRelativeTorque((Vector3.right * Actions.WristExtendAxis * wristExtendSpeed), ForceMode.VelocityChange);

				elbowRigidbody.AddRelativeTorque((Vector3.down * Actions.ElbowExtendAxis * elbowExtendSpeed), ForceMode.VelocityChange);

			} else if (playerType == PlayerType.RightArm) {

				wristRigidbody.AddRelativeTorque((Vector3.forward * Actions.WristRotateAxis * wristRotateSpeed), ForceMode.VelocityChange);
				wristRigidbody.AddRelativeTorque((Vector3.right * Actions.WristExtendAxis * wristExtendSpeed), ForceMode.VelocityChange);

				elbowRigidbody.AddRelativeTorque((Vector3.down * Actions.ElbowExtendAxis * elbowExtendSpeed), ForceMode.VelocityChange);

			}

            if (Actions.Grab.IsPressed)
            {
                if (itemHeld != null)
                {
                    itemHeld.GetComponent<Rigidbody>().transform.SetParent(null);
                    itemHeld = null;
                }
            }

        }

    }
    void isGrabButtonPressed(messageData data)
    {
        if(Actions.Grab.IsPressed)
        {
            data.isButtonPressed = true;
            itemHeld = data.itemToBeHeld;
        }
    }
}


