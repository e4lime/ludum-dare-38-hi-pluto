using UnityEngine;

namespace Lime.LudumDare.HiPluto {
    public class TriggerPlanetShake : MonoBehaviour {

        public void OnTriggerEnter() {
			PlanetShaker.INSTANCE.DoTheShakeDance();
		}
    }
}
