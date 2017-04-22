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
		private float m_HighestBuilt = 0f;
		

		private void Start() {
			CreateLevel();
		}

		private void CreateLevel() {

			float currentHeight = m_BottomOfLevel.transform.position.y;
			
			while (currentHeight < 1000f) {
				float nextY = Random.Range(m_MinJumpObjectDistance, m_JumpObjectDistance);
				currentHeight += nextY;
				GameObject jumpObj = GameObject.Instantiate(m_JumpObjects[0],transform);
				Vector3 newPos = new Vector3(GetRandomX(), currentHeight, m_BottomOfLevel.position.z);
				jumpObj.transform.position = newPos;
				m_LatestCreatedJumpObjectLocation = newPos;
			}

		}

		private void Update() {
			CheckAndUpdateHeightReached();

			if (m_HighestBuilt < m_HighestReached ) {

			}

		}

		private void CheckAndUpdateHeightReached() {
			float playerHeight = m_Player.transform.position.y;
			if (playerHeight > m_HighestReached) {
				m_HighestReached = playerHeight;
			}
		}

		private void BuildToReached() {
			//TODO HERE
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
