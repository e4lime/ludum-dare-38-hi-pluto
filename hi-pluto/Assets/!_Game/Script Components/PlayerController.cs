using UnityEngine;

namespace Lime.LudumDare.HiPluto {
    public class PlayerController : MonoBehaviour {
	
	    #region cache
		private Rigidbody m_Rigidbody;
		#endregion

        void Awake(){
			m_Rigidbody = this.GetComponent<Rigidbody>();
        }

		void Update(){
			Vector3 mousePos = Input.mousePosition;
			float desiredX = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 0, 10)).x;
			m_Rigidbody.position = new Vector3(desiredX, m_Rigidbody.position.y, m_Rigidbody.position.z);
		}
	}
}
