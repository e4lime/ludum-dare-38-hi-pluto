using UnityEngine;

namespace Lime.LudumDare.HiPluto {
    public class HighscoreDisplay : MonoBehaviour {
	
	    #region cache
		private Transform m_Transform;
		#endregion

        void Awake(){
			m_Transform = this.transform;
        }
    }
}
