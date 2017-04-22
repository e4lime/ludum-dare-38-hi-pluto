using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components.Physics {
    public class PushPlayerUp : MonoBehaviour {
	
	    #region cache
		private Rigidbody m_Rigidbody;
		#endregion

        void Awake(){
			m_Rigidbody = this.GetComponent<Rigidbody>();
        }


    }
}
