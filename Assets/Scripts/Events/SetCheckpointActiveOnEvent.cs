using UnityEngine;

namespace Assets.Scripts.Events
{
    public class SetCheckpointActiveOnEvent : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private bool used = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (used) return;

            used = true;
            animator.Play("checkpoint-on");
        }
    }
}
