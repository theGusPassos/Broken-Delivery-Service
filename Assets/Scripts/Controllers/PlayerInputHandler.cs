using Assets.Scripts.Physics;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private Character character;

        private void Update()
        {
            var xInput = Input.GetAxisRaw("Horizontal");

            character.SetXInput(xInput);
        }
    }
}
