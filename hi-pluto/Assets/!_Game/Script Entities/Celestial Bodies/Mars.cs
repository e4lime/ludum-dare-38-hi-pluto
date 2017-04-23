using System;
using UnityEngine;

namespace Lime.LudumDare.HiPluto.Entities.CelestialBodies {
    public class Mars : CelestialBody {

		public override string GetName() {
			return "Mars";
		}

		public override float GetSizeModifier() {
			return 0.53f;
		}

	}
}
