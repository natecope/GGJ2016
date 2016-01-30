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


		void Update()
		{
			if (Actions == null)
			{
				// If no controller exists for this cube, just make it translucent.
				cachedRenderer.material.color = new Color( 1.0f, 1.0f, 1.0f, 0.2f );
			}
			else
			{

				// Moving up,down,left right on 2d plane
				shoulder.transform.Translate(Actions.Pan.Value * Time.deltaTime * panningSpeed, Space.World);

				// Moving forward and back in 3d space
				shoulder.transform.Translate(Vector3.back * Actions.InOut.Value * Time.deltaTime * panningSpeed, Space.World); 

				// Rotating left/right
				wrist.transform.Rotate(Vector3.back * Actions.Rotate.Value * Time.deltaTime * rotateSpeed, Space.World);
			}

			if(Actions.Grab.WasPressed){

				Debug.Log("Grab pressed!");
			}
		}


		/*Color GetColorFromInput()
		{
			if (Actions.Green)
			{
				return Color.green;
			}

			if (Actions.Red)
			{
				return Color.red;
			}

			if (Actions.Blue)
			{
				return Color.blue;
			}

			if (Actions.Yellow)
			{
				return Color.yellow;
			}

			return Color.white;
		}*/
	}
}

