using UnityEngine;
using Lime.LudumDare.HiPluto.Components;
using System.Collections;
using UnityEngine.UI;
using Lime.LudumDare.HiPluto.Sound;

namespace Lime.LudumDare.HiPluto.Managers {
	public class GameManager : MonoBehaviour {

		[SerializeField]
		private bool m_VisibleCursor;

		[SerializeField]
		private Transform m_Player;

		[SerializeField]
		private SmoothFollowTarget m_CameraSmoothFollow;

		[SerializeField]
		private LevelManager m_LevelManager;

		[SerializeField]
		private PauseManager m_PauseManager;

		[SerializeField]
		private ScoreManager m_ScoreManager;



		[SerializeField]
		private FollowTargetUpwards m_GameOverTrigger;


		// Height is in levelmanager

		private bool m_AfterIntro = false;
		private bool m_GameCompleted = false;
		private void Awake() {
			Cursor.visible = m_VisibleCursor;
		}

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
			
		}
		

		public bool IsAfterIntro() {
			return m_AfterIntro;
		}

		public bool IsGameCompleted() {
			return m_GameCompleted;
		}

		public void CompleteGame() {
			m_GameCompleted = true;
			m_PauseManager.PauseObjects();
		}

		public void StartGame() {
			m_AfterIntro = true;
			m_PauseManager.PauseObjects();
		}

		/// BUG: Is called twice after hitting pluto
		public void KillPlayer(bool respawnPlayer) {
			m_CameraSmoothFollow.enabled = false;
			PlayRandomClip.INSTANCE.PlayRandomFall();
			StartCoroutine(NewTry(respawnPlayer));
		}
		private IEnumerator NewTry(bool respawnPlayer) {
			yield return new WaitForSeconds(1);
			if (respawnPlayer) {
				m_PauseManager.PauseObjects();
				// Placed here instead of in Killplayer case of the double call to KillPlayer bug
				// And to avoid getting called when player hits the pause key
				Analyze.AnalyticsManager.INSTANCE.PlayerDie();
			}
			m_ScoreManager.ResetScore();
			m_ScoreManager.ResetAltitude();

			m_LevelManager.ResetAltitude();
			if (respawnPlayer) {
				RespawnPlayer();
				m_LevelManager.ClearAndRebuildFromCheckpoint();
			}
			m_CameraSmoothFollow.enabled = true;
		}

		private void RespawnPlayer() {

			m_Player.GetComponent<Rigidbody>().position = m_LevelManager.GetActiveSpawnpoint();
			m_GameOverTrigger.ResetForRespawn();


		}
	}
}
