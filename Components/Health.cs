using Godot;

namespace Gruff.Components {
    [Tool]
    [GlobalClass, Icon("res://GruffNodes/Icons/Health.svg")]
    public partial class Health : Node
    {
        private double _value;
        private double _minValue;
        private double _maxValue;

        [Export]
        public _2D.HealthBar healthBar;
        [Export]
        public double MinValue
        {
            set {
                _minValue = value;
                if (healthBar != null)
                    healthBar.MinValue = value;
            }
            get => _minValue;
        }
        [Export]
        public double MaxValue
        {
            set {
                _maxValue = value;
                if (healthBar != null)
                    healthBar.MaxValue = value;
            }
            get => _maxValue;
        }
        [Export]
        public double Value {
            set {
                double val = value;
                Mathf.Clamp(val, MinValue, MaxValue);
                _value = val;
                if (healthBar != null)
                    healthBar.Value = _value;
            }
            get => _value;
        }

        public Health() : this(100, 0, 100) {}

        public Health(double value, double minVal, double maxVal)
        {
            Value = value;
            MinValue = minVal;
            MaxValue = maxVal;
        }

        public override void _Ready()
        {
            base._Ready();

            Value = _value;
            MinValue = _minValue;
            MaxValue = _maxValue;
        }

        public void Heal(double amount) { Value += amount; }
        public void Hurt(double amount) { Value -= amount; }

        public bool IsDead() { return (Value <= 0); }
    }
}
