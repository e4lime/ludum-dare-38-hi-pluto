using UnityEngine;
using DG.Tweening;

namespace Lime.LudumDare.HiPluto.Components.Physics {
	public class PushPlayer : MonoBehaviour {

		[SerializeField]
		private Rigidbody m_PlayerRigidbody;

		[SerializeField, Range(0, 4)]
		private float m_Height;
		[SerializeField, Range(0, 4)]
		private float m_Duration;
		[SerializeField]
		private Ease m_Ease;

		private float m_LastTweenedYVelocity = 0f;
		void Start() {
			if (m_PlayerRigidbody == null) {
				Debug.LogError("Player is null!");
			}
		}

		private void OnTriggerEnter(Collider other) {
			Debug.Log(transform.name);
			m_PlayerRigidbody.isKinematic = true;
			m_PlayerRigidbody.velocity = new Vector3(m_PlayerRigidbody.velocity.x, 0, m_PlayerRigidbody.velocity.z);
			Vector3 currentPos = m_PlayerRigidbody.position;
			m_PlayerRigidbody.DOMoveY(currentPos.y + m_Height, m_Duration)
				.SetLoops(1, LoopType.Yoyo)
				.SetEase(m_Ease)
				.OnComplete(OnCompleteCallback);
			//m_PlayerRigidbody.DOJump(currentPos, 3, 2, 2);

			//	Vector3 currentVel = m_PlayerRigidbody.velocity;
			//	m_PlayerRigidbody.velocity = new Vector3(currentVel.x, 7, currentVel.z);
			//m_PlayerRigidbody.AddForce(m_PushDirection,ForceMode.Impulse);

			Destroy(this.gameObject);

		}
		private void OnCompleteCallback() {
			m_PlayerRigidbody.isKinematic = false;

		}
	}
}
