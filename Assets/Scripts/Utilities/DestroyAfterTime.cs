using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy;

        private void Awake()
        {
            Destroy(gameObject, timeToDestroy);
        }
    }
}
