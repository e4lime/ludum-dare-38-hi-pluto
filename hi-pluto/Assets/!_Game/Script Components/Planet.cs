using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components{
    public class Planet : MonoBehaviour {

		[SerializeField, Header("Size modifier compared to earth")]
		private float m_SizeModifier;

	    #region cache
		private Transform m_Transform;
		#endregion

        void Awake(){
			m_Transform = this.transform;
        }
    }
}
