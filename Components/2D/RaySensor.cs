using Godot;

namespace Gruff.Components._2D {
    [Tool]
    [GlobalClass, Icon("res://Gruff/Icons/RaySensor.svg")]
    public partial class RaySensor : RayCast2D, EnvSensor
    {
        [Signal]
        public delegate void BodyDetectedEventHandler(Node2D body);

        public bool IsBodyDetected()
        {
            return IsColliding();
        }

        public override void _PhysicsProcess(double delta)
        {
            if (!IsColliding())
                return;
            EmitSignal(SignalName.BodyDetected, GetCollider());
        }
    }
}
