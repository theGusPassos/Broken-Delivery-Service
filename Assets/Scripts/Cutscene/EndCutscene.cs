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

        [SerializeField] private GameObject[] blacks;
        [SerializeField] private float blackTargetSize;
        [SerializeField] private float blackSpeed;

        private float currentTime;
        private bool walkingForward;
        private bool showBlack;

        public void StartEndCutscene()
        {
            DisableInputs();

            walkingForward = true;
            showBlack = true;
            character.SetXInput(1);

            foreach (var gameObject in blacks)
                gameObject.SetActive(true);
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

            if (showBlack)
            {
                foreach (var gameObject in blacks)
                {
                    gameObject.transform.localScale += Vector3.one * Time.deltaTime * blackSpeed;

                    if (gameObject.transform.localScale.x >= blackTargetSize)
                    {
                        showBlack = false;
                    }
                }
            }
        }
    }
}
