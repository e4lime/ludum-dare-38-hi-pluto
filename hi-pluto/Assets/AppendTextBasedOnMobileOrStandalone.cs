using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace E4lime.LudumDare.Ld38 {
	public class AppendTextBasedOnMobileOrStandalone : MonoBehaviour {
		
		[SerializeField]
		private Text m_Text = null;

#if UNITY_STANDALONE || UNITY_EDITOR
		[SerializeField]
		private string[] m_StandaloneTextLines;
#endif

#if UNITY_ANDROID
		[SerializeField]
		private string[] m_AndroidTextLines;
#endif
		private string[] m_TextLinesToUse;

		void Start() {

#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL
			m_TextLinesToUse = m_StandaloneTextLines;
#endif

#if UNITY_ANDROID
			m_TextLinesToUse = m_AndroidTextLines;
#endif

			string newLine = System.Environment.NewLine;

			m_Text.text += newLine + newLine;
			foreach (string s in m_TextLinesToUse) {
				m_Text.text += s;
				m_Text.text += System.Environment.NewLine;
			}
		}
	}
}

