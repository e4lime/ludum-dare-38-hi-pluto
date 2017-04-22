using UnityEngine;
using DG.Tweening;
namespace Lime.LudumDare.HiPluto.Tweens {
    public class RotateYAxisTween : MonoBehaviour {

		[SerializeField]
		private float m_RotateTime = 5f;

		[SerializeField]
		private Ease m_Ease = Ease.Linear;


		private Transform m_Transform;
		
        void Awake(){
			m_Transform = transform;
			m_Transform.DOLocalRotate(new Vector3(0, 360, 0), m_RotateTime, RotateMode.LocalAxisAdd)
				.SetLoops(-1, LoopType.Incremental)
				.SetEase(m_Ease)
				.SetRelative(true);
		}
    }
}
