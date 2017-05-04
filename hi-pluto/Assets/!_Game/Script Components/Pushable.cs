using UnityEngine;
using DG.Tweening;
using System;
using Lime.LudumDare.HiPluto.Managers;

namespace Lime.LudumDare.HiPluto.Components {

	/// <summary>
	/// Pushes the rigidbody in y axis
	/// </summary>
    public class Pushable : MonoBehaviour, IPausableObject {
	
	 
		[SerializeField]
		private Rigidbody m_RigidBody;

		[SerializeField, Range(0, 4)]
		private float m_Height;
		[SerializeField, Range(0, 4)]
		private float m_Duration;
		[SerializeField]
		private Ease m_Ease;


		[SerializeField]
		private PauseManager m_PauseManager;

		private Tweener m_Tweener;

		void Awake(){
			if (m_RigidBody == null) {
				m_RigidBody = this.GetComponent<Rigidbody>();
			}
			m_PauseManager.RegisterObject(this);
		}

	
		public void Push() {
			if (m_Tweener!= null) {
				m_Tweener.Complete();
			}

			m_RigidBody.isKinematic = true;
			m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0, m_RigidBody.velocity.z);
			Vector3 currentPos = m_RigidBody.position;
			m_Tweener = m_RigidBody.DOMoveY(currentPos.y + m_Height, m_Duration)
				.SetLoops(1, LoopType.Yoyo)
				.SetEase(m_Ease)
				.OnComplete(OnCompleteCallback);
		}

		public bool IsTweening() {
			if (m_Tweener != null && m_Tweener.IsPlaying())
				return true;
			return false;
		}

		private void OnCompleteCallback() {
			m_RigidBody.isKinematic = false;
		}

		void IPausableObject.OnPause() {
			if (m_Tweener != null) {
				m_Tweener.Pause();
			}
		}

		void IPausableObject.OnUnPause() {
			if (m_Tweener != null) {
				m_Tweener.Play();
			}
		}
	}
}
