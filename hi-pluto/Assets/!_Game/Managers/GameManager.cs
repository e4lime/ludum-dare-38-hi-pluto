using UnityEngine;

namespace Lime.LudumDare.HiPluto.Managers {
    public class GameManager : MonoBehaviour {
	
		[SerializeField]
		private bool m_VisibleCursor;


		private void Start() {
			Setup();
		}
		private void Setup(){
			Cursor.visible = m_VisibleCursor;
		}
    }
}
