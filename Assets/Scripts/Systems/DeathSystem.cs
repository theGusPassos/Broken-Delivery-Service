using Assets.Scripts.Controllers;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class DeathSystem : MonoBehaviour
    {
        public static DeathSystem Instance;

        [SerializeField] private GameObject character;
        [SerializeField] private JumpInputHandler jumpInputHandler;
        [SerializeField] private float timeToRespawn;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;
        }

        public void RespawnPlayerAt(Transform respawn)
        {
            character.SetActive(false);

            StartCoroutine(Respawn(respawn));
        }

        private IEnumerator Respawn(Transform respawn)
        {
            jumpInputHandler.ResetAfterJump();
            yield return new WaitForSeconds(timeToRespawn);

            character.transform.position = respawn.position;
            character.SetActive(true);
        }
    }
}
