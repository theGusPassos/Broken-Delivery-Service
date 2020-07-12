using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class SoundSystem : MonoBehaviour
    {
        public static SoundSystem Instance;

        [SerializeField] private AudioClip checkpointClip;

        private AudioSource audioSource;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            audioSource = GetComponent<AudioSource>();

            DontDestroyOnLoad(gameObject);
        }

        public void PlaySoundEffect(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }

        public void PlayCheckpoint()
        {
            audioSource.PlayOneShot(checkpointClip);
        }
    }
}
