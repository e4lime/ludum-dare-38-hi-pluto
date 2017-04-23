using UnityEngine;
using System.Collections;
namespace Lime.LudumDare.HiPluto.Components {
    public class EnableAndDisableLoop : MonoBehaviour {

		[SerializeField]
		private Transform m_TargetToToggle;

		[SerializeField, Range(0,100)]
		private float m_Seconds;



		void Awake(){
			
			if (m_TargetToToggle == null) {
				Debug.LogError("Target not set!");
			}
			else {
				StartCoroutine(Toggling());
			}
		
        }

		private IEnumerator Toggling() {
			GameObject target = m_TargetToToggle.gameObject;
			while (true) {
				target.SetActive(!target.activeInHierarchy);
				yield return new WaitForSeconds(m_Seconds);
			}
		}
    }
}
