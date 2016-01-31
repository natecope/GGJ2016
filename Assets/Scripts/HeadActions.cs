using System;
using InControl;



public class HeadActions : PlayerActionSet
{
	public PlayerAction Grab;
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;
	public PlayerAction SpinLeft;
	public PlayerAction SpinRight;
	public PlayerAction SpinForward;
	public PlayerAction SpinBackward;
	public PlayerAction Raise;
	public PlayerAction Lower;
	public PlayerOneAxisAction Height;
	public PlayerTwoAxisAction Rotate;
	public PlayerTwoAxisAction Pan;
	public PlayerOneAxisAction InOut;


	public HeadActions()
	{
		Grab = CreatePlayerAction( "Grab" );
		Left = CreatePlayerAction( "Left" );
		Right = CreatePlayerAction( "Right" );
		Up = CreatePlayerAction( "Up" );
		Down = CreatePlayerAction( "Down" );;
		SpinLeft = CreatePlayerAction ("SpinLeft");
		SpinRight = CreatePlayerAction ("SpinRight");
		SpinForward = CreatePlayerAction ("SpinForward");
		SpinBackward = CreatePlayerAction ("SpinBackward");
		Raise = CreatePlayerAction("Raise");
		Lower = CreatePlayerAction("Lower");
		Height = CreateOneAxisPlayerAction(Lower, Raise);
		Rotate = CreateTwoAxisPlayerAction(SpinRight, SpinLeft, SpinForward, SpinBackward);
		Pan = CreateTwoAxisPlayerAction(Left,Right,Down,Up);
	}


	public static HeadActions CreateWithKeyboardBindings()
	{
		var actions = new HeadActions();

		actions.Grab.AddDefaultBinding( Key.Space );
		actions.Up.AddDefaultBinding( Key.UpArrow );
		actions.Down.AddDefaultBinding( Key.DownArrow );
		actions.Left.AddDefaultBinding( Key.LeftArrow );
		actions.Right.AddDefaultBinding( Key.RightArrow );
		actions.SpinForward.AddDefaultBinding( Key.W );
		actions.SpinBackward.AddDefaultBinding( Key.S );
		actions.SpinLeft.AddDefaultBinding (Key.A);
		actions.SpinRight.AddDefaultBinding (Key.D);
		actions.Raise.AddDefaultBinding (Key.R);
		actions.Lower.AddDefaultBinding (Key.F);

		return actions;
	}


	public static HeadActions CreateWithJoystickBindings()
	{
		var actions = new HeadActions();

		actions.Grab.AddDefaultBinding ( InputControlType.Action1);

		actions.Up.AddDefaultBinding( InputControlType.LeftStickUp );
		actions.Down.AddDefaultBinding( InputControlType.LeftStickDown );
		actions.Left.AddDefaultBinding( InputControlType.LeftStickLeft );
		actions.Right.AddDefaultBinding( InputControlType.LeftStickRight );

		actions.Up.AddDefaultBinding( InputControlType.DPadUp );
		actions.Down.AddDefaultBinding( InputControlType.DPadDown );
		actions.Left.AddDefaultBinding( InputControlType.DPadLeft );
		actions.Right.AddDefaultBinding( InputControlType.DPadRight );

		actions.SpinForward.AddDefaultBinding (InputControlType.RightStickUp);
		actions.SpinBackward.AddDefaultBinding (InputControlType.RightStickDown);

		actions.SpinLeft.AddDefaultBinding (InputControlType.RightStickLeft);
		actions.SpinRight.AddDefaultBinding (InputControlType.RightStickRight);

		actions.Raise.AddDefaultBinding(InputControlType.RightTrigger);
		actions.Lower.AddDefaultBinding(InputControlType.LeftTrigger);






		return actions;
	}
}


