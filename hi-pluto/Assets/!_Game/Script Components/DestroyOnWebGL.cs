using UnityEngine;

namespace Lime.LudumDare.HiPluto {
    public class DestroyOnWebGL : MonoBehaviour {



#if UNITY_WEBGL
		void LateUpdate(){
			Destroy(this.gameObject);
        }
#endif
	}
}
