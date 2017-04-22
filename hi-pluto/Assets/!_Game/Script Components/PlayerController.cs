using UnityEngine;

namespace Lime.LudumDare.HiPluto {
    public class PlayerController : MonoBehaviour {
	
	    [SerializeField]
		private Rigidbody m_PlayerRigidbody;
		

        void Awake(){
			if (m_PlayerRigidbody == null)
				m_PlayerRigidbody = this.GetComponent<Rigidbody>();
        }

		void Update(){
			Vector3 mousePos = Input.mousePosition;
			float desiredX = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 0, 10)).x;
			m_PlayerRigidbody.position = new Vector3(desiredX, m_PlayerRigidbody.position.y, m_PlayerRigidbody.position.z);
		}
	}
}
