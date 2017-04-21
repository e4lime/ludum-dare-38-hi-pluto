using UnityEngine;

namespace Project.Sub {
    public class TemplateMonobehaviour : MonoBehaviour {
	
	    #region cache
		private Transform m_Transform;
		#endregion

        void Awake(){
			m_Transform = this.transform;
        }
    }
}
