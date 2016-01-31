using System;
using InControl;



	public class HeadActions : PlayerActionSet
	{
		public PlayerAction Grab;
		public PlayerAction Left;
		public PlayerAction Right;
		public PlayerAction Up;
		public PlayerAction Down;
		public PlayerAction In;
		public PlayerAction Out;
		public PlayerAction SpinLeft;
		public PlayerAction SpinRight;
		public PlayerOneAxisAction Rotate;
		public PlayerTwoAxisAction Pan;
		public PlayerOneAxisAction InOut;


		public HeadActions()
		{
			Grab = CreatePlayerAction( "Grab" );
			Left = CreatePlayerAction( "Left" );
			Right = CreatePlayerAction( "Right" );
			Up = CreatePlayerAction( "Up" );
			Down = CreatePlayerAction( "Down" );
			In = CreatePlayerAction( "In" );
			Out = CreatePlayerAction( "Out" );
			SpinLeft = CreatePlayerAction ("SpinLeft");
			SpinRight = CreatePlayerAction ("SpinRight");
			InOut = CreateOneAxisPlayerAction(In, Out);
			Rotate = CreateOneAxisPlayerAction(SpinLeft, SpinRight);
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
			actions.In.AddDefaultBinding( Key.W );
			actions.Out.AddDefaultBinding( Key.S );
			actions.SpinLeft.AddDefaultBinding (Key.A);
			actions.SpinRight.AddDefaultBinding (Key.D);

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

			actions.In.AddDefaultBinding (InputControlType.RightStickUp);
			actions.Out.AddDefaultBinding (InputControlType.RightStickDown);

			actions.SpinLeft.AddDefaultBinding (InputControlType.RightStickLeft);
			actions.SpinRight.AddDefaultBinding (InputControlType.RightStickRight);

			return actions;
		}
	}


