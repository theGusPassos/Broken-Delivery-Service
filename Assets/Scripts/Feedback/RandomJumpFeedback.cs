using UnityEngine;

namespace Assets.Scripts.Feedback
{
    public class RandomJumpFeedback : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        [SerializeField] private Color targetColor;
        private Color noAlphaColor;

        private float maxValue;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            noAlphaColor = new Color(0, 0, 0, 0);
        }

        private Color CalcTargetColor(float currentValue)
        {
            var percentage = currentValue * 100 / maxValue;
            var currentColor = targetColor;
            currentColor.a *= (percentage / 100);

            return currentColor;
        }

        public void ResetColor() => spriteRenderer.color = noAlphaColor;

        public void SetMaxValue(float maxValue) => this.maxValue = maxValue;

        public void SetCurrentTimeToJump(float currentValue)
        {
            spriteRenderer.color = CalcTargetColor(currentValue);
        }
    }
}
