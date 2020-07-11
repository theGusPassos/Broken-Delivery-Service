using UnityEngine;

namespace Assets.Scripts.Animations
{
    public class WheelAnimation : MonoBehaviour
    {
        [SerializeField] private float wheelSpeed;

        private bool isRunning = false;

        private void Update()
        {
            if (isRunning)
            {
                transform.Rotate(0, 0, -wheelSpeed * Time.deltaTime);
            }
        }

        public void SetVelocity(float velocity)
        {
            isRunning = velocity > 0;
        }
    }
}
