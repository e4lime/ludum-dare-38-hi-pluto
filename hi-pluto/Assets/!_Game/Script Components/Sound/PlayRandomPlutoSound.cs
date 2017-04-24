using UnityEngine;

namespace Lime.LudumDare.HiPluto.Sound {
	public class PlayRandomPlutoSound : MonoBehaviour {

		public void OnTriggerEnter(Collider other) {
			PlayRandomClip.INSTANCE.PlayRandomHitPluto();
		}
	}
}
