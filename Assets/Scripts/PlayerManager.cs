using System;
using UnityEngine;
using System.Collections.Generic;
using InControl;



// This example iterates on the basic multiplayer example by using action sets with
// bindings to support both joystick and keyboard players. It would be a good idea
// to understand the basic multiplayer example first before looking a this one.
//
public class PlayerManager : MonoBehaviour
{
	public GameObject[] playerPrefabs;
	public GameObject mainCam;
	public Transform[] cameraMounts;


	const int maxPlayers = 4;

	List<Vector3> playerPositions = new List<Vector3>() {
		Vector3.zero,
		Vector3.zero,
		Vector3.zero,
		Vector3.zero,
	};

	List<Player> players = new List<Player>( maxPlayers );

	ArmActions keyboardListener;
	ArmActions joystickListener;
	HeadActions headKeyboardListener;
	HeadActions headJoystickListener;


	void OnEnable()
	{
		InputManager.OnDeviceDetached += OnDeviceDetached;
		keyboardListener = ArmActions.CreateWithKeyboardBindings();
		joystickListener = ArmActions.CreateWithJoystickBindings();
		headKeyboardListener = HeadActions.CreateWithKeyboardBindings();
		headJoystickListener = HeadActions.CreateWithJoystickBindings();
	}


	void OnDisable()
	{
		InputManager.OnDeviceDetached -= OnDeviceDetached;
		joystickListener.Destroy();
		keyboardListener.Destroy();
		headJoystickListener.Destroy();
		headKeyboardListener.Destroy();
	}


	void Update()
	{
		if (JoinButtonWasPressedOnListener( joystickListener ))
		{
			var inputDevice = InputManager.ActiveDevice;

			if (ThereIsNoPlayerUsingJoystick( inputDevice ) && ThereIsNoHeadPlayerUsingJoystick( inputDevice))
			{
				CreatePlayer( inputDevice );
			}
		}

		if (JoinButtonWasPressedOnListener( keyboardListener ))
		{
			if (ThereIsNoPlayerUsingKeyboard() && ThereIsNoHeadPlayerUsingKeyboard())
			{
				CreatePlayer( null );
			}
		}

		if (HeadJoinButtonWasPressedOnListener( headJoystickListener ))
		{
			var inputDevice = InputManager.ActiveDevice;

			if (ThereIsNoHeadPlayerUsingJoystick( inputDevice ) && ThereIsNoPlayerUsingJoystick( inputDevice))
			{
				CreatePlayer( inputDevice );
			}
		}

		if (HeadJoinButtonWasPressedOnListener( headKeyboardListener ))
		{
			if (ThereIsNoPlayerUsingKeyboard() && ThereIsNoHeadPlayerUsingKeyboard())
			{
				CreatePlayer( null );
			}
		}
	}


	bool JoinButtonWasPressedOnListener( ArmActions actions )
	{
		return actions.Grab.WasPressed;
	}

	bool HeadJoinButtonWasPressedOnListener (HeadActions actions)
	{
		return actions.Grab.WasPressed;
	}


	Player HeadFindPlayerUsingJoystick( InputDevice inputDevice )
	{
		var playerCount = players.Count;
		for (int i = 0; i < playerCount; i++)
		{
			var player = players[i];
			if (player.HeadActions != null)
			{
				if(player.HeadActions.Device == inputDevice)
					{
						return player;
					}
			}
		}

		return null;
	}

	Player FindPlayerUsingJoystick( InputDevice inputDevice )
	{
		var playerCount = players.Count;
		for (int i = 0; i < playerCount; i++)
		{
			var player = players[i];
			if(player.Actions != null)
			{
				
				if (player.Actions.Device == inputDevice)
				{
					return player;
				}

			}
		}

		return null;
	}

	bool ThereIsNoPlayerUsingJoystick( InputDevice inputDevice )
	{
		return FindPlayerUsingJoystick( inputDevice ) == null;
	}

