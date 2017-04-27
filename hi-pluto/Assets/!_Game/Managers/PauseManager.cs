using UnityEngine;
using Lime.LudumDare.HiPluto.Components;
using System.Collections;

namespace Lime.LudumDare.HiPluto.Managers {
	public class PauseManager : MonoBehaviour {

		[SerializeField]
		private Canvas m_PauseMenu;

		[SerializeField]
		private GameManager m_GameManager;

		[SerializeField]
		private ScoreManager m_ScoreManager;

		[SerializeField]
		private Canvas m_CongratScreen;




		/// <summary>
		/// Make object register themself with the PauseManager instead, cant have interfaces in inspector view
		/// </summary>
		private ArrayList m_PauseObjects = new ArrayList();


		private bool m_IsPaused = true;
		private bool m_ResetScoreNextPause = false;


		private void Start() {
			if (m_IsPaused) {
				PauseObjects();
			}
		}

		public void PauseObjects() {

			Cursor.visible = true;
			m_IsPaused = true;
			if (m_ResetScoreNextPause) {
				m_GameManager.KillPlayer(false);
			}


			if (m_ResetScoreNextPause == false && m_GameManager.IsGameCompleted()) {
				m_CongratScreen.gameObject.SetActive(true);
			}


			if (m_GameManager.IsAfterIntro()) {
				m_PauseMenu.gameObject.SetActive(true);
			}

			foreach (IPausableObject obj in m_PauseObjects) {
				obj.OnPause();
			}
		}


		public void UnPauseObjects() {

			Cursor.visible = false;
			m_IsPaused = false;


			if (m_ResetScoreNextPause == false && m_GameManager.IsGameCompleted()) {
				m_CongratScreen.gameObject.SetActive(false);
				m_ResetScoreNextPause = true;
			}

			m_PauseMenu.gameObject.SetActive(false);
			foreach (IPausableObject obj in m_PauseObjects) {
				obj.OnUnPause();
			}
		}

		public void RegisterObject(IPausableObject obj) {
			if (obj == null) {
				Debug.LogError("Adding null! Skipping");
			}
			else {
				m_PauseObjects.Add(obj);
			}
		}

		/// <summary>
		///  Avoid! slow
		/// </summary>
		/// <param name="obj"></param>
		public void UnregisterObject(IPausableObject obj) {
			Debug.LogError("Not yet implemented");
		}

		public bool IsPaused() {
			return m_IsPaused;
		}

		private void Update() {

			if (m_GameManager.IsAfterIntro() && Input.GetButtonDown("Pause")) {
				m_IsPaused = !m_IsPaused;
				if (m_IsPaused) {
					Analyze.AnalyticsManager.INSTANCE.PlayerHitPause();
					PauseObjects();
				}
				else {
					UnPauseObjects();
				}
			}
		}
	}
}
