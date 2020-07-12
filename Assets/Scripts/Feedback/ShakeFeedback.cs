using UnityEngine;

namespace Assets.Scripts.Feedback
{
    public class ShakeFeedback : MonoBehaviour
    {
        private Vector3 originalPosition;
        private bool shaking;

        [SerializeField] private float magnitude;

        private void Awake()
        {
            originalPosition = gameObject.transform.localPosition;
        }

        [ContextMenu("shake")]
        public void StartShaking()
        {
            shaking = true;
        }

        public void StopShaking()
        {
            shaking = false;
        }

        private void Update()
        {
            if (shaking)
            {
                float x = Random.Range(-1, 2) * magnitude;
                float y = Random.Range(-1, 2) * magnitude;

                transform.localPosition = originalPosition + new Vector3(x, y);
            }
        }
    }
}
