using UnityEngine;

namespace Lime.LudumDare.HiPluto {
	public class QuitOnButton : MonoBehaviour {


		[SerializeField]
		private string m_ButtonName;

		private void Update() {
			if (Input.GetButtonDown(m_ButtonName)) {
				Application.Quit();
			}
		}
	}
}
