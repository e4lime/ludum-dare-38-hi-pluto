using UnityEngine;

namespace Lime.LudumDare.HiPluto.Entities.CelestialBodies {
	public class Jupiter : CelestialBody {

		public override string GetName() {
			return this.GetType().Name;
		}
		public override float GetSizeModifier() {
			return 11.2f;
		}
	}
}
