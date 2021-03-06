﻿using Lime.LudumDare.HiPluto.Managers;
using System;
using System.Collections;
using UnityEngine;

namespace Lime.LudumDare.HiPluto.GUI {
    public class IntroScreen : MonoBehaviour {


		[SerializeField]
		private bool m_Skipp = false;

		[SerializeField]
		private float m_WaitTime = 0f;

	
		[SerializeField]
		private RectTransform[] m_IntroGUI;

		[SerializeField]
		private RectTransform[] m_InstructionsGUI;

		[SerializeField]
		private RectTransform[] m_GameGUI;

		[SerializeField]
		private Camera m_MainCamera;
		[SerializeField]
		private Camera m_IntroCamera;

		[SerializeField]
		private Transform m_PlanetsIntroParent;

		[SerializeField]
		private GameManager m_GameManager;

		private void Awake() {
			m_MainCamera.gameObject.SetActive(false);
			m_IntroCamera.gameObject.SetActive(true);


			foreach (RectTransform rect in m_IntroGUI) {
				rect.gameObject.SetActive(true);
			}

			foreach (RectTransform rect in m_InstructionsGUI) {
				rect.gameObject.SetActive(false);
			}

			foreach (RectTransform rect in m_GameGUI) {
				rect.gameObject.SetActive(false);
			}


			if (m_Skipp) {
				OnStartClick();
			}
		}

		public void OnPrepareClick() {
			
			StartCoroutine(LoadInstructions());
		}

		public void OnStartClick() {
			foreach (RectTransform rect in m_InstructionsGUI) {
				rect.gameObject.SetActive(false);
			}



			m_MainCamera.gameObject.SetActive(true);
			m_IntroCamera.gameObject.SetActive(false);


			m_GameManager.StartGame();

			Destroy(m_IntroCamera.gameObject);
			Destroy(m_PlanetsIntroParent.gameObject);

			foreach (RectTransform rect in m_GameGUI) {
				rect.gameObject.SetActive(true);
			}

			Destroy(this.gameObject);
		}

		private IEnumerator LoadInstructions() {
			yield return new WaitForSeconds(m_WaitTime);

			foreach(RectTransform rect in m_IntroGUI) {
				rect.gameObject.SetActive(false);
			}

			foreach (RectTransform rect in m_InstructionsGUI) {
				rect.gameObject.SetActive(true);
			}
		}

		
	}
}
