using UnityEngine;

namespace Lime.LudumDare.HiPluto.Sound {
	public class PlayRandomAstroidSound : MonoBehaviour {
	
	
		public void OnTriggerEnter(Collider other) {
			PlayRandomClip.INSTANCE.PlayRandomAstroid();
		}
	}
}
