using UnityEngine;

namespace Assets.Scripts.Events
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ActivateObjectOnCollisionEvent : MonoBehaviour
    {
        [SerializeField] private GameObject objectToActivate;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            objectToActivate.SetActive(true);
        }
    }
}