	bool ThereIsNoHeadPlayerUsingJoystick( InputDevice inputDevice){

		return HeadFindPlayerUsingJoystick( inputDevice ) == null;
	}

	Player HeadFindPlayerUsingKeyboard()
	{
		var playerCount = players.Count;
		for (int i = 0; i < playerCount; i++)
		{
			var player = players[i];
			if (player.HeadActions == headKeyboardListener || player.Actions == keyboardListener)
			{
				return player;
			}
		}

		return null;
	}

	Player FindPlayerUsingKeyboard()
	{
		var playerCount = players.Count;
		for (int i = 0; i < playerCount; i++)
		{
			var player = players[i];
			if (player.HeadActions == headKeyboardListener || player.Actions == keyboardListener)
			{
				return player;
			}
		}

		return null;
	}
	bool ThereIsNoPlayerUsingKeyboard()
	{

		return FindPlayerUsingKeyboard() == null;

	}

	bool ThereIsNoHeadPlayerUsingKeyboard()
	{
		
		return HeadFindPlayerUsingKeyboard() == null;

	}


	void OnDeviceDetached( InputDevice inputDevice )
	{
		var player = FindPlayerUsingJoystick( inputDevice );
	
		if (player != null)
		{
			RemovePlayer( player );
		}

		var headPlayer = HeadFindPlayerUsingJoystick( inputDevice );

		if (headPlayer != null)
		{
			RemovePlayer ( player);
		}
	}


	Player CreatePlayer( InputDevice inputDevice )
	{
		Player player;
		if (players.Count < maxPlayers)
		{
			// Pop a position off the list. We'll add it back if the player is removed.

			// First player is the walker
			if(players.Count == 0){

				var gameObject = (GameObject)Instantiate(playerPrefabs[players.Count], mainCam.transform.position, mainCam.transform.rotation);
				mainCam.transform.parent = gameObject.transform;

				player = gameObject.GetComponentInChildren<Player>();

				if (inputDevice == null)
				{
					// We could create a new instance, but might as well reuse the one we have
					// and it lets us easily find the keyboard player.
					player.HeadActions = headKeyboardListener;
				}
				else
				{
					// Create a new instance and specifically set it to listen to the
					// given input device (joystick).
					var actions = HeadActions.CreateWithJoystickBindings();
					actions.Device = inputDevice;

					player.HeadActions = actions;
				}

			} else {
				var gameObject = (GameObject) Instantiate( playerPrefabs[players.Count], cameraMounts[players.Count].position, cameraMounts[players.Count].rotation );
				gameObject.transform.parent = cameraMounts[players.Count];

				player = gameObject.GetComponentInChildren<Player>();

				if (inputDevice == null)
				{
					// We could create a new instance, but might as well reuse the one we have
					// and it lets us easily find the keyboard player.
					player.Actions = keyboardListener;
				}
				else
				{
					// Create a new instance and specifically set it to listen to the
					// given input device (joystick).
					var actions = ArmActions.CreateWithJoystickBindings();
					actions.Device = inputDevice;

					player.Actions = actions;
				}
			}

			players.Add( player );

			return player;
		}

		return null;
	}


	void RemovePlayer( Player player )
	{
		playerPositions.Insert( 0, player.transform.position );
		players.Remove( player );
		player.Actions = null;
		player.HeadActions = null;
		Destroy( player.gameObject );
	}


	void OnGUI()
	{
		const float h = 22.0f;
		var y = 10.0f;

		GUI.Label( new Rect( 10, y, 300, y + h ), "Active players: " + players.Count + "/" + maxPlayers );
		y += h;

		if (players.Count < maxPlayers)
		{
			GUI.Label( new Rect( 10, y, 300, y + h ), "Press a button or a/s/d/f key to join!" );
			y += h;
		}
	}

	void MountCamera(GameObject objectToMount){


	}
}
