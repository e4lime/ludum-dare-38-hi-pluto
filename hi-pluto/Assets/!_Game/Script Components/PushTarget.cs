using UnityEngine;


namespace Lime.LudumDare.HiPluto.Components.Physics {
	public class PushTarget : MonoBehaviour {

		/// <summary>
		/// Added after deadline. To fix fluto getting destroyed
		/// </summary>
		[SerializeField]
		private bool m_DestroyOnHit = true;

		private void OnTriggerEnter(Collider other) {
			Pushable target = other.gameObject.GetComponent<Pushable>();
			if (target != null) {
				target.Push();

				/// <summary>
				/// Added after deadline. To fix fluto getting destroyed
				/// </summary>
				if (m_DestroyOnHit) {
					Destroy(this.gameObject);
				}
			}
		}
	}
}
