using Assets.Scripts.Feedback;
using Assets.Scripts.Physics;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class JumpInputHandler : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private RandomJumpFeedback jumpFeedback;

        [SerializeField] private float timeToWaitBeforePreparingToJump;
        [SerializeField] private float minTimeToJump;
        [SerializeField] private float maxTimeToJump;
        [SerializeField] private float timeToWaitWithJumpPressed;

        private float currentTimer = 0;
        private float currentTimeToJump = 0;

        private State currentState = State.WAITING;

        [SerializeField] private bool manualJump;

        private void Awake()
        {
            CalculateNewTimeToJump();
        }

        private void CalculateNewTimeToJump()
        {
            currentTimeToJump = Random.Range(minTimeToJump, maxTimeToJump);
            jumpFeedback.SetMaxValue(currentTimeToJump);
        }

        private void Update()
        {
            if (manualJump)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    character.OnJumpButtonDown();
                else if (Input.GetKeyUp(KeyCode.Space))
                    character.OnJumpButtonUp();
            }
            else
            {
                if (currentState == State.WAITING)
                    WaitToJump();
                else if (currentState == State.PREPARING_JUMP)
                    ExecutePreparingToJump();
            }
        }

        private void WaitToJump()
        {
            currentTimer += Time.deltaTime;

            if (currentTimer > timeToWaitBeforePreparingToJump)
            {
                currentTimer = 0;
                currentState = State.PREPARING_JUMP;
            }
        }

        private void ExecutePreparingToJump()
        {
            currentTimer += Time.deltaTime;

            jumpFeedback.SetCurrentTimeToJump(currentTimer);

            if (currentTimer >= currentTimeToJump)
            {
                StartCoroutine(Jump());

                ResetAfterJump();
            }
        }

        public void ResetAfterJump()
        {
            currentTimer = 0;
            CalculateNewTimeToJump();
            jumpFeedback.ResetColor();
            currentState = State.WAITING;
        }

        private IEnumerator Jump()
        {
            character.OnJumpButtonDown();

            yield return new WaitForSeconds(timeToWaitWithJumpPressed);

            character.OnJumpButtonUp();
        }

        private enum State
        {
            WAITING,
            PREPARING_JUMP
        }
    }
}
