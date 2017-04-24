using UnityEngine;

namespace Lime.LudumDare.HiPluto.Sound {
    public class PlayRandomClip : MonoBehaviour {

		public static PlayRandomClip INSTANCE;

		[SerializeField]
		private AudioClip[] m_Checkpoints;

		[SerializeField]
		private AudioClip[] m_Astroids;

		[SerializeField]
		private AudioClip m_HitPluto;

		[SerializeField]
		private float m_Volume = 1f;
		private bool m_Mute = false;



		[SerializeField]
		private AudioSource m_Source;

        void Awake(){
			INSTANCE = this;
		}
	

		public void PlayRandomCheckpoint() {
			AudioClip rand = m_Checkpoints[Random.Range(0, m_Checkpoints.Length)];
			m_Source.PlayOneShot(rand, m_Volume);
		}

		public void PlayRandomAstroid() {
			AudioClip rand = m_Astroids[Random.Range(0, m_Astroids.Length)];
			m_Source.PlayOneShot(rand, m_Volume);
		}

		public void PlayRandomHitPluto() {
			m_Source.PlayOneShot(m_HitPluto, m_Volume);
		}


		private float m_PrevMuteVolume = 0;
		private void Update() {
			if (Input.GetButtonDown("Mute")) {
				m_Mute = !m_Mute;
				if (m_Mute) {
					m_PrevMuteVolume = m_Volume;
					m_Volume = 0;

				}
				else {
					m_Volume = m_PrevMuteVolume;
				}
			}

			
		}
	}
}
