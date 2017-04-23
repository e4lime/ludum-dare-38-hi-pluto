using Lime.LudumDare.HiPluto.Managers;
using UnityEngine;

namespace Lime.LudumDare.Components {
    public class Checkpoint : MonoBehaviour {

		private LevelManager m_LevelEditor;

		/// <summary>
		/// Call when spawned
		/// </summary>
		/// <param name="manager"></param>
		public void SetLevelManager(LevelManager manager) {
			m_LevelEditor = manager;
		}

		private void OnTriggerEnter() {
			m_LevelEditor.CheckpointHit(this);
		}
	}
}
