using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Ui.Options
{
    public class LoadSceneButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private string sceneName;
        [SerializeField] private float timeToWaitBeforeLoad;

        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(timeToWaitBeforeLoad);

            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);

            while (!loading.isDone)
            {
                yield return null;
            }
        }
    }
}
