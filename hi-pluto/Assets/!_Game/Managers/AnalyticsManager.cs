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

		[SerializeField]
		private PlayerController m_Player;

		private int m_TotalDeaths = 0;
		private int m_TotalPauses = 0;
		
		private int m_HighestScoreReached = 0;
		private bool m_Muted = false;

		private static Dictionary<string, object> m_SendDataNoPlutoDict = new Dictionary<string, object>();
		private static Dictionary<string, object> m_SendDataWithPlutoDict = new Dictionary<string, object>();
		private static Dictionary<string, object> m_PlayerMutesDict = new Dictionary<string, object>();


		void Awake() {
			INSTANCE = this;
		}

		public void PlayerQuit() {
			SendData("player_quits", true);
		}

		public void PlayerHitPause() {
			m_TotalPauses++;
		}

		public void PlayerHitPluto() {
			SendData("hits_pluto", true);
		}

		bool m_MutedEventSent = false;
		public void SendPlayerMutes() {

			if (!m_MutedEventSent) {
				int height = m_ScoreManager.GetAltitude();
				m_PlayerMutesDict["time_passed"] = Time.realtimeSinceStartup;
				m_PlayerMutesDict["altitude"] = height;
				Analytics.CustomEvent("mutes_sound", m_PlayerMutesDict);
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

		// Does not work in WebGL
#if UNITY_STANDALONE

		private bool allowQuit = false;
		private bool quitting = false;
		void OnApplicationQuit() {
			//Debug.Log("Application Quit allowQuit: " + allowQuit + " quitting: " + quitting);
			if (!allowQuit) {
			//	Debug.Log("   Cancel Quit");
				Application.CancelQuit();
				this.allowQuit = true;
				PlayerQuit();
				OnApplicationQuit();
			}
			else if (allowQuit && !quitting) {
			//	Debug.Log("   Quit");
				quitting = true;
				Application.Quit();
			}
		}
#endif


		/// <summary>
		/// Earlier solution:
		/// - Application Lost Focus Does not work when closing the webgl game. lost focus gets called but data doesnt get sent
		/// 
		/// New solution:
		/// Send every ALTITUDE_NEEDED_TO_SEND. After 50 sends use ALTITUDE_NEEDED_TO_SEND_AFTER_50_SENDS. Reset after 1 hour.
		/// Assumes client gains 100 new units of data to send after 1h which probabli is wrong,
		///   (i guess client gain 1 new data to send 1h after each send but w/e).
		/// </summary>

		private float m_AltitudeNeededToSend = ALTITUDE_NEEDED_TO_SEND;
		private const float ALTITUDE_NEEDED_TO_SEND = 50f;
		private const float ALTITUDE_NEEDED_TO_SEND_AFTER_50_SENDS = 250f;

		private float m_TimePassedSinceReset = 0f;

		private float m_SentOnAltitude = 0;
		private int m_TotalSends = 0;

		private Rigidbody m_PlayerRigidbody;
		private void Start() {
			m_PlayerRigidbody = m_Player.GetComponent<Rigidbody>();
		}
		private void FixedUpdate() {
			m_TimePassedSinceReset += Time.fixedDeltaTime;
			float currentHeight = m_PlayerRigidbody.position.y;
			float nextSend = m_SentOnAltitude + m_AltitudeNeededToSend;

			if (currentHeight > nextSend) {
				m_SentOnAltitude = currentHeight;

				m_TotalSends++;
				if (m_TotalSends > 50) {
					m_AltitudeNeededToSend = ALTITUDE_NEEDED_TO_SEND_AFTER_50_SENDS;

					// If more than an hour
					if (m_TimePassedSinceReset > 3600f ) {
						m_TotalSends = 0;
						m_TimePassedSinceReset = 0f;
						m_AltitudeNeededToSend = ALTITUDE_NEEDED_TO_SEND;
					}

				}

				// Dont send on > 99, in case player hits pluto
				if (m_TotalSends < 99) {
					SendData("altitude_reached");
				}
				
			}
		}

		
		private void SendData(string eventName, bool sendPlutoHit) {

#if UNITY_EDITOR
			Debug.Log(eventName);
#endif

			int score = m_ScoreManager.GetScore();
			if (score > m_HighestScoreReached) {
				m_HighestScoreReached = score;
			}



			int highestScoreReached = m_HighestScoreReached;    // Sent
			int height = m_ScoreManager.GetAltitude();          // Sent
			int deaths = m_TotalDeaths;                         // Sent
			int pauses = m_TotalPauses;                         // Sent
			float timePassed = Time.realtimeSinceStartup;       // Sent
			bool muted = m_Muted;                               // Sent

			Dictionary<string, object> dict;
			if (sendPlutoHit) {
				bool hitPluto = m_GameManager.IsGameCompleted();
				dict = m_SendDataWithPlutoDict;
				dict["hit_pluto"] = hitPluto;
			} else {
				dict = m_SendDataNoPlutoDict;
			}

			dict["time_passed"] = timePassed;
			dict["highest_score"] = highestScoreReached;
			dict["current_score"] = score;
			dict["altitude"] = height;
			dict["deaths"] = deaths;
			dict["total_pauses"] = pauses;
			dict["sound_muted"] = muted;

			Analytics.CustomEvent(eventName, dict);

		}


		private void SendData(string eventName) {
			SendData(eventName, false);
		}
	}
}
