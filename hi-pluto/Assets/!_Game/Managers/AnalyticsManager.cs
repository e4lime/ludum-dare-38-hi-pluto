using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;
using Lime.LudumDare.HiPluto.Components;
using System.Collections;

namespace Lime.LudumDare.HiPluto.Managers.Analyze {
	public class AnalyticsManager : MonoBehaviour {

		public static AnalyticsManager INSTANCE;

		[SerializeField]
		private ScoreManager m_ScoreManager;

		[SerializeField]
		private GameManager m_GameManager;


		private int m_TotalDeaths = 0;
		private int m_TotalPauses = 0;
		private int m_TotalSends = 0;
		private int m_HighestScoreReached = 0;
		private bool m_Muted = false;

		void Awake() {
			INSTANCE = this;
		}

		public void PlayerQuit() {
			SendData("Application Quits");
		}

		public void PlayerHitPause() {
			m_TotalPauses++;
		}

		public void PlayerHitPluto() {
			SendData("Hits Pluto");
		}

		bool m_MutedEventSent = false;
		public void SendPlayerMutes() {

			if (!m_MutedEventSent) {
				Analytics.CustomEvent("Mutes Sound", new Dictionary<string, object> {
					{"time passed", Time.realtimeSinceStartup}
				});
				m_Muted = true;
				m_MutedEventSent = true;
			}
		}

		public void SendPlayerUnMutes() {
			m_Muted = false;
		}

		public void PlayerDie() {
			++m_TotalDeaths;
		}

		private bool allowQuit = false;
		void OnApplicationQuit() {
			if (!allowQuit) {
				Application.CancelQuit();
				this.allowQuit = true;
				PlayerQuit();
				OnApplicationQuit();
			}
			else {
				Application.Quit();
			}
		}

		private void SendData(string eventName) {
			m_TotalSends++;


			int score = m_ScoreManager.GetScore();
			if (score > m_HighestScoreReached) {
				m_HighestScoreReached = score;
			}

			int highestScoreReached = m_HighestScoreReached; // Sent
			int height = m_ScoreManager.GetAltitude(); // Sent
			int deaths = m_TotalDeaths; // Sent
			int pauses = m_TotalPauses; // Sent
			float timePassed = Time.realtimeSinceStartup; // Sent
			bool muted = m_Muted; // Sent
			bool hitPluto = m_GameManager.IsGameCompleted(); // Sent

			Analytics.CustomEvent(eventName, new Dictionary<string, object>{
				{"Time Passed", timePassed},
				{"Hit pluto", hitPluto},
				{"Highest Score", highestScoreReached},
				{"Current Score", score},
				{"Altitude", height},
				{"Deaths", deaths},
				{"Total pauses", pauses},
				{"Sound is muted", muted}
			});
		}
	}
}
