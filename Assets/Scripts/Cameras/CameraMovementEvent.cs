using Assets.Scripts.Systems;
using UnityEngine;

namespace Assets.Scripts.Cameras
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class CameraMovementEvent : MonoBehaviour
    {
        [SerializeField] private Transform cameraTargetPosition;

        private bool used = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (used) return;

            CameraMover.Instance.SetTarget(cameraTargetPosition);
            SoundSystem.Instance.PlayCheckpoint();
            used = true;
        }
    }
}
