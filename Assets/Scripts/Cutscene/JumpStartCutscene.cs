using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Cutscene
{
    public class JumpStartCutscene : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI skipMessage;
        [SerializeField] private float speed;
        [SerializeField] private string gameSceneName;

        private bool sceneLoaded = false;

        private void Update()
        {
            if (sceneLoaded) return;

            if (Input.anyKey)
            {
                skipMessage.enabled = true;

                skipMessage.color -= new Color(1, 1, 1) * Time.deltaTime * speed ;

                if (skipMessage.color.r <= 0)
                {
                    sceneLoaded = true;
                    StartCoroutine(LoadScene());
                }
            }
            else
            {
                skipMessage.color = Color.white;
            }
        }
        

        private IEnumerator LoadScene()
        {
            AsyncOperation loading = SceneManager.LoadSceneAsync(gameSceneName);

            while (!loading.isDone)
            {
                Debug.Log("loading");
                yield return null;
            }
        }

    }
}
