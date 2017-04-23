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
		private FollowTargetUpwards m_GameOverTrigger;

		private float m_SpawnPointHeight;

		private int m_CurrentScore;
		private int m_MaxScore;
		// Height is in levelmanager

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
			Cursor.visible = m_VisibleCursor;
			m_SpawnPointHeight = m_Player.position.y;
		}

		public void KillPlayer() {
			m_CameraSmoothFollow.enabled = false;
			m_MaxScore = m_CurrentScore;
			m_CurrentScore = 0;

			StartCoroutine(NewTry());
		}
		private IEnumerator NewTry() {
			yield return new WaitForSeconds(1);
			RespawnPlayer();
		}
	
		private void RespawnPlayer() {
			m_CameraSmoothFollow.enabled = true;
			
			m_Player.GetComponent<Rigidbody>().position = m_LevelManager.GetActiveSpawnpoint();
			m_GameOverTrigger.ResetForRespawn();

			m_LevelManager.ClearAndRebuildFromCheckpoint();
		}
    }
}
