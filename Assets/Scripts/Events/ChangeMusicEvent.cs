using Assets.Scripts.Sfx;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ChangeMusicEvent : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            MusicSystem.Instance.ChangeMusic();
        }
    }
}
