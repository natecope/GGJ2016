using System;
using UnityEngine;
using InControl;


namespace TerribleMorningPerson
{

	public class Player : MonoBehaviour
	{
		public PlayerActions Actions { get; set; }
		public float panningSpeed;
		public float rotateSpeed;
		public GameObject elbow;
		public GameObject shoulder;
		public GameObject wrist;
        public GameObject rudeFinger;
        public GameObject indexFinger;
        public GameObject pinkyFinger;
       
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
                // Moving up,down,left right on 2d plane
                //              shoulder.transform.Translate(Actions.Pan.Value * Time.deltaTime * panningSpeed, Space.World);
                // Moving forward and back in 3d space
                //                shoulder.transform.Translate(Vector3.back * Actions.InOut.Value * Time.deltaTime * panningSpeed, Space.World);
                elbowRigidbody.AddForce(Actions.Pan.Value * 0.0005f, ForceMode.VelocityChange);

                wristRigidbody.AddForce(Vector3.back * Actions.InOut.Value * panningSpeed, ForceMode.VelocityChange);
                wristRigidbody.AddTorque((Vector3.back * Actions.Rotate.Value * rotateSpeed * .002f), ForceMode.VelocityChange);
                // Rotating left/right
                //wrist.transform.Rotate(Vector3.back * Actions.Rotate.Value * Time.deltaTime * rotateSpeed, Space.World);
            }

            if (Actions.Grab.WasPressed)
            {

                Debug.Log("Grab pressed!");
            }
        }
    }
}

