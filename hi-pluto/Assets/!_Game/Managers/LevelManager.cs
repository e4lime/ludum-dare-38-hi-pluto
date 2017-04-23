using UnityEngine;

namespace Lime.LudumDare.HiPluto.Managers {
    public class LevelManager : MonoBehaviour {
		[SerializeField]
		private Transform m_Player;

		[SerializeField, Header("Max distance between two jumpObjects, should be tweaked with jumps height")]
		private float m_JumpObjectDistance = 3.8f;
		[SerializeField]
		private float m_MinJumpObjectDistance = 0.8f;

		[SerializeField]
		private Checkpoint[] m_Checkpoints;
		[SerializeField]
		private GameObject[] m_JumpObjects;
		[SerializeField, Header("Level Size")]
		private Transform m_LeftEndOfLevel;
		[SerializeField]
		private Transform m_RightEndOfLevel;
		[SerializeField]
		private Transform m_BottomOfLevel;

		[SerializeField, Header("How much offscreen should be built in advance")]
		private float m_HighestBuiltOffset = 100f;
		private Vector3 m_LatestCreatedJumpObjectLocation;
		private float m_HighestReached = 0f;
		private float m_CurrentBuilt = 0f;
		

		private void Start() {
			//PreCreateLevel();
		}


		/// <summary>
		/// Create a chuck of level before on the fly creating
		/// </summary>
		private void PreCreateLevel() {
			BuildToHeight(m_HighestBuiltOffset);
		}

		private void Update() {
			CheckAndUpdateHeightReached();

			BuildToHeight(m_HighestReached + m_HighestBuiltOffset);

		}

		private void CheckAndUpdateHeightReached() {
			float playerHeight = m_Player.transform.position.y;
			if (playerHeight > m_HighestReached) {
				m_HighestReached = playerHeight;
			}
		}


		private void BuildToHeight(float height) {
			while (m_CurrentBuilt < m_HighestReached + m_HighestBuiltOffset) {
				float nextY = Random.Range(m_MinJumpObjectDistance, m_JumpObjectDistance);
				m_CurrentBuilt += nextY;
				GameObject jumpObj = GameObject.Instantiate(m_JumpObjects[0], transform);
				Vector3 newPos = new Vector3(GetRandomX(), m_CurrentBuilt, m_BottomOfLevel.position.z);
				jumpObj.transform.position = newPos;
				m_LatestCreatedJumpObjectLocation = newPos;
			}
		}

		private float GetRandomX() {
			//return m_BottomOfLevel.position.x;
			return Random.Range(m_LeftEndOfLevel.position.x, m_RightEndOfLevel.position.x);

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
