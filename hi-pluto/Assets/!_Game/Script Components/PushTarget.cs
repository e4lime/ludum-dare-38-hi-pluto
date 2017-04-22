using UnityEngine;


namespace Lime.LudumDare.HiPluto.Components.Physics {
	public class PushTarget : MonoBehaviour {


		private void OnTriggerEnter(Collider other) {
			Pushable target = other.gameObject.GetComponent<Pushable>();
			if (target != null) {
				target.Push();
				Destroy(this.gameObject);
			}
		}
	}
}
