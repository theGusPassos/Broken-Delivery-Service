using Assets.Scripts.Cameras;
using Assets.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class DeathSystem : MonoBehaviour
    {
        public static DeathSystem Instance;

        [SerializeField] private GameObject deathPrefab;
        [SerializeField] private GameObject character;
        [SerializeField] private JumpInputHandler jumpInputHandler;
        [SerializeField] private float timeToRespawn;
        [SerializeField] private CameraShakeData deathCameraShake;
        [SerializeField] private AudioClip deathSound;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;
        }

        public void RespawnPlayerAt(Transform respawn)
        {
            character.SetActive(false);
            Instantiate(deathPrefab, character.transform.position, character.transform.rotation);
            CameraShaker.Instance.Shake(deathCameraShake);
            SoundSystem.Instance.PlaySoundEffect(deathSound);

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
