using Assets.Scripts.Feedback;
using UnityEngine;

namespace Assets.Scripts.Animations
{
    public class RobotDeath : MonoBehaviour
    {
        [SerializeField] private Particle[] robotParts;

        [SerializeField] private float minDirection;
        [SerializeField] private float maxDirection;
        [SerializeField] private float minDirectionDiff;

        private void OnEnable()
        {
            KillRobot();
        }

        [ContextMenu("kill")]
        public void KillRobot()
        {
            for (var i = 0; i < robotParts.Length; i++)
            {
                var direction = Random.Range(minDirection, maxDirection);
                robotParts[i].SetDirection(direction);
            }
        }
    }
}
