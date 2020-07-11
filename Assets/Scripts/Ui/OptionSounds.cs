using UnityEngine;

namespace Assets.Scripts.Ui
{
    public class OptionSounds : MonoBehaviour
    {
        public static OptionSounds Instance;

        [SerializeField] private AudioClip onHoverClip;
        [SerializeField] private AudioClip onClickClip;

        public AudioClip OnHoverClip { get => onHoverClip; }
        public AudioClip OnClickClip { get => onClickClip; }

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;
        }
    }
}
