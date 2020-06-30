using Godot;

namespace LoveIsBlind2.Entities.Touchable {
	public class Touchable : StaticBody {
		protected MeshInstance Mesh => GetNode<MeshInstance>("Mesh");
		protected float Strength;
		protected bool Touched;

		public void SetParam(string paramName, object value) {
			for (var i = 0; i < Mesh.GetSurfaceMaterialCount(); i++) {
				var material = (ShaderMaterial)Mesh.GetSurfaceMaterial(i);
				material.SetShaderParam(paramName, value);
			}
		}

		public override void _Ready() {
			for (var i = 0; i < Mesh.GetSurfaceMaterialCount(); i++) {
				var material = (ShaderMaterial) Mesh.GetSurfaceMaterial(i).Duplicate();
				Mesh.SetSurfaceMaterial(i, material);
			}

			//Visible = false;
			SetParam("strength", 0);
		}

		public void Reveal(Vector3 from) {
			if (Touched) return;
			Touched = true;
			//Visible = true;
			SetParam("touch_point", from);
		}

		public override void _Process(float delta) {
			if (!Touched) return;

			Strength += delta;
			SetParam("strength", Strength);
		}
	}
}
