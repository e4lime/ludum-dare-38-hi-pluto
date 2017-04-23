using UnityEngine;

namespace Lime.LudumDare.HiPluto.Entities.CelestialBodies {
	public class Uranus : CelestialBody {

		public override string GetName() {
			return this.GetType().Name;
		}

		public override float GetSizeModifier() {
			return 4f;
		}

	}
}
