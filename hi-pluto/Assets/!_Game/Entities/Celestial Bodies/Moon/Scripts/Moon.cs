﻿using System;
using UnityEngine;

namespace Lime.LudumDare.HiPluto.Entities.CelestialBodies {
	public class Moon : CelestialBody {


		public override string GetName() {
			return this.GetType().Name;
		}

		public override float GetSizeModifier() {
			return 0.27f;
		}
	}
}
