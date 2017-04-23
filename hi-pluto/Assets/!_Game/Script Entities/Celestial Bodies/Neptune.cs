using UnityEngine;

namespace Lime.LudumDare.HiPluto.Entities.CelestialBodies {
	public class Neptune : CelestialBody {

		public override string GetName() {
			return this.GetType().Name;
		}

		public override float GetSizeModifier() {
			return 3.88f;
		}

	}
}
