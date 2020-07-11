using Assets.Scripts.Systems;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class EndGameEvent : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EndGameSystem.Instance.OnEndGameEvent();
        }
    }
}
