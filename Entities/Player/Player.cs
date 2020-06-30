using Godot;

namespace LoveIsBlind2.Entities.Player {
	public class Player : KinematicBody {
		public Area RevealArea => GetNode<Area>("RevealArea");
		
		public override void _PhysicsProcess(float delta) {
			var up = Input.IsActionPressed("move_up") ? 1 : 0;
			var down = Input.IsActionPressed("move_down") ? 1 : 0;
			var left = Input.IsActionPressed("move_left") ? 1 : 0;
			var right = Input.IsActionPressed("move_right") ? 1 : 0;
			var motion = new Vector3(right - left, 0,down - up);
			MoveAndSlide(motion);

			RevealBlocks();
		}

		private void RevealBlocks() {
			var bodies = RevealArea.GetOverlappingBodies();
			foreach (var body in bodies) {
				if (!(body is Touchable.Touchable touchable)) continue;
				touchable.Reveal();
			}
		}
	}
}
