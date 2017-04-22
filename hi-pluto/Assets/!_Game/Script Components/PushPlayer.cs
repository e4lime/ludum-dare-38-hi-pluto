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

		void Start() {
			if (m_PlayerRigidbody == null) {
				Debug.LogError("Player is null!");
			}
		}

		private void OnTriggerEnter() {

	
			Vector3 currentPos = m_PlayerRigidbody.position;
			m_PlayerRigidbody.DOMoveY(currentPos.y + m_Height, m_Duration).SetLoops(2, LoopType.Yoyo).SetEase(m_Ease);
			//m_PlayerRigidbody.DOJump(currentPos, 3, 2, 2);

			//	Vector3 currentVel = m_PlayerRigidbody.velocity;
			//	m_PlayerRigidbody.velocity = new Vector3(currentVel.x, 7, currentVel.z);
			//m_PlayerRigidbody.AddForce(m_PushDirection,ForceMode.Impulse);
		}


		private void TweenBackDown() {
			//m_PlayerRigidbody.DOMoveY(-3, 2).OnComplete(TweenBackDown);
			//m_PlayerRigidbody.velocity = new Vector3(m_PlayerRigidbody.velocity.x, 0, m_PlayerRigidbody.velocity.z);



		}
	}
}
