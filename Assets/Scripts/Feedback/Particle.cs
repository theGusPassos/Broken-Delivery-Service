using UnityEngine;

namespace Assets.Scripts.Feedback
{
    public class Particle : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private float forceRand;

        [SerializeField] private float gravity;

        private float currentForce;
        private float direction;

        private bool directionSet = false;

        private void Awake()
        {
            currentForce = force;
            force = Random.Range(force - forceRand, force + forceRand);
        }

        public void SetDirection(float direction)
        {
            directionSet = true;
            this.direction = direction;
        }

        private void Update()
        {
            if (directionSet)
            {
                var velocity = new Vector3(direction * Time.deltaTime, 1 * currentForce * Time.deltaTime);
                transform.position += velocity;

                currentForce -= Time.deltaTime * gravity;
            }
        }
    }
}
