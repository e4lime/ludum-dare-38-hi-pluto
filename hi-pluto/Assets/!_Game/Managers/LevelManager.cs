using UnityEngine;

namespace Lime.LudumDare.HiPluto.Managers {
    public class LevelManager : MonoBehaviour {


		[SerializeField, Header("Max distance between two jumpObjects")]
		private float m_JumpObjectDistance;

		[SerializeField]
		private Checkpoint[] m_Checkpoints;

		[SerializeField, Header("Level Size")]
		private Transform m_LeftEndOfLevel;

		[SerializeField]
		private Transform m_RightEndOfLevel;

		[SerializeField]
		private Transform m_BottomOfLevel;

		private Vector3 m_LatestCreatedJumpObjectLocation;

		private void Start() {
			CreateLevel();
		}

		private void CreateLevel() {

		}

		[System.Serializable]
		public class Checkpoint {
			public string name;
			public float height;
			public GameObject planet;
			public bool enabled;
		}

	}
}
