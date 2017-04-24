using Lime.LudumDare.Components;
using UnityEngine;

namespace Lime.LudumDare.HiPluto.Managers {

	/// <summary>
	/// Todo: Destroy jumpobjekt under player
	/// </summary>
    public class LevelManager : MonoBehaviour {
		[SerializeField]
		private Transform m_Player;

		[SerializeField, Header("Max distance between two jumpObjects, should be tweaked with jumps height")]
		private float m_JumpObjectDistance = 3.8f;
		[SerializeField]
		private float m_MinJumpObjectDistance = 0.8f;
		[SerializeField, Header("How often checkpoints should be created, every X jumpobject")]
		private int m_CheckpointFrequency = 50;


		[SerializeField, Header("Comets etc")]
		private Transform m_CheckPointObject;
		[SerializeField, Header("Astroids etc")]
		private GameObject[] m_JumpObjects;

		[SerializeField, Header("Level Size")]
		private Transform m_LeftEndOfLevel;
		[SerializeField]
		private Transform m_RightEndOfLevel;
		[SerializeField]
		private Transform m_BottomOfLevel;

		[SerializeField, Header("How much offscreen should be built, also how much that gets built right at Start")]
		private float m_HighestBuiltOffset = 100f;

		[SerializeField, Header("Where jumpobjects gets created")]
		private Transform m_JumpObjectsParent;


		private Vector3 m_LatestCheckpointHit;
		private Vector3 m_LatestCreatedJumpObjectLocation; // Not jused atm, idea was to prevent object to be created to close each other
		private float m_HighestReached = 0f;
		private float m_CurrentBuilt = 0f;
		private int m_JumpObjectsSinceLastCheckpoint = 0;
		private bool m_FirstCheckpointHit = false;
		private float m_PlayerHeightOffset = 0f; // For score resets

		private int m_JumpObjectsHit = 0;
		
		//TODO Change creaton mode when certain planets area reached

		private CreationMode m_State = CreationMode.Random;
		private enum CreationMode {
			Random,
			InARow
		}

		private void Start() {
			BuildToHeight(m_HighestBuiltOffset);
			m_LatestCheckpointHit = m_Player.position;
		}


		private void Update() {
			CheckAndUpdateHeightReached();
			BuildToHeight(m_HighestReached + m_HighestBuiltOffset);
		}

		private void CheckAndUpdateHeightReached() {
			float playerHeight = m_Player.transform.position.y - m_PlayerHeightOffset;
			if (playerHeight > m_HighestReached) {
				m_HighestReached = playerHeight;
			}
		}


		private void BuildToHeight(float height) {
			while (m_CurrentBuilt < m_HighestReached + m_HighestBuiltOffset) {
				float nextY = GetNextY();
				m_CurrentBuilt += nextY;

				Transform objectToCreate = null;
				if (m_JumpObjectsSinceLastCheckpoint > this.m_CheckpointFrequency) {
					objectToCreate = CreateCheckpoint();
				}
				else {
					objectToCreate = CreateRandomJumpObject();
				}

				RandomPositionAndRotation(objectToCreate);

				m_LatestCreatedJumpObjectLocation = objectToCreate.position; // Not used atm


			}
		}

		public int GetAltitude() {
			return (int)m_HighestReached;
		}

		private void UpdateState() {
			switch (m_State) {
				case CreationMode.Random: 
					
					break;
				case CreationMode.InARow:

					break;
			}
		}


		private Transform CreateRandomJumpObject() {
			m_JumpObjectsSinceLastCheckpoint++;
			return GameObject.Instantiate(m_JumpObjects[Random.Range(0, m_JumpObjects.Length)], m_JumpObjectsParent).transform;
		}

		private void RandomPositionAndRotation(Transform target) {
			Vector3 newPos = new Vector3(GetRandomX(), m_CurrentBuilt, m_BottomOfLevel.position.z);
			target.transform.position = newPos;
			target.transform.localRotation = Random.rotationUniform;
		}

		private Transform CreateCheckpoint() {
			m_JumpObjectsSinceLastCheckpoint = 0;
			Transform cp = GameObject.Instantiate(m_CheckPointObject, m_JumpObjectsParent).transform;
			cp.GetComponent<Checkpoint>().SetLevelManager(this);
			return cp;
		}

		public void ResetAltitude() {
			//m_PlayerHeightOffset = m_HighestReached;
			//this.m_HighestReached = 0;
		}

		private float GetNextY() {
			return Random.Range(m_MinJumpObjectDistance, m_JumpObjectDistance);
		}

		private float GetRandomX() {
			//return m_BottomOfLevel.position.x;
			return Random.Range(m_LeftEndOfLevel.position.x, m_RightEndOfLevel.position.x);

		}

		public void CheckpointHit(Checkpoint checkpoint) {
			m_FirstCheckpointHit = true;
			m_LatestCheckpointHit = checkpoint.transform.position;
		}

		public Vector3 GetActiveSpawnpoint() {
			return m_LatestCheckpointHit;
		}

		public void ClearAndRebuildFromCheckpoint() {
			m_JumpObjectsSinceLastCheckpoint = 0;
			m_HighestReached = m_LatestCheckpointHit.y;
			m_CurrentBuilt = m_LatestCheckpointHit.y;

			foreach (Transform child in m_JumpObjectsParent) {
				Destroy(child.gameObject);
			}
			BuildToHeight(m_HighestReached + m_HighestBuiltOffset);



			// Place "old checkpoint" under spawn
			Transform objUnder = null;
			if (m_FirstCheckpointHit) {
				objUnder = CreateCheckpoint();
			}
			else {
				objUnder = CreateRandomJumpObject();
			}
			objUnder.position = new Vector3(m_LatestCheckpointHit.x, m_LatestCheckpointHit.y - 3f, m_LatestCheckpointHit.z);

			Transform helpJump = CreateRandomJumpObject();
			RandomPositionAndRotation(helpJump);
			helpJump.position = new Vector3(helpJump.position.x, objUnder.position.y + 3.6f, helpJump.position.z);
		}
	}
}
