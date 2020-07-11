using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Systems
{
    public class GameStarterSystem : MonoBehaviour
    {
        [SerializeField] private string gameSceneName;

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                StartCoroutine(LoadScene());
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
