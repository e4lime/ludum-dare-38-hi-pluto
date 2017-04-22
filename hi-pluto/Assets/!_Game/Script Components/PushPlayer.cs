using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components.Physics {
    public class PushPlayer : MonoBehaviour {

		[SerializeField]
		private Rigidbody m_PlayerRigidbody;

		[SerializeField]
		private Vector3 m_PushDirection;

		#region cache
		private Rigidbody m_Rigidbody;
		#endregion

        void Awake(){
			m_Rigidbody = this.GetComponent<Rigidbody>();
        }

		void Start() {
			if (m_PlayerRigidbody == null) {
				Debug.LogError("Player is null!");
			}
		}

		private void OnTriggerEnter() {
			Vector3 currentVel = m_PlayerRigidbody.velocity;
			m_PlayerRigidbody.velocity = new Vector3(currentVel.x, 7, currentVel.z);
			//m_PlayerRigidbody.AddForce(m_PushDirection,ForceMode.Impulse);
		}

	}
}
