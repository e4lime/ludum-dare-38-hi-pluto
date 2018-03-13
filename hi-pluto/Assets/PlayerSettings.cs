using UnityEngine;

namespace E4lime.LudumDare.Ld38 {
	public class PlayerSettings : MonoBehaviour {


#if UNITY_ANDROID
		void Awake() {


			Application.targetFrameRate = 60;
			QualitySettings.vSyncCount = 0;
			QualitySettings.antiAliasing = 0;

			QualitySettings.shadowCascades = 0;
			QualitySettings.shadowDistance = 15;

			Screen.sleepTimeout = SleepTimeout.NeverSleep;


		}

#endif
	}
}
