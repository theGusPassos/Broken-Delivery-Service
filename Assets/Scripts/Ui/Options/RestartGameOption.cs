using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Ui.Options
{
    public class RestartGameOption : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private string firstScene;

        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine(LoadScene());
        }
        
        private IEnumerator LoadScene()
        {
            AsyncOperation loading = SceneManager.LoadSceneAsync(firstScene);

            while (!loading.isDone)
            {
                Debug.Log("loading");
                yield return null;
            }
        }

    }
}
