using Godot;

namespace Gruff.Components._2D {
    [Tool]
    [GlobalClass, Icon("res://GruffNodes/Icons/Attack.svg")]
    public partial class Attack : Area2D
    {
        [Export]
        public Shape2D ColliderShape
        {
            get => collider.Shape;
            set => collider.Shape = value;
        }

        [Export]
        public float Value;

        private CollisionShape2D collider = new CollisionShape2D();

        public Attack() : this(10, new RectangleShape2D()) {}

        public Attack(float value, Shape2D shape)
        {
            Value = value;
            ColliderShape = shape;
            AddChild(collider);
        }
    }
}
