using UnityEngine;
using DG.Tweening;
namespace Lime.LudumDare.HiPluto.Tweens {
    public class ShakeScaleTween : MonoBehaviour {
	
	    #region cache
		private Transform m_Transform;
		#endregion

		private void Awake() {
			m_Transform = this.GetComponent<Transform>();
		}

		public void DoShake() {
			m_Transform.DOShakeScale(2f, 1f,5, 45);
		}
    }
}
