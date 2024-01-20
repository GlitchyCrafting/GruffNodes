using Export = Godot.ExportAttribute;
using ExportGroup = Godot.ExportGroupAttribute;

namespace Gruff.Components._2D {
    [Godot.GlobalClass, Godot.Icon("res://GruffNodes/Icons/Character.svg")]
    public partial class Character : Godot.CharacterBody2D
    {
        [Export] public CharacterType characterType;
        [Export] public Direction direction;

        [ExportGroup("Modifiers")]
        [Export] public float speed;
        [Export] public float jumpForce;
        [Export] public float stopSpeed;

        [ExportGroup("Components")]
        [Export] public Health health;
        [Export] public Input input;
        [Export] public Hitbox hitbox;
        [Export] public Attack attack;

        private float gravity = Godot.ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

        private bool onGround;

        private bool isJumping;
        private bool isFalling;
        private bool isWalking;

        private bool canUseSpecial = true;

        public override void _PhysicsProcess(double delta)
        {
            Godot.Vector2 velocity = Velocity;
            onGround = IsOnFloor();

            if (!onGround)
                velocity.Y += gravity * (float)delta;
            isFalling = (velocity.Y > 0);

            if (input.UpPressed && !isJumping && onGround)
                velocity.Y = -jumpForce;
            isJumping = (velocity.Y < 0);

            if (input.LeftPressed && !input.RightPressed)
                velocity.X = -speed;
            if (input.RightPressed && !input.LeftPressed)
                velocity.X = speed;
            isWalking = (input.LeftPressed ^ input.RightPressed);

            if (!isWalking)
                velocity.X = Godot.Mathf.MoveToward(velocity.X, 0, stopSpeed);

            if (input.ActionOnePressed)
                Godot.GD.Print(attack.Value);

            if (input.ActionTwoPressed && canUseSpecial)
                canUseSpecial = false;

            Velocity = velocity;
            MoveAndSlide();
        }
    }
}
