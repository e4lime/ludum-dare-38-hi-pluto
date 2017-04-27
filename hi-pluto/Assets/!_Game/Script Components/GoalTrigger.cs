using Lime.LudumDare.HiPluto.Managers;
using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components {
	public class GoalTrigger : MonoBehaviour {

		[SerializeField]
		private GameManager m_GameManager;

		private void OnTriggerEnter(Collider other) {
			m_GameManager.CompleteGame();
			Managers.Analyze.AnalyticsManager.INSTANCE.PlayerHitPluto();

		}


	}
}
