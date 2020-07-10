﻿using Assets.Scripts.Physics;
using Assets.Scripts.UI;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class JumpInputHandler : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private RandomJumpUi ui;

        [SerializeField] private float minTimeToJump;
        [SerializeField] private float maxTimeToJump;
        [SerializeField] private float timeToWaitWithJumpPressed;

        private float currentTimer = 0;
        private float currentTimeToJump = 0;

        private void Awake()
        {
            CalculateNewTimeToJump();
        }

        private void CalculateNewTimeToJump()
        {
            currentTimeToJump = Random.Range(minTimeToJump, maxTimeToJump);
            ui.SetCurrentRandom(currentTimeToJump);
        }

        private void Update()
        {
            currentTimer += Time.deltaTime;
            ui.SetCurrentValue(currentTimer);

            if (currentTimer >= currentTimeToJump)
            {
                currentTimer = 0;
                CalculateNewTimeToJump();

                StartCoroutine(Jump());
            }
        }

        private IEnumerator Jump()
        {
            character.OnJumpButtonDown();

            yield return new WaitForSeconds(timeToWaitWithJumpPressed);

            character.OnJumpButtonUp();
        }
    }
}