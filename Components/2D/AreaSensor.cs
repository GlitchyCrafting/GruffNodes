using Godot;

namespace Gruff.Components._2D {
    [Tool]
    [GlobalClass, Icon("res://GruffNodes/Icons/AreaSensor.svg")]
    public partial class AreaSensor : Area2D, EnvSensor
    {
        [Signal]
        public delegate void BodyDetectedEventHandler(Node2D body);

        private CollisionShape2D collider = new CollisionShape2D();
        [Export]
        public Shape2D ColliderShape
        {
            get => collider.Shape;
            set => collider.Shape = value;
        }

        public AreaSensor() : this(new RectangleShape2D()) {}

        public AreaSensor(Shape2D shape)
        {
            ColliderShape = shape;
            AddChild(collider);
        }

        public bool IsBodyDetected()
        {
            return HasOverlappingBodies();
        }

        public override void _Ready()
        {
            BodyEntered += (Node2D body) => {
                EmitSignal(SignalName.BodyDetected, body);
            };
        }
    }
}
