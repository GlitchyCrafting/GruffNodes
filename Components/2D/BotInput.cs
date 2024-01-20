using GI = Godot.Input;
using Export = Godot.ExportAttribute;
using Vec2 = Godot.Vector2;

namespace Gruff.Components._2D {
    [Godot.Tool]
    [Godot.GlobalClass, Godot.Icon("res://GruffNodes/Icons/BotInput.svg")]
    public partial class BotInput : Input
    {
        [Export] public Vec2 target = Vec2.Zero;

        [Export] public bool isActive = false;
        [Export] public AreaSensor activationDetectionSensor;

        [Export] public float upSensorLength
        {
            set => upSensor.TargetPosition = new Vec2(0, -value);
            get => -upSensor.TargetPosition.Y;
        }
        [Export] public float downSensorLength
        {
            set => downSensor.TargetPosition = new Vec2(0, value);
            get => downSensor.TargetPosition.Y;
        }
        [Export] public float leftSensorLength
        {
            set => leftSensor.TargetPosition = new Vec2(-value, 0);
            get => -leftSensor.TargetPosition.X;
        }
        [Export] public float rightSensorLength
        {
            set => rightSensor.TargetPosition = new Vec2(value, 0);
            get => rightSensor.TargetPosition.X;
        }

        public RaySensor upSensor = new RaySensor();
        public RaySensor downSensor = new RaySensor();
        public RaySensor leftSensor = new RaySensor();
        public RaySensor rightSensor = new RaySensor();

        public BotInput()
        {
            AddChild(upSensor);
            AddChild(downSensor);
            AddChild(leftSensor);
            AddChild(rightSensor);

            upSensorLength = 50;
            downSensorLength = 50;
            leftSensorLength = 50;
            rightSensorLength = 50;
        }

        public override void _Ready()
        {
            base._Ready();

            if (activationDetectionSensor != null)
                activationDetectionSensor.BodyDetected += (Godot.Node2D body) => {
                    if (body.Name.ToString().Contains("Player"))
                        isActive = true;
                };

            RightPressed = true;
            UpPressed = true;
        }

        public override void _Process(double delta)
        {
            base._Process(delta);

            if (Godot.Engine.IsEditorHint())
                return;

            if (!isActive)
                return;

            if (leftSensor.IsBodyDetected())
            {
                Godot.Node2D col = (Godot.Node2D)leftSensor.GetCollider();
                if (col.Name == "Player")
                    return;
                RightPressed = true;
                LeftPressed = false;
            }
            if (rightSensor.IsBodyDetected())
            {
                Godot.Node2D col = (Godot.Node2D)rightSensor.GetCollider();
                if (col.Name == "Player")
                    return;
                LeftPressed = true;
                RightPressed = false;
            }

            if (upSensor.IsBodyDetected())
            {
                Godot.Node2D col = (Godot.Node2D)upSensor.GetCollider();
                if (col.Name == "Player")
                    return;
                DownPressed = true;
                UpPressed = false;
            }
            if (downSensor.IsBodyDetected())
            {
                Godot.Node2D col = (Godot.Node2D)downSensor.GetCollider();
                if (col.Name == "Player")
                    return;
                UpPressed = true;
                DownPressed = false;
            }
        }
    }
}
