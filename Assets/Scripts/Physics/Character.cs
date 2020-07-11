using Assets.Scripts.Systems;
using UnityEngine;

namespace Assets.Scripts.Physics
{
    [RequireComponent(typeof(CustomCollision))]
    public class Character : MonoBehaviour
    {
        [HideInInspector] public CustomCollision collision;
        private Vector2 currentVelocity;

        public bool facingRight = true;

        [SerializeField] private float maxJumpHeight;
        [SerializeField] private float minJumpDivisor;
        [SerializeField] private float timeToMaxJumpHeight;
        private float gravity;
        private float jumpVelocity;
        private float minJumpVelocity;

        [SerializeField] private float moveSpeed;
        [SerializeField] private LayerMask collisionMask;

        private float xInput;
        private bool walkingBackwards = false;

        private bool onSecondJump = false;

        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private AudioClip secondJumpSound;

        private void Awake()
        {
            collision = GetComponent<CustomCollision>();
            CalculateGravity();

            if (!facingRight)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        [ContextMenu("Recalculate gravity")]
        private void CalculateGravity()
        {
            gravity = (-2 * maxJumpHeight) / timeToMaxJumpHeight * 2;
            jumpVelocity = Mathf.Abs(gravity) * timeToMaxJumpHeight;
            minJumpVelocity = jumpVelocity / minJumpDivisor;
        }

        public void SetXInput(float xInput)
        {
            walkingBackwards = false;
            this.xInput = xInput;
        }

        public void OnJumpButtonDown()
        {
            if (collision.info.bellow) 
            {
                SoundSystem.Instance.PlaySoundEffect(jumpSound);
                currentVelocity.y = jumpVelocity;
            }
            else if (CanJumpAgain())
            {
                SoundSystem.Instance.PlaySoundEffect(secondJumpSound);
                currentVelocity.y = jumpVelocity;
            }
        }

        public bool CanJumpAgain()
        {
            if (onSecondJump)
            {
                return false;
            }
            else
            {
                onSecondJump = true;
                return true;
            }
        }

        public void OnJumpButtonUp()
        {
            if (currentVelocity.y > minJumpVelocity)
            {
                currentVelocity.y = minJumpVelocity;
            }
        }

        public void ResetCurrentVelocity()
        {
            currentVelocity = Vector2.zero;
        }

        private void FixedUpdate()
        {
            ApplyGravityIfEnabled();
            TestFaceSwap();
            HandleHorizontalMovement();

            Vector2 velocity = currentVelocity * Time.deltaTime;

            bool wasGrounded = collision.info.bellow;

            collision.UpdateRayOrigins();
            collision.info.Reset();

            if (velocity.x != 0)
            {
                collision.HandleHorizontalCollisions(ref velocity, collisionMask);
            }
            if (velocity.y != 0)
            {
                LayerMask verticalLayerMask = collisionMask;
                collision.HandleVerticalCollisions(ref velocity, verticalLayerMask);
            }

            transform.Translate(velocity);

            if (collision.info.bellow)
            {
                if (onSecondJump) onSecondJump = false;

                if (wasGrounded)
                {
                }
            }

            if (collision.info.bellow || collision.info.above)
            {
                currentVelocity.y = 0;
            }
        }

        private void ApplyGravityIfEnabled()
        {
            currentVelocity.y += gravity * Time.deltaTime;
        }

        private void TestFaceSwap()
        {
            if (walkingBackwards) return;
            if (facingRight && currentVelocity.x < 0 || !facingRight && currentVelocity.x > 0)
                SwapFaceDirection();
        }

        public void SwapFaceDirection()
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        private void HandleHorizontalMovement()
        {
            currentVelocity.x = xInput * moveSpeed;
        }
    }

    public enum CharacterEvent
    {
        MOVEMENT_REESTABLISHED,
    }
}
