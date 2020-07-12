using Assets.Scripts.Sfx;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ChangeMusicEvent : MonoBehaviour
    {
        private bool musicChanged = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (musicChanged) return;

            MusicSystem.Instance.ChangeMusic();
            musicChanged = true;
        }
    }
}
