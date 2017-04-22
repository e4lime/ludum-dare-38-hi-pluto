using UnityEngine;

namespace Lime.LudumDare.HiPluto.Managers {
    public class GameManager : MonoBehaviour {
	
		[SerializeField]
		private bool m_VisibleCursor;

		[SerializeField]
		private Transform m_Player;

		#region cache
		private Rigidbody m_PlayerRigidBody;
	

		#endregion endCache
		private void Start() {
			if (m_Player == null) {
				Debug.LogWarning("Player isn't set! Finding player");
				GameObject playerGo = GameObject.FindGameObjectWithTag("Player");
				if (playerGo == null) {
					Debug.LogError("No GO with Player tag found! Abort abort!");
#if UNITY_EDITOR
					UnityEditor.EditorApplication.isPlaying = false;
#endif
				}
				else {
					m_Player = playerGo.transform;
				}
			}
			Setup();
			Cache();
		}
		private void Setup(){
			Cursor.visible = m_VisibleCursor;
		}

		private void Cache() {
			//m_PlayerRigidBody = 
		}

    }
}
