using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components {
    public class SmoothFollowTarget : MonoBehaviour {

		[SerializeField]
		private Rigidbody m_Target;

		[SerializeField]
		private float m_Damp = 0.3f;
		#region cache
		private Transform m_Transform;
		#endregion


		private Vector3 velocity = Vector3.zero;
        void Awake(){
			m_Transform = this.transform;
		}

		void FixedUpdate() {
			Vector3 targetPos = new Vector3(m_Transform.position.x, m_Target.position.y, m_Transform.position.z);
			m_Transform.position = Vector3.SmoothDamp(m_Transform.position, targetPos, ref velocity, m_Damp);
		}
	}
}
