using Assets.Scripts.Systems;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class DeathEvent : MonoBehaviour
    {
        [SerializeField] private Transform respawn;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DeathSystem.Instance.RespawnPlayerAt(respawn);
        }
    }
}
