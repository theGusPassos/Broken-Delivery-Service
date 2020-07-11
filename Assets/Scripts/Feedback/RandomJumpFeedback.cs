using UnityEngine;

namespace Assets.Scripts.Feedback
{
    public class RandomJumpFeedback : MonoBehaviour
    {
        [SerializeField] private Transform robotBody;
        [SerializeField] private Transform normalPosition;
        [SerializeField] private Transform crouchedPosition;

        private float distanceFromNormalToCrouched;

        private Transform targetPosition;

        private float maxValue;

        private void Awake()
        {
            distanceFromNormalToCrouched = Mathf.Abs(normalPosition.position.y - crouchedPosition.position.y);
        }

        public void ResetPosition() => targetPosition = normalPosition;

        public void SetMaxValue(float maxValue) => this.maxValue = maxValue;

        public void SetCurrentTimeToJump(float currentValue)
        {
            var timePercentage = currentValue * 100 / maxValue;
            var distancePercentage =  distanceFromNormalToCrouched * (timePercentage / 100);

            var newPosition = normalPosition.position - new Vector3(0, distancePercentage);
            robotBody.transform.position = newPosition;
        }
    }
}
