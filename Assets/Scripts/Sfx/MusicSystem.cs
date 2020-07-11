using UnityEngine;

namespace Assets.Scripts.Sfx
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicSystem : MonoBehaviour
    {
        public static MusicSystem Instance;

        [SerializeField] private AudioClip mainTheme;
        [SerializeField] private AudioClip endTheme;
        [SerializeField] private float musicSpeed;

        private AudioSource[] musicSources;
        private int current = 0;
        private int changing = 0;
        private bool changingMusic = false;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;

            DontDestroyOnLoad(gameObject);

            musicSources = GetComponents<AudioSource>();
            musicSources[current].clip = mainTheme;
            musicSources[current].Play();
        }

        private void Update()
        {
            if (changingMusic)
            {
                musicSources[changing].volume -= musicSpeed * Time.deltaTime;
                musicSources[current].volume += musicSpeed * Time.deltaTime;

                if (musicSources[changing].volume <= 0 && musicSources[current].volume >= 1)
                {
                    changingMusic = false;
                }
            }
        }

        public void PlayMusic(AudioClip music)
        {
            musicSources[current].clip = music;
            musicSources[current].Play();
        }

        [ContextMenu("change music")]
        public void PlayEndTheme()
        {
            changing = current;
            current = current == 0 ? 1 : 0;
            
            changingMusic = true;

            musicSources[current].volume = 0;

            if (current == 0)
                PlayMusic(mainTheme);
            else
                PlayMusic(endTheme);
        }
    }
}
