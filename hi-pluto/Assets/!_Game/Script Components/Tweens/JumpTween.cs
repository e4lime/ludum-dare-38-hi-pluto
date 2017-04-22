using UnityEngine;
using DG.Tweening;

namespace Lime.LudumDare.HiPluto.Tweens {
    public class Tweens : MonoBehaviour {
	
	    #region cache
		private Rigidbody m_Rigidbody;
		#endregion

        void Awake(){
			m_Rigidbody = this.GetComponent<Rigidbody>();
			Vector3 currentPos = m_Rigidbody.position;
			m_Rigidbody.DOJump(currentPos,10, 1, 5);
        }

    }
}
