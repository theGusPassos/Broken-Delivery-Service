using UnityEngine;

namespace Assets.Scripts.Sfx
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicSystem : MonoBehaviour
    {
        public static MusicSystem Instance;

        [SerializeField] private AudioClip mainTheme;
        private AudioSource musicSource;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;

            DontDestroyOnLoad(gameObject);

            musicSource = GetComponent<AudioSource>();
            musicSource.clip = mainTheme;
            musicSource.Play();
        }

        public void PlayMusic(AudioClip music)
        {
            musicSource.clip = music;
            musicSource.Play();
        }
    }
}
