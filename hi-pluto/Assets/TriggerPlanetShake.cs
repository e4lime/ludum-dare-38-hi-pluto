using UnityEngine;

namespace Lime.LudumDare.HiPluto {
    public class TriggerPlanetShake : MonoBehaviour {

        public void OnTriggerEnter() {
			Debug.Log("YES");
			PlanetShaker.INSTANCE.DoTheShakeDance();
		}
    }
}
