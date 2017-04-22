using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components {
    public class SnapToTarget : MonoBehaviour {

		[SerializeField]
		private Transform m_Target;


		public int maaaan;

	    #region cache
		private Transform m_Transform;
		#endregion

        void Awake(){
			m_Transform = this.transform;
        }

		void Update() {
			m_Transform.position = m_Target.position;
		}
	}
}
