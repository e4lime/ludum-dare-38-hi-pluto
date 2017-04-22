using UnityEngine;

namespace Lime.LudumDare.HiPluto {
    public class LimitFallSpeed : MonoBehaviour {

		[SerializeField, Range(-100, 0)]
		private float m_LimitAtSpeed = -11f;

	    #region cache
		private Rigidbody m_Rigidbody;
		#endregion

	
        void Awake(){
			m_Rigidbody = GetComponent<Rigidbody>();
        }



		private void FixedUpdate() {
			Vector3 cv = m_Rigidbody.velocity;
			if (cv.y < m_LimitAtSpeed) {
				m_Rigidbody.velocity = new Vector3(cv.x, m_LimitAtSpeed, cv.z);
			}
		}
	}
}
