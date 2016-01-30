using System;
using InControl;


namespace TerribleMorningPerson
{
	public class ArmActions : PlayerActionSet
	{
		public PlayerAction Grab;
		public PlayerAction WristRotateLeft;
		public PlayerAction WristRotateRight;
		public PlayerAction WristExtend;
		public PlayerAction WristRetract;
		public PlayerAction ElbowExtend;
		public PlayerAction ElbowRetract;
		public PlayerAction ShoulderLiftUp;
		public PlayerAction ShoulderDropDown;
		public PlayerOneAxisAction WristRotateAxis;
		public PlayerOneAxisAction WristExtendAxis;
		public PlayerOneAxisAction ElbowExtendAxis;
		public PlayerOneAxisAction ShoulderLiftAxis;



		public ArmActions()
		{
			Grab = CreatePlayerAction( "Grab" );
			WristRotateLeft = CreatePlayerAction( "WristRotateLeft" );
			WristRotateRight = CreatePlayerAction( "WristRotateRight" );
			WristExtend = CreatePlayerAction( "WristExtend" );
			WristRetract = CreatePlayerAction( "WristRetract" );
			ElbowExtend = CreatePlayerAction( "ElbowExtend" );
			ElbowRetract = CreatePlayerAction( "ElbowRetract" );
			ShoulderLiftUp = CreatePlayerAction ("ShoulderLiftUp");
			ShoulderDropDown = CreatePlayerAction ("ShoulderDropDown");
			WristRotateAxis = CreateOneAxisPlayerAction(WristRotateRight, WristRotateLeft);
			WristExtendAxis = CreateOneAxisPlayerAction(WristExtend, WristRetract);
			ElbowExtendAxis = CreateOneAxisPlayerAction(ElbowRetract,ElbowExtend);
			ShoulderLiftAxis = CreateOneAxisPlayerAction(ShoulderLiftUp, ShoulderDropDown);
		}


		public static ArmActions CreateWithKeyboardBindings()
		{
			var actions = new ArmActions();

			actions.Grab.AddDefaultBinding( Key.Space );
			actions.WristRotateLeft.AddDefaultBinding( Key.LeftArrow );
			actions.WristRotateRight.AddDefaultBinding( Key.RightArrow );
			actions.WristExtend.AddDefaultBinding( Key.UpArrow );
			actions.WristRetract.AddDefaultBinding( Key.DownArrow );
			actions.ElbowExtend.AddDefaultBinding( Key.W );
			actions.ElbowRetract.AddDefaultBinding( Key.S );
			actions.ShoulderLiftUp.AddDefaultBinding (Key.A);
			actions.ShoulderDropDown.AddDefaultBinding (Key.D);

			return actions;
		}


		public static ArmActions CreateWithJoystickBindings()
		{
			var actions = new ArmActions();

			actions.Grab.AddDefaultBinding ( InputControlType.Action1);

			actions.ElbowExtend.AddDefaultBinding( InputControlType.LeftStickUp );
			actions.ElbowRetract.AddDefaultBinding( InputControlType.LeftStickDown );

			actions.ShoulderLiftUp.AddDefaultBinding( InputControlType.LeftStickLeft );
			actions.ShoulderDropDown.AddDefaultBinding( InputControlType.LeftStickRight );
		
			actions.WristRotateLeft.AddDefaultBinding (InputControlType.RightStickLeft );
			actions.WristRotateRight.AddDefaultBinding (InputControlType.RightStickRight );
			actions.WristExtend.AddDefaultBinding (InputControlType.RightStickUp);
			actions.WristRetract.AddDefaultBinding (InputControlType.RightStickDown);
		

			return actions;
		}
	}
}

