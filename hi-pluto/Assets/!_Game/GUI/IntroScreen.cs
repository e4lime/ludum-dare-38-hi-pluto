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
		private Camera m_MainCamera;
		[SerializeField]
		private Camera m_IntroCamera;

		[SerializeField]
		private Transform m_PlanetsIntroParent;

		private void Awake() {


			foreach (RectTransform rect in m_IntroGUI) {
				rect.gameObject.SetActive(true);
			}

			foreach (RectTransform rect in m_InstructionsGUI) {
				rect.gameObject.SetActive(false);
			}

			m_MainCamera.enabled = false;
			m_IntroCamera.enabled = true;

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

			m_MainCamera.enabled = true;
			m_IntroCamera.enabled = false;
			Destroy(m_IntroCamera.gameObject);
			Destroy(m_PlanetsIntroParent.gameObject);
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
