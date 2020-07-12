using UnityEngine;
using UnityEngine.Windows.Speech;

namespace Assets.Scripts.Utilities
{
    public class RotateObjectOnce : MonoBehaviour
    {
        private bool rotating = false;
        [SerializeField] private float speed;
        private Quaternion original;

        [ContextMenu("rotate")]
        public void Rotate()
        {
            original = transform.rotation;
            rotating = true;
        }

        private void Update()
        {
            if (rotating)
            {
                transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * speed);

                if (Mathf.Abs(transform.rotation.z - original.z) < 0.1f)
                {
                    transform.rotation = original;
                    rotating = false;
                }
            }
        }
    }
}
