using UnityEngine;

namespace Lime.LudumDare.HiPluto {
    public class ShakeScaleTween : MonoBehaviour {
	
	    #region cache
		private Transform m_Transform;
		#endregion

        void Awake(){
			m_Transform = this.transform;
        }
    }
}
