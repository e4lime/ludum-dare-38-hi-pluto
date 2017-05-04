using System;
using UnityEngine;
using Lime.LudumDare.HiPluto.Managers;

namespace Lime.LudumDare.HiPluto.Components {
	public class PlayerController : MonoBehaviour, IPausableObject {

		[SerializeField]
		private Rigidbody m_PlayerRigidbody;

		[SerializeField]
		private Transform m_LeftLimit;

		[SerializeField]
		private Transform m_RightLimit;


		/// <summary>
		/// Added after deadline. To fix game not working on 4:3
		/// </summary>
		[SerializeField]
		private Transform m_43LeftLimit;
		[SerializeField]
		private Transform m_43RightLimit;

		[SerializeField]
		private PauseManager m_PauseManager;

		private float m_LeftLimitX;
		private float m_RightLimitX;

		private bool m_Paused = false;

		private Pushable m_Pushable;
		

		void Awake() {
			if (m_PlayerRigidbody == null)
				m_PlayerRigidbody = this.GetComponent<Rigidbody>();
			m_PauseManager.RegisterObject(this);

			/// <summary>
			/// Added after deadline. To fix game not working on 4:3
			/// </summary>
			// If 4:3
			if (Camera.main.aspect <= 1.4) {
				m_LeftLimit = m_43LeftLimit;
				m_RightLimit = m_43RightLimit;
			}

			m_Pushable = GetComponent<Pushable>();
		}

		private void Start() {
			m_LeftLimitX = m_LeftLimit.position.x;
			m_RightLimitX = m_RightLimit.position.x;

			if (m_LeftLimitX > m_RightLimitX) {
				Debug.LogError("Somethings wrong...");
			}

		
		}

		void Update() {
			if (m_Paused)
				return;

			Vector3 mousePos = Input.mousePosition;
			float desiredX = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 0, 10)).x;
			if (desiredX < m_LeftLimitX) {
				desiredX = m_LeftLimitX;
			}
			else if (desiredX > m_RightLimitX) {
				desiredX = m_RightLimitX;
			}

			if (m_Pushable.IsTweening()) {
				m_PlayerRigidbody.position = new Vector3(desiredX, m_PlayerRigidbody.position.y, m_PlayerRigidbody.position.z);
			}
			else {
				m_PlayerRigidbody.MovePosition(new Vector3(desiredX, m_PlayerRigidbody.position.y, m_PlayerRigidbody.position.z));
			}
			
		}

		public void OnPause() {

			m_PlayerRigidbody.isKinematic = true;
			m_Paused = true;

		}
		public void OnUnPause() {
			m_PlayerRigidbody.isKinematic = false;
			m_Paused = false;
		}

	}
}
