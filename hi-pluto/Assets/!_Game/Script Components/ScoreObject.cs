using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components {
    public class ScoreObject : MonoBehaviour {
		[SerializeField]
		private int m_ScoreValue = 1;

		private void OnTriggerEnter(Collider other) {
			ScoreTrigger scoreTrigger = other.GetComponent<ScoreTrigger>();
			if (scoreTrigger) {
				scoreTrigger.GainScore(m_ScoreValue);
			}
		}
	}
}
