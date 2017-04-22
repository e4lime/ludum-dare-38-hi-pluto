using System.Collections;
using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components {
    public class RotateAroundAxis : MonoBehaviour {


		[SerializeField]
		private float m_Speed = 1f;

		[SerializeField]
		private Vector3 m_AroundAxis = Vector3.up;

	    #region cache
		private Transform m_Transform;
		#endregion

        void Start(){
			m_Transform = transform;
			StartCoroutine(RotateTransform());
		}


		private IEnumerator RotateTransform() {
			while (true) {
				m_Transform.Rotate(m_AroundAxis, m_Speed * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}
		}
	}
}
