using UnityEngine;

namespace Lime.LudumDare.HiPluto.Entities.CelestialBodies {
    public abstract class CelestialBody : MonoBehaviour {

		public const float MERCURY = 0.38f;
		public const float VENUS = 0.95f;
		public const float MOON = 0.27f;
		public const float MARS = 0.53f;
		public const float JUPITER = 11.2f;
		public const float SATURN = 9.45f;
		public const float URANUS = 4f;
		public const float NEPTUNE = 3.88f;
		public const float PLUTO = 0.18f;


		#region cache
		private Transform m_Transform;
		#endregion

		void Awake() {
			m_Transform = this.transform;
		}

	
		[SerializeField]
		private bool m_AffectByEarthSizeReference = false;

		public abstract float GetSizeModifier();
		public abstract string GetName();

		public bool GetAffectByEarthSizeReference() {
			return m_AffectByEarthSizeReference;
		}
    }
}
