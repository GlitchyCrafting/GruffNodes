using IM = Godot.InputMap;
using GI = Godot.Input;

namespace Gruff.Components._2D {
    [Godot.Tool]
    [Godot.GlobalClass, Godot.Icon("res://GruffNodes/Icons/UserInput.svg")]
    public partial class UserInput : Input
    {
        private string[] actions = {
            "Up",
            "Down",
            "Left",
            "Right",
            "ActionOne",
            "ActionTwo",
            "ActionThree",
            "ActionFour",
            "ActionFive",
        };

        public UserInput()
        {
            foreach (string action in actions)
            {
                if (!IM.GetActions().Contains(action))
                {
                    IM.AddAction(action);
                }
            }
        }

        ~UserInput()
        {
            foreach (string action in actions)
            {
                if (!IM.GetActions().Contains(action))
                    continue;
                if (IM.ActionGetEvents(action).Count > 0)
                    continue;
                IM.EraseAction(action);
            }
        }

        public override void _Process(double delta)
        {
            base._Process(delta);

            UpPressed = GI.IsActionPressed("Up");
            DownPressed = GI.IsActionPressed("Down");
            LeftPressed = GI.IsActionPressed("Left");
            RightPressed = GI.IsActionPressed("Right");
            ActionOnePressed = GI.IsActionPressed("ActionOne");
            ActionTwoPressed = GI.IsActionPressed("ActionTwo");
            ActionThreePressed = GI.IsActionPressed("ActionThree");
            ActionFourPressed = GI.IsActionPressed("ActionFour");
            ActionFivePressed = GI.IsActionPressed("ActionFive");
        }
    }
}
