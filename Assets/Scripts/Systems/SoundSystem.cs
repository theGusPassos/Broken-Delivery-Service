using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class SoundSystem : MonoBehaviour
    {
        [SerializeField] private AudioClip mainTheme;
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            audioSource.PlayOneShot(mainTheme);
        }
    }
}
