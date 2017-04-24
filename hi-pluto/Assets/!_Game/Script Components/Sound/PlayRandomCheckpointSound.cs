using UnityEngine;

namespace Lime.LudumDare.HiPluto.Sound {
    public class PlayRandomCheckpointSound : MonoBehaviour {

		public void OnTriggerEnter(Collider other) {
			PlayRandomClip.INSTANCE.PlayRandomCheckpoint();
		}
	}
}
