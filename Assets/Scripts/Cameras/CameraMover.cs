using UnityEngine;

namespace Assets.Scripts.Cameras
{
    public class CameraMover : MonoBehaviour
    {
        public static CameraMover Instance;

        [SerializeField] private float cameraSpeed;
        [SerializeField] private float distanceToStopMoving;

        private Transform target;
        private bool moving = false;

        private void Awake()
        {
            if (Instance != null) Destroy(gameObject);

            Instance = this;
        }

        public void SetTarget(Transform target)
        {
            moving = true;
            this.target = target;
        }

        private void Update()
        {
            if (moving)
            {
                var x = Mathf.Lerp(transform.position.x, target.position.x, cameraSpeed);
                var y = Mathf.Lerp(transform.position.y, target.position.y, cameraSpeed);

                transform.position = new Vector3(x, y, transform.position.z);

                if (Vector2.Distance(transform.localPosition, target.localPosition) < distanceToStopMoving)
                    moving = false;
            }
        }
    }
}
