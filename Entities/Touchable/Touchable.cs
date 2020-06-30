using Godot;

namespace LoveIsBlind2.Entities.Touchable {
    public class Touchable : StaticBody
    {
        public override void _Ready() {
            Visible = false;
        }

        public void Reveal() {
            Visible = true;
        }
    }
}
