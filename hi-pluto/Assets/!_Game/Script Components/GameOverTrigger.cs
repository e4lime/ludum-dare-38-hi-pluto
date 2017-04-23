using Lime.LudumDare.HiPluto.Managers;
using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components {
    public class GameOverTrigger : MonoBehaviour {

		[SerializeField]
		private Rigidbody m_Player;

		[SerializeField]
		private GameManager m_GameManager;

		public void OnTriggerExit() {
			m_GameManager.KillPlayer();
		}
	}
}
