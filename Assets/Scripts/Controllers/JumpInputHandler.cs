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
        [SerializeField] private float timeToJump;
        [SerializeField] private float timeToWaitWithJumpPressed;

        private float currentTimer = 0;

        private State currentState = State.WAITING;

        private bool wasNotGrounded;

        [SerializeField] private bool manualJump;

        private void Awake()
        {
            jumpFeedback.SetMaxValue(timeToJump);
        }

        public void SetWaiting()
        {
            jumpFeedback.ResetPosition();
            currentState = State.WAITING_GROUND;
            currentTimer = 0;
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
                else if (currentState == State.WAITING_GROUND)
                {
                    if (!character.collision.info.bellow)
                    {
                        wasNotGrounded = true;
                    }

                    if (wasNotGrounded && character.collision.info.bellow)
                    {
                        currentState = State.WAITING;
                        currentTimer = 0;
                        wasNotGrounded = false;
                    }
                }
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

            if (currentTimer >= timeToJump)
            {
                StartCoroutine(Jump());
                ResetAfterJump();
            }
        }

        public void ResetAfterJump()
        {
            currentTimer = 0;
            jumpFeedback.ResetPosition();
            currentState = State.WAITING_GROUND;
        }

        public void ResetAfterDeath()
        {
            ResetAfterJump();
            character.OnJumpButtonUp();
            wasNotGrounded = true;
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
            PREPARING_JUMP,
            WAITING_GROUND
        }
    }
}
