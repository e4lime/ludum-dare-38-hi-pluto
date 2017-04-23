using Lime.LudumDare.HiPluto.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Lime.LudumDare.HiPluto {
    public class ScoreManager : MonoBehaviour {

		[SerializeField]
		private Text m_AltitudeReachedDisplay;
		[SerializeField]
		private Text m_ScoreDisplay;

		private int m_Score = 0;
		private int m_GainedAltitude = 0;

		[SerializeField]
		private GameManager m_GameManager;
		[SerializeField]
		private LevelManager m_LevelManager;

		[SerializeField]
		private PauseManager m_PauseManager;

		public void GainScore(int amount) {
			m_Score += amount;
		}

		public void ResetScore() {
			m_Score = 0;
		}

		public void ResetAltitude() {
			m_GainedAltitude = 0;
		}


		public int GetScore() {
			return m_Score;
		}

		public int GetAltitude() {
			return m_GainedAltitude;
		}

		private void FixedUpdate() {
			m_GainedAltitude = m_LevelManager.GetAltitude();
		}

		public void OnGUI() {
			if (!m_PauseManager.IsPaused()) {
				m_ScoreDisplay.text = m_Score + "";
				m_AltitudeReachedDisplay.text = m_GainedAltitude + "";
			}
		}
	}
}
