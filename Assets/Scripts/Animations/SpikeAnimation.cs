using UnityEngine;

namespace Assets.Scripts.Animations
{
    public class SpikeAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject spike;
        [SerializeField] private float timeActivated;
        [SerializeField] private float timeInactivated;

        private float currentTimer;
        private bool active = false;

        private void Update()
        {
            currentTimer += Time.deltaTime;

            if (active && currentTimer > timeActivated)
            {
                spike.SetActive(false);
                active = false;
                currentTimer = 0;
            }
            else if (!active && currentTimer > timeInactivated)
            {
                spike.SetActive(true);
                active = true;
                currentTimer = 0;
            }
        }
    }
}
