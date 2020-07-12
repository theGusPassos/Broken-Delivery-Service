using Assets.Scripts.Sfx;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ChangeMusicOnCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            MusicSystem.Instance.ChangeMusic();
            Destroy(gameObject);
        }
    }
}
