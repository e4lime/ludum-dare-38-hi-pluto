using UnityEngine;
using DG.Tweening;

namespace Lime.LudumDare.HiPluto.Components {

	/// <summary>
	/// Pushes the rigidbody in y axis
	/// </summary>
    public class Pushable : MonoBehaviour {
	
	 
		[SerializeField]
		private Rigidbody m_RigidBody;

		[SerializeField, Range(0, 4)]
		private float m_Height;
		[SerializeField, Range(0, 4)]
		private float m_Duration;
		[SerializeField]
		private Ease m_Ease;

		void Awake(){
			if (m_RigidBody == null) {
				m_RigidBody = this.GetComponent<Rigidbody>();
			}
        }

		public void Push() {
			m_RigidBody.isKinematic = true;
			m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0, m_RigidBody.velocity.z);
			Vector3 currentPos = m_RigidBody.position;
			m_RigidBody.DOMoveY(currentPos.y + m_Height, m_Duration)
				.SetLoops(1, LoopType.Yoyo)
				.SetEase(m_Ease)
				.OnComplete(OnCompleteCallback);
		}

		private void OnCompleteCallback() {
			m_RigidBody.isKinematic = false;
		}
    }
}
