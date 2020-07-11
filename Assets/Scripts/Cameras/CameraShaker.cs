using UnityEngine;

namespace Assets.Scripts.Cameras
{
    public class CameraShaker : MonoBehaviour
    {
        public static CameraShaker Instance;

        private Vector3 originalPosition;
        private float timeShaking;
        private CameraShakeData data;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }

            Instance = this;
        }

        private void Update()
        {
            if (timeShaking < data.timeToShake)
            {
                timeShaking += Time.deltaTime;

                float x = Random.Range(-1, 2) * data.magnitude;
                float y = Random.Range(-1, 2) * data.magnitude;

                transform.localPosition = originalPosition + new Vector3(x, y);
                data.DecreaseMagnitude();

                if (timeShaking >= data.timeToShake)
                {
                    transform.localPosition = originalPosition;
                    timeShaking = 0;
                    data.timeToShake = 0;
                }
            }
        }

        public void Shake(CameraShakeData data)
        {
            this.data = data;
            originalPosition = transform.localPosition;
        }
    }

    [System.Serializable]
    public struct CameraShakeData
    {
        private float declineRate;
        public float timeToShake;
        public float magnitude;

        private float DeclineRate
        {
            get
            {
                if (declineRate == 0)
                    declineRate = magnitude / timeToShake;

                return declineRate;
            }
        }

        public void DecreaseMagnitude()
        {
            magnitude -= DeclineRate * Time.deltaTime;
        }
    }
}

