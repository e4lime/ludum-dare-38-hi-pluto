using UnityEngine;
using Lime.LudumDare.HiPluto.Components;
using System.Collections;

namespace Lime.LudumDare.HiPluto.Managers {
    public class PauseManager : MonoBehaviour {


		/// <summary>
		/// Make object register themself with the PauseManager instead, cant have interfaces in inspector view
		/// </summary>
		private ArrayList m_PauseObjects = new ArrayList();


		private bool m_IsPaused = true;

		private void Start() {
			if (m_IsPaused) {
				PauseObjects();
			}
		}

		public void PauseObjects() {
			Cursor.visible = true;
			m_IsPaused = true;
			foreach (IPausableObject obj in m_PauseObjects) {
				obj.OnPause();
			}
		}


		public void UnPauseObjects() {
			Cursor.visible = false;
			m_IsPaused = false;
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

		private void Update() {
			if (Input.GetButtonDown("Pause")) {
				m_IsPaused = !m_IsPaused;
				if (m_IsPaused) {
					PauseObjects();
				}
				else {
					UnPauseObjects();
				}
			}
		}
	}
}
