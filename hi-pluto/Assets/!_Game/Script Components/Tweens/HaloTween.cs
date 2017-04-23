using UnityEngine;

namespace Lime.LudumDare.HiPluto {
    public class CustomAttributeTween : MonoBehaviour {
	
	    #region cache
		private Transform m_Transform;
		#endregion

        void Awake(){
			m_Transform = this.transform;
        }
    }
}
