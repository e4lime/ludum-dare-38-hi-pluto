using UnityEngine;
using Lime.LudumDare.HiPluto.Components;
using System.Collections;

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

		private float m_SpawnPointHeight;


		// Height is in levelmanager

		private bool m_AfterIntro = false;

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
			Setup();
		}
		private void Setup(){
		
			m_SpawnPointHeight = m_Player.position.y;
		}

		public bool IsAfterIntro() {
			return m_AfterIntro;
		}

		public void StartGame() {
			m_AfterIntro = true;
			m_PauseManager.PauseObjects();
		}

		public void KillPlayer() {
			m_CameraSmoothFollow.enabled = false;
			StartCoroutine(NewTry());
		}
		private IEnumerator NewTry() {
			yield return new WaitForSeconds(1);
			m_PauseManager.PauseObjects();
			m_ScoreManager.ResetScore();
			m_ScoreManager.ResetAltitude();
			m_LevelManager.ClearAndRebuildFromCheckpoint();
			RespawnPlayer();
		}
	
		private void RespawnPlayer() {
			m_CameraSmoothFollow.enabled = true;
			
			m_Player.GetComponent<Rigidbody>().position = m_LevelManager.GetActiveSpawnpoint();
			m_GameOverTrigger.ResetForRespawn();

			
		}
    }
}
