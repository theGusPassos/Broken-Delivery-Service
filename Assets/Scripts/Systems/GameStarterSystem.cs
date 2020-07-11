using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Systems
{
    public class GameStarterSystem : MonoBehaviour
    {
        [SerializeField] private float timeToStartGame;
        [SerializeField] private string gameSceneName;

        public void StartGame() => StartCoroutine(LoadScene());

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(timeToStartGame);

            AsyncOperation loading = SceneManager.LoadSceneAsync(gameSceneName);

            while (!loading.isDone)
            {
                Debug.Log("loading");
                yield return null;
            }
        }
    }
}
