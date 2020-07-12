using Assets.Scripts.Physics;
using System.Linq.Expressions;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class DummyController : MonoBehaviour
    {
        private int direction = 1;
        [SerializeField] private float timeToChangeDirection;
        private float time;

        [SerializeField] private Character character;

        private void Update()
        {
            character.SetXInput(direction);
            time += Time.deltaTime;

            if (time > timeToChangeDirection)
            {
                direction = -direction;
                time = 0;
            }
        }
    }
}
