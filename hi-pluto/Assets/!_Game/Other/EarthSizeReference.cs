using UnityEngine;
using Lime.LudumDare.HiPluto.Entities.CelestialBodies;
namespace Lime.LudumDare.HiPluto.Other {
    public class EarthSizeReference : MonoBehaviour {

		[SerializeField, Header("Apply scale on these if they m_AffectByEarthSizeReference. Check contextmenu to apply")]
		private CelestialBody[] m_AllCelestialBodies;

		[ContextMenu("Apply Scale on Celestial Bodies with m_AffectByEarthSizeReference set to true")]
		void ApplyScaleOnCelestials() {
			Vector3 refScale = this.transform.localScale;
			foreach (CelestialBody cb in m_AllCelestialBodies) { 
				if (cb != null && cb.GetAffectByEarthSizeReference()) {
					float modifier = cb.GetSizeModifier();

					UnityEditor.Undo.RecordObject(cb.transform, "Changed Scale");
					cb.transform.localScale = new Vector3(refScale.x * modifier, refScale.y * modifier, refScale.z * modifier);
					
					Debug.Log("Changed scale on: " + cb.GetName() + "(" + modifier +")");
				}
				
			}
		}

	
	}
}
