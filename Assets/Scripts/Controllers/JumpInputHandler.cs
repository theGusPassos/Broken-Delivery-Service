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
            currentTimer += Time.deltaTime;

            if (currentState == State.WAITING)
                WaitToJump();
            else if (currentState == State.PREPARING_JUMP)
                ExecutePreparingToJump();
        }

        private void WaitToJump()
        {
            if (currentTimer > timeToWaitBeforePreparingToJump)
            {
                currentTimer = 0;
                currentState = State.PREPARING_JUMP;
            }
        }

        private void ExecutePreparingToJump()
        {
            jumpFeedback.SetCurrentTimeToJump(currentTimer);

            if (currentTimer >= currentTimeToJump)
            {
                currentTimer = 0;
                CalculateNewTimeToJump();
                jumpFeedback.ResetColor();

                StartCoroutine(Jump());

                currentState = State.WAITING;
            }
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
