using Godot;

namespace Gruff.Components._2D {
    [Tool]
    [GlobalClass, Icon("res://GruffNodes/Icons/Hitbox.svg")]
    public partial class Hitbox : Area2D
    {
        [Export]
        public Shape2D ColliderShape
        {
            get => collider.Shape;
            set => collider.Shape = value;
        }

        private CollisionShape2D collider = new CollisionShape2D();

        public Hitbox() : this(new RectangleShape2D()) {}

        public Hitbox(Shape2D shape)
        {
            ColliderShape = shape;
            AddChild(collider);
        }
    }
}
