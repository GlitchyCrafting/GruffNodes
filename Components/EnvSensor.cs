using Godot;

namespace Gruff.Components {
    public interface EnvSensor
    {
        [Signal]
        public delegate void BodyDetectedEventHandler(Node2D body);

        public bool IsBodyDetected();
    }
}
