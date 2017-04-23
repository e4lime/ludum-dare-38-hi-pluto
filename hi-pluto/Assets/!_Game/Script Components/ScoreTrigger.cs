using System;
using UnityEngine;

namespace Lime.LudumDare.HiPluto.Components {
    public class ScoreTrigger : MonoBehaviour {

		[SerializeField]
		private ScoreManager m_ScoreManager;

   
		public void GainScore(int m_ScoreValue) {
			m_ScoreManager.GainScore(m_ScoreValue);
		}
	}
}
