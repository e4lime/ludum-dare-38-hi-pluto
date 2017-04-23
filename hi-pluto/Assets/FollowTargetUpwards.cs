﻿using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components {
    public class FollowTargetUpwards : MonoBehaviour {

		[SerializeField]
		private Rigidbody m_Target;

		#region cache
		private Rigidbody m_Rigidbody;
		#endregion


		private float m_HeightReached;
        void Awake(){
			m_Rigidbody = this.GetComponent<Rigidbody>();
	     }

		private void Start() {
			m_HeightReached = m_Target.position.y;
		}

		private void FixedUpdate() {
			float targetHeight = m_Target.position.y;
			if (m_HeightReached < targetHeight) {
				m_HeightReached = targetHeight;
				m_Rigidbody.position = new Vector3(m_Rigidbody.position.x, m_HeightReached, m_Rigidbody.position.z);
			}
		}

	}
}
