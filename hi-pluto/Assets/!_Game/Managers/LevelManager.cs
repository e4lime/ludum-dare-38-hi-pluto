﻿using UnityEngine;

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



		private Vector3 m_LatestCreatedJumpObjectLocation; // Not jused atm, idea was to prevent object to be created to close each other
		private float m_HighestReached = 0f;
		private float m_CurrentBuilt = 0f;
		private int m_JumpObjectsSinceLastCheckpoint = 0;
		
		//TODO Change creaton mode when certain planets area reached

		private CreationMode m_State = CreationMode.Random;
		private enum CreationMode {
			Random,
			InARow
		}

		private void Start() {
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
			return GameObject.Instantiate(m_CheckPointObject, m_JumpObjectsParent).transform;
		}

		private float GetNextY() {
			return Random.Range(m_MinJumpObjectDistance, m_JumpObjectDistance);
		}

		private float GetRandomX() {
			//return m_BottomOfLevel.position.x;
			return Random.Range(m_LeftEndOfLevel.position.x, m_RightEndOfLevel.position.x);

		}

	

	}
}
