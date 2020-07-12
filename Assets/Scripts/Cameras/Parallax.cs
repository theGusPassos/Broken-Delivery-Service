using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private ParallaxLayer[] parallaxLayer;

        private float lastCameraX;

        private void Awake()
        {
            lastCameraX = cameraTransform.position.x;
        }

        private void LateUpdate()
        {
            float cameraDeltaX = cameraTransform.position.x - lastCameraX;

            foreach (var parallax in parallaxLayer)
            {
                parallax.layer.position += Vector3.right * (cameraDeltaX * parallax.layerSpeed);
            }

            lastCameraX = cameraTransform.position.x;
        }
    }
    
    [System.Serializable]
    public struct ParallaxLayer
    {
        public Transform layer;
        public float layerSpeed;
    }
}
