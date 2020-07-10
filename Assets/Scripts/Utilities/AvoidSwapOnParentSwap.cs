using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class AvoidSwapOnParentSwap : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        private float lastLocalScale;

        private void Awake()
        {
            lastLocalScale = parent.localScale.x;
        }

        private void Update()
        {
            if (parent.localScale.x != lastLocalScale)
            {
                lastLocalScale = parent.localScale.x;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
