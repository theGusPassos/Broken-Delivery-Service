using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class MoveObjectToMe : MonoBehaviour
    {
        [SerializeField] private Transform target;

        [ContextMenu("move to me")]
        public void MoveToMe()
        {
            target.position = transform.position;
        }

        [ContextMenu("reset position")]
        public void ResetPosition()
        {
            target.position = Vector3.zero;
        }
    }
}
