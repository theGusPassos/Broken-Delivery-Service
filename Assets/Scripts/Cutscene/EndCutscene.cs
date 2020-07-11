using Assets.Scripts.Controllers;
using Assets.Scripts.Physics;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class EndCutscene : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private PlayerInputHandler inputHandler;
        [SerializeField] private JumpInputHandler jumpInputHandler;
        [SerializeField] private LetterCutscene letterCutscene;

        [SerializeField] private float timeToWalkForwards;

        private float currentTime;
        private bool walkingForward;

        public void StartEndCutscene()
        {
            DisableInputs();

            walkingForward = true;
            character.SetXInput(1);
        }

        private void DisableInputs()
        {
            inputHandler.enabled = false;

            jumpInputHandler.ResetAfterJump();
            jumpInputHandler.enabled = false;
        }

        private void Update()
        {
            if (walkingForward)
            {
                currentTime += Time.deltaTime;

                if (currentTime > timeToWalkForwards)
                {
                    walkingForward = false;
                    character.SetXInput(0);

                    letterCutscene.StartLetterCutscene();
                }
            }
        }
    }
}
