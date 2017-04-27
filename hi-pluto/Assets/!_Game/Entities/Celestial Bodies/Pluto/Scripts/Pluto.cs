using UnityEngine;

namespace Lime.LudumDare.HiPluto.Entities.CelestialBodies {
	public class Pluto : CelestialBody {

		public override string GetName() {
			return this.GetType().Name;
		}

		public override float GetSizeModifier() {
			return 0.18f;
		}

		/// <summary>
		/// Added after deadline. To fix fluto getting destroyed to early
		/// </summary>
		public void OnTriggerExit() {
			Destroy(this.gameObject);
		}
	}
}
