using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Slider))]
    public class RandomJumpUi : MonoBehaviour
    {
        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }
         
        public void SetCurrentRandom(float max)
        {
            slider.maxValue = max;
        }

        public void ResetValue() => slider.value = 0;

        public void SetCurrentValue(float currentValue)
        {
            slider.value = currentValue;
        }
    }
}
