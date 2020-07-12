using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class MoveToDirection : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0));
        }
    }
}
