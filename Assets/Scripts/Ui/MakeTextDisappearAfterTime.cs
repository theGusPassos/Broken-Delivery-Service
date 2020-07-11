using TMPro;
using UnityEngine;

namespace Assets.Scripts.Ui
{
    public class MakeTextDisappearAfterTime : MonoBehaviour
    {
        private TextMeshProUGUI mesh;
        private float timeToDisappear;
        private float speedToDisappear;

        private float currentTime;

        private void Start()
        {
            mesh = GetComponent<TextMeshProUGUI>();
        }

        public void StartToDisappear(float timeToDisappear, float speedToDisappear)
        {
            this.timeToDisappear = timeToDisappear;
            this.speedToDisappear = speedToDisappear;
        }

        private void Update()
        {
            currentTime += Time.deltaTime;

            if (currentTime > timeToDisappear)
            {
                mesh.color -= new Color(0, 0, 0, Time.deltaTime * speedToDisappear);
            }
        }
    }
}
