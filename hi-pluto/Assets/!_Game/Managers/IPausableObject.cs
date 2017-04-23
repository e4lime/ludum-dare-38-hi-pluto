using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components {

	/// <summary>
	/// Make sure to register the object to whatever wants them
	/// </summary>
    public interface IPausableObject {
		void OnPause();
		void OnUnPause();
	}
}
