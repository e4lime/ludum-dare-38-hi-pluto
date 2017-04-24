using UnityEngine;
using Lime.LudumDare.HiPluto.Tweens;
namespace Lime.LudumDare.HiPluto {
    public class PlanetShaker : MonoBehaviour {

		[SerializeField]
		private ShakeScaleTween[] m_PlanetsToShake;

		public static PlanetShaker INSTANCE;

		public void Awake(){
			INSTANCE = this;
		}

		public void DoTheShakeDance() {

			foreach (ShakeScaleTween shake in m_PlanetsToShake) {
				shake.DoShake();
			}
		}
    }
}
